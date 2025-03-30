using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private static List<ToDo> tasks = new List<ToDo>();

        // GET /tasks
        [HttpGet]
        public IActionResult GetAll() => Ok(tasks);
        
        // POST /tasks
        [HttpPost]
        public IActionResult Create([FromBody] ToDo task)
        {
            if (string.IsNullOrWhiteSpace(task.Titulo))
                return BadRequest(new { message = "El título es obligatorio" });

            task.Id = tasks.Count + 1;
            tasks.Add(task);

            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }
        
        // PUT /tasks/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ToDo updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound(new { message = "Tarea no encontrada" });

            task.Titulo = updatedTask.Titulo;
            task.Estado = updatedTask.Estado;

            return Ok(new { message = "Tarea actualizada", task });
        }
                // GET /tasks/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound(new { message = "Tarea no encontrada" });
            return Ok(task);
        }
        // DELETE /tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound(new { message = "Tarea no encontrada." });

            tasks.Remove(task);
            return Ok(new { message = "Tarea eliminada.", tasks });
        }
    }
}
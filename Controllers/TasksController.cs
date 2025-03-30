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

    }
}
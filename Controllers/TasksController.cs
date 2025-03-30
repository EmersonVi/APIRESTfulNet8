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
    }
}
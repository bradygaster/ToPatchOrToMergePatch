using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace JsonPatchExample.Controllers
{
    public record Todo(int Id, string Title, bool IsCompleted = false);

    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Todo>> Get()
        {
            return new ActionResult<List<Todo>>(new List<Todo>(new Todo[] {
                new Todo(Id: 1, Title: "Test the JsonPatch scenario"),
                new Todo(Id: 2, Title: "Test the JsonMergePatch scenario")
            }));
        }

        [HttpPatch]
        public ActionResult<Todo> Patch([FromBody] JsonPatchDocument<Todo> todo)
        {
            return Ok();
        }
    }
}
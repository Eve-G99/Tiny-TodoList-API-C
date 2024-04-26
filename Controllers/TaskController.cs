//Controllers/TaskController.cs

using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TaskModel = TaskApi.Models.Task; //Avoid ambiguity
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; 

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMongoCollection<TaskModel> _tasks;

        public TasksController(IMongoClient client)
        {
            var database = client.GetDatabase("todoListDB");
            _tasks = database.GetCollection<TaskModel>("tasks");
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks([FromQuery] string? completed = null, [FromQuery] string? sort_by = null)
        {
            // Check if multiple 'sort_by' or 'completed' parameters are used
            if (HttpContext.Request.Query["sort_by"].Count > 1 || HttpContext.Request.Query["completed"].Count > 1)
            {
                return BadRequest("Multiple same parameters are not allowed.");
            }

            var builder = Builders<TaskModel>.Filter;
            var filter = builder.Empty;

            // Handle completion filter
            //GET: api/tasks?completed=true or GET: api/tasks?completed=false
            if (!string.IsNullOrEmpty(completed))
            {
                if (bool.TryParse(completed, out bool isCompleted))
                {
                    filter = builder.Eq("completed", isCompleted);
                    Console.WriteLine($"Filtering tasks by completion: {isCompleted}");  // Debugging output
                }
                else
                {
                    return BadRequest("Invalid value for 'completed'. Must be 'true' or 'false'.");
                }
            }

            // Debugging: Check what filter is applied
            Console.WriteLine($"Filter applied: {filter}");

            // Handle sorting
            //GET: api/tasks?sort_by=createdDate or GET: api/tasks?sort_by=-createdDate
            SortDefinition<TaskModel> sort = null;
            if (!string.IsNullOrEmpty(sort_by))
            {
                var sortFields = new List<string> { "createdDate", "dueDate" };
                string sortField = sort_by.TrimStart('-');
                bool isDescending = sort_by.StartsWith("-");

                if (!sortFields.Contains(sortField))
                {
                    return BadRequest($"Invalid sort field: '{sortField}'. Only 'createdDate' and 'dueDate' are valid sort fields.");
                }

                sort = isDescending ? Builders<TaskModel>.Sort.Descending(sortField) : Builders<TaskModel>.Sort.Ascending(sortField);
            }

            // Debugging: Check what sort is applied
            Console.WriteLine($"Sort applied: {sort}");

            var tasks = await _tasks.Find(filter).Sort(sort).ToListAsync();

            // Debugging: Check how many tasks were found
            Console.WriteLine($"Number of tasks found: {tasks.Count}");

            return Ok(tasks);
        }


        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTask(string id)
        {
            var task = await _tasks.Find(t => t.Id == id).FirstOrDefaultAsync();
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskModel task)
        {
            await _tasks.InsertOneAsync(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(string id, [FromBody] TaskModel updatedTask)
        {
            var result = await _tasks.ReplaceOneAsync(t => t.Id == id, updatedTask);
            if (result.MatchedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(string id)
        {
            var result = await _tasks.DeleteOneAsync(t => t.Id == id);
            if (result.DeletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}


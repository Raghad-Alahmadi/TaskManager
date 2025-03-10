using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TaskModel = services.TaskAPI.Models.Task;

namespace services.TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<TaskModel> tasks = new List<TaskModel>();

        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> GetTasks()
        {
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskModel> GetTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskModel> CreateTask(TaskModel task)
        {
            task.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
            tasks.Add(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskModel updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Completed = updatedTask.Completed;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            tasks.Remove(task);
            return NoContent();
        }
    }
}

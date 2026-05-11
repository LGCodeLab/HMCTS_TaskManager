using HMCTS_TaskManager.Data;
using HMCTS_TaskManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMCTS_TaskManager.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskManagerDbContext _dbContext;

        public TasksController(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Status))
            {
                task.Status = "ToDo";
            }

            _dbContext.Tasks.Add(task);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            List<Models.TaskItem> tasks = await _dbContext.Tasks.ToListAsync();

            return View(tasks);
        }
    }
}

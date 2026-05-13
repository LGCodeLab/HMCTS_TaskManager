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

        public async Task<IActionResult> Delete(int id)
        {
            TaskItem? task = await _dbContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            TaskItem? taskToDelete = await _dbContext.Tasks.FindAsync(id);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            _dbContext.Tasks.Remove(taskToDelete);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskItem task)
        {
            TaskItem? existingTask = await _dbContext.Tasks.FindAsync(task.Id);

            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.Status = task.Status;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            TaskItem? task = await _dbContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        public async Task<IActionResult> Index()
        {
            List<Models.TaskItem> tasks = await _dbContext.Tasks.ToListAsync();

            return View(tasks);
        }
    }
}

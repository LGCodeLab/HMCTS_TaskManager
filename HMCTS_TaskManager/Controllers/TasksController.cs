using HMCTS_TaskManager.Data;
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

        public async Task<IActionResult> Index()
        {
            List<Models.TaskItem> tasks = await _dbContext.Tasks.ToListAsync();

            return View(tasks);
        }
    }
}

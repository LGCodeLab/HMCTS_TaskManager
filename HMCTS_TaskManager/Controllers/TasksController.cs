using Microsoft.AspNetCore.Mvc;

namespace HMCTS_TaskManager.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

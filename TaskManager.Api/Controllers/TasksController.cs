using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Api.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
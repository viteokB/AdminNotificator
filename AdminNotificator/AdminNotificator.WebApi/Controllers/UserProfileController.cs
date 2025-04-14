using Microsoft.AspNetCore.Mvc;

namespace AdminNotificator.WebApi.Controllers;

public class UserProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
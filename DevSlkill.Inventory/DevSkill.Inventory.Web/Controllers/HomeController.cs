using DevSkill.Inventory.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DevSkill.Inventory.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IEmailSender _emailSender;
        private readonly IMembership _membership;

        public HomeController(ILogger<HomeController> logger,IMembership membership)
        {
            _logger = logger;
            //_emailSender = emailSender;
            _membership = membership;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("I am in index");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Test()
        {
            var model=new TestModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken] //#ValidateAntiForgeryToken -prevent csrf attack
        public IActionResult Test(TestModel model)
        {
            if (ModelState.IsValid)
            {
                // Handle valid form submission (e.g., create user or log in)
                //return RedirectToAction("Success"); // Redirect to a success page
                //EmailSender sender = new EmailSender();
                //_emailSender.SendEmail(model.Email, "Welcome", "Thank You");
            }

            return View(model); // Redisplay form with validation errors
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

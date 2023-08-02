using CodeFirstapproach_CrudApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeFirstapproach_CrudApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly student_Db_context studentDB;


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(student_Db_context StudentDB)
        {
            studentDB = StudentDB;
        }



        public IActionResult Index()
        {
            var studata=studentDB.Students.ToList();
            return View(studata);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using CodeFirstapproach_CrudApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

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



        
        public async Task<IActionResult> Index()
        {
            var studata=await studentDB.Students.ToListAsync();
            return View(studata);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Create(StudentModel stdata)
        {
            if(ModelState.IsValid)
            {
             await studentDB.Students.AddAsync(stdata);
             await studentDB.SaveChangesAsync();//for successfully submit:
                TempData["created"] = " Created";
                return RedirectToAction("Index","Home");
            }
            
            return View();
        }
       
        public async Task<IActionResult> Details(int id)
        {
            var studata = await studentDB.Students.FirstOrDefaultAsync(x=>x.ID == id);
            return View(studata);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null || studentDB.Students == null)
            {
                return NotFound();
            }
            var studata = await studentDB.Students.FindAsync(id);
            if (studata == null)
            {
                return NotFound();
            }
            TempData["edited"] = " Edited";
            return View(studata);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,StudentModel std)
        {
            if(id!=std.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                 studentDB.Students.Update(std);
                 await studentDB.SaveChangesAsync();//for successfully submit:
                 return RedirectToAction("Index", "Home");
            }
            return View(std);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {      if(id==null || studentDB.Students == null)
            {
                return NotFound();
            } 
            var studata = await studentDB.Students.FirstOrDefaultAsync(x => x.ID == id);
            if (studata == null)
            {
                return NotFound();
            }
            TempData["deleted"] = " Deleted";
            return View(studata);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var studata = await studentDB.Students.FindAsync(id);
            if (studata != null)
            {
                studentDB.Students.Remove(studata);
            }
            await studentDB.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
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
using codefirstASPCore6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace codefirstASPCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext _studentDB;
        private readonly ILogger<HomeController> _logger;

        public HomeController(StudentDBContext studentDB, ILogger<HomeController> logger)
        {
            _studentDB = studentDB;
            _logger = logger;
        }

       

        public IActionResult Index()
        {
            var stdData = _studentDB.Students.ToList();
            return View(stdData);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid) 
            {
                _studentDB.Students.Add(std);
                _studentDB.SaveChanges();
                TempData["insert_success"] = "inserted";
                return RedirectToAction("Index" , "home");
            
            }
            
            return View(std);
        }
        public IActionResult Details(int id)
        {
            if(null == id || _studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = _studentDB.Students.FirstOrDefault(x => x.Id == id);
            if (null == stdData)
            {
                return NotFound();
            }
            return View(stdData);
        }

        public IActionResult Edit(int? id)
        {
            if (null == id || _studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = _studentDB.Students.Find(id);
            if (null == stdData)
            {
                return NotFound();
            }
            return View(stdData);

        }
        [HttpPost]
        public IActionResult Edit(int? id, Student std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _studentDB.Update(std);
                _studentDB.SaveChanges();
                TempData["update_success"] = "updated";
                return RedirectToAction("index", "home");

            }
            return View(std);

        }
         public IActionResult Delete(int? id)
        {
            if (null == id || _studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = _studentDB.Students.FirstOrDefault(x => x.Id == id);
            if (null == stdData)
            {
                return NotFound();
            }

            return View(stdData);
        }
            [HttpPost , ActionName ("Delete")]
          public IActionResult Deleteconfirm(int? id)
             {  
                var stdData = _studentDB.Students.Find(id);
                if(null != stdData)
                {
                    _studentDB.Students.Remove(stdData);
                }
                   _studentDB.SaveChanges();
             TempData["Delete_success"] = "Deleted";
            return RedirectToAction("index", "home");

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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult List()
        {
           
            //for(int i = 0; i < 15; i++)
            //{
            //    //var anylistobj = new AnyList();
            //    //anylistobj.FatherName = "Gabru";
            //    //list.Add(anylistobj);


                
            //    Utility.list.Add(
            //        new AnyList()
            //        {
            //            Id = i,
            //            Name = "Hammad" + i,
            //            FatherName = "Gabru" + i
            //        });

            //}

            return View(Utility.list);
        }

        [HttpGet]
        public IActionResult AnyListCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AnyListCreate(AnyList anyList)
        {
            anyList.Id = Utility.list.Count + 1;
            Utility.list.Add(anyList);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult AnyListEdit(int Id)
        {
            var obj =  Utility.list[Id - 1];
            return View(obj);
        }

        [HttpPost]
        public IActionResult AnyListEdit(AnyList anyList)
        {
            Utility.list[anyList.Id - 1] = anyList;
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult AnyListDetail(int Id)
        {
            var obj = Utility.list[Id - 1];
            return View(obj);
        }

        [HttpGet]
        public IActionResult AnyListDelete(int Id)
        {
            Utility.list.RemoveAt(Id - 1);
            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
 
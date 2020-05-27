using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudiumTracker.Models;

namespace StudiumTracker.Controllers
{
    public class StudentCoursesMVCController : Controller
    {
        //[HttpPost]
        //public IActionResult Index(object data)
        //{


        //    return RedirectToAction("Index", "StudentCourses",data);
        //}

        [HttpGet]
        public IActionResult Index()
        {
            //if (data == null)
                return View(new StudentCourse());

           // return View(data);
        }
    }
}
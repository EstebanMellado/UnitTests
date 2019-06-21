using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unittest.Models;

namespace Unittest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string GetDeveloperName(int empId)
        {
            string name;
            if (empId == 1)
            {
                name = "Fernando";
            }
            else if (empId == 2)
            {
                name = "Florencia";
            }
            else if (empId == 3)
            {
                name = "Esteban";
            }
            else if (empId == 4)
            {
                name = "Sabrina";
            }
            else
            {
                name = "Not Found";
            }
            return name;
        }

    }
}

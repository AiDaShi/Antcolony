using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntcolonyProgram.Filter;
using AntcolonyProgram.JWT;
using Microsoft.AspNetCore.Mvc;

namespace AntcolonyProgram.Controllers
{
    [ServiceFilter(typeof(CheckTokenFilter))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        ///  /Home/Child
        /// </summary>
        /// <returns></returns>
        public IActionResult Child()
        {
            return View();
        }
    }
}
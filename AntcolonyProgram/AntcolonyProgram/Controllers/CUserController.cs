using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AntcolonyProgram.Controllers
{
    public class CUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
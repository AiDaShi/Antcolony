using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AntcolonyProgram.Controllers
{
    public class CLoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public void TestCommit() 
        {
            
        }
    }
}
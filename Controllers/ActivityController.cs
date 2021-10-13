using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

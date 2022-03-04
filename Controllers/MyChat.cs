using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Chat_Service.Controllers
{
    public class MyChat : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NayeemsFirstMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello .Net from Home";
        }
        public string MyMethod(int? id)
        {
            return "Yep It Works "+id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebApplication.Models;

namespace MyWebApplication.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            if(collection["name"] != "")
            {
                if (collection["username"] != "")
                {
                    if (collection["password"] != "" & collection["confirmpassword"] != "" & collection["password"] == collection["confirmpassword"])
                    {
                        if (collection["dob"] != "")
                        {
                            if (collection["bloodgroup"] != "")
                            {
                                if (collection["gender"] != "")
                                {
                                    if (collection["tac"] != "")
                                    {
                                        if (collection["profilepicture"] != null)
                                        {
                                            ViewData["name"] = collection["name"];
                                            ViewData["username"] = collection["username"];
                                            ViewData["password"] = collection["password"];
                                            ViewData["confirmpassword"] = collection["confirmpassword"];
                                            ViewData["dob"] = collection["dob"];
                                            ViewData["bloodgroup"] = collection["bloodgroup"];
                                            ViewData["gender"] = collection["gender"];
                                            ViewData["profilepicture"] = collection["profilepicture"];
                                            ViewData["tac"] = collection["tac"];
                                            return View("Person");
                                            //return Content(collection["name"] + "</br>" + collection["username"] + "</br>" + collection["password"] + "</br>" + collection["dob"] + "</br>" + collection["bloodgroup"] + "</br>" + collection["gender"] + "</br>");

                                        }
                                        else
                                        {
                                            ViewData["error"] = "Select a profile picture";
                                        }
                                    }
                                    else
                                    {
                                        ViewData["error"] = "Check the term and conditions";
                                    }
                                }
                                else
                                {
                                    ViewData["error"] = "Fill In gender";
                                }
                            }
                            else
                            {
                                ViewData["error"] = "Select the blood group";
                            }
                        }
                        else
                        {
                            ViewData["error"] = "Fill In date of birth";
                        }
                    }
                    else
                    {
                        ViewData["error"] = "Password or confirm password is empty or not same";
                    }
                }
                else
                {
                    ViewData["error"] = "Fill In Username";
                }
            }
            else
            {
                ViewData["error"] = "Fill In Name";
            }
            return View("Index");
        }
    }
}
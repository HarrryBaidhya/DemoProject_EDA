using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using StaffWeb.Models;
using DAL.Context;

namespace StaffWeb.Controllers
{
    public class loginController : Controller
    {

        public IUserService UService;
        public loginController(IUserService userService)
        {
            UService = userService;

        }

        public IActionResult index()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Model.login model)
        {
            if (ModelState.IsValid)
            {
                bool valid = UService.ValiadateUser(model.Username, model.Password);
                if (valid)
                {
                    TempData["msg"] = "You are welcome to  Section";
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    TempData["msg"] = "Username or Password is wrong.!";
                }
            }
            return View("login");

        }
        [HttpGet]
       public IActionResult List()
        {
            return View("");
        }
    }

}
    


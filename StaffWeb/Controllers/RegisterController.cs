using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffWeb.Controllers
{
    public class RegisterController : Controller
    {
        public IRegister _Staff;
        public RegisterController(IRegister staff)
        {
            _Staff = staff;

        }

        public IActionResult Display()
        {
            return View(_Staff.GetAllStaff());
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] StaffModel staff)
        {
            if (ModelState.IsValid)
            {
                if (staff != null)
                {

                    _Staff.Create(staff);
                    //_Staff.SaveChanges(staff);
                    return Json(new { status = true });
                }
                else
                {
                    return Json("Some thing is error");
                }


            }
            return RedirectToAction("Display");
        }
        
        //public IActionResult Edit(int id)
        //{
        //    if (id == null || id <= 0)
        //        return BadRequest();

        //}

        public IActionResult Update(int id)
        {
            StaffModel staff = _Staff.GetStaffById(id);
            return View("Update", staff);
        }
        [HttpPost]
        public IActionResult Update(StaffModel staff)
        {
            if (ModelState.IsValid)
            {
                _Staff.Update(staff);
                
                return RedirectToAction("Display");
            }
            
            return View("Display");
        }
        [HttpPost]
        public IActionResult DeleteMessages(int id)
        {
            if (ModelState.IsValid)
                
                   {
                _Staff.Delete(id);

                    return RedirectToAction("Display");
                   }

               return View("Display");
                
               
            
           
        }
        public IActionResult ViewPartial()
        {
            return PartialView("ViewPartial");
        }
        //public PartialViewResult ()
        //{
        //    return PartialView();
        //}  
        [HttpPost]
        public IActionResult Display(StaffModel staff)
        {
            return Json(staff);
        }

    }

    
}


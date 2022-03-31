using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        GeneralInsuranceEntities gie = new GeneralInsuranceEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult RegistrationDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationDetails(RegistrationInfo reginfo)
        {
            gie.RegistrationInfoes.Add(reginfo);
            gie.SaveChanges();
            return View(reginfo);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(RegistrationInfo reg)
        {
            if (ModelState.IsValid == true)
            {
                var credentials = gie.RegistrationInfoes.Where(model => model.Reg_Email == reg.Reg_Email && model.Reg_Password == reg.Reg_Password).First();
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "Login Failed";
                    return RedirectToAction("Login");
                }
                else
                {
                    Session["username"] = reg.Reg_Name;
                    return RedirectToAction("BuyInsurance");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public ActionResult Reset()
        {
            ModelState.Clear();
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult BuyInsurance()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuyInsurance(VehicleInsuranceInfo vif)
        {
            gie.VehicleInsuranceInfoes.Add(vif);
            gie.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
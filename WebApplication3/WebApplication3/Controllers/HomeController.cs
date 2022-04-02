using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{


    public class HomeController : Controller
    {

        GeneralInsuranceContext gic = new GeneralInsuranceContext();

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
            gic.RegistrationInfos.Add(reginfo);
            gic.SaveChanges();
            return RedirectToAction("Login");
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
                var credentials = gic.RegistrationInfos.Where(model => model.Registration_EmailAddress == reg.Registration_EmailAddress && model.Registration_Password == reg.Registration_Password).FirstOrDefault();
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "Login Failed";
                    return RedirectToAction("Login");
                }
                else
                {
                    Session["username"] = reg.Registration_Name;
                    return RedirectToAction("BuyInsurance");
                }
            }
            return View();
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
        public ActionResult BuyInsurance(VehicleInfo vf)
        {
            gic.VehicleInfos.Add(vf);
            gic.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
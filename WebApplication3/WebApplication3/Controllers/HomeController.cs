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
        public static int s;
        [HttpPost]
        public ActionResult Login(LoginInfo li)
        {
            if (ModelState.IsValid == true)
            {
                // var s = gic.RegistrationInfos.Find(li.Email); 
                var credentials = gic.RegistrationInfos.Where(model => model.Registration_EmailAddress == li.Email && model.Registration_Password == li.Password).FirstOrDefault();
                s = credentials.Registration_ID;
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "Login Failed";
                    return RedirectToAction("Login");
                }
                else
                {
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
            //gic.VehicleInfos.Add(vf);
            //gic.SaveChanges();
            VehicleInfo vehicleInfo = gic.VehicleInfos.Add(vf);
            vehicleInfo.Registration_Id = s;
            gic.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
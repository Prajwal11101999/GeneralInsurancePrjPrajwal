﻿using System;
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
            var ri = (from reg in gic.RegistrationInfos
                                   where reg.Registration_EmailAddress == reginfo.Registration_EmailAddress
                                   select reg).FirstOrDefault();

            if(ri == null)//|| reginfo.Registration_Phone_No == ri.Registration_Phone_No)
            {
                if(reginfo.Registration_DOB < DateTime.Today)
                {
                    gic.RegistrationInfos.Add(reginfo);
                    gic.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.ErrorMessageforDOB = "Date of Birth Cannot be bigger or equal to than todays Date";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Registration Failed!!!! Already User with same Email Address or Name.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public static int s;
        public static int h;
        [HttpPost]
        public ActionResult Login(LoginInfo li)
        {
            if (ModelState.IsValid == true)
            {
                var credentials = gic.RegistrationInfos.Where(model => model.Registration_EmailAddress == li.Email && model.Registration_Password == li.Password).FirstOrDefault();
                // s = credentials.Registration_ID;
                if (credentials == null)
                {
                    // ModelState.AddModelError(nameof(credentials.Registration_EmailAddress),"Login Failed !!!! EmailAddress or Password is Incorrect");
                    ViewBag.ErrorMessage = "Login Failed!!!! EmailAddress or Password is Incorrect";
                    return View();
                    // return RedirectToAction("Login");
                }
                else if(credentials.Registration_EmailAddress == "prajwal.borawake85@gmail.com")
                {
                    return RedirectToAction("AdminPage");
                }
                else 
                {
                    s = credentials.Registration_ID;
                    var ui = gic.UserPageInfos.Where(model => model.Registration_Id == s).FirstOrDefault();
                    if (ui == null)
                    {
                        return RedirectToAction("BuyInsurance");
                    }
                    else
                    {
                        h = ui.User_Id;
                        return RedirectToAction("UserPage");
                    }
                }
            }
            return View();
        }

        //[HttpGet]
        //public ActionResult ForgotPassword()
        //{
        //    return View();
        //    //ModelState.Clear();
        //    //return RedirectToAction("Login", "Home");
        //}

        //public static ResetPassword reset = new ResetPassword();
        //// public static int reg_id;
        //[HttpPost]
        //public ActionResult ForgotPassword(ResetPassword rp)
        //{
        //    var ri = gic.RegistrationInfos.Where(model => model.Registration_EmailAddress == rp.Registration_EmailAddress).FirstOrDefault();
        //    if (ri == null)
        //    {
        //        ViewBag.ErrorMessage = "There is no such EmailAddress Please Enter Correct EmailAddress.";
        //        return View();
        //    }
        //    else
        //    {
        //        rp.Registration_ID = ri.Registration_ID;
        //        reset = rp;
        //        return RedirectToAction("CommitChanges");
        //    }
        //}

        //public ActionResult CommitChanges()
        //{
        //    // reg_id = ri.Registration_ID;
        //    RegistrationInfo reg = (from re in gic.RegistrationInfos
        //                            where re.Registration_ID == reset.Registration_ID
        //                            select re).FirstOrDefault();//gic.RegistrationInfos.Find(reset.Registration_ID);
        //    reg.Registration_Password = reset.Registration_Password;
        //    reg.Registration_Confirm_Password = reset.Registration_Confirm_Password;
        //    gic.SaveChanges();
        //    return RedirectToAction("Login");
        //}

        [HttpGet]
        public ActionResult BuyInsurance()
        {
            return View();
        }

        public static int d;
        [HttpPost]
        public ActionResult BuyInsurance(VehicleInfo vf)
        {
            //gic.VehicleInfos.Add(vf);
            //gic.SaveChanges();
            VehicleInfo vehicleInfo = gic.VehicleInfos.Add(vf);
            vehicleInfo.Registration_Id = s;
            gic.SaveChanges();
            d = vehicleInfo.Vehicle_ID;
            return RedirectToAction("InsuranceDetails");
        }

        [HttpGet]
        public ActionResult InsuranceDetails()
        {
            return View();
        }

        public static int f;
        [HttpPost]
        public ActionResult InsuranceDetails(InsurancePlanInfo ipi)
        {
            InsurancePlanInfo insurancePlanInfo = gic.InsurancePlanInfos.Add(ipi);
            insurancePlanInfo.Vehicle_Id = d;
            insurancePlanInfo.Registration_Id = s;
            gic.SaveChanges();
            f = insurancePlanInfo.InsurancePlan_ID;
            return RedirectToAction("PolicyInfoDetails");
        }

        public static int g;
        public ActionResult PolicyInfoDetails()
        {
            float idv;
            PolicyInfo pi = new PolicyInfo();
            pi.Vehicle_Id = d;
            pi.InsurancePlan_Id = f;
            pi.Policy_IssuedDate = DateTime.Today;
            InsurancePlanInfo ipi = gic.InsurancePlanInfos.Find(f);
            VehicleInfo vi = gic.VehicleInfos.Find(d);
            if(vi.Vehicle_No_Years_Old <= 1 )
            {
                float price = vi.Vehicle_Price;
                idv = price - (float)(0.1 * price);
            }
            else if(vi.Vehicle_No_Years_Old <= 2 && vi.Vehicle_No_Years_Old > 1)
            {
                float price = vi.Vehicle_Price;
                idv = price - (float)(0.2 * price);
            }
            else if (vi.Vehicle_No_Years_Old <= 3 && vi.Vehicle_No_Years_Old > 3)
            {
                float price = vi.Vehicle_Price;
                idv = price - (float)(0.3 * price);
            }
            else if (vi.Vehicle_No_Years_Old <= 4 && vi.Vehicle_No_Years_Old > 3)
            {
                float price = vi.Vehicle_Price;
                idv = price - (float)(0.4 * price);
            }
            else
            {
                float price = vi.Vehicle_Price;
                idv = price - (float)(0.5 * price);
            }
            pi.Policy_Amount = idv;
            float z = (float)((1.970 / 100) * idv);
            float a = (float)(0.2 * z);
            float c = z - a;
            float x = 100;
            float v = 50;
            float m = 1110;
            float net = c + x + v + m;
            float gst = (float)((18 / 100) * net);
            pi.Policy_Premium = net + gst;
            pi.Policy_ExpiryDate = pi.Policy_IssuedDate.AddYears(ipi.InsurancePlan_No_Of_Years);
            pi.Policy_Status = "Pendind...";
            pi.Policy_Reason = "";
            pi.Registration_Id = s;
            gic.PolicyInfos.Add(pi);
            gic.SaveChanges();
            g = pi.PolicyInfo_Number;
            return RedirectToAction("DisplayPolicyInfo");
        }

        public ActionResult DisplayPolicyInfo()
        {
            PolicyInfo pi = gic.PolicyInfos.Find(g);
            return View(pi);
        }

        public ActionResult AdminPage()
        {
            List<PolicyInfo> policyInfos = gic.PolicyInfos.ToList();
            return View(policyInfos);
        }

        public ActionResult ClaimList()
        {
            List<ClaimInfo> claimInfos = gic.ClaimInfos.ToList();
            return View(claimInfos);
        }

        [HttpGet]
        public ActionResult ClaimEdit(int id)
        {
            ClaimInfo ci = gic.ClaimInfos.Find(id);
            return View(ci);
        }

        [HttpPost]
        public ActionResult ClaimEdit(ClaimInfo claimInfo)
        {
            ClaimInfo ci = gic.ClaimInfos.Find(claimInfo.Claim_Number);
            ci.Claim_Approval_Result = claimInfo.Claim_Approval_Result;
            ci.Claim_Approved_Amount = claimInfo.Claim_Approved_Amount;
            gic.SaveChanges();
            return RedirectToAction("AdminPage");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            PolicyInfo pi = gic.PolicyInfos.Find(id);
            return View(pi);
        }

        [HttpPost]
        public ActionResult Edit(PolicyInfo policyInfo)
        {
            PolicyInfo pi = gic.PolicyInfos.Find(policyInfo.PolicyInfo_Number);
            pi.Policy_Status = policyInfo.Policy_Status;
            pi.Policy_Amount = policyInfo.Policy_Amount;
            gic.SaveChanges();
            UserPageInfo upi = (from pol in gic.UserPageInfos
                                where pol.Policy_Number == pi.PolicyInfo_Number
                                select pol).FirstOrDefault();
            upi.Policy_Status = pi.Policy_Status;
            upi.Policy_Amount = policyInfo.Policy_Amount;
            gic.SaveChanges();
            return RedirectToAction("AdminPage");
        }

        public ActionResult Delete(int id)
        {
            PolicyInfo pi = gic.PolicyInfos.Find(id);
            gic.PolicyInfos.Remove(pi);
            gic.SaveChanges();
            return RedirectToAction("AdminPage");
        }

        public ActionResult ClaimDelete(int id)
        {
            ClaimInfo ci = gic.ClaimInfos.Find(id);
            gic.ClaimInfos.Remove(ci);
            gic.SaveChanges();
            return RedirectToAction("ClaimList");
        }

        public static int l; 
        public ActionResult GetUserInfo()
        {
            RegistrationInfo ri = (from reg in gic.RegistrationInfos
                                   where reg.Registration_ID == s
                                   select reg).FirstOrDefault();
            PolicyInfo pi = (from reg in gic.PolicyInfos
                                   where reg.PolicyInfo_Number == g
                                   select reg).FirstOrDefault();
            VehicleInfo vi = (from reg in gic.VehicleInfos
                                   where reg.Vehicle_ID == d
                                   select reg).FirstOrDefault();
            UserPageInfo upi = new UserPageInfo();
            upi.Registration_Id = ri.Registration_ID;
            upi.User_Name = ri.Registration_Name;
            upi.Policy_Number = pi.PolicyInfo_Number;
            upi.Vehicle_Model = vi.Vehicle_Model;
            upi.Vehicle_Reg_no = vi.Vehicle_Regis_No;
            upi.Policy_Amount = pi.Policy_Amount;
            upi.Policy_Premium = pi.Policy_Premium;
            upi.Policy_Status = pi.Policy_Status;
            upi.Policy_IssuedDate = pi.Policy_IssuedDate;
            upi.Policy_ExpiryDate = pi.Policy_ExpiryDate;
            gic.UserPageInfos.Add(upi);
            gic.SaveChanges();
            l = upi.User_Id;
            return RedirectToAction("Login");
        }

        public ActionResult UserPage()
        {
            UserPageInfo userPageInfo = gic.UserPageInfos.Find(h);
            return View(userPageInfo);
        }

        [HttpGet]
        public ActionResult ClaimProcedure()
        {
            ClaimInfo ci = (from st in gic.ClaimInfos
                     where st.Registration_Id == s
                     select st).FirstOrDefault();
            if(ci == null)
            {
               return View(); ;
            }
            else
            {
                return RedirectToAction("ClaimPage");
            }
        }

        public static int j;
        [HttpPost]
        public ActionResult ClaimProcedure(ClaimInfo ci)
        {
            UserPageInfo upi = gic.UserPageInfos.Find(h);
            ClaimInfo claimInfo = gic.ClaimInfos.Add(ci);
            claimInfo.Claim_Date = DateTime.Today;
            claimInfo.Policy_Number = upi.Policy_Number;
            claimInfo.Registration_Id = upi.Registration_Id;
            gic.SaveChanges();
            j = claimInfo.Claim_Number;
            return RedirectToAction("ClaimPage");
        }

        public ActionResult ClaimError()
        {
            ViewBag.ErrorMessage = "Policy Status is Pending or Rejected.";
            return View();
        }

        public ActionResult ClaimPage()
        {
            ClaimInfo ci = (from st in gic.ClaimInfos
                     where st.Registration_Id == s
                     select st).FirstOrDefault();
            return View(ci);
        }

        [HttpGet]
        public ActionResult Renewal()
        {
            PolicyInfo pi = (from pit in gic.PolicyInfos
                             where pit.Registration_Id == s
                             select pit).FirstOrDefault();
            if(pi.Policy_ExpiryDate > DateTime.Today)
            {
                // ViewBag.ErrorMessage = "The Policy is Still Valid No need to Renew.";
                return RedirectToAction("NewView");
            }
            else
            {
                return View(pi);
            }
        }

        public ActionResult NewView()
        {
            ViewBag.ErrorMessage = "The Policy is Still Valid No need to Renew.";
            return View();
        }

        [HttpPost]
        public ActionResult Renewal(PolicyInfo pi)
        {
            PolicyInfo policyInfo = gic.PolicyInfos.Find(pi.PolicyInfo_Number);
            policyInfo.Policy_IssuedDate = pi.Policy_IssuedDate;
            policyInfo.Policy_ExpiryDate = pi.Policy_ExpiryDate;
            policyInfo.Policy_Amount = 0;
            policyInfo.Policy_Status = "Pending...";
            UserPageInfo upi = (from ui in gic.UserPageInfos
                                where ui.Policy_Number == pi.PolicyInfo_Number
                                select ui).FirstOrDefault();
            upi.Policy_IssuedDate = pi.Policy_IssuedDate;
            upi.Policy_ExpiryDate = pi.Policy_ExpiryDate;
            upi.Policy_Amount = 0; // pi.Policy_Amount;
            upi.Policy_Status = "Pending...";
            gic.SaveChanges();
            return RedirectToAction("UserPage");
        }
    }
}
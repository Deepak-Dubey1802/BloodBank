using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankManagementSystem.Models;
using Npgsql;

namespace BloodBankManagementSystem.Controllers
{
 
    public class HomeController : Controller
    {

        BloodBankDBContext db = new Models.BloodBankDBContext();
        public ActionResult Donor()
        {

            
            List<Donor> obj = db.GetDonors();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Donor donor)
        {
            if (ModelState.IsValid == true)
            {
                BloodBankDBContext context = new BloodBankDBContext();
                bool check = context.AddDonor(donor);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Donor");
                }
            }
            return View();
        }



        public ActionResult Registration()
        {
            getcountry();
          
            getBloodGroupList();
            getGenderList();

           
            return View();
        }


        public JsonResult getGenderList()
        {
           
            List<Gender> GenderList = (List<Gender>)db.GetGenders();
            ViewBag.GenderList = new SelectList(GenderList, "genderid", "gender");

            return Json(GenderList, JsonRequestBehavior.AllowGet);
        }




        public JsonResult getBloodGroupList()
        {
           
            List<BloodGroup> BloodGroupList = db.GetBloodGroups();
            ViewBag.BloodGroupList = new SelectList(BloodGroupList, "bloodgroupid", "bloodgroup");

            return Json(BloodGroupList, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Index()
        //{
        //    BloodBankDBContext db = new Models.BloodBankDBContext();
        //    List<Country> CountryList = db.GetCountries();
        //    ViewBag.CountryList = new SelectList(CountryList, "countryid", "countryname");
        //    return View(CountryList);
        //}


        public void getcountry()
        {
            List<Country> CountryList = db.GetCountries();
            ViewBag.CountryList = new SelectList(CountryList, "countryid", "countryname");

        }




        public JsonResult getState(int countryid)
        {

            List<State> StateList = db.getState(countryid);
            ViewBag.StateList = new SelectList(StateList, "stateid", "statename");
            return Json(StateList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getCities(int stateid)
        {

            List<City> CityList = db.getCities(stateid);
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult Registration(Donor donor)
        {
            if (ModelState.IsValid == true)
            {
                BloodBankDBContext context = new BloodBankDBContext();
                bool check = context.AddDonor(donor);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Donor");
                }
            }
            return View();
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Donor donor)
        {
            Boolean check = db.Loginuser(donor);
            if (check == true)
            {
                Session["login "] = "login  Successfuly";
                return RedirectToAction("Donor", "Home");
            }
            else
            {
                return RedirectToAction("Donor ", "Login");
            }
        }






        public ActionResult BloodBank()
        {
            BloodBankDBContext db = new Models.BloodBankDBContext();
            List<BloodBank> obj = db.GetBloodBanks();
            return View(obj);
        }


        public ActionResult Request()
        {

            List<Request> obj = db.GetRequests();
            return View(obj);
        }



        public ActionResult Requst()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Requst(Request request)
        {
            if (ModelState.IsValid == true)
            {
                BloodBankDBContext context = new BloodBankDBContext();
                bool check = context.AddRequest(request);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Request");
                }
            }
            return View();
        }







        public ActionResult RequestForm()
        {
            getBloodBankList();
            getDonorList();
            getBloodGroupList();
            return View();
        }



        public JsonResult getDonorList()
        {

            List<Donor> DonorList = db.GetDonors();
            ViewBag.DonorList = new SelectList(DonorList, "donorid", "fullname");

            return Json(DonorList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult getBloodBankList()
        {

            List<BloodBank> BloodBankList = db.GetBloodBanks();
            ViewBag.BloodBankList = new SelectList(BloodBankList, "bloodbankid", "name");

            return Json(BloodBankList, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult RequstForm(Request request)
        {
            if (ModelState.IsValid == true)
            {
                BloodBankDBContext context = new BloodBankDBContext();
                bool check = context.AddRequest(request);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Request");
                }
            }
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
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankManagementSystem.Data;
using BloodBankManagementSystem.Models;
using Npgsql;

namespace BloodBankManagementSystem.Controllers
{
 
 
    public class HomeController : Controller
    {

        BloodBankDBContext db = new BloodBankDBContext();
        RegistrationDBContext rdb = new RegistrationDBContext();
      
        public IEnumerable RegistrationList { get; private set; }

        public ActionResult Ind()
        {
            return View();
        }




        //public ActionResult Admins()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Admins(Admin admin)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        BloodBankDBContext context = new BloodBankDBContext();
        //        bool check = context.AddAdmin(admin);
        //        if (check == true)
        //        {
        //            TempData["InsertMessage"] = "Data has been Inserted Successfully.";
        //            ModelState.Clear();
        //            return RedirectToAction("Admin");
        //        }
        //    }
        //    return View();
        //}




        //public ActionResult AdminLogin()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AdminLogin(Admin admin)
        //{
        //    Boolean check = db.Loginadmin(admin);
        //    if (check == true)
        //    {
        //        Session["login "] = "login  Successfuly";
        //        TempData["InsertMessage"] = "Admin Login Successfully.";
        //        return RedirectToAction("Layout", "Admin", new {area = "Admin" });
        //    }
        //    else
        //    {
        //        return RedirectToAction("Ind", "Home");
        //    }
        //}









        //public ActionResult CreateBS()
        //{
        //    getBloodtypeslist();
        //    getBloodGroupList();
        //    getBloodBankList();
        //    return View();
        //}

        // public JsonResult getBloodtypeslist()
        //{

        //    DataDBContext db = new DataDBContext();
        //    List<Bloodtypes> Bloodtypeslist = db.GetBloodtypes();
        //    ViewBag.Bloodtypeslist = new SelectList(Bloodtypeslist, "bloodtypeid", "bloodtype");

        //    return Json(Bloodtypeslist, JsonRequestBehavior.AllowGet);
        //}




        //[HttpPost]
        //public ActionResult CreateBS(Bstockb bS)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        BloodBankDBContext context = new BloodBankDBContext();
        //        bool check = context.AddBS(bS);
        //        if (check == true)
        //        {
        //            TempData["InsertMessage"] = "Data has been Inserted Successfully.";
        //            ModelState.Clear();
        //            return RedirectToAction("BS");
        //        }
        //    }
        //    return View();
        //}

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



        public ActionResult Edit(string panno)
        {
            BloodBankDBContext context = new BloodBankDBContext();
            var row = context.GetDonors().Find(model => model.panno == panno);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(string panno, Donor donor)
        {
            if (ModelState.IsValid == true)
            {
                BloodBankDBContext context = new BloodBankDBContext();
                bool check = context.UpdateDonor(donor);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Ind");
                }


            }
            return View();

        }



        public ActionResult Delete(string panno)
        {
            BloodBankDBContext context = new BloodBankDBContext();
            var row = context.GetDonors().Find(model => model.panno == panno);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(string panno, Donor donor)
        {

            BloodBankDBContext context = new BloodBankDBContext();
            bool check = context.DeleteDonor(panno);
            if (check == true)
            {
                TempData["UpdatetMessage"] = "Data has been Deleted Successfully.";

                return RedirectToAction("Ind");
            }


            return View();

        }



        public ActionResult Gender()
        {


            List<Gender> obj = db.GetGenders();
            return View(obj);
        }




        public ActionResult BloodGroup()
        {


            List<BloodGroup> obj = db.GetBloodGroups();
            return View(obj);
        }



        public ActionResult Createb()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Createb(BloodGroup bloodGroup)
        {
            if (ModelState.IsValid == true)
            {
                BloodBankDBContext context = new BloodBankDBContext();
                bool check = context.AddBloodGroup(bloodGroup);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("BloodGroup");
                }
            }
            return View();
        }




         public ActionResult Editb(int id)
        {
            BloodBankDBContext context = new BloodBankDBContext();
            var row = context.GetBloodGroups().Find(model => model.bloodgroupid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Editb(int id, BloodGroup bloodGroup)
        {
            if (ModelState.IsValid == true)
            {
                BloodBankDBContext context = new BloodBankDBContext();
                bool check = context.UpdateBloodGroup(bloodGroup);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("BloodGroup");
                }


            }
            return View();

        }





        //public ActionResult BloodStock()
        //{


        //    List<BloodStock> obj = db.GetBloodStocks();
        //    return View(obj);
        //}




        //public ActionResult Createbloodstock()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Createbloodstock(BloodStock bloodStock)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        BloodBankDBContext context = new BloodBankDBContext();
        //        bool check = context.Addbloodstock(bloodStock);
        //        if (check == true)
        //        {
        //            TempData["InsertMessage"] = "Data has been Inserted Successfully.";
        //            ModelState.Clear();
        //            return RedirectToAction("BloodStock");
        //        }
        //    }
        //    return View();
        //}





        public ActionResult Country()
        {
            BloodBankDBContext db = new Models.BloodBankDBContext();
            List<Country> CountryList = db.GetCountries();
            ViewBag.CountryList = new SelectList(CountryList, "countryid", "countryname");
            return View(CountryList);
        }



        public ActionResult State()
        {
            BloodBankDBContext db = new Models.BloodBankDBContext();
            List<State> obj = db.GetState();
            return View(obj);
        }





       


        public ActionResult City()
        {
            BloodBankDBContext db = new Models.BloodBankDBContext();
            List<City> obj = db.GetCities();
            return View(obj);
        }


  



        public ActionResult UserRegistration()
        {

            RegistrationDBContext db = new RegistrationDBContext();
            List<Registration> obj = db.GetRegistrations();
            return View(obj);
        }



        public ActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserCreate(Registration registration)
        {
            if (ModelState.IsValid == true)
            {
                RegistrationDBContext rcontext = new RegistrationDBContext();
                bool check = rcontext.AddRegistration(registration);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("UserRegistration");
                }
            }
            return View();
        }


        public ActionResult Registration()
        {

            getcountry();
            getGenderList();
            getBloodGroupList();
            getGenderList();


            return View();
        }



        public JsonResult getGenderList()
        {

            List<Gender> GenderList = db.GetGenders();
            ViewBag.GenderList = new SelectList(GenderList, "genderid", "gender");

            return Json(GenderList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult getBloodGroupList()
        {
           
            List<BloodGroup> BloodGroupList = db.GetBloodGroups();
            ViewBag.BloodGroupList = new SelectList(BloodGroupList, "bloodgroupid","bloodgroup");

            return Json(BloodGroupList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            BloodBankDBContext db = new Models.BloodBankDBContext();
            List<Country> CountryList = db.GetCountries();
            ViewBag.CountryList = new SelectList(CountryList, "countryid", "countryname");
            return View(CountryList);
        }


        public void getcountry()
        {
            List<Country> CountryList = db.GetCountries();
            ViewBag.CountryList = new SelectList(CountryList, "countryid","countryname");
        }

        public JsonResult GetStateList(int countryid)
        {

            List<State> StateList = db.getState(countryid);
            return Json(StateList, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetCityList(int stateid)
        {

            List<City> CityList = db.getCities(stateid);
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Registration(Registration registration)
        {
            if (ModelState.IsValid == true)
            {
                RegistrationDBContext rcontext = new RegistrationDBContext();
                bool check = rcontext.AddRegistration(registration);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Donor Registration Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Ind");
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
            
          Donor lg  = db.Loginuser(donor);
            if (lg.role == 2)
            {
                Session["login "] = "Donor Login  Successfully";
                return RedirectToAction("Home", "User");
            }
            else if(lg.role== 1)
            {
                Session["Admin"] = lg.role;
                return RedirectToAction("Layout", "Admin", new { area = "Admin" });
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


        //public ActionResult Request()
        //{

        //    List<Request> obj = db.GetRequests();
        //    return View(obj);
        //}

        [HttpGet]
        /*[HttpPost]*/
        public JsonResult GetRequests(int id)
        {
            BloodBankDBContext db = new BloodBankDBContext();
            List<Request> RequestList = db.GetRequestForApproval(id);
            int userdemand = Convert.ToInt32(RequestList[0].quantity);

            List<BloodStock> BlooodStockList = db.GetRequestedBloodStock(RequestList[0].bloodgroupid);
            int availableStock = BlooodStockList[0].quantity;

            if(availableStock > userdemand)
            {
                int updateStockInDatabase = availableStock - userdemand;
                // Stock Available
                db.UpdateStock(RequestList[0].bloodgroupid, updateStockInDatabase);
            }
            else
            {
                // Stock is Less than Available
            }

            
            return Json("true", JsonRequestBehavior.AllowGet);
          
        }



        public ActionResult approvedrequst(int id)
        {

            BloodBankDBContext db = new Models.BloodBankDBContext();
            List<Request> RequestList = db.Requests();
            return View(RequestList);
        }


        public ActionResult rejected(int id)
        {

            List<Request> obj = db.GetRequests();
            Boolean check = db.rejected(id);
            return Json("true", JsonRequestBehavior.AllowGet);
        }









        public ActionResult UserRequest()
        {

            RegistrationDBContext db = new RegistrationDBContext();
            List<RequestForm> obj = db.GetRequestForms();
            return View(obj);
        }





        public ActionResult UserReq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserReq(RequestForm requestForm)
        {
            if (ModelState.IsValid == true)
            {
                RegistrationDBContext rcontext = new RegistrationDBContext();
                bool check = rcontext.AddDonorRequest(requestForm);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("UserRegistration");
                }
            }
            return View();
        }




        public ActionResult RequestForm()
        {
            getBloodBankList();
            getRegistrationList();
            getBloodGroupList();
            return View();
        }

        public JsonResult getRegistrationList()
        {

            List<Registration> RegistrationList = rdb.GetRegistrations();
            ViewBag.RegistrationList = new SelectList(RegistrationList, "donorid", "fullname");

            return Json(RegistrationList, JsonRequestBehavior.AllowGet);
        }



        public JsonResult getBloodBankList()
        {

            List<BloodBank> BloodBankList = db.GetBloodBanks();
            ViewBag.BloodBankList = new SelectList(BloodBankList, "bloodbankid", "name");

            return Json(BloodBankList, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult RequestForm(RequestForm requestForm)
        {
            if (ModelState.IsValid == true)
            {
                RegistrationDBContext rcontext = new RegistrationDBContext();
                bool check = rcontext.AddDonorRequest(requestForm);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Blood Request Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Home","User");
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

        public ActionResult Master()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult DonorProfile(string panno)
        {
            BloodBankDBContext context = new BloodBankDBContext();
            var row = context.GetDonors().Find(model => model.panno == panno);
           

            getcountry();
            getBloodGroupList();
            getGenderList();
            return View(row);
        }

        [HttpPost]
        public ActionResult DonorProfile(string panno, Donor donor)
        {
            if (ModelState.IsValid == true)
            {
                BloodBankDBContext context = new BloodBankDBContext();
                bool check = context.UpdateDonor(donor);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Ind");
                }


            }
            return View();

        }


        public ActionResult dashboard()
        {
            return View();
        }


        public ActionResult LogOut()
        {

        
            Session.Abandon();
            return RedirectToAction("Ind", "Home");

           

        }
    }
}
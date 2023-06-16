using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankManagementSystem.Data;
using BloodBankManagementSystem.Models;
using BloodBankManagementSystem.Areas.Admin.Model;
using Npgsql;


namespace BloodBankManagementSystem.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {

        BloodBankDBContext db = new BloodBankDBContext();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult Donor()
        {


            List<Donor> obj = db.GetDonors();
            return View(obj);
        }


        public ActionResult BloodGroup()
        {


           DataDBContext db = new DataDBContext();
            List<BloodGroup> obj = db.GetBloodgroups();
            return View(obj);
        }



        public ActionResult Createb()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Createb(BloodGroup blood)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.AddBloodGroup(blood);
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
            DataDBContext context = new DataDBContext();
            var row = context.GetBloodgroups().Find(model => model.bloodgroupid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Editb(int id, BloodGroup blood)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.UpdateBloodGroup(blood);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("BloodGroup");
                }


            }
            return View();

        }



        public ActionResult Deleteb(int id)
        {
            DataDBContext context = new DataDBContext();
            var row = context.GetBloodgroups().Find(model => model.bloodgroupid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Deleteb(int id, BloodGroup blood)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.DeleteBloodGroup(id);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("BloodGroup");
                }


            }
            return View();

        }



        public ActionResult BloodStock()
        {


            DataDBContext db = new DataDBContext();
            List<BloodStock> obj = db.GetStocks();
            return View(obj);
        }


        public ActionResult Stockblood()
        {


            DataDBContext db = new DataDBContext();
            List<Stockblood> obj = db.GetStockbloods();

            return View(obj);
        }



        //public ActionResult CreateS()
        //{
        //    getBloodtypeslist();
        //    getBloodGroupList();
        //    getBloodBankList();
        //    return View();
        //}




        public JsonResult getBloodtypeslist()
        {

            DataDBContext db = new DataDBContext();
            List<Bloodtypes> Bloodtypeslist = db.GetBloodtypes();
            ViewBag.Bloodtypeslist = new SelectList(Bloodtypeslist, "bloodtypeid", "bloodtype");

            return Json(Bloodtypeslist, JsonRequestBehavior.AllowGet);
        }



        public JsonResult getBloodGroupList()
        {

            List<BloodGroup> bloodgrouplist = db.GetBloodGroups();
            ViewBag.bloodgrouplist = new SelectList(bloodgrouplist, "bloodgroupid", "bloodgroup");

            return Json(bloodgrouplist, JsonRequestBehavior.AllowGet);
        }





        public JsonResult getBloodBankList()
        {

            List<BloodBank> BloodBankList = db.GetBloodBanks();
            ViewBag.BloodBankList = new SelectList(BloodBankList, "bloodbankid", "name");

            return Json(BloodBankList, JsonRequestBehavior.AllowGet);
        }






        public ActionResult CreateS()
        {
            getBloodtypeslist();
            getBloodGroupList();
            getBloodBankList();
            return View();
        }




        [HttpPost]
        public ActionResult CreateS(Stockblood stockblood)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.AddBloodStock(stockblood);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("BloodStock");
                }
            }
            return View();
        }









        public ActionResult EditS(int id)
        {

            getBloodtypeslist();
            getBloodGroupList();
            getBloodBankList();

            DataDBContext context = new DataDBContext();
            var row = context.GetStockbloods().Find(model => model.bloodstockid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult EditS(int id, Stockblood stockblood)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.UpdateBloodStock(stockblood);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("BloodStock");
                }


            }
            return View();

        }





        public ActionResult DeleteS(int id)
        {
           

            DataDBContext db = new DataDBContext();
            List<BloodStock> obj = db.GetStocks();
            var row = db.GetStocks().Find(model => model.bloodstockid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult DeleteS(int id, Stockblood stockblood)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.DeleteBloodStock(id);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("BloodStock");
                }


            }
            return View();

        }













        public ActionResult BloodB()
        {
            BloodBankDBContext db = new Models.BloodBankDBContext();
            List<BloodBank> obj = db.GetBloodBanks();
            return View(obj);
        }



        public ActionResult BloodBank()
        {


            DataDBContext db = new DataDBContext();
            List<BloodBank> obj = db.GetBanks();
            return View(obj);
        }





        public ActionResult Createbb()
        {

            getBloodGroupList();
            getcountry();
            return View();
        }



        public void getcountry()
        {
            List<Country> CountryList = db.GetCountries();
            ViewBag.CountryList = new SelectList(CountryList, "countryid", "countryname");
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
        public ActionResult Createbb(BloodBank bank)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.AddBloodBank(bank);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("BloodBank");
                }
            }
            return View();
        }




        public ActionResult Editbb(int id)
        {
            DataDBContext context = new DataDBContext();
            var row = context.GetBanks().Find(model => model.bloodbankid == id);

            getBloodGroupList();
            getcountry();
            return View(row);
           


        }

        [HttpPost]
        public ActionResult Editbb(int id, BloodBank bank)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.UpdateBloodBank(bank);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("BloodBank");
                }


            }
            return View();

        }



        public ActionResult Deletebb(int id)
        {
            BloodBankDBContext db = new Models.BloodBankDBContext();
            List<BloodBank> obj = db.GetBloodBanks();
            var row = db.GetBloodBanks().Find(model => model.bloodbankid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Deletebb(int id, BloodBank bank)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.DeleteBloodBank(id);
                if (check == true)
                {
                    TempData["DeleteMessage"] = "Data has been Deleted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("BloodBank");
                }


            }
            return View();

        }












        public ActionResult Country()
        {
         
            List<Country> CountryList = db.GetCountries();
            ViewBag.CountryList = new SelectList(CountryList, "countryid", "countryname");
            return View(CountryList);
        }


        public ActionResult CreateC()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateC(Country country)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.AddCountry(country);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Country");
                }
            }
            return View();
        }




        public ActionResult EditC(int id)
        {
            DataDBContext context = new DataDBContext();
            var row = context.GetCountries().Find(model => model.countryid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult EditC(int id, Country country)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.UpdateCountry(country);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Country");
                }


            }
            return View();

        }



        public ActionResult DeleteC(int id)
        {
            DataDBContext context = new DataDBContext();
            var row = context.GetCountries().Find(model => model.countryid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult DeleteC(int id, Country country)
        {
            
                DataDBContext context = new DataDBContext();
                bool check = context.DeleteCountry(id);
                if (check == true)
                {
                    TempData["DeleteMessage"] = "Data has been Deleted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Country");
                }


            
            return View();

        }





        public ActionResult State()
        {
            DataDBContext db = new DataDBContext();
            List<State> obj = db.GetStates();
            return View(obj);
        }




        public ActionResult CreateState()
        {

            getcountry();

            return View();
        }
        [HttpPost]
        public ActionResult CreateState(State state)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.AddState(state);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("State");
                }
            }
            return View();
        }



        public ActionResult EditState(int id)
        {
            DataDBContext context = new DataDBContext();
            var row = context.GetStates().Find(model => model.stateid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult EditState(int id, State state)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.UpdateState(state);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("State");
                }


            }
            return View();

        }



        public ActionResult DeleteState(int id)
        {
            DataDBContext context = new DataDBContext();
            var row = context.GetStates().Find(model => model.stateid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult DeleteState(int id, State state)
        {

            DataDBContext context = new DataDBContext();
            bool check = context.DeleteState(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "Data has been Deleted Successfully.";
                ModelState.Clear();
                return RedirectToAction("State");
            }



            return View();

        }





        public ActionResult City()
        {
           
            List<City> obj = db.GetCities();
            return View(obj);
        }

        public JsonResult getStateList()
        {

            List<State> StateList = db.GetState();
            ViewBag.StateList = new SelectList(StateList, "stateid", "statename");

            return Json(StateList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateCity()
        {


            getStateList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCity(City city)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.AddCity(city);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("City");
                }
            }
            return View();
        }


        public ActionResult EditCity(int id)
        {
            DataDBContext context = new DataDBContext();
            var row = context.GetCities().Find(model => model.cityid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult EditCity(int id, City city)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.UpdateCity(city);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("City");
                }


            }
            return View();

        }



        public ActionResult DeleteCity(int id)
        {
            DataDBContext context = new DataDBContext();
            var row = context.GetCities().Find(model => model.cityid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult DeleteCity(int id, City city)
        {

            DataDBContext context = new DataDBContext();
            bool check = context.DeleteCity(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "Data has been Deleted Successfully.";
                ModelState.Clear();
                return RedirectToAction("City");
            }



            return View();

        }



        public ActionResult Bloodtypes()
        {


            DataDBContext db = new DataDBContext();
            List<Bloodtypes> obj = db.GetBloodtypes();
            return View(obj);
        }








       

        public ActionResult Createbt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Createbt(Bloodtypes bloodtypes)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.AddBloodtypes(bloodtypes);
                if (check == true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Bloodtypes");
                }
            }
            return View();
        }


        public ActionResult Editbt(int id)
        {
            DataDBContext context = new DataDBContext();
            var row = context.GetBloodtypes().Find(model => model.bloodtypeid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Editbt(int id, Bloodtypes bloodtypes)
        {
            if (ModelState.IsValid == true)
            {
                DataDBContext context = new DataDBContext();
                bool check = context.UpdateBloodtypes(bloodtypes);
                if (check == true)
                {
                    TempData["UpdatetMessage"] = "Data has been Updated Successfully.";
                    ModelState.Clear();
                    return RedirectToAction("Bloodtypes");
                }


            }
            return View();

        }



        public ActionResult Deletebt(int id)
        {
            DataDBContext context = new DataDBContext();
            var row = context.GetBloodtypes().Find(model => model.bloodtypeid == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Deletebt(int id, Bloodtypes bloodtypes)
        {

            DataDBContext context = new DataDBContext();
            bool check = context.DeleteBloodtypes(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "Data has been Deleted Successfully.";
                ModelState.Clear();
                return RedirectToAction("Bloodtypes");
            }



            return View();

        }




        public ActionResult Layout()
        {
            return View();
        }


      

        public ActionResult Charts()
        {


            return View();
        }


        public ActionResult stock()
        {


            return View();
        }



        public ActionResult Request()
        {


            List<Request> obj = db.GetRequests();
            return View(obj);
        }

        public ActionResult Approved()
        {


            List<Request> obj = db.GetApproved();
            return View(obj);
        }


        public ActionResult Rejected()
        {


            List<Request> obj = db.GetRejected();
            return View(obj);
        }








        [HttpPost]
        public JsonResult GetRequests(int data)
        {
            BloodBankDBContext db = new BloodBankDBContext();

            return Json("true", JsonRequestBehavior.AllowGet);
        }

        public ActionResult logOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Home", new { area = "" });

        }
    }
}
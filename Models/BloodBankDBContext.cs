using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodBankManagementSystem.Models;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Npgsql;


namespace BloodBankManagementSystem.Models
{
    public class BloodBankDBContext
    {

        String cs = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;








        public List<Admin> GetAdmins()
        {
            List<Admin> AddminList = new List<Admin>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from Admin", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Admin admin = new Admin();

                admin.email = rdr.GetValue(1).ToString();
                admin.password = rdr.GetValue(2).ToString();
                AddminList.Add(admin);

            }

            con.Close();
            return AddminList;
        }




        public bool AddAdmin(Admin admin)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("insert into admin (email,password) values(@email,@password)", con);
            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@email", admin.email);
            cmd.Parameters.AddWithValue("@password", admin.password);

            con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();


            if (i > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }




        public List<Donor> GetDonors()
        {
            // String cs = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            List<Donor> DonorList = new List<Donor>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("select D.donorid, D.fullname, D.phoneno, D.panno, D.address, D.email, D.password, CT.cityid, CT.cityname, S.stateid, S.statename, CY.countryid, CY.countryname, B.bloodgroupid, B.bloodgroup, GR.genderid, GR.gender from donor D join city CT on CT.cityid = D.cityid join state S on S.stateid = D.stateid join country CY on CY.countryid = D.countryid join bloodgroup B on B.bloodgroupid = D.bloodgroupid join gender GR on GR.genderid = D.genderid; ", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Donor donor = new Donor();

                donor.fullname = rdr.GetValue(1).ToString();
              
              
                donor.phoneno = rdr.GetValue(2).ToString();
                donor.panno = rdr.GetValue(3).ToString();
                donor.address = rdr.GetValue(4).ToString();
                donor.email = rdr.GetValue(5).ToString();
                donor.password = rdr.GetValue(6).ToString();

                donor.cityid = Convert.ToInt32(rdr.GetValue(7).ToString());
                donor.cityname = rdr.GetValue(8).ToString();
                donor.stateid = Convert.ToInt32(rdr.GetValue(9).ToString());
                donor.statename = rdr.GetValue(10).ToString();
                donor.countryid = Convert.ToInt32(rdr.GetValue(11).ToString());
                donor.countryname = rdr.GetValue(12).ToString();
                donor.bloodgroupid = Convert.ToInt32(rdr.GetValue(13).ToString());
                donor.bloodgroup = rdr.GetValue(14).ToString();
                donor.genderid = Convert.ToInt32(rdr.GetValue(15).ToString());
                donor.gender = rdr.GetValue(16).ToString();




                DonorList.Add(donor);

            }

            con.Close();
            return DonorList;
        }

        public bool AddDonor(Donor donor)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("insert into donor (fullname,phoneno,panno,address,email,cityid,stateid,countryid,bloodgroupid,genderid,password) values(@fullname,@phoneno,@panno,@address,@email,@cityid,@stateid,@countryid,@bloodgroupid,@genderid,@password)", con);
            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fullname", donor.fullname);
           
            cmd.Parameters.AddWithValue("@phoneno", donor.phoneno);
            cmd.Parameters.AddWithValue("@panno", donor.panno);
            cmd.Parameters.AddWithValue("@address", donor.address);
            cmd.Parameters.AddWithValue("@email", donor.email);
            cmd.Parameters.AddWithValue("@cityid", donor.cityid);
            cmd.Parameters.AddWithValue("@stateid", donor.stateid);
            cmd.Parameters.AddWithValue("@countryid", donor.countryid);
            cmd.Parameters.AddWithValue("@bloodgroupid", donor.bloodgroupid);
            cmd.Parameters.AddWithValue("@genderid", donor.genderid);
            cmd.Parameters.AddWithValue("@password", donor.password);

            // NpgsqlCommand cmd = new NpgsqlCommand("insert into donor values(@donorid,@fullname,@lastdonationdate,@phoneno,@panno,@address,@email,@password,@cityid,@stateid,@countryid,@bloodgroupid,@genderid", con);

            con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();


            if (i > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }



        public bool UpdateDonor(Donor donor)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("update  donor set fullname =@fullname,phoneno =phoneno,address =@address,email =@email,cityid =@cityid,stateid =@stateid,countryid =@countryid,bloodgroupid =@bloodgroupid,genderid =@genderid where panno=@panno ", con);
            // cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@fullname", donor.fullname);
          
            cmd.Parameters.AddWithValue("@phoneno", donor.phoneno);
            cmd.Parameters.AddWithValue("@panno", donor.panno);
            cmd.Parameters.AddWithValue("@address", donor.address);
            cmd.Parameters.AddWithValue("@email", donor.email);
            cmd.Parameters.AddWithValue("@cityid", donor.cityid);
            cmd.Parameters.AddWithValue("@stateid", donor.stateid);
            cmd.Parameters.AddWithValue("@countryid", donor.countryid);
            cmd.Parameters.AddWithValue("@bloodgroupid", donor.bloodgroupid);
            cmd.Parameters.AddWithValue("@genderid", donor.genderid);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }


        public bool DeleteDonor(string panno)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("delete from donor where panno= @panno", con);



            cmd.Parameters.AddWithValue("@panno", panno);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }






        public List<Gender> GetGenders()
        {
            List<Gender> GenderList = new List<Gender>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from Gender", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Gender gender = new Gender();
                gender.genderid = Convert.ToInt32(rdr.GetValue(0).ToString());
                gender.gender = rdr.GetValue(1).ToString();


                GenderList.Add(gender);

            }

            con.Close();
            return GenderList;
        }




        public List<BloodGroup> GetBloodGroups()
        {
            List<BloodGroup> BloodGroupList = new List<BloodGroup>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("select * from bloodgroup;", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                BloodGroup bloodGroup = new BloodGroup();
                bloodGroup.bloodgroupid = Convert.ToInt32(rdr.GetValue(0).ToString());
                bloodGroup.bloodgroup = rdr.GetValue(1).ToString();


                BloodGroupList.Add(bloodGroup);

            }

            con.Close();
            return BloodGroupList;
        }


        public bool AddBloodGroup(BloodGroup bloodGroup)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("insert into bloodgroup values(@bloodgroupid,@bloodgroup)", con);
            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bloodgroupid", bloodGroup.bloodgroupid);
            cmd.Parameters.AddWithValue("@bloodgroup", bloodGroup.bloodgroup);



            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }







        public bool UpdateBloodGroup(BloodGroup bloodGroup)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("update  bloodgroup set bloodgroup =@bloodgroup where bloodgroupid=@bloodgroupid ", con);

            cmd.Parameters.AddWithValue("@bloodgroupid", bloodGroup.bloodgroupid);
            cmd.Parameters.AddWithValue("@bloodgroup", bloodGroup.bloodgroup);



            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }




        public List<Country> GetCountries()
        {
            List<Country> CountryList = new List<Country>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from Country", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Country country = new Country();
                country.countryid = Convert.ToInt32(rdr.GetValue(0).ToString());
                country.countryname = rdr.GetValue(1).ToString();

                CountryList.Add(country);

            }

            con.Close();
            return CountryList;
        }





        public List<State> GetState()
        {
            List<State> StateList = new List<State>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("select S.stateid, S.statename, CY.countryid, CY.countryname from state S join country CY on CY.countryid = S.countryid; ", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                State state = new State();

                state.stateid = Convert.ToInt32(rdr.GetValue(0).ToString());
                state.statename = rdr.GetValue(1).ToString();
                state.countryid = Convert.ToInt32(rdr.GetValue(2).ToString());


                StateList.Add(state);

            }

            con.Close();
            return StateList;
        }


        public List<State> getState(int countryid)
        {
            List<State> StateList = new List<State>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from State where countryid = @countryid", con);

            cmd.Parameters.AddWithValue("@countryid", countryid);
            // cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                State state = new State();


                state.stateid = Convert.ToInt32(rdr.GetValue(0).ToString());
                state.statename = rdr.GetValue(1).ToString();

                StateList.Add(state);
            }
            con.Close();
            return StateList;
        }



        //public bool AddState(State state)
        //{
        //    NpgsqlConnection con = new NpgsqlConnection(cs);


        //    NpgsqlCommand cmd = new NpgsqlCommand("insert into state (stateid,statename,countryid) values(@stateid,@statename,@countryid)", con);
        //    //  cmd.CommandType = CommandType.StoredProcedure;


        //    cmd.Parameters.AddWithValue("@stateid", state.stateid);
        //    cmd.Parameters.AddWithValue("@statename", state.statename);
        //    cmd.Parameters.AddWithValue("@countryid", state.countryid);

        //    con.Open();

        //    int i = cmd.ExecuteNonQuery();
        //    con.Close();


        //    if (i > 0)
        //    {
        //        return true;

        //    }
        //    else
        //    {
        //        return false;
        //    }


        //}




        public List<City> getCities(int stateid)
        {
            List<City> CityList = new List<City>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from city where stateid =@stateid", con);
            cmd.Parameters.AddWithValue("@stateid", stateid);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                City city = new City();

                city.cityid = Convert.ToInt32(rdr.GetValue(0).ToString());
                city.cityname = rdr.GetValue(1).ToString();



                CityList.Add(city);

            }

            con.Close();
            return CityList;
        }



        public List<City> GetCities()
        {
            List<City> CityList = new List<City>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("select CT.cityid, CT.cityname, S.stateid, S.statename from city CT join state S on S.stateid = CT.stateid; ", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                City city = new City();


                city.cityid = Convert.ToInt32(rdr.GetValue(0).ToString());
                city.cityname = rdr.GetValue(1).ToString();
                city.stateid = Convert.ToInt32(rdr.GetValue(2).ToString());
                city.statename = rdr.GetValue(3).ToString();


                CityList.Add(city);

            }

            con.Close();
            return CityList;
        }



        public List<BloodBank> GetBloodBanks()
        {
            List<BloodBank> BloodBankList = new List<BloodBank>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("select BB.bloodbankid, BB.name, BB.address, BB.phoneno, BB.website, BB.email, B.bloodgroupid, B.bloodgroup, CT.cityid, CT.cityname, S.stateid, S.statename, CY.countryid, CY.countryname from bloodbank BB join bloodgroup B on B.bloodgroupid = BB.bloodgroupid join city CT on CT.cityid = BB.cityid join state S on S.stateid = BB.stateid join country CY on CY.countryid = BB.countryid; ", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                BloodBank bloodBank = new BloodBank();
                bloodBank.bloodbankid = Convert.ToInt32(rdr.GetValue(0).ToString());
                bloodBank.name = rdr.GetValue(1).ToString();
                bloodBank.address = rdr.GetValue(2).ToString();
                bloodBank.phoneno = rdr.GetValue(3).ToString();
                bloodBank.website = rdr.GetValue(4).ToString();
                bloodBank.email = rdr.GetValue(5).ToString();
                bloodBank.bloodgroupid = Convert.ToInt32(rdr.GetValue(6).ToString());
                bloodBank.bloodgroup = rdr.GetValue(7).ToString();
                bloodBank.cityid = Convert.ToInt32(rdr.GetValue(8).ToString());
                bloodBank.cityname = rdr.GetValue(9).ToString();
                bloodBank.stateid = Convert.ToInt32(rdr.GetValue(10).ToString());
                bloodBank.statename = rdr.GetValue(11).ToString();
                bloodBank.countryid = Convert.ToInt32(rdr.GetValue(12).ToString());
                bloodBank.countryname = rdr.GetValue(13).ToString();



                BloodBankList.Add(bloodBank);

            }

            con.Close();
            return BloodBankList;
        }




        //public List<BloodStock> GetBloodStocks()
        //{
        //    List<BloodStock> BloodStockList = new List<BloodStock>();
        //    NpgsqlConnection con = new NpgsqlConnection(cs);
        //    NpgsqlCommand cmd = new NpgsqlCommand("select BS.bloodstockid, BS.bloodcomponents, BS.quantity, B.bloodgroupid, B.bloodgroup, BB.bloodbankid, BB.name from bloodstock BS join bloodgroup B on B.bloodgroupid = BS.bloodgroupid join bloodbank BB on BB.bloodbankid = BS.bloodbankid; ", con);
        //    // cmd.CommandType = CommandType.StoredProcedure;

        //    con.Open();
        //    NpgsqlDataReader rdr = cmd.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        BloodStock bloodStock = new BloodStock();

        //        bloodStock.bloodcomponents = rdr.GetValue(1).ToString();

        //        bloodStock.quantity = Convert.ToInt32(rdr.GetValue(2).ToString());
        //        bloodStock.bloodgroupid = Convert.ToInt32(rdr.GetValue(3).ToString());
        //        bloodStock.bloodgroup = rdr.GetValue(4).ToString();
        //        bloodStock.bloodbankid = Convert.ToInt32(rdr.GetValue(5).ToString());
        //        bloodStock.name = rdr.GetValue(6).ToString();
        //        BloodStockList.Add(bloodStock);

        //    }

        //    con.Close();
        //    return BloodStockList;
        //}





        //public bool Addbloodstock(BloodStock bloodStock)
        //{
        //    NpgsqlConnection con = new NpgsqlConnection(cs);


        //    NpgsqlCommand cmd = new NpgsqlCommand("insert into bloodstock (bloodcomponents,quantity,bloodgroupid,bloodbankid) values(@bloodcomponents,@quantity,@bloodgroupid,@bloodbankid)", con);
        //    //  cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@bloodcomponents", bloodStock.bloodcomponents);
        //    cmd.Parameters.AddWithValue("@quantity", bloodStock.quantity);
        //    cmd.Parameters.AddWithValue("@bloodgroupid", bloodStock.bloodgroupid);
        //    cmd.Parameters.AddWithValue("@bloodbankid", bloodStock.bloodbankid);


        //    // NpgsqlCommand cmd = new NpgsqlCommand("insert into donor values(@donorid,@fullname,@lastdonationdate,@phoneno,@panno,@address,@email,@password,@cityid,@stateid,@countryid,@bloodgroupid,@genderid", con);

        //    con.Open();

        //    int i = cmd.ExecuteNonQuery();
        //    con.Close();


        //    if (i > 0)
        //    {
        //        return true;

        //    }
        //    else
        //    {
        //        return false;
        //    }


        //}






        public List<Request> GetRequests()
        {
            List<Request> RequestList = new List<Request>();
            NpgsqlConnection con = new NpgsqlConnection(cs);

            NpgsqlCommand cmd = new NpgsqlCommand("select R.requestid, R.date_time, D.donorid, D.fullname, B.bloodgroupid, B.bloodgroup, BB.bloodbankid, BB.name, R.quantity from request R join donor D on D.donorid = R.donorid join bloodgroup B on B.bloodgroupid = R.bloodgroupid join bloodbank BB on BB.bloodbankid = R.bloodbankid where R.status=1 ", con);


            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Request request = new Request();

               request.requestid = Convert.ToInt32(rdr.GetValue(0).ToString());
                request.date_time = rdr.GetDateTime(1);
                request.donorid = Convert.ToInt32(rdr.GetValue(2).ToString());
                request.fullname = rdr.GetValue(3).ToString();
                request.bloodgroupid = Convert.ToInt32(rdr.GetValue(4).ToString());
                request.bloodgroup = rdr.GetValue(5).ToString();
                request.bloodbankid = Convert.ToInt32(rdr.GetValue(6).ToString());
                request.name = rdr.GetValue(7).ToString();
                request.quantity = rdr.GetValue(8).ToString();
              

                RequestList.Add(request);

            }

            con.Close();
            return RequestList;
        }



        public List<Request> GetApproved()
        {
            List<Request> RequestList = new List<Request>();
            NpgsqlConnection con = new NpgsqlConnection(cs);

            NpgsqlCommand cmd = new NpgsqlCommand("select R.requestid, R.date_time, D.donorid, D.fullname, B.bloodgroupid, B.bloodgroup, BB.bloodbankid, BB.name, R.quantity from request R join donor D on D.donorid = R.donorid join bloodgroup B on B.bloodgroupid = R.bloodgroupid join bloodbank BB on BB.bloodbankid = R.bloodbankid where R.status=2 ", con);


            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Request request = new Request();

                request.requestid = Convert.ToInt32(rdr.GetValue(0).ToString());
                request.date_time = rdr.GetDateTime(1);
                request.donorid = Convert.ToInt32(rdr.GetValue(2).ToString());
                request.fullname = rdr.GetValue(3).ToString();
                request.bloodgroupid = Convert.ToInt32(rdr.GetValue(4).ToString());
                request.bloodgroup = rdr.GetValue(5).ToString();
                request.bloodbankid = Convert.ToInt32(rdr.GetValue(6).ToString());
                request.name = rdr.GetValue(7).ToString();
                request.quantity = rdr.GetValue(8).ToString();


                RequestList.Add(request);

            }

            con.Close();
            return RequestList;
        }


        public List<Request> GetRejected()
        {
            List<Request> RequestList = new List<Request>();
            NpgsqlConnection con = new NpgsqlConnection(cs);

            NpgsqlCommand cmd = new NpgsqlCommand("select R.requestid, R.date_time, D.donorid, D.fullname, B.bloodgroupid, B.bloodgroup, BB.bloodbankid, BB.name, R.quantity from request R join donor D on D.donorid = R.donorid join bloodgroup B on B.bloodgroupid = R.bloodgroupid join bloodbank BB on BB.bloodbankid = R.bloodbankid where R.status=3 ", con);


            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Request request = new Request();

                request.requestid = Convert.ToInt32(rdr.GetValue(0).ToString());
                request.date_time = rdr.GetDateTime(1);
                request.donorid = Convert.ToInt32(rdr.GetValue(2).ToString());
                request.fullname = rdr.GetValue(3).ToString();
                request.bloodgroupid = Convert.ToInt32(rdr.GetValue(4).ToString());
                request.bloodgroup = rdr.GetValue(5).ToString();
                request.bloodbankid = Convert.ToInt32(rdr.GetValue(6).ToString());
                request.name = rdr.GetValue(7).ToString();
                request.quantity = rdr.GetValue(8).ToString();


                RequestList.Add(request);

            }

            con.Close();
            return RequestList;
        }


        public bool approved(int id)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("update request set status =2 where requestid=@requestid", con);
            //  cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@requestid", id);
            Request request = new Request();


            string query = "select * from public.donorreq('donoreqref'";
            query = query + ",d_check:=" + 2;

            cmd.Parameters.AddWithValue("@bloodgroupid", id);
            cmd.Parameters.AddWithValue("@bloodbankid", id);
         

            query = query + ");fetch all in " + "\"donoreqref\";";


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();


            if (i > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }





        public List<Request> Requests()
        {
            List<Request> RequestList = new List<Request>();
            NpgsqlConnection con = new NpgsqlConnection(cs);

            NpgsqlCommand cmd = new NpgsqlCommand("select * from request where status = 2 ", con);


            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Request request = new Request();

                request.requestid = Convert.ToInt32(rdr.GetValue(0).ToString());
                request.donorid = Convert.ToInt32(rdr.GetValue(1).ToString());
                request.fullname = rdr.GetValue(2).ToString();
                request.quantity = rdr.GetValue(3).ToString();
                request.bloodgroupid = Convert.ToInt32(rdr.GetValue(3).ToString());
                request.bloodgroup = rdr.GetValue(4).ToString();
                request.bloodbankid = Convert.ToInt32(rdr.GetValue(5).ToString());
                request.name = rdr.GetValue(6).ToString();

                request.quantity = rdr.GetValue(4).ToString();
                request.date_time = rdr.GetDateTime(7);
               

                RequestList.Add(request);

            }

            con.Close();
            return RequestList;
        }










        public bool rejected(int id)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("update request set status =3 where requestid=@requestid", con);
            //  cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@requestid", id);



            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();


            if (i > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }



        public bool AddRequest(Request request)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("insert into request values(@donorid,@bloodgroupid,@bloodbankid)", con);
            //  cmd.CommandType = CommandType.StoredProcedure;

          
            cmd.Parameters.AddWithValue("@donorid", request.donorid);
            cmd.Parameters.AddWithValue("@bloodgroupid", request.bloodgroupid);
            cmd.Parameters.AddWithValue("@bloodbankid", request.bloodbankid);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();


            if (i > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }




        public Donor  Loginuser(Donor donor)
        {
            Donor lg = new Donor();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            string query = "Select email,password,role from donor where email =@email and password =@password ";
            NpgsqlCommand cm = new NpgsqlCommand(query, con);
            con.Open();
            cm.Parameters.AddWithValue("@email", donor.email);
            cm.Parameters.AddWithValue("@password", donor.password);
            NpgsqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                lg.role = Convert.ToInt32(dr.GetValue(2).ToString());


            }
            return lg;
           
        }

        public Boolean Loginadmin(Admin admin)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            string query = "Select email,password from admin where email =@email and password =@password ";
            NpgsqlCommand cm = new NpgsqlCommand(query, con);
            con.Open();
            cm.Parameters.AddWithValue("@email", admin.email);
            cm.Parameters.AddWithValue("@password", admin.password);
            NpgsqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                return true;
            }

            return false;

        }




        public int getid()
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);

            NpgsqlCommand cmd = new NpgsqlCommand("select requestid from request ", con);


            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
           if(rdr.Read())
            {
                return rdr.GetInt32(0);
            }
            else
            {
                return -1;
            }

            
        }










        // New Function

        public List<Request> GetRequestForApproval(int approval)
        {
            List<Request> RequestList = new List<Request>();
            NpgsqlConnection con = new NpgsqlConnection(cs);

            NpgsqlCommand cmd = new NpgsqlCommand($"select * from request where requestid={approval};", con);


            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Request request = new Request();

               // request.requestid = Convert.ToInt32(rdr.GetValue(0).ToString());
                request.donorid = Convert.ToInt32(rdr.GetValue(1).ToString());
                request.bloodgroupid = Convert.ToInt32(rdr.GetValue(2).ToString());
                request.bloodbankid = Convert.ToInt32(rdr.GetValue(3).ToString());
                request.quantity = rdr.GetValue(4).ToString();
                /*request.bloodtypeid = rdr.GetValue(5).ToString();*/
/*                request.date_time = rdr.GetDateTime(1);
                request.fullname = rdr.GetValue(3).ToString();*/


                RequestList.Add(request);

            }

            con.Close();
            return RequestList;
        }


        public List<BloodStock> GetRequestedBloodStock(int approval)
        {
            List<BloodStock> RequestList = new List<BloodStock>();
            NpgsqlConnection con = new NpgsqlConnection(cs);

            NpgsqlCommand cmd = new NpgsqlCommand($"select * from bloodstock where bloodgroupid={approval};", con);


            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                BloodStock bloodstock = new BloodStock();

                bloodstock.bloodstockid = Convert.ToInt32(rdr.GetValue(0).ToString());
                bloodstock.quantity = Convert.ToInt32(rdr.GetValue(1).ToString());/*
                request.bloodgroupid = Convert.ToInt32(rdr.GetValue(2).ToString());
                request.bloodbankid = Convert.ToInt32(rdr.GetValue(3).ToString());
                request.quantity = rdr.GetValue(4).ToString();*/
                /*request.bloodtypeid = rdr.GetValue(5).ToString();*/
                /*                request.date_time = rdr.GetDateTime(1);
                                request.fullname = rdr.GetValue(3).ToString();*/


                RequestList.Add(bloodstock);

            }

            con.Close();
            return RequestList;
        }


        public void UpdateStock(int id,int quan)
        {
            List<BloodStock> RequestList = new List<BloodStock>();
            NpgsqlConnection con = new NpgsqlConnection(cs);

            //  NpgsqlCommand cmd = new NpgsqlCommand($"update  bloodstock set quantity = {quan} where bloodgroupid={id};", con);
            NpgsqlCommand cmd = new NpgsqlCommand("select updatestock(:quanity,:bgid)", con);
            cmd.Parameters.AddWithValue("quanity", quan);
            cmd.Parameters.AddWithValue("bgid", id);
           // NpgsqlCommand cmd = new NpgsqlCommand($"select updatestock({quan},{id})");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }


    }
}
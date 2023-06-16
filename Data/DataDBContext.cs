using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BloodBankManagementSystem.Models;
using System.Configuration;
using BloodBankManagementSystem.Areas.Admin.Model;

namespace BloodBankManagementSystem.Data
{
    public class DataDBContext
    {

        string cs = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;


        public List<BloodGroup> GetBloodgroups()
        {
            List<BloodGroup> bloodgrouplist = new List<BloodGroup>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from bloodgroup", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                BloodGroup blood = new BloodGroup();
                blood.bloodgroupid = Convert.ToInt32(rdr.GetValue(0).ToString());
                blood.bloodgroup = rdr.GetValue(1).ToString();



                bloodgrouplist.Add(blood);
            }


            con.Close();

            return bloodgrouplist;
        }




        public bool AddBloodGroup(BloodGroup blood)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("insert into bloodgroup values(@bloodgroupid,@bloodgroup)", con);
            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bloodgroupid", blood.bloodgroupid);
            cmd.Parameters.AddWithValue("@bloodgroup", blood.bloodgroup);



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


        public bool UpdateBloodGroup(BloodGroup blood)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("update  bloodgroup set bloodgroup =@bloodgroup where bloodgroupid=@bloodgroupid ", con);

            cmd.Parameters.AddWithValue("@bloodgroupid", blood.bloodgroupid);
            cmd.Parameters.AddWithValue("@bloodgroup", blood.bloodgroup);



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


        public bool DeleteBloodGroup(int bloodgroupid)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("delete from bloodgroup where bloodgroupid= @bloodgroupid", con);

            cmd.Parameters.AddWithValue("@bloodgroupid", bloodgroupid);



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


        public List<BloodStock> GetStocks()
        {
            List<BloodStock> BloodStockList = new List<BloodStock>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("select BS.bloodstockid, BS.quantity, BS.date_time, B.bloodgroupid, B.bloodgroup, BB.bloodbankid, BB.name,  BT.bloodtypeid, BT.bloodtype from bloodstock BS join bloodgroup B on B.bloodgroupid = BS.bloodgroupid join bloodbank BB on BB.bloodbankid = BS.bloodbankid join bloodtypes BT on BT.bloodtypeid = BS.bloodtypeid; ", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                BloodStock stock = new BloodStock();



                stock.bloodstockid = Convert.ToInt32(rdr.GetValue(0).ToString());
                stock.quantity = Convert.ToInt32(rdr.GetValue(1).ToString());
                stock.date_time = rdr.GetDateTime(2);
                stock.bloodgroupid = Convert.ToInt32(rdr.GetValue(3).ToString());
                stock.bloodgroup = rdr.GetValue(4).ToString();

                stock.bloodbankid = Convert.ToInt32(rdr.GetValue(5).ToString());
                stock.name = rdr.GetValue(6).ToString();
                stock.bloodtypeid = Convert.ToInt32(rdr.GetValue(7).ToString());
                stock.bloodtype = rdr.GetValue(8).ToString();
              

                BloodStockList.Add(stock);

            }

            con.Close();
            return BloodStockList;
        }








        public List<Stockblood> GetStockbloods()
        {
            List<Stockblood> stocklist = new List<Stockblood>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("select BS.bloodstockid, BS.quantity, BS.date_time, B.bloodgroupid, B.bloodgroup, BB.bloodbankid, BB.name,  BT.bloodtypeid, BT.bloodtype from bloodstock BS join bloodgroup B on B.bloodgroupid = BS.bloodgroupid join bloodbank BB on BB.bloodbankid = BS.bloodbankid join bloodtypes BT on BT.bloodtypeid = BS.bloodtypeid; ", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Stockblood stockblood = new Stockblood();



                stockblood.bloodstockid = Convert.ToInt32(rdr.GetValue(0).ToString());
                stockblood.quantity = Convert.ToInt32(rdr.GetValue(1).ToString());
                stockblood.date_time = rdr.GetDateTime(2);
                stockblood.bloodgroupid = Convert.ToInt32(rdr.GetValue(3).ToString());

                stockblood.bloodbankid = Convert.ToInt32(rdr.GetValue(5).ToString());

                stockblood.bloodtypeid = Convert.ToInt32(rdr.GetValue(7).ToString());



                stocklist.Add(stockblood);

            }

            con.Close();
            return stocklist;
        }













        public bool AddBloodStock(Stockblood stockblood)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("insert into bloodstock (quantity,bloodgroupid,bloodbankid,bloodtypeid) values(@quantity,@bloodgroupid,@bloodbankid,@bloodtypeid )", con);
            //  cmd.CommandType = CommandType.StoredProcedure;


            

            cmd.Parameters.AddWithValue("@quantity", stockblood.quantity);
            cmd.Parameters.AddWithValue("@bloodgroupid", stockblood.bloodgroupid);
            cmd.Parameters.AddWithValue("@bloodbankid", stockblood.bloodbankid);
            cmd.Parameters.AddWithValue("@bloodtypeid", stockblood.bloodtypeid);


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




        public bool UpdateBloodStock(Stockblood stockblood)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("update  bloodstock set  quantity = @quantity,bloodgroupid = @bloodgroupid, bloodbankid = @bloodbankid, bloodtypeid =@bloodtypeid   where bloodstockid = @bloodstockid", con);
            //  cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@bloodstockid", stockblood.bloodstockid);
            cmd.Parameters.AddWithValue("@quantity", stockblood.quantity);
            cmd.Parameters.AddWithValue("@bloodgroupid", stockblood.bloodgroupid);
            cmd.Parameters.AddWithValue("@bloodbankid", stockblood.bloodbankid);
            cmd.Parameters.AddWithValue("@bloodtypeid", stockblood.bloodtypeid);


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


        public bool DeleteBloodStock(int bloodstockid)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("delete from bloodstock where bloodstockid= @bloodstockid", con);
            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@bloodstockid", bloodstockid);



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





        public List<BloodBank> GetBanks()
        {
            List<BloodBank> BloodBankList = new List<BloodBank>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("select BB.bloodbankid, BB.name, BB.address, BB.phoneno, BB.website, BB.email, B.bloodgroupid, B.bloodgroup, CT.cityid, CT.cityname, S.stateid, S.statename, CY.countryid, CY.countryname from bloodbank BB join bloodgroup B on B.bloodgroupid = BB.bloodgroupid join city CT on CT.cityid = BB.cityid join state S on S.stateid = BB.stateid join country CY on CY.countryid = BB.countryid; ", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                BloodBank bank = new BloodBank();
                bank.bloodbankid = Convert.ToInt32(rdr.GetValue(0).ToString());
                bank.name = rdr.GetValue(1).ToString();
                bank.address = rdr.GetValue(2).ToString();
                bank.phoneno = rdr.GetValue(3).ToString();
                bank.website = rdr.GetValue(4).ToString();
                bank.email = rdr.GetValue(5).ToString();
                bank.bloodgroupid = Convert.ToInt32(rdr.GetValue(6).ToString());
              
                bank.cityid = Convert.ToInt32(rdr.GetValue(8).ToString());
              
                bank.stateid = Convert.ToInt32(rdr.GetValue(10).ToString());
             
                bank.countryid = Convert.ToInt32(rdr.GetValue(12).ToString());
              



                BloodBankList.Add(bank);

            }

            con.Close();
            return BloodBankList;
        }




        public bool AddBloodBank(BloodBank bank)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("insert into bloodbank (bloodbankid,name,address,phoneno,website,email,bloodgroupid,cityid,stateid,countryid)" +
                " values(@bloodbankid,@name,@address,@phoneno,@website,@email,@bloodgroupid,@cityid,@stateid,@countryid)", con);
            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@bloodbankid", bank.bloodbankid);
            cmd.Parameters.AddWithValue("@name", bank.name);
            cmd.Parameters.AddWithValue("@address", bank.address);
            cmd.Parameters.AddWithValue("@phoneno", bank.phoneno);
            cmd.Parameters.AddWithValue("@website", bank.website);
            cmd.Parameters.AddWithValue("@email", bank.email);
            cmd.Parameters.AddWithValue("@bloodgroupid", bank.bloodgroupid);
            cmd.Parameters.AddWithValue("@cityid", bank.cityid);
            cmd.Parameters.AddWithValue("@stateid", bank.stateid);
            cmd.Parameters.AddWithValue("@countryid", bank.countryid);


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



        public bool UpdateBloodBank(BloodBank bank)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("update  bloodbank set name = @name, address = @address,phoneno = @phoneno, website = @website, email =@email, bloodgroupid =@bloodgroupid, cityid =@cityid, stateid =@stateid, countryid =@countryid   where bloodbankid = @bloodbankid", con);

            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@bloodbankid", bank.bloodbankid);
            cmd.Parameters.AddWithValue("@name", bank.name);
            cmd.Parameters.AddWithValue("@address", bank.address);
            cmd.Parameters.AddWithValue("@phoneno", bank.phoneno);
            cmd.Parameters.AddWithValue("@website", bank.website);
            cmd.Parameters.AddWithValue("@email", bank.email);
            cmd.Parameters.AddWithValue("@bloodgroupid", bank.bloodgroupid);
            cmd.Parameters.AddWithValue("@cityid", bank.cityid);
            cmd.Parameters.AddWithValue("@stateid", bank.stateid);
            cmd.Parameters.AddWithValue("@countryid", bank.countryid);


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



        public bool DeleteBloodBank(int bloodbankid)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("delete from bloodbank where bloodbankid= @bloodbankid", con);
            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@bloodbankid", bloodbankid);



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



        public bool AddCountry(Country country)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);

            NpgsqlCommand cmd = new NpgsqlCommand("insert into country (countryid,countryname) values(@countryid,@countryname)", con);


            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@countryid", country.countryid);
            cmd.Parameters.AddWithValue("@countryname", country.countryname);
           


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



        public bool UpdateCountry(Country country)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);

            NpgsqlCommand cmd = new NpgsqlCommand("update  country set countryname = @countryname   where countryid = @countryid", con);


            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@countryid", country.countryid);
            cmd.Parameters.AddWithValue("@countryname", country.countryname);



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




        public bool DeleteCountry(int countryid)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("delete from country where countryid= @countryid", con);
            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@countryid", countryid);



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


        public List<State> GetStates()
        {
            List<State> StateList = new List<State>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("select S.stateid, S.statename, CY.countryid, CY.countryname from state S join country CY on CY.countryid = S.countryid ", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                State state = new State();

                state.stateid = Convert.ToInt32(rdr.GetValue(0).ToString());
                state.statename = rdr.GetValue(1).ToString();
                state.countryid = Convert.ToInt32(rdr.GetValue(2).ToString());
                state.countryname = rdr.GetValue(3).ToString();



                StateList.Add(state);

            }

            con.Close();
            return StateList;
        }





        public bool AddState(State state)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);

            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.state(stateid, statename, countryid)VALUES(@stateid,@statename,@countryid)", con);


            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stateid", state.stateid);
            cmd.Parameters.AddWithValue("@statename", state.statename);
            cmd.Parameters.AddWithValue("@countryid", state.countryid);



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



        public bool UpdateState(State state)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);

            NpgsqlCommand cmd = new NpgsqlCommand("update  state set statename = @statename  where stateid = @stateid", con);


            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stateid", state.stateid);
            cmd.Parameters.AddWithValue("@statename", state.statename);
           // cmd.Parameters.AddWithValue("@countryid", state.countryid);



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

        public bool DeleteState(int stateid)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("delete from state where stateid= @stateid", con);
            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stateid", stateid);



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



        public bool AddCity(City city)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);

           
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.city(cityid, cityname, stateid)VALUES(@cityid,@cityname,@stateid)", con);


            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cityid", city.cityid);
            cmd.Parameters.AddWithValue("@cityname", city.cityname);
            cmd.Parameters.AddWithValue("@stateid", city.stateid);



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


        public bool UpdateCity(City city)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);



            NpgsqlCommand cmd = new NpgsqlCommand("update  city set cityname = @cityname  where cityid = @cityid", con);


            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cityid", city.cityid);
            cmd.Parameters.AddWithValue("@cityname", city.cityname);
            //cmd.Parameters.AddWithValue("@stateid", city.stateid);



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





        public bool DeleteCity(int cityid)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("delete from city where cityid= @cityid", con);
            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cityid", cityid);



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



        public List<Bloodtypes> GetBloodtypes()
        {
            List<Bloodtypes> Bloodtypeslist = new List<Bloodtypes>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from bloodtypes", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Bloodtypes bloodtypes = new Bloodtypes();
                bloodtypes.bloodtypeid = Convert.ToInt32(rdr.GetValue(0).ToString());
                bloodtypes.bloodtype = rdr.GetValue(1).ToString();



                Bloodtypeslist.Add(bloodtypes);
            }


            con.Close();

            return Bloodtypeslist;
        }



        public bool AddBloodtypes(Bloodtypes bloodtypes)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("insert into bloodtypes values(@bloodtypeid,@bloodtype)", con);
            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bloodtypeid", bloodtypes.bloodtypeid);
            cmd.Parameters.AddWithValue("@bloodtype", bloodtypes.bloodtype);



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


        public bool UpdateBloodtypes(Bloodtypes bloodtypes)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("update  bloodtypes set bloodtype =@bloodtype where bloodtypeid=@bloodtypeid ", con);

            // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bloodtypeid", bloodtypes.bloodtypeid);
            cmd.Parameters.AddWithValue("@bloodtype", bloodtypes.bloodtype);



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


        public bool DeleteBloodtypes(int bloodtypeid)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("delete from bloodtypes where bloodtypeid= @bloodtypeid", con);

            cmd.Parameters.AddWithValue("@bloodtypeid", bloodtypeid);



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



    }
}
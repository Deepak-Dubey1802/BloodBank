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
    public class RegistrationDBContext
    {
        String cs = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;



        public List<Registration> GetRegistrations()
        {
            // String cs = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            List<Registration> RegistrationList = new List<Registration>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from Donor", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Registration registration = new Registration();
                registration.donorid = Convert.ToInt32(rdr.GetValue(0).ToString());
                registration.fullname = rdr.GetValue(1).ToString();
              
                // donor.lastdonationdate = Convert.ToDateTime(rdr.GetValue(1).ToString());
                registration.phoneno = rdr.GetValue(2).ToString();
                registration.panno = rdr.GetValue(3).ToString();
                registration.address = rdr.GetValue(4).ToString();
                registration.email = rdr.GetValue(5).ToString();
                registration.cityid = Convert.ToInt32(rdr.GetValue(6).ToString());
                registration.stateid = Convert.ToInt32(rdr.GetValue(7).ToString());
                registration.countryid = Convert.ToInt32(rdr.GetValue(8).ToString());
                registration.bloodgroupid = Convert.ToInt32(rdr.GetValue(9).ToString());
                registration.genderid = Convert.ToInt32(rdr.GetValue(10).ToString());
                registration.password = rdr.GetValue(11).ToString();





                RegistrationList.Add(registration);

            }


            con.Close();
            return RegistrationList;

        }









        public bool AddRegistration(Registration registration)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("insert into donor (fullname,phoneno,panno,address,email,cityid,stateid,countryid,bloodgroupid,genderid,password) values(@fullname,@phoneno,@panno,@address,@email,@cityid,@stateid,@countryid,@bloodgroupid,@genderid,@password)", con);
            //  cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fullname", registration.fullname);
         
            cmd.Parameters.AddWithValue("@phoneno", registration.phoneno);
            cmd.Parameters.AddWithValue("@panno", registration.panno);
            cmd.Parameters.AddWithValue("@address", registration.address);
            cmd.Parameters.AddWithValue("@email", registration.email);
            cmd.Parameters.AddWithValue("@cityid", registration.cityid);
            cmd.Parameters.AddWithValue("@stateid", registration.stateid);
            cmd.Parameters.AddWithValue("@countryid", registration.countryid);
            cmd.Parameters.AddWithValue("@bloodgroupid", registration.bloodgroupid);
            cmd.Parameters.AddWithValue("@genderid", registration.genderid);
            cmd.Parameters.AddWithValue("@password", registration.password);

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





      




        public List<RequestForm> GetRequestForms()
        {
            List<RequestForm> RequestFormList = new List<RequestForm>();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from Request", con);
            // cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                RequestForm requestForm = new RequestForm();

                requestForm.requestdate = Convert.ToDateTime(rdr.GetValue(1));
                requestForm.donorid = Convert.ToInt32(rdr.GetValue(2).ToString());
                requestForm.bloodgroupid = Convert.ToInt32(rdr.GetValue(3).ToString());
                requestForm.bloodbankid = Convert.ToInt32(rdr.GetValue(4).ToString());
                requestForm.quantity = Convert.ToInt32(rdr.GetValue(5).ToString());

                RequestFormList.Add(requestForm);

            }

            con.Close();
            return RequestFormList;
        }





        public bool AddDonorRequest(RequestForm requestForm)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);


            NpgsqlCommand cmd = new NpgsqlCommand("insert into request (donorid,bloodgroupid,bloodbankid,quantity) values(@donorid,@bloodgroupid,@bloodbankid,@quantity)", con);
            //  cmd.CommandType = CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@donorid", requestForm.donorid);
            cmd.Parameters.AddWithValue("@bloodgroupid", requestForm.bloodgroupid);
            cmd.Parameters.AddWithValue("@bloodbankid", requestForm.bloodbankid);
            cmd.Parameters.AddWithValue("@quantity", requestForm.quantity);


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
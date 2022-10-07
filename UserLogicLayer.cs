using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LaptopServiceManagement.BusinessLogicLayer
{
    public class UserLogicLayer
    {
        // get all users 
        public IEnumerable<User> Users
        {
            get
            {
                string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                List<User> user_list = new List<User>();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllUsers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                       User user = new User();
                        user.id = Convert.ToInt32(read.GetValue(0).ToString());
                        user.Name = read.GetValue(1).ToString();
                        user.ContactNumber = read.GetValue(2).ToString();
                        user.address = read.GetValue(3).ToString();
                        user.appointmentBookingDate = read.GetValue(4).ToString();
                        user.LaptopModel = read.GetValue(5).ToString();
                        user.ServiceCenterId = Convert.ToInt32(read.GetValue(6).ToString());
                        user_list.Add(user);
                    }
                    con.Close();

                }
                return Users;
            }


        }

        //insert user
        public void AddUser( User user)
        {
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInsertUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", user.id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@ContactNumber", user.ContactNumber);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@appointmentBookingDate", user.appointmentBookingDate);
                cmd.Parameters.AddWithValue("@LaptopModel ", user.LaptopModel);
                cmd.Parameters.AddWithValue("@ServiceCenterId", user.ServiceCenterId);
                cmd.ExecuteNonQuery();


            }
        }
        //update 
        public void UpdateUser(User user)
        {
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spspUpdateStore", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", user.id);
                cmd.Parameters.AddWithValue("@ContactNumber", user.ContactNumber);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spDeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

  }


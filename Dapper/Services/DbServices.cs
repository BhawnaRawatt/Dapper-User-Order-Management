using Dapper.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Dapper.Services
{
    public class DbServices
    {
        private readonly string _connectionString;

        public DbServices(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        public void AddUsers(User user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public List<User> GetUsers()
        {
            List<User> list = new List<User>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new User
                        {
                        Id = Convert.ToInt32(reader["id"]),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString()

                    });
                }
            }
            return list;
        }

        public void AddOrder(Order order)
        {
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Add", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Product", order.Product);
                cmd.Parameters.AddWithValue("@Qty", order.Qty);
                cmd.Parameters.AddWithValue("@UserId", order.UserId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Order> GetOrders()
        {
            List<Order> list = new List<Order>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetUsers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Product = reader["Product"].ToString(),
                        Qty = Convert.ToInt32(reader["Qty"]),
                        UserId = Convert.ToInt32(reader["UserId"])

                    });
                }
            }
            return list;

        }
        }

    }


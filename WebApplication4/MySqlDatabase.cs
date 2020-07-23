using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using WebApplication4.Models;

namespace WebApplication4
{
    public class MySqlDatabase : IDisposable
    {
        private MySqlConnection Connection;

        public IConfigurationRoot GetConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();
            return builder;

        }
        public MySqlDatabase()
        {
            String connString = GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            //String connString = this.Configuration.GetConnectionString("DefaultConnection");
            //Connection = new MySqlConnection("Server=40.76.25.191;Port=3306;Database=db_work;Uid=root;Pwd=Creosafe2020;");
            Connection = new MySqlConnection(connString);
            Connection.Open();
        }

        public UserLogin userControl(String eMail, String password)
        {
            String jsonData = null;
            JObject jsonObj;
            string sql = "spc_UserSelect";
            using (MySqlCommand sqlCmd = new MySqlCommand(sql, Connection))
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@uuserEmail", eMail);
                sqlCmd.Parameters.AddWithValue("@uuserPassword", password);
                MySqlDataReader reader = sqlCmd.ExecuteReader();
                reader.Read();
                jsonData = reader["userJSON"].ToString();
                if (jsonData != "" && jsonData != null)
                {
                    jsonObj = JObject.Parse(jsonData);
                    if (jsonObj["firstname"] != null && jsonObj["lastname"] != null)
                    {
                        return new UserLogin()
                        {
                            Id = (int)jsonObj["userid"],
                            UserName = (string)jsonObj["username"],
                            DisplayName = (string)jsonObj["displayname"],
                            Email = (string)jsonObj["useremail"],
                            AccountInfoEx = true
                        };
                    }
                    else
                    {
                        return new UserLogin()
                        {
                            Id = (int)jsonObj["userid"],
                            UserName = (string)jsonObj["username"],
                            Email = (string)jsonObj["useremail"],
                            AccountInfoEx = false
                        };
                    }
                }
                else 
                {
                    return null;
                }
                
            }
            return null;
        }

        public Boolean accountIndividualJsonCreate(String userId,String transactionType,String jsonData)
        {
            string sql = "spc_ProfileTransactionCreate";
            using (MySqlCommand sqlCmd = new MySqlCommand(sql, Connection))
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@uuserId", userId);
                sqlCmd.Parameters.AddWithValue("@uuserProfileTransactionOperation", transactionType);
                sqlCmd.Parameters.AddWithValue("@uuserProfileTransactionJSON", jsonData);
                MySqlDataReader reader = sqlCmd.ExecuteReader();
                reader.Read();
                if (reader["RETURNVALUE"].ToString() == "1")
                    return true;
                else
                    return false;

            }
            return false;
        }


        public Boolean accountInstitutionalJsonCreate(String userId, String transactionType, String jsonData)
        {
            string sql = "spc_ProfileTransactionCreate";
            using (MySqlCommand sqlCmd = new MySqlCommand(sql, Connection))
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@uuserId", userId);
                sqlCmd.Parameters.AddWithValue("@uuserProfileTransactionOperation", transactionType);
                sqlCmd.Parameters.AddWithValue("@uuserProfileTransactionJSON", jsonData);
                MySqlDataReader reader = sqlCmd.ExecuteReader();
                reader.Read();
                if (reader["RETURNVALUE"].ToString() == "1")
                    return true;
                else
                    return false;

            }
            return false;
        }



        public Boolean NewPassword(String eMail, String password)
        {
            string sql = "spc_UserCreate";
            using (MySqlCommand sqlCmd = new MySqlCommand(sql, Connection))
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@uuserPassword", password);
                sqlCmd.Parameters.AddWithValue("@uuserEmail", eMail);
                MySqlDataReader reader = sqlCmd.ExecuteReader();
                reader.Read();
                if (reader["RETURNVALUE"].ToString() == "1")
                    return true;
                else
                    return false;

            }
            return false;
        }

        public Tuple<List<string>, List<string>, List<string>> dropDownListReturn()
        {
            string sql = "spc_LocationGet";
            using (MySqlCommand sqlCmd = new MySqlCommand(sql, Connection))
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader reader = sqlCmd.ExecuteReader();
                List<string> countryList = new List<string> {};
                List<string> stateList = new List<string> { };
                List<string> cityList = new List<string> { };
                while (reader.Read())
                {
                    countryList.Add(reader["countryName"].ToString());
                    stateList.Add(reader["stateName"].ToString());
                    cityList.Add(reader["cityName"].ToString());
                }

                countryList = countryList.Distinct().ToList();
                stateList = stateList.Distinct().ToList();
                cityList = cityList.Distinct().ToList();

                return Tuple.Create(countryList, stateList, cityList);

            }
            return null;
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}

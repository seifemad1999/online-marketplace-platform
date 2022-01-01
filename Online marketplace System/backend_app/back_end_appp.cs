using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using System.Runtime.InteropServices;
using System.IO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Online_marketplace_System.backend_app
{
    
    public partial class back_end_appp
    {
        static MySqlConnection sqlconn = new MySqlConnection();
        static MySqlCommand sqlCmd = new MySqlCommand();
        static DataTable sqlDt = new DataTable();
        static MySqlDataAdapter sqlDtA = new MySqlDataAdapter();
        static MySqlDataReader sqlRd;
        static DataSet DS = new DataSet();
        static String sqlQuery;

        static String server = "localhost";
        static String database = "marketplace_user";
        static String database2 = "marketplace_product";
        static String username = "root";
        static String password = "admin";
        public static void Post_new_user(string email, string first_name, string last_name, string phone, string password_user, string profile_pic, int wallet) 
        {

            sqlconn.Close();
            sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database;
            try
            {
                string replaced = profile_pic.Replace(@"\", @"\\");

                sqlconn.Open();

                sqlQuery = "INSERT INTO marketplace_user.user (email,first_name,last_name,phone,password,profile_pic,wallet)" +
                         "VALUES('" + email + "','" + first_name + "','" + last_name + "','" + phone + "','" + password_user + "','" + profile_pic + "','" + wallet + "')";

                sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        public static void Post_new_product(string product_name, string price, string description, string picture, string owner_email)
        {
            sqlconn.Close();
            sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database2;
            try
            {               
                sqlconn.Open();

                sqlQuery = "INSERT INTO marketplace_product.product (product_name , price , description , picture , owner_email)" +
                 "VALUES('" + product_name + "','" + price + "','" + description + "','" + picture + "','" + owner_email + "')";
               
                sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        public static void Update(string in_of_query, string in_of_query_att, string in_of_query2, string in_of_query_att2, string table)
        {
            sqlconn.Close();
            if (table == "user") {
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database;
                try
                {
                    sqlconn.Open();
                    sqlQuery = "UPDATE " + "marketplace_user.user" + " SET " + in_of_query_att + " = '" + in_of_query + "' where " + in_of_query_att2 + "='" + in_of_query2 + "'";
                    //string tt = "UPDATE " + table + " SET " + in_of_query_att + " = '" + in_of_query + "' where " + in_of_query_att2 + "='" + in_of_query2 + "'";
                    sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
                    sqlRd = sqlCmd.ExecuteReader();
                    sqlDt.Load(sqlRd);
                    sqlRd.Close();
                    sqlconn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlconn.Close();
                }
            }
            else if(table=="product")
            {
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database2;
                try
                {
                    sqlconn.Open();
                    sqlQuery = "UPDATE " + "marketplace_product.product" + " SET " + in_of_query_att + " = '" + in_of_query + "' where " + in_of_query_att2 + "='" + in_of_query2 + "'";
                    //string tt = "UPDATE " + table + " SET " + in_of_query_att + " = '" + in_of_query + "' where " + in_of_query_att2 + "='" + in_of_query2 + "'";
                    sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
                    sqlRd = sqlCmd.ExecuteReader();
                    sqlDt.Load(sqlRd);
                    sqlRd.Close();
                    sqlconn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlconn.Close();
                }
            }
           
        }

        public static List<string> Get(string out_of_query ,string in_of_query , string in_of_query_att ,string table)
        {
            sqlconn.Close();
            List<string> str = new List<string>();
            if (table == "user") {
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database;
                try
                {
                    sqlconn.Open();

                    if (in_of_query == "IS NOT NULL" || in_of_query == "IS NULL")
                        sqlQuery = "SELECT * FROM " + "marketplace_user.user" + " WHERE " + in_of_query_att + " " + in_of_query;
                    else
                        sqlQuery = "SELECT * FROM " + "marketplace_user.user" + " WHERE " + in_of_query_att + "= " + "'" + in_of_query + "'";

                    using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
                    {
                        using (sqlRd = sqlCmd.ExecuteReader())
                        {
                            if (sqlRd != null)
                            {
                                while (sqlRd.Read())
                                {
                                    str.Add(Convert.ToString(sqlRd.GetString(out_of_query)));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (table == "product")
            {
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database2;
                try
                {
                    sqlconn.Open();

                    if (in_of_query == "IS NOT NULL" || in_of_query == "IS NULL")
                        sqlQuery = "SELECT * FROM " + "marketplace_product.product" + " WHERE " + in_of_query_att + " " + in_of_query;
                    else
                        sqlQuery = "SELECT * FROM " + "marketplace_product.product" + " WHERE " + in_of_query_att + "= " + "'" + in_of_query + "'";

                    using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
                    {
                        using (sqlRd = sqlCmd.ExecuteReader())
                        {
                            if (sqlRd != null)
                            {
                                while (sqlRd.Read())
                                {
                                    str.Add(Convert.ToString(sqlRd.GetString(out_of_query)));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlconn.Close();
            return str;
        }
        public static List<string> GetAll(string out_of_query , string table)
        {
            List<string> str = new List<string>();
            if (table == "user") {
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database;
                try
                {
                    sqlconn.Open();
                    sqlQuery = "SELECT * FROM " + "marketplace_user.user";
                    // sqlQuery = "SELECT * FROM user WHERE password=''" + textBox3.Text;
                    using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
                    {
                        using (sqlRd = sqlCmd.ExecuteReader())
                        {
                            if (sqlRd != null)
                            {
                                while (sqlRd.Read())
                                {
                                    str.Add(sqlRd.GetString(out_of_query));

                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (table == "product")
            {
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database2;
                try
                {
                    sqlconn.Open();
                    sqlQuery = "SELECT * FROM " + "marketplace_product.product";
                    // sqlQuery = "SELECT * FROM user WHERE password=''" + textBox3.Text;
                    using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
                    {
                        using (sqlRd = sqlCmd.ExecuteReader())
                        {
                            if (sqlRd != null)
                            {
                                while (sqlRd.Read())
                                {
                                    str.Add(sqlRd.GetString(out_of_query));

                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlconn.Close();
            return str;
        }

        public static List<string> GetWithAND(string out_of_query, string in_of_query, string in_of_query_att, string in_of_query2 , string in_of_query_att2, string table)
        {
            List<string> str = new List<string>();
            sqlconn.Close();
            if (table == "user")
            {
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" +
            "password=" + password + ";" + "database=" + database;

                sqlconn.Open();
                sqlQuery = "SELECT * FROM " + "marketplace_user.user" + " WHERE " + in_of_query_att + "= " + "'" + in_of_query + "' AND " + in_of_query_att2 + " " + in_of_query2;
                using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
                {
                    using (sqlRd = sqlCmd.ExecuteReader())
                    {
                        if (sqlRd != null)
                        {
                            while (sqlRd.Read())
                            {
                                str.Add(sqlRd.GetString(out_of_query));
                            }
                        }
                    }
                }
            }
            else if (table == "product")
            {
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" +
            "password=" + password + ";" + "database=" + database2;

                sqlconn.Open();
                sqlQuery = "SELECT * FROM " + "marketplace_product.product" + " WHERE " + in_of_query_att + "= " + "'" + in_of_query + "' AND " + in_of_query_att2 + " " + in_of_query2;
                using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
                {
                    using (sqlRd = sqlCmd.ExecuteReader())
                    {
                        if (sqlRd != null)
                        {
                            while (sqlRd.Read())
                            {
                                str.Add(sqlRd.GetString(out_of_query));
                            }
                        }
                    }
                }
            }

            return str;
        }
        public static void DeleteWithAND(string in_of_query_att, string in_of_query, string in_of_query_att2, string in_of_query2, string table)
        {
            sqlconn.Close();
            if (table == "user")
            {
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" +
           "password=" + password + ";" + "database=" + database;

                sqlconn.Open();
                sqlQuery = "DELETE FROM" + "marketplace_user.user" + "WHERE" + in_of_query_att + "= " + "'" + in_of_query + "' AND " + in_of_query_att2 + "NULL" + in_of_query2;
                sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlconn.Close();
            }
            else if (table == "product")
            {
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" +
           "password=" + password + ";" + "database=" + database2;

                sqlconn.Open();
                sqlQuery = "DELETE FROM marketplace_product.product WHERE owner_email = " + "'" + in_of_query + "' AND buyer_name IS NULL";
                sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlconn.Close();
            }
        }
    }
}

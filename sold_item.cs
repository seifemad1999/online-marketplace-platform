using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Online_marketplace_System
{
    public partial class sold_item : Form
    {

        MySqlConnection sqlconn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqlDt = new DataTable();
        MySqlDataAdapter sqlDtA = new MySqlDataAdapter();
        MySqlDataReader sqlRd;
        DataSet DS = new DataSet();

        String sqlQuery;

        String server = "localhost";
        String database = "marketplace_user";
        String database2 = "marketplace_product";
        String username = "root";
        String password = "admin";

        public sold_item()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            email_of_owner.Text = Form11.user_email;
            sqlconn.Close();
            sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database2;

            sqlconn.Open();
            sqlQuery = "SELECT * FROM marketplace_product.product WHERE buyer_name IS NOT NULL";
            using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
            {
                using (sqlRd = sqlCmd.ExecuteReader())
                {
                    while (sqlRd.Read())
                    {
                        if (sqlRd.GetString("owner_email") == email_of_owner.Text)
                        {
                            string name_product = sqlRd.GetString("product_name");
                            string price_product = sqlRd.GetString("price");
                            string date_product = sqlRd.GetString("purchase_date");
                            None.Items.Add("name: " + name_product + "   price: " + price_product + "   date: " + date_product);
                        }

                    }
                }
            }
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlconn.Close();
        }

        private void click_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

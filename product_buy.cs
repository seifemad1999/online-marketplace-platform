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

    public partial class product_buy : Form
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

        string y,j;
        string x_user_email = Form11.user_email;


        string x_owner_email;
        

        public product_buy()
        {
            InitializeComponent();
            

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text=search_item.seif_adel;

            y = textBox1.Text;
            sqlconn.Close();
            sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database2;

            sqlconn.Open();
            sqlQuery = "SELECT * FROM marketplace_product.product WHERE product_id= '" + y + "' "; /*global variable*/

            using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
            {
                using (sqlRd = sqlCmd.ExecuteReader())
                {
                    while (sqlRd.Read())
                    {
                        name.Text = sqlRd.GetString("product_name");
                        price.Text = sqlRd.GetString("price");
                        x_owner_email = sqlRd.GetString("owner_email");
                        owner_email.Text = x_owner_email;
                        description.Text = sqlRd.GetString("description");
                        string pic_path = sqlRd.GetString("picture");
                        picture.Image = new Bitmap(pic_path);
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


        private void buy_Click(object sender, EventArgs e)
        {

            textBox2.Text = Form11.user_email;
            int x;
            sqlconn.Close();
            sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database;


            sqlconn.Open();
            sqlQuery = "SELECT * FROM marketplace_user.user WHERE email= '" + textBox2.Text + "' ";
            using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
            {
                using (sqlRd = sqlCmd.ExecuteReader())
                {
                    while (sqlRd.Read())
                    {
                        string client_money = sqlRd.GetString("wallet");
                        int j=Convert.ToInt32(client_money) - Convert.ToInt32(price.Text);
                        string mystring1= j.ToString();
                        client_wallet.Text = mystring1;
                    }
                }
            }

            x = Convert.ToInt32(client_wallet.Text);
            if ( x >= 0)
            {
                sqlQuery = "UPDATE marketplace_user.user SET wallet = '" + client_wallet.Text + "' where email='" + textBox2.Text + "'";

                sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
                sqlRd = sqlCmd.ExecuteReader();

                MessageBox.Show("Successful Payment");
               // profile.Show();

                sqlDt.Load(sqlRd);
                sqlRd.Close();
            }
            else
            {
                MessageBox.Show("Money is not enough", "");
            }
            sqlconn.Close();

            //sqlconn.Close();
            sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" +
       "password=" + password + ";" + "database=" + database;

            
            sqlconn.Open();
            sqlQuery = "SELECT * FROM marketplace_user.user WHERE email= '" + x_owner_email + "' ";
            using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
            {
                using (sqlRd = sqlCmd.ExecuteReader())
                {
                    while (sqlRd.Read())
                    {
                        string buyer_money = sqlRd.GetString("wallet");
                        int i = Convert.ToInt32(buyer_money) + Convert.ToInt32(price.Text);
                        string mystring = i.ToString();
                        owner_wallet.Text = mystring;
                    }
                }
            }
            if (x >= 0)
            {
                sqlconn.Close();
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" +
      "password=" + password + ";" + "database=" + database;


                sqlconn.Open();
                sqlQuery = "UPDATE marketplace_user.user SET wallet = '" + owner_wallet.Text + "' where email='" + x_owner_email + "'";

                sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
                sqlRd = sqlCmd.ExecuteReader();

                sqlDt.Load(sqlRd);
                sqlRd.Close();
            }
            else
            {

            }
            sqlconn.Close();
            if (x >= 0)
            {
                sqlconn.Close();
                sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" +
      "password=" + password + ";" + "database=" + database2;


                sqlconn.Open();
                string date_time = DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt");
                sqlQuery = "UPDATE marketplace_product.product SET buyer_name='" + textBox2.Text + "', purchase_date='" + date_time + "'WHERE(product_id='" + y + "' )";
                sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
                sqlRd = sqlCmd.ExecuteReader();

                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlconn.Close();
            }
            /*
            string c = "C:\\Users\\Oem\\Downloads\\209-2095632_sold-sold-out-icon-png.png";
            string replaced = c.Replace(@"\", @"\\");

            sqlconn.Open();
            sqlQuery = "UPDATE product SET picture = '" + replaced + "' where product_id='" + y + "'";

            sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
            sqlRd = sqlCmd.ExecuteReader();


            sqlDt.Load(sqlRd);
            sqlRd.Close();
            */
        }

        private void picture_Click(object sender, EventArgs e)
        {

        }

        private void email_of_client_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void product_of_owner_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

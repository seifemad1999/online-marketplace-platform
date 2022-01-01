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
using Online_marketplace_System.backend_app;

namespace Online_marketplace_System
{
    public partial class purchased_item : Form
    {

        MySqlConnection sqlconn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqlDt = new DataTable();
        MySqlDataAdapter sqlDtA = new MySqlDataAdapter();
        MySqlDataReader sqlRd;
        DataSet DS = new DataSet();

        String sqlQuery;

        String server = "localhost";
        //String database = "marketplace_user";
        String database2 = "market place";
        String username = "root";
        String password = "451994@henD";

        public purchased_item()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            email_of_client.Text = Form11.user_email;

            List<string> prod_name = back_end_appp.Get("product_name",email_of_client.Text,"buyer_name", "product");
            List<string> prod_price = back_end_appp.Get("price", email_of_client.Text, "buyer_name", "product");
            List<string> prod_purchasedate = back_end_appp.Get("purchase_date", email_of_client.Text, "buyer_name", "product");
            int count = prod_name.Count;
            while (count>0)
            {
                string name_product = prod_name[count-1];
                string price_product = prod_price[count-1];
                string date_product = prod_purchasedate[count-1]; 
                None.Items.Add("name: " + name_product + "   price: " + price_product + "   date: " + date_product);
                count--;
            }           
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

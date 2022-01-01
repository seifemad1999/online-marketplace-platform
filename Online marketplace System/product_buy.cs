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
    public partial class product_buy : Form
    {
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
            List<string> prod_name = back_end_appp.Get("product_name", y, "product_id", "product");
            List<string> prod_price = back_end_appp.Get("price", y, "product_id", "product");
            List<string> prod_owner_email = back_end_appp.Get("owner_email", y, "product_id", "product");
            List<string> prod_description = back_end_appp.Get("description", y, "product_id", "product");
            List<string> prod_picture = back_end_appp.Get("picture", y, "product_id", "product");
            name.Text = prod_name[0];
            price.Text = prod_price[0];
            x_owner_email = prod_owner_email[0];
            owner_email.Text = x_owner_email;
            description.Text = prod_description[0];
            string pic_path = prod_picture[0];
            picture.Image = new Bitmap(pic_path);
        }
        private void click_Click(object sender, EventArgs e)
        {

        }
        private void buy_Click(object sender, EventArgs e)
        {
            textBox2.Text = Form11.user_email;

            List<string> user_wallet = back_end_appp.Get("wallet", textBox2.Text, "email", "user");           
            int j=Convert.ToInt32(user_wallet[0]) - Convert.ToInt32(price.Text);
            client_wallet.Text = j.ToString();
            int x = Convert.ToInt32(client_wallet.Text);

            if (x >= 0)
            {
                back_end_appp.Update(client_wallet.Text, "wallet", textBox2.Text, "email", "user");
                MessageBox.Show("Successful Payment");
            }
            else
            {
                MessageBox.Show("Money is not enough", "");
            }

            List<string> user_wallet2 = back_end_appp.Get("wallet", x_owner_email, "email", "user");
            int i = Convert.ToInt32(user_wallet2[0]) + Convert.ToInt32(price.Text);
            owner_wallet.Text = i.ToString();

            if (x >= 0)
            {
                back_end_appp.Update(owner_wallet.Text, "wallet", x_owner_email, "email", "user");
            }
            if (x >= 0)
            {
                string date_time = DateTime.Now.ToString("MM\\/dd\\/yyyy h\\:mm tt");
                back_end_appp.Update(textBox2.Text, "buyer_name", y, "product_id", "product");
                back_end_appp.Update(date_time, "purchase_date", y, "product_id", "product");
            }
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

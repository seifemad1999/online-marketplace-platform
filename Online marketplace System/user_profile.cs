using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using MySql.Data.MySqlClient;
using Online_marketplace_System.backend_app;

namespace Online_marketplace_System
{
    public partial class user_profile : Form
    {
        public string seif = "ss";
        public static string seif_emad;
        public static ComboBox mycomp;
        public user_profile()
        {
            InitializeComponent();
            mycomp = comboBox1;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox11.Text = Form11.user_email;
            List<string> firstname_of_project, lasttname_of_project,wallet_list,pict_list = new List<string>();
            List<string> res = back_end_appp.GetAll("product_name", "product");
            
            for(int i = 0; i < res.Count; i++) 
            {
                if (comboBox1.Items.Contains(res[i]))
                {
                }
                else
                {
                    comboBox1.Items.Add(res[i]);
                }
            }

            // Read picture 
            pict_list = back_end_appp.Get("profile_pic", textBox11.Text, "email", "user");
            if (pict_list.Count > 0)
            {
                pictureBox1.Image = new Bitmap(pict_list[0]);
            }
            

            // REad first name and put it in first name string
            firstname_of_project = back_end_appp.Get("first_name", textBox11.Text, "email", "user");

            // Read last name
            lasttname_of_project = back_end_appp.Get("last_name", textBox11.Text, "email", "user");            
            last_name.Text = firstname_of_project[0] + " " + lasttname_of_project[0];

            // Read wallet
            wallet_list = back_end_appp.Get("wallet", textBox11.Text, "email", "user");
            wallet.Text = wallet_list[0] + "  $";

            // Read email
            email.Text = textBox11.Text;

            // Read product name

            List<string> product_name_list = back_end_appp.GetWithAND("product_name", textBox11.Text, "owner_email", "IS NULL", "buyer_name", "product");
            List<string> price_list = back_end_appp.GetWithAND("price", textBox11.Text, "owner_email", "IS NULL", "buyer_name", "product");
            List<string> picture_list = back_end_appp.GetWithAND("picture", textBox11.Text, "owner_email", "IS NULL", "buyer_name", "product");
            for(int i = 0; i < 4 && i< product_name_list.Count; i++) 
            {
                if (i == 0)
                {
                    productname1.Show();
                    panel5.Show();
                    pictureBoxproduct1.Show();
                    price1.Show();
                    productname1.Text = product_name_list[i];
                    price1.Text = price_list[i] + "  $";
                    pictureBoxproduct1.Image = new Bitmap(picture_list[i]);
                }
                else if (i == 1)
                {
                    productname2.Show();
                    panel6.Show();
                    pictureBoxproduct2.Show();
                    price2.Show();
                    productname2.Text = product_name_list[i];
                    price2.Text = price_list[i] + "  $";
                    pictureBoxproduct2.Image = new Bitmap(picture_list[i]);
                }
                else if (i == 2)
                {
                    productname4.Show();
                    panel8.Show();
                    pictureBoxproduct4.Show();
                    price4.Show();
                    productname4.Text = product_name_list[i];
                    price4.Text = price_list[i] + "  $";
                    pictureBoxproduct4.Image = new Bitmap(picture_list[i]);
                }
                else if (i == 3)
                {
                    productname3.Show();
                    panel7.Show();
                    pictureBoxproduct3.Show();
                    price3.Show();
                    productname3.Text = product_name_list[i];
                    price3.Text = price_list[i] + "  $";
                    pictureBoxproduct3.Image = new Bitmap(picture_list[i]);
                }
            }           
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            add_product Form2 = new add_product();
            Form2.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            seif_emad = comboBox1.Text;
            search_item search = new search_item();
            search.Show();
            user_profile profile_user = new user_profile();
            profile_user.Hide();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            purchased_item purchase_items = new purchased_item();
            purchase_items.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            sold_item sold_items = new sold_item();
            sold_items.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form11 login_sign_form = new Form11();
            login_sign_form.Show();
            user_profile profile_user = new user_profile();
            profile_user.Hide();
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void refresh_Click(object sender, EventArgs e)
        {
            List<string> wallet_list = new List<string>();
            wallet_list = back_end_appp.Get("wallet", textBox11.Text, "email", "user");
            wallet.Text = wallet_list[0] + "  $";

            List<string> product_name_list = back_end_appp.GetWithAND("product_name", textBox11.Text, "owner_email", "IS NULL", "buyer_name", "product");
            List<string> price_list = back_end_appp.GetWithAND("price", textBox11.Text, "owner_email", "IS NULL", "buyer_name", "product");
            List<string> picture_list = back_end_appp.GetWithAND("picture", textBox11.Text, "owner_email", "IS NULL", "buyer_name", "product");
            for(int i = 0; i < 4 && i < product_name_list.Count; i++) 
            {
                if (i == 0)
                {
                    productname1.Show();
                    panel5.Show();
                    pictureBoxproduct1.Show();
                    price1.Show();
                    productname1.Text = product_name_list[i];
                    price1.Text = price_list[i] + "  $";
                    pictureBoxproduct1.Image = new Bitmap(picture_list[i]);
                }
                else if (i == 1)
                {
                    productname2.Show();
                    panel6.Show();
                    pictureBoxproduct2.Show();
                    price2.Show();
                    productname2.Text = product_name_list[i];
                    price2.Text = price_list[i] + "  $";
                    pictureBoxproduct2.Image = new Bitmap(picture_list[i]);
                }
                else if (i == 2)
                {
                    productname4.Show();
                    panel8.Show();
                    pictureBoxproduct4.Show();
                    price4.Show();
                    productname4.Text = product_name_list[i];
                    price4.Text = price_list[i] + "  $";
                    pictureBoxproduct4.Image = new Bitmap(picture_list[i]);
                }
                else if (i == 3)
                {
                    productname3.Show();
                    panel7.Show();
                    pictureBoxproduct3.Show();
                    price3.Show();
                    productname3.Text = product_name_list[i];
                    price3.Text = price_list[i] + "  $";
                    pictureBoxproduct3.Image = new Bitmap(picture_list[i]);
                }
            }
        }
        private void email_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Read phone
            List<string> phone = new List<string>();
            phone = back_end_appp.Get("phone", textBox11.Text, "email", "user");
            phone_txt.Text = phone[0];          
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button8_Click(object sender, EventArgs e)
        {

        }
        private void wallet_Click(object sender, EventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void last_name_Click(object sender, EventArgs e)
        {

        }
        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        private void productname4_Click(object sender, EventArgs e)
        {

        }
        private void pictureBoxproduct4_Click(object sender, EventArgs e)
        {

        }
        private void price4_Click(object sender, EventArgs e)
        {

        }
        private void label18_Click(object sender, EventArgs e)
        {

        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBoxproduct3_Click(object sender, EventArgs e)
        {

        }
        private void productname3_Click(object sender, EventArgs e)
        {

        }
        private void price3_Click(object sender, EventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private void productname2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBoxproduct2_Click(object sender, EventArgs e)
        {

        }
        private void price2_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void price1_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
        private void phone_txt_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            back_end_appp.DeleteWithAND("owner_email",textBox11.Text,"buyer_name","NULL", "product");

            List<string> res = back_end_appp.GetAll("produc_name", "product");
            for (int i = 0; i < res.Count; i++)
            {
                if (comboBox1.Items.Contains(res[i]))
                {
                }
                else
                {
                    comboBox1.Items.Add(res[i]);
                }
            }
            List<string> first_name_of_project, lastt_name_of_project,wallet_list,pict_list = new List<string>();

            // Read profile pic
            //pict_list = back_end_appp.Get("profile_pic", textBox11.Text, "email", "user");
            //if (pict_list.Count > 0) {
            //    pictureBox1.Image = new Bitmap(pict_list[0]);
            //}
            
            
            // REad first name and put it in first name string
            first_name_of_project = back_end_appp.Get("first_name", textBox11.Text, "email", "user");

            // Read last name
            lastt_name_of_project = back_end_appp.Get("last_name", textBox11.Text, "email", "user");
            last_name.Text = first_name_of_project[0] + " " + lastt_name_of_project[0];

            // Read wallet
            wallet_list = back_end_appp.Get("wallet", textBox11.Text, "email", "user");
            wallet.Text = wallet_list[0] + "  $";

            // Read email
            email.Text = textBox11.Text;

            // Read product name
            List<string> product_name_list = back_end_appp.GetWithAND("product_name", textBox11.Text, "owner_email", "IS NULL", "buyer_name", "product");
            List<string> price_list = back_end_appp.GetWithAND("price", textBox11.Text, "owner_email", "IS NULL", "buyer_name", "product");
            List<string> picture_list = back_end_appp.GetWithAND("picture", textBox11.Text, "owner_email", "IS NULL", "buyer_name", "product");
            for (int i = 0; i < 4 && i < product_name_list.Count; i++)
            {
                if (i == 0)
                {
                    productname1.Show();
                    panel5.Show();
                    pictureBoxproduct1.Show();
                    price1.Show();

                    productname1.Text = product_name_list[i];
                    price1.Text = price_list[i] + "  $";
                    pictureBoxproduct1.Image = new Bitmap(picture_list[i]);
                }
                else if (i == 1)
                {
                    productname2.Show();
                    panel6.Show();
                    pictureBoxproduct2.Show();
                    price2.Show();

                    productname2.Text = product_name_list[i];
                    price2.Text = price_list[i] + "  $";
                    pictureBoxproduct2.Image = new Bitmap(picture_list[i]) ;
                }
                else if (i == 2)
                {

                    productname4.Show();
                    panel8.Show();
                    pictureBoxproduct4.Show();
                    price4.Show();

                    productname4.Text = product_name_list[i];
                    price4.Text = price_list[i] + "  $";
                    pictureBoxproduct4.Image = new Bitmap(picture_list[i]);
                }
                else if (i == 3)
                {

                    productname3.Show();
                    panel7.Show();
                    pictureBoxproduct3.Show();
                    price3.Show();

                    productname3.Text = product_name_list[i];
                    price3.Text = price_list[i] + "  $";
                    pictureBoxproduct3.Image = new Bitmap(picture_list[i]);
                }
            }
            productname1.Hide();
            panel5.Hide();
            pictureBoxproduct1.Hide();
            price1.Hide();
        }
    }
}

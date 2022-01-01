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
    public partial class search_item : Form
    {
        
        public static int id_1 = 0;
        public static int id_2 = 0;
        public static int id_3 = 0;
        public static int id_4 = 0;
        public static int id_buy = 0;
        public static string seif_adel;
        string f;


        public static search_item instance;
        public search_item()
        {
            InitializeComponent();
            instance = this;
            
        }
        private void search_item_Load(object sender, EventArgs e)
        {
            textBox1.Text = user_profile.seif_emad;
            f = textBox1.Text;

            List<string> product_identifier = back_end_appp.GetWithAND("product_id",f,"product_name","IS NULL","buyer_name","product");
            List<string> product_price = back_end_appp.GetWithAND("price", f, "product_name", "IS NULL", "buyer_name", "product");
            List<string> product_pict = back_end_appp.GetWithAND("picture", f, "product_name", "IS NULL", "buyer_name", "product");
            List<string> product_desc = back_end_appp.GetWithAND("description", f, "product_name", "IS NULL", "buyer_name", "product");
            List<string> product_ownemail = back_end_appp.GetWithAND("owner_email", f, "product_name", "IS NULL", "buyer_name", "product");

            for (int i = 0; i < 4 && i < product_identifier.Count; i++)
            {
                if (product_ownemail[i] == Form11.user_email)
                {
                    continue;
                }
                if (i == 0)
                {
                    label3.Show();
                    label4.Show();
                    pictureBox1.Show();
                    panel1.Show();
                    button1.Show();
                    label4.Text = product_price[i] + "  $";
                    label3.Text = product_desc[i];
                    id_1 = Convert.ToInt16(product_identifier[i]);
                    pictureBox1.Image = new Bitmap(product_pict[i]);
                }
                else if (i == 1)
                {
                    label5.Show();
                    label6.Show();
                    pictureBox2.Show();
                    panel3.Show();
                    button2.Show();
                    label6.Text = product_price[i] + "  $";
                    label5.Text = product_desc[i];
                    id_2 = Convert.ToInt16(product_identifier[i]);
                    pictureBox2.Image = new Bitmap(product_pict[i]);
                }
                else if (i == 2)
                {

                    label7.Show();
                    label8.Show();
                    pictureBox3.Show();
                    panel4.Show();
                    button3.Show();
                    label8.Text = product_price[i]+ "  $";
                    label7.Text = product_desc[i];
                    id_3 = Convert.ToInt16(product_identifier[i]);
                    pictureBox3.Image = new Bitmap(product_pict[i]);
                }
                else if (i == 3)
                {

                    label9.Show();
                    label10.Show();
                    pictureBox4.Show();
                    panel2.Show();
                    button4.Show();
                    label10.Text = product_price[i] + "  $";
                    label9.Text = product_desc[i];
                    id_4 = Convert.ToInt16(product_identifier[i]);
                    pictureBox4.Image = new Bitmap(product_pict[i]);
                }
            }       
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            id_buy = id_1;
            seif_adel = id_buy.ToString();
            product_buy details = new product_buy();
            details.Show();
            search_item search = new search_item();
            search.Hide();

            //product_buy.instance.tb1.Text = id_buy.ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            id_buy = id_2;
            seif_adel = id_buy.ToString();

            product_buy details = new product_buy();
            details.Show();
            search_item search = new search_item();
            search.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            id_buy = id_4;
            seif_adel = id_buy.ToString();

            product_buy details = new product_buy();
            details.Show();
            search_item search = new search_item();
            search.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            id_buy = id_3;
            seif_adel = id_buy.ToString();

            product_buy details = new product_buy();
            details.Show();
            search_item search = new search_item();
            search.Hide();
        }
    }
}

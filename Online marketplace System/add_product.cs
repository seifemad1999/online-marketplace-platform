using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using Online_marketplace_System.backend_app;

namespace Online_marketplace_System
{
    public partial class add_product : Form
    {
        string new_product_photo_string = "";

       

     
        public add_product()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog new_product_photo = new OpenFileDialog();
            new_product_photo.Filter = "Image Files(*.png;*.PNG; *.jpg; *.jpeg; *.gif; *.bmp;)|*.png; *.jpg; *.jpeg; *.gif; *.bmp;";
            if (new_product_photo.ShowDialog() == DialogResult.OK)
            {
                new_product_photo_string = new_product_photo.FileName;
               
                pictureBoxnewproductphoto.Image = new Bitmap(new_product_photo.FileName);
            }

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string new_product_name = newproductname.Text;
            string new_product_price = newproductprice.Text;
            string new_product_description = newproductdescription.Text;           
            string replaced = new_product_photo_string.Replace(@"\", @"\\");

            List<string> product_name = new List<string>();
            product_name = back_end_appp.Get("product_id", new_product_name, "product_name", "product");
            if (product_name.Count==0)
            {
                user_profile.mycomp.Items.Add(new_product_name);
            }
            else
            {

            }

            back_end_appp.Post_new_product(new_product_name, new_product_price, new_product_description, replaced, textBox1.Text);
            MessageBox.Show("Product Added");          
        }
        private void add_product_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form11.user_email;
        }
    }
}

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

namespace Online_marketplace_System
{
    public partial class add_product : Form
    {
        string new_product_photo_string = "";

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
            string new_product_name = "";
            string new_product_price = "";
            string new_product_description = "";


            new_product_name = newproductname.Text;
            new_product_price = newproductprice.Text;
            new_product_description = newproductdescription.Text;
            
            string replaced = new_product_photo_string.Replace(@"\", @"\\");


            sqlconn.Close();
            sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" +
            "password=" + password + ";" + "database=" + database2;

            sqlconn.Open();
            sqlQuery = "SELECT * FROM marketplace_product.product WHERE product_name = " + "'" + new_product_name+ "'";

            using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
            {
                using (sqlRd = sqlCmd.ExecuteReader())
                {
                    if(!(sqlRd.Read()))
                    {
                        user_profile.mycomp.Items.Add(new_product_name);
                    }
                    else
                    {

                    }
                }
            }
            sqlQuery = "INSERT INTO marketplace_product.product (product_name , price , description , picture , owner_email)" +
                "VALUES('" + new_product_name + "','" + new_product_price + "','" + new_product_description + "','" + replaced + "','" + textBox1.Text + "')";

            sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlconn.Close();

            MessageBox.Show("Product Added");

            


        }

            private void add_product_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form11.user_email;
        }
    }
}

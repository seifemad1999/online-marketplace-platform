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


namespace Online_marketplace_System
{
    public partial class Form11 : Form
    {
       // public static Form11 innnn;
        

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

        public static string user_email = "";
        string user_id1 ,user_id2;

        

        public Form11()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            label6.Hide();
            textBox5.Hide();
            label4.Hide();
            textBox6.Hide();
            label5.Show();
            textBox4.Show();
            label3.Hide();
            label7.Show();
            textBox3.Hide();
            label1.Hide();
            textBox1.Hide();
            label2.Hide();
            textBox2.Hide();
            button1.Hide();
            button2.Hide();
            button3.Show();
            button4.Show();
            label9.Hide();
            textBox7.Hide();
            textBox8.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //==================database===============
            sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database;


            try
            {
                string replaced = textBox2.Text.Replace(@"\", @"\\");

                sqlconn.Open();

                sqlQuery = "INSERT INTO marketplace_user.user (email,first_name,last_name,phone,password,profile_pic,wallet)" +
                         "VALUES('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox1.Text+ "','" + replaced + "','" + textBox7.Text + "')";

                sqlCmd = new MySqlCommand(sqlQuery, sqlconn);
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlconn.Close();
                MessageBox.Show("Account Created Sucessfuly");

                label6.Hide();
                textBox5.Hide();
                label4.Hide();
                textBox6.Hide();
                label5.Show();
                textBox4.Show();
                label3.Hide();
                label7.Show();
                textBox3.Hide();
                label1.Hide();
                textBox1.Hide();
                label2.Hide();
                textBox2.Hide();
                button1.Hide();
                button2.Hide();
                button3.Show();
                button4.Show();
                label9.Hide();
                textBox7.Hide();
                textBox8.Show();
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

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Show();
            textBox5.Show();
            label4.Show();
            textBox6.Show();
            label5.Show();
            textBox4.Show();
            label3.Show();
            textBox3.Show();
            label1.Show();
            textBox1.Show();
            label2.Show();
            textBox2.Show();
            button2.Show();
            button1.Show();
            button3.Hide();
            label7.Hide(); 
            button4.Hide();
            label9.Show();
            textBox7.Show();
            textBox8.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" + "password=" + password + ";" + "database=" + database;
            try
            {
                sqlconn.Open();
                sqlQuery = "SELECT * FROM marketplace_user.user WHERE email=" + "'" + textBox4.Text + "'";
               // sqlQuery = "SELECT * FROM user WHERE password=''" + textBox3.Text;
                using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn)) {
                    using (sqlRd = sqlCmd.ExecuteReader()) {
                        if (sqlRd != null)
                        {
                            while (sqlRd.Read())
                            {
                                user_id1 = Convert.ToString(sqlRd.GetInt16("User_id"));
                                //user_id1 = Convert.ToString(sqlRd.GetInt16("User_id"));
                            }
                        }
                    }
                }
                sqlQuery = "SELECT * FROM marketplace_user.user WHERE User_id=" + "'" + user_id1 + "'";
                using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
                {
                    using (sqlRd = sqlCmd.ExecuteReader())
                    {
                        if (sqlRd != null)
                        {
                            while (sqlRd.Read())
                            {
                                
                                user_id2 = sqlRd.GetString("password");
                            }
                        }
                    }
                }
              
                if (user_id2 == textBox8.Text)
                {
                    
                    //MessageBox.Show("Login existed");
                    user_email = textBox4.Text;
                    user_profile profile = new user_profile();
                    profile.Show();
                    this.Hide();
                    Form11 login_signup = new Form11();
                    login_signup.Hide();

                }
                else {
                    MessageBox.Show("Wrong password or email try again or signup");
                    textBox4.Clear();
                    textBox8.Clear();
                }



                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlconn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }
            //   textBox4.Clear();
            // textBox3.Clear();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog new_product_photo = new OpenFileDialog();
            new_product_photo.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp;)|*.png; *.jpg; *.jpeg; *.gif; *.bmp;";
            if (new_product_photo.ShowDialog() == DialogResult.OK)
            {
                //user_photo_string
                  textBox2.Text  = new_product_photo.FileName;
                //pictureBoxnewproductphoto.Image = new Bitmap(new_product_photo.FileName);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

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
    public partial class search_item : Form
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
            sqlconn.Close();
            sqlconn.ConnectionString = "server=" + server + ";" + "username=" + username + ";" +
            "password=" + password + ";" + "database=" + database2;
            sqlconn.Open();

            int counter = 0;
            // Read profile pic
            sqlQuery = "SELECT * FROM marketplace_product.product WHERE product_name = " + "'" + f + "'AND buyer_name IS NULL";

            using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
            {
                using (sqlRd = sqlCmd.ExecuteReader())
                {
                    if (sqlRd != null)
                    {
                        while (sqlRd.Read())
                        {
                            if(sqlRd.GetString("owner_email")==Form11.user_email)
                            {
                                continue;
                            }
                            


                            if (counter == 0)
                            {
                                label3.Show();
                                label4.Show();
                                pictureBox1.Show();
                                panel1.Show();
                                button1.Show();

                                pictureBox1.Image = new Bitmap(sqlRd.GetString("picture"));
                                counter++;
                            }
                            else if (counter == 1)
                            {

                                label5.Show();
                                label6.Show();
                                pictureBox2.Show();
                                panel3.Show();
                                button2.Show();
                                pictureBox2.Image = new Bitmap(sqlRd.GetString("picture"));
                                counter++;
                            }
                            else if (counter == 2)
                            {

                                label7.Show();
                                label8.Show();
                                pictureBox3.Show();
                                panel4.Show();
                                button3.Show();
                                pictureBox3.Image = new Bitmap(sqlRd.GetString("picture"));
                                counter++;
                            }
                            else if (counter == 3)
                            {

                                label9.Show();
                                label10.Show();
                                pictureBox4.Show();
                                panel2.Show();
                                button4.Show();
                                pictureBox4.Image = new Bitmap(sqlRd.GetString("picture"));
                                counter++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            ////////////////////////////////////////////////////////////////////
            counter = 0;
            // Read product price

            sqlQuery = "SELECT * FROM marketplace_product.product WHERE product_name = " + "'" + f + "'AND buyer_name IS NULL";

            using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
            {
                using (sqlRd = sqlCmd.ExecuteReader())
                {
                    if (sqlRd != null)
                    {
                        while (sqlRd.Read())
                        {


                            if (sqlRd.GetString("owner_email") == Form11.user_email)
                            {
                                continue;
                            }


                            if (counter == 0)
                            {
                                label4.Text = sqlRd.GetString("price") + "  $";

                                counter++;
                            }
                            else if (counter == 1)
                            {
                                label6.Text = sqlRd.GetString("price") + "  $";

                                counter++;

                            }
                            else if (counter == 2)
                            {
                                label8.Text = sqlRd.GetString("price") + "  $";

                                counter++;

                            }
                            else if (counter == 3)
                            {
                                label10.Text = sqlRd.GetString("price") + "  $";

                                counter++;

                            }
                            else
                            {
                                break;
                            }
                        }

                    }
                }
            }
            /////////////////////////////////////////////////////////
            counter = 0;
            // Read product description

            sqlQuery = "SELECT * FROM marketplace_product.product WHERE product_name = " + "'" + f + "'AND buyer_name IS NULL";

            using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
            {
                using (sqlRd = sqlCmd.ExecuteReader())
                {
                    if (sqlRd != null)
                    {
                        while (sqlRd.Read())
                        {


                            if (sqlRd.GetString("owner_email") == Form11.user_email)
                            {
                                continue;
                            }


                            if (counter == 0)
                            {
                                label3.Text = sqlRd.GetString("description");
                                counter++;
                            }
                            else if (counter == 1)
                            {
                                label5.Text = sqlRd.GetString("description");
                                counter++;
                            }
                            else if (counter == 2)
                            {
                                label7.Text = sqlRd.GetString("description");
                                counter++;
                            }
                            else if (counter == 3)
                            {
                                label9.Text = sqlRd.GetString("description");
                                counter++;
                            }
                            else
                            {
                                break;
                            }
                        }

                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////
            counter = 0;
            // Read product price

            sqlQuery = "SELECT * FROM marketplace_product.product WHERE product_name = " + "'" + f + "'AND buyer_name IS NULL";

            using (sqlCmd = new MySqlCommand(sqlQuery, sqlconn))
            {
                using (sqlRd = sqlCmd.ExecuteReader())
                {
                    if (sqlRd != null)
                    {
                        while (sqlRd.Read())
                        {

                            if (sqlRd.GetString("owner_email") == Form11.user_email)
                            {
                                continue;
                            }
                            if (counter == 0)
                            {
                                id_1 = sqlRd.GetInt16("product_id");
                                counter++;
                            }
                            else if (counter == 1)
                            {
                                id_2 = sqlRd.GetInt16("product_id");

                                counter++;

                            }
                            else if (counter == 2)
                            {
                                id_3 = sqlRd.GetInt16("product_id");

                                counter++;

                            }
                            else if (counter == 3)
                            {
                                id_4 = sqlRd.GetInt16("product_id");

                                counter++;

                            }
                            else
                            {
                                break;
                            }
                        }

                    }
                }
            }
            counter = 0;

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

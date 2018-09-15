using System;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace EShop
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }


        private void back(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome a = new AdminHome();
            a.Show();
        }

        DataTable dt;

        private void load(object sender, EventArgs e)
        {
            string query = "select * from Product";
            string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(query, myConnection);
            SqlDataReader dr = myCommand.ExecuteReader();

            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            myConnection.Close();
        }

        private void insert(object sender, EventArgs e)
        {
            string query = "select * from Product where ProductId='" + textBox2.Text + "' or ProductName='" + textBox1.Text + "'";

            string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(query, myConnection);
            //myCommand.ExecuteNonQuery();
            SqlDataReader sdr = myCommand.ExecuteReader();

            if (sdr.HasRows)
            {
                MessageBox.Show("ID already exists!");
            }

            else
            {
                query = "insert into Product values (" + textBox2.Text + ",'" + textBox1.Text + "'," + textBox3.Text + "," + textBox4.Text + ")";

                myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
                myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();
                myCommand = new SqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Insert Done!");
            }
            myConnection.Close();
        }

        private void update(object sender, EventArgs e)
        {
            string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            if (textBox1.Text != "")
            {
                string query = "update Product set ProductName='" + textBox1.Text + "'where ProductId=" + textBox2.Text;
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();
            }
            if (textBox3.Text != "")
            {
                string query = "update Product set Price='" + textBox3.Text + "'where ProductId=" + textBox2.Text;
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();
            }
            if (textBox4.Text != "")
            {
                string query = "update Product set Quantity='" + textBox4.Text + "'where ProductId=" + textBox2.Text;
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();
            }
            MessageBox.Show("Update Done!");
        }

        private void delete(object sender, EventArgs e)
        {
            string query = "delete from Product where ProductId=" + textBox5.Text;
            string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.ExecuteNonQuery();
            MessageBox.Show("Delete Done!");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from Product where ProductName like '%" + textBox6.Text + "%'";
            string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(query, myConnection);
            SqlDataReader dr = myCommand.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

            myConnection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                string query = "select * from Product where ProductName='" + textBox1.Text + "'";
                string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlDataReader dr = myCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    textBox2.Text = dr["ProductId"].ToString();
                    textBox3.Text = dr["Price"].ToString();
                    textBox4.Text = dr["Quantity"].ToString();
                }
                myConnection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }
    }

}



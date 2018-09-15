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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void load(object sender, EventArgs e)
        {
            string query = "select * from UserInfo";
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

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome a = new AdminHome();
            a.Show();
        }

        private void insert(object sender, EventArgs e)
        {
            string query = "select * from UserInfo where UserId='"+idTB.Text+"'";

            string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(query, myConnection);
            //myCommand.ExecuteNonQuery();
            SqlDataReader sdr = myCommand.ExecuteReader();

            if(sdr.HasRows)
            {
                MessageBox.Show("ID already exists!");
            }

            else
            {
                 query = "insert into UserInfo values ('" + idTB.Text + "','" + nameTB.Text + "','" + passTB.Text + "','" + addTB.Text + "','" + pTB.Text + "')";

                myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
                 myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();
                myCommand = new SqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Insert Done!");
               
            }
            myConnection.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (ID.Text == "admin")
            {
                MessageBox.Show("Not possible");

            }

            else
            {
                string query = "delete from UserInfo where UserId='" + ID.Text + "'";
                string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Delete Done!");
            }

            
        }

        private void Update_Click(object sender, EventArgs e)
        {
            string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            if (nameTB.Text != "")
            {
                string query = "update UserInfo set UserName='" + nameTB.Text + "' where UserId= '" + idTB.Text + "'";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();
            }
            if (passTB.Text != "")
            {
                string query = "update UserInfo set Password='" + passTB.Text + "'where UserId= '" + idTB.Text + "'";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();
            }
            if (addTB.Text != "")
            {
                string query = "update UserInfo set Address='" + addTB.Text + "'where UserId= '" + idTB.Text + "'";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();
            }
            if (pTB.Text != "")
            {
                string query = "update UserInfo set Phone='" + pTB.Text + "'where UserId= '" + idTB.Text + "'";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();
            }
            MessageBox.Show("Update Done!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from UserInfo where UserName like '%" + textBox1.Text + "%'";
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

        private void idTB_TextChanged(object sender, EventArgs e)
        {
            if (idTB.Text == "") {
                addTB.Text = "";
                nameTB.Text= "";
                passTB.Text= "";
                pTB.Text = "";
            }
            else
            {
                string query = "select * from UserInfo where UserId='"+idTB.Text+"'";
                string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlDataReader dr = myCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    addTB.Text=dr["Address"].ToString();
                    nameTB.Text=dr["UserName"].ToString();
                    passTB.Text=dr["Password"].ToString();
                    pTB.Text=dr["Phone"].ToString();
                }
                myConnection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login n = new Login();
            n.Show();
        }
    }
}

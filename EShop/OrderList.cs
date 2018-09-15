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
    public partial class OrderList : Form
    {
        public OrderList()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, EventArgs e)
        {
            string query = "select * from Order1";
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

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();

            AdminHome ad = new AdminHome();
            ad.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from Order1 where UserName like '%" + textBox1.Text + "%' or OrderId like '%" + textBox1.Text + "%'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login i = new Login();
            i.Show();
        }

    }
}

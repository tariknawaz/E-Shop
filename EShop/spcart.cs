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
    public partial class spcart : Form
    {
        public spcart()
        {
            InitializeComponent();
            loadtable();
            textBox1.Text = gettotal();
        }
         string gettotal()
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += (Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value)) * (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value));
            }
            return sum.ToString();
        }
        void loadtable()
        {
            string query = "select * from Cart where CartId = (select max(OrderId) from Order1)";
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
            string query = "update Order1 set Total='" + textBox1.Text + "'where OrderId=(select max(OrderId) from Order1)";
            string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.ExecuteNonQuery();
             query = "insert into Order1(UserName)values((select distinct(UserName) from Order1 where OrderId=(select max(OrderId) from Order1)) )";
             myCommand = new SqlCommand(query, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            MessageBox.Show("Order Confirmed!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

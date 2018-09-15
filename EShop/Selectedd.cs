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
    public partial class Selectedd : Form
    {
        public Selectedd(string id, string name, int price, int quantity)
        {
            InitializeComponent();

            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = price.ToString();
        }
        public Selectedd()
        {
            InitializeComponent();

            textBox1.Text = "24";
            textBox2.Text = "fsdf";
            textBox3.Text = "34";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                label5.Visible = true;
            }
            else
            {
                string query = "insert into Cart(CartId,ProductId,Quantity,Price)values ((select max(OrderId) from Order1),'" + textBox1.Text + "','" + textBox4.Text + "','" + textBox3.Text + "')";

                string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();

                label6.Visible = true;
                this.Close();
            }



        }
    }
}

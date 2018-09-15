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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Register r1 = new Register();
            r1.Show();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from UserInfo where UserID ='" + textBox1.Text + "'AND Password='" + textBox2.Text + "'";
            string myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(query, myConnection);
            SqlDataReader dr = myCommand.ExecuteReader();

            if (dr.HasRows)
            {
                if(textBox1.Text=="admin")
                {
                AdminHome h = new AdminHome();
                h.Visible = true;
                this.Visible = false;
                }
                else{
                    
                   // ProductList p = new ProductList();
                    mypro p = new mypro();


                string qorder = "Insert into Order1(UserName)values('" + textBox1.Text + "')";
           
                 myConnectionString = ConfigurationManager.ConnectionStrings["EshopDB"].ConnectionString.ToString();
                 myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();
                 myCommand = new SqlCommand(qorder, myConnection);
                 myCommand.ExecuteNonQuery();
                 p.Visible = true;
                 this.Visible = false;
                }
            }  
            else
            {
                MessageBox.Show("Not Done!");
            }
            myConnection.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
    }
}

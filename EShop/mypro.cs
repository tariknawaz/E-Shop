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
    public partial class mypro : Form
    {
        public mypro()
        {
            InitializeComponent();

            loadtable();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
       
           // Selectedd spd = new Selectedd();
          //  spd.Show();
        }

        void loadtable()
        {
            string query = "select * from Product";
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



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show("sgds");
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int price = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            int quantity = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
            
           Selectedd spd = new Selectedd(id, name, price, quantity);
        //    Selectedd spd = new Selectedd();
            spd.Show();
        }

        private void bsc_Click(object sender, EventArgs e)
        {
            spcart sc = new spcart();
            sc.Show();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            /*BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "select * from Product where ProductName like '%" + textBox1.Text + "'%";
            dataGridView1.DataSource = bs;

            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("name like '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv;
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login o = new Login();
            o.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           /* DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("select * where productname like '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv;*/

          //   "Insert into Order1(UserName)values('" + textBox1.Text + "')";
            string query = "select * from Product where ProductName like '%"+textBox1.Text+"%'";
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
    }
}

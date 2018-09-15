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
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void exit_click(object sender, EventArgs e)
        {
            this.Close();
            Login l = new Login();
            l.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Inventory i = new Inventory();
            i.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Customer c = new Customer();
            c.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderList o = new OrderList();
            o.Show();

        }
    }
}

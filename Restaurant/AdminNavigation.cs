using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class AdminNavigation : Form
    {
        public AdminNavigation()
        {
            InitializeComponent();
        }

        private void AdminNavigation_Load(object sender, EventArgs e)
        {   
            //if(User.Position != "Admin")
            //{
            //    MessageBox.Show("User doesnt have permission");

            //    this.Close();
            //}
            lbl_welcome.Text = $"Welcome, {User.Name}";
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            FormManageEmployee formManageEmployee = new FormManageEmployee();
            formManageEmployee.Show();
            this.Hide();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            formMenu.Show();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOrder order = new FormOrder();
            order.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPayment payment = new FormPayment();
            payment.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormViewOrder formViewOrder = new FormViewOrder();
            formViewOrder.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Show();
        }
    }
}

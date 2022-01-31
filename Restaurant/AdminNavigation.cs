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
    }
}

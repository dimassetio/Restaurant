using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        DbHelper dbHelper = new DbHelper();

        private void btn_login_Click(object sender, EventArgs e)
        {
            string messages = "";
            if (tf_email.Text != String.Empty && tf_email.Text != string.Empty)
            {
                SqlDataReader reader = dbHelper.read($"Select * From msemployee where email = '{tf_email.Text}'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader["password"].ToString() == tf_password.Text)
                        {
                            
                            User.Email = reader["email"].ToString();
                            User.Name = reader["name"].ToString();
                            User.Position = reader["position"].ToString();
                            User.Handphone = reader["handphone"].ToString();
                            User.EmployeeID = reader["employeeID"].ToString();
                            switch (reader["position"].ToString())
                            {
                                case "Admin":
                                    AdminNavigation admin = new AdminNavigation();
                                    admin.Show();
                                    break;
                                case "Cashier":
                                    CashierNavigation cashier = new CashierNavigation();
                                    cashier.Show();
                                    break;
                                case "Chef":
                                    ChefNavigation chef = new ChefNavigation();
                                    chef.Show();
                                    break;
                                
                            }
                            this.Hide();
                            return;
                        }
                        else
                        {
                            messages = "Invalid Password";
                        }
                    }
                }
                else
                {
                   
                    messages = "Invalid Email";
                }
                reader.Close();
            } else
            {
             messages = "All field must be filled!";
            }
            MessageBox.Show(messages);
        }
    }
}

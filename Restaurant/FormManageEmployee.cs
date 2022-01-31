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
    public partial class FormManageEmployee : Form
    {
        public FormManageEmployee()
        {
            InitializeComponent();
        }
        DbHelper dbHelper = new DbHelper();
       public DataTable datatable = new DataTable();

        private void FormManageEmployee_Load(object sender, EventArgs e)
        {
            getTable();
            btn_cancel.Enabled = false;
            btn_save.Enabled = false;
            toggleField();
        }

        public void getTable()
        {
            datatable = dbHelper.getTable("Select * From msemployee");
            dataGridView1.DataSource = datatable;
        }

        private void toggleField() 
        {
            tf_name.Enabled = !tf_name.Enabled;
            tf_email.Enabled = !tf_email.Enabled;
            tf_handphone.Enabled = !tf_handphone.Enabled;
            cb_position.Enabled = !cb_position.Enabled;
        }

        private void clearField()
        {
            tf_id.Clear();
            tf_name.Clear();
            tf_email.Clear();
            cb_position.SelectedIndex = -1;
            tf_handphone.Clear();
        }


        private void toggleButton()
        {
            btn_insert.Enabled = !btn_insert.Enabled;
            btn_update.Enabled = !btn_update.Enabled;
            btn_delete.Enabled = !btn_delete.Enabled;
            btn_save.Enabled  = !btn_save.Enabled;
            btn_cancel.Enabled = !btn_cancel.Enabled;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   
            System.Diagnostics.Debug.WriteLine($"Index : {e.RowIndex}");
            tf_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tf_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tf_email.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            tf_handphone.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cb_position.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            clearField();
            toggleButton();
            toggleField();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                int res;
                if(tf_id.Text == String.Empty)
                {
                    res = dbHelper.execute(storeQuery());
                }
                else
                {
                    res = dbHelper.execute(updateQuery());
                }
                if(res >= 0) 
                {
                    MessageBox.Show("Success");                
                } else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            toggleButton();
            clearField();
            toggleField();
            getTable();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            toggleButton();
            clearField();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if(tf_id.Text == String.Empty)
            {
                MessageBox.Show("Select data from table first!");
            }
            else
            {
                toggleButton();
                toggleField();
                
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (tf_id.Text == string.Empty)
            {
                MessageBox.Show("Select data first!");
            }
            else
            {
                try
                {
                    int res = dbHelper.execute($"Delete From msemployee where employeeid = '{tf_id.Text}'");
                    if (res >= 0)
                    {
                        getTable();
                        MessageBox.Show("Delete Success");
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private string storeQuery()
        {
            return $"Insert into msemployee values ('{dbHelper.getRandomID(6)}','{tf_name.Text}','{tf_email.Text}','password','{tf_handphone.Text}','{cb_position.SelectedItem}')";
        }

        private string updateQuery()
        {
            return $"Update msEmployee  Set name = '{tf_name.Text}', email = '{tf_email.Text}', handphone = '{tf_handphone.Text}', position = '{cb_position.SelectedItem}' where employeeID = '{tf_id.Text}'";
        }
    }
}

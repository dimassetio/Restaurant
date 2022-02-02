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
    public partial class FormMember : Form
    {
        public FormMember()
        {
            InitializeComponent();
        }
        public DataTable dataTable = new DataTable(); 
        DbHelper dbHelper = new DbHelper();

        private void FormMember_Load(object sender, EventArgs e)
        {
            btn_cancel.Enabled = false;
            btn_save.Enabled = false;
            toggleField();
            loadTable();
        }

        private void toggleButton()
        {
            btn_cancel.Enabled = !btn_cancel.Enabled;  
            btn_save.Enabled = !btn_save.Enabled;  
            btn_insert.Enabled = !btn_insert.Enabled;  
            btn_update.Enabled = !btn_update.Enabled;  
            btn_delete.Enabled = !btn_delete.Enabled;  
        }

        private void toggleField()
        {
            tb_email.Enabled = !tb_email.Enabled;
            tb_handphone.Enabled = !tb_handphone.Enabled;
            tb_name.Enabled = !tb_name.Enabled; 
        }

        private void clearField()
        {
            tb_email.Clear();
            tb_handphone.Clear();
            tb_id.Clear();
            tb_name.Clear();
        }

        private void loadTable() {
            dataTable = dbHelper.getTable("Select * From msmember");
            dataGridView1.DataSource = dataTable;
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            clearField();
            toggleButton();
            toggleField();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (tb_id.Text == String.Empty)
            {
                MessageBox.Show("Select data from table first!");
            }
            else
            {
                toggleButton();
                toggleField();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
            DataGridViewRow dr = dataGridView1.Rows[e.RowIndex];
            if (dr != null)
            {
                tb_id.Text = dr.Cells[0].Value.ToString();
                tb_name.Text = dr.Cells[1].Value.ToString();
                tb_email.Text = dr.Cells[2].Value.ToString();
                tb_handphone.Text = dr.Cells[3].Value.ToString();   
            }
            }
        }

        private string storeQuery() => $"Insert into msmember values( '{dbHelper.getRandomID(8)}', '{tb_name.Text}', '{tb_email.Text}', '{tb_handphone.Text}', @joinDate )";
        private string updateQuery() => $"Update msmember set name =  '{tb_name.Text}', email = '{tb_email.Text}', handphone = '{tb_handphone.Text}' where memberID = '{tb_id.Text}'";
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                int res = 0;
                if (tb_id.Text == string.Empty)
                {

                  res = dbHelper.execute(storeQuery(), addDate : true, "joinDate");
                }
                else
                {
                   res = dbHelper.execute(updateQuery());
                }
                if (res >= 0)
                {
                    MessageBox.Show("SUCCESS");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            loadTable();
            clearField();
            toggleButton();
            toggleField();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            clearField();
            toggleButton();
            toggleField();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(tb_id.Text == string.Empty)
            {
                MessageBox.Show("Select Data First!");
            }
            else
            {
                try
                {
                    if (dbHelper.execute($"Delete from msmember where memberID = '{tb_id.Text}'") > 0)
                    {
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
                clearField();
                toggleButton();
                toggleField();
                loadTable();
            }

        }
    }
}

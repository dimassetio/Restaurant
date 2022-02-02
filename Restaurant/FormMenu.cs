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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        
        string filename = "";
        DataTable dataTable = new DataTable();
        DbHelper dbHelper = new DbHelper();
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
            tb_price.Enabled = !tb_price.Enabled;
            tb_name.Enabled = !tb_name.Enabled;
        }

        private void clearField()
        {
            tb_price.Clear();
            tb_photo.Clear();
            tb_id.Clear();
            tb_name.Clear();
            pictureBox1.Image = null;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files (*.png)|*.png| jpg files (*.jpg)|*.jpg| all files (*.)|*.";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                pictureBox1.ImageLocation = filename;
                tb_photo.Text = filename;
            }
            
        }

        private void loadTable()
        {
            dataTable = dbHelper.getTable("Select * from msmenu");
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = dataGridView1.Rows[e.RowIndex];
                if (dr != null)
                {
                    tb_id.Text = dr.Cells[0].Value.ToString();
                    tb_name.Text = dr.Cells[1].Value.ToString();
                    tb_price.Text = dr.Cells[2].Value.ToString();
                    tb_photo.Text = dr.Cells[3].Value.ToString();
                    pictureBox1.ImageLocation = tb_photo.Text;
                }
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            btn_cancel.Enabled = false;
            btn_save.Enabled = false;
            toggleField();
            loadTable();
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
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (tb_id.Text == string.Empty)
            {
                MessageBox.Show("Select data first!");
            }
            else
            {
                try
                {
                    int res = dbHelper.execute($"Delete From msmenu where menuid = '{tb_id.Text}'");
                    if (res >= 0)
                    {
                        loadTable();
                        clearField();
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            clearField();
            
        }
        string storeQuery() => $"Insert into msmenu values ('{tb_name.Text}',{int.Parse(tb_price.Text)},'{tb_photo.Text}')";

        string updateQuery() => $"Update msmenu set name = '{tb_name.Text}', price = {int.Parse(tb_price.Text)}, photo = '{filename}' where menuID = {tb_id.Text}";
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                int res = 0;
                if (tb_id.Text == string.Empty)
                {
                    System.Diagnostics.Debug.WriteLine(storeQuery());
                    res = dbHelper.execute(storeQuery());
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
    }
}

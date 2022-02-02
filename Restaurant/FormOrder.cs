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
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
        }
        DbHelper dbHelper = new DbHelper();
        DataTable dt_menu = new DataTable();
        DataTable dt_order = new DataTable();

        private void FormOrder_Load(object sender, EventArgs e)
        {

            dt_order.Columns.Add(new DataColumn("Id", typeof(Int32)));
            dt_order.Columns.Add(new DataColumn("Name", typeof(string)));
            dt_order.Columns.Add(new DataColumn("Qty", typeof(Int32)));
            dt_order.Columns.Add(new DataColumn("Price", typeof(Int32)));
            dt_order.Columns.Add(new DataColumn("Total", typeof(Int32)));
            loadMenu();
            loadOrder();
        }

        private void loadMenu() 
        {

            dt_menu = dbHelper.getTable("Select * From msMenu");     
            dgv_menu.DataSource = dt_menu;
            dgv_menu.ClearSelection();
        }

        private void loadOrder()
        {
            

            dgv_order.DataSource = dt_order;
        }

        private void dgv_menu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = dgv_menu.Rows[e.RowIndex];
                if (dr != null)
                {
                    tb_name.Text = dr.Cells[1].Value.ToString();
                    tb_price.Text = dr.Cells[2].Value.ToString();
                    pictureBox1.ImageLocation =  dr.Cells[3].Value.ToString();
                }
            }
        }
        private void clearField()
        {
            tb_name.Clear();
            tb_price.Clear();
            tb_qty.Clear();
            dgv_menu.ClearSelection();
            dgv_order.ClearSelection();
            pictureBox1.Image = null;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (dgv_menu.SelectedRows.Count < 1 || tb_qty.Text == String.Empty)
            {
                MessageBox.Show("Complete data first");
            }
            else
            {
                int qty;
                if (int.TryParse(tb_qty.Text, out qty))
                {
                    DataRow dr = dt_menu.Rows[dgv_menu.CurrentCell.RowIndex];
                    int total = qty * int.Parse(dr["price"].ToString());
                    dt_order.Rows.Add(dr["menuid"],dr["name"],tb_qty.Text, dr["price"], total );
                    loadOrder();
                    clearField();
                    getTotal();
                } else
                {
                    MessageBox.Show("Quantity is not correct");
                }
                
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (dgv_order.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select Data First!");

            }
            else
            {
                dt_order.Rows.RemoveAt(dgv_order.CurrentCell.RowIndex);
                getTotal();
            }
        }

        private void getTotal()
        {
            int total = 0;
            foreach (DataRow dr in dt_order.Rows)
            {
                total = total + int.Parse(dr["total"].ToString());
            }
            lbl_total.Text = $"Total : {total}";
        }

        private void storeOrder()
        {
            //var res = dbHelper.executeScalar($"Insert into headerOrder values('{dbHelper.getRandomID(10)}', '001001','3SOPX2JD',@date,'','')",addDate:true, "date");
            try
            {
                string orderID = dbHelper.getRandomID(10);
                
                if (dbHelper.execute($"Insert into headerOrder values('{orderID}', '001001','3SOPX2JD',@date,'','','','')", addDate: true, "date")>0)
                {
                    foreach (DataRow dr in dt_order.Rows)
                    {
                        string storeQuery = $"Insert into detailOrder values('{orderID}', {dr["id"]}, {dr["qty"]}, {dr["price"]}, 'Pending')";
                        dbHelper.execute(storeQuery);
                    }
                    dt_order.Clear();
                    loadOrder();        
                    MessageBox.Show("SUCCESS");
                }
                else
                {
                    MessageBox.Show($"Failed Create Order");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            storeOrder();
        }
    }
}

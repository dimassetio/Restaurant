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
    public partial class FormViewOrder : Form
    {
        public FormViewOrder()
        {
            InitializeComponent();
        }
        DbHelper dbHelper = new DbHelper();
        DataTable dt = new DataTable();
        private void loadCB()
        {
            SqlDataReader reader = dbHelper.read("Select orderid from detailorder group by orderid");
            while (reader.Read())
            {
                cb_id.Items.Add(reader.GetString(0));
            }
            reader.Close();

        }

        private void FormViewOrder_Load(object sender, EventArgs e)
        {
           
            loadCB();
        }

        private void loadTable(string orderid)
        {
            dt = dbHelper.getTable($"Select detailID, msmenu.name as menuid, qty, status from detailorder inner join msmenu on detailorder.menuid = msmenu.menuid where orderID = '{orderid}'");
            //dt.Columns["status"].
            dgv_detail.DataSource = dt;
        }

        private void cb_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTable(cb_id.SelectedItem.ToString());
        }

        private void dgv_detail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_detail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string newStatus = dgv_detail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                dbHelper.execute($"Update detailorder set status = '{newStatus}' where detailid = {dt.Rows[e.RowIndex][0]}");
                MessageBox.Show("Data Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
    }
}

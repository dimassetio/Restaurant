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
    public partial class FormPayment : Form
    {
        public FormPayment()
        {
            InitializeComponent();
        }

        DbHelper dbHelper = new DbHelper();
        DataTable dt = new DataTable();
        //string[] listType = new string [] ["Debit","E-Wallet"];
        string[] listType = new string[] { "Debit", "E-Wallet" };
        string[] listBank = new string[] { "BRI", "BCA" };
        string[] listWallet = new string[] { "Dana", "Gopay","ShopeePay","OVO" };


        private void loadCB()
        {
            SqlDataReader reader = dbHelper.read("Select orderid from detailorder group by orderid");
            while (reader.Read())
            {
                cb_id.Items.Add(reader.GetString(0));
            }
            reader.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            loadCB();
            loadTable();
            cb_type.Items.AddRange(listType);
        }
        int total = 0;

        private void loadTable()
        {
            dt = dbHelper.getTable($"Select name , detailorder.price, qty,detailorder.price * qty as total From detailorder inner join msmenu on msmenu.menuid = detailorder.menuid where orderID = '{cb_id.SelectedItem}'");
            dgv_detail.DataSource = dt;
            total = 0;
            foreach (DataRow dr in dt.Rows)
            {
                total = total + int.Parse(dr["total"].ToString());
            }
            lbl_price.Text = $"Rp {total},-";
        }

        private void cb_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTable();
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_bank.Items.Clear();
            if (cb_type.SelectedIndex == 0)
            {
                cb_bank.Items.AddRange(listBank);
            } else if (cb_type.SelectedIndex == 1)
            {
                cb_bank.Items.AddRange(listWallet);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cb_id.SelectedIndex < 0)
            {
                MessageBox.Show("Select Order Data first");
            }else
            {
                try
                {
                    int res = dbHelper.execute($"Update headerorder set payment = '{cb_type.SelectedItem}', bank = '{cb_bank.SelectedItem}', card_number = '{tb_number.Text}', total_price = {total} where orderid = '{cb_id.SelectedItem}'");
                    if (res>0)
                    {
                        MessageBox.Show("SUCCESS");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

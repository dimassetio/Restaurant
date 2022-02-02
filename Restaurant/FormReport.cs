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
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        DateTime startDate = DateTime.Now.AddDays(-7);
        DataTable dt = new DataTable();
        DbHelper dbHelper = new DbHelper();

        private void FormReport_Load(object sender, EventArgs e)
        {
            dtp_from.Value = startDate;
            loadTable();
            loadChart();
        }

        private void loadTable()
        {
            SqlCommand cmd = new SqlCommand($"Select date, payment, bank, total_price from headerorder  where date between @startDate and @endDate");
            cmd.Parameters.AddWithValue("startDate", dtp_from.Value);
            cmd.Parameters.AddWithValue("endDate", dtp_to.Value);
            dt = dbHelper.tableFromCommand(cmd);
            dgv_report.DataSource = dt;
        }

        private void loadChart()
        {
            SqlCommand cmd = new SqlCommand($"Select bank, sum(total_price) as money From headerorder where date between @startDate and @endDate group by bank");
            cmd.Parameters.AddWithValue("startDate", dtp_from.Value);
            cmd.Parameters.AddWithValue("endDate", dtp_to.Value);

            DataTable dt_chart = dbHelper.tableFromCommand(cmd);

            chart_report.DataSource = dt_chart;

            chart_report.Series["Income"].XValueMember = "bank";
            chart_report.Series["Income"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chart_report.Series["Income"].YValueMembers = "money";
            chart_report.Series["Income"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
        }

        private void dtp_from_ValueChanged(object sender, EventArgs e)
        {
            loadTable();
            loadChart();
        }
    }
}

namespace Restaurant
{
    partial class FormViewOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.fKDetailOrderMsMenuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.msMenuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.restaurantDataSet2 = new Restaurant.RestaurantDataSet2();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_id = new System.Windows.Forms.ComboBox();
            this.detailOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detailOrderTableAdapter = new Restaurant.RestaurantDataSet2TableAdapters.DetailOrderTableAdapter();
            this.msMenuTableAdapter = new Restaurant.RestaurantDataSet2TableAdapters.MsMenuTableAdapter();
            this.dgv_detail = new System.Windows.Forms.DataGridView();
            this.menuIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fKDetailOrderMsMenuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msMenuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(321, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "View Order";
            // 
            // fKDetailOrderMsMenuBindingSource
            // 
            this.fKDetailOrderMsMenuBindingSource.DataMember = "FK_DetailOrder_MsMenu";
            this.fKDetailOrderMsMenuBindingSource.DataSource = this.msMenuBindingSource;
            // 
            // msMenuBindingSource
            // 
            this.msMenuBindingSource.DataMember = "MsMenu";
            this.msMenuBindingSource.DataSource = this.restaurantDataSet2;
            // 
            // restaurantDataSet2
            // 
            this.restaurantDataSet2.DataSetName = "RestaurantDataSet2";
            this.restaurantDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order ID";
            // 
            // cb_id
            // 
            this.cb_id.FormattingEnabled = true;
            this.cb_id.Location = new System.Drawing.Point(326, 59);
            this.cb_id.Name = "cb_id";
            this.cb_id.Size = new System.Drawing.Size(221, 21);
            this.cb_id.TabIndex = 3;
            this.cb_id.SelectedIndexChanged += new System.EventHandler(this.cb_id_SelectedIndexChanged);
            // 
            // detailOrderBindingSource
            // 
            this.detailOrderBindingSource.DataMember = "DetailOrder";
            this.detailOrderBindingSource.DataSource = this.restaurantDataSet2;
            // 
            // detailOrderTableAdapter
            // 
            this.detailOrderTableAdapter.ClearBeforeFill = true;
            // 
            // msMenuTableAdapter
            // 
            this.msMenuTableAdapter.ClearBeforeFill = true;
            // 
            // dgv_detail
            // 
            this.dgv_detail.AllowUserToAddRows = false;
            this.dgv_detail.AllowUserToDeleteRows = false;
            this.dgv_detail.AutoGenerateColumns = false;
            this.dgv_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.menuIDDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dgv_detail.DataSource = this.fKDetailOrderMsMenuBindingSource;
            this.dgv_detail.Location = new System.Drawing.Point(75, 118);
            this.dgv_detail.Name = "dgv_detail";
            this.dgv_detail.Size = new System.Drawing.Size(643, 235);
            this.dgv_detail.TabIndex = 4;
            this.dgv_detail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_detail_CellEndEdit);
            // 
            // menuIDDataGridViewTextBoxColumn
            // 
            this.menuIDDataGridViewTextBoxColumn.DataPropertyName = "MenuID";
            this.menuIDDataGridViewTextBoxColumn.HeaderText = "Name";
            this.menuIDDataGridViewTextBoxColumn.Name = "menuIDDataGridViewTextBoxColumn";
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "Pending",
            "Cooking",
            "Delivering",
            "Done"});
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.statusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FormViewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_detail);
            this.Controls.Add(this.cb_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormViewOrder";
            this.Text = "FormViewOrder";
            this.Load += new System.EventHandler(this.FormViewOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fKDetailOrderMsMenuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msMenuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_id;
        private RestaurantDataSet2 restaurantDataSet2;
        private System.Windows.Forms.BindingSource detailOrderBindingSource;
        private RestaurantDataSet2TableAdapters.DetailOrderTableAdapter detailOrderTableAdapter;
        private System.Windows.Forms.BindingSource msMenuBindingSource;
        private RestaurantDataSet2TableAdapters.MsMenuTableAdapter msMenuTableAdapter;
        private System.Windows.Forms.BindingSource fKDetailOrderMsMenuBindingSource;
        private System.Windows.Forms.DataGridView dgv_detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn statusDataGridViewTextBoxColumn;
    }
}
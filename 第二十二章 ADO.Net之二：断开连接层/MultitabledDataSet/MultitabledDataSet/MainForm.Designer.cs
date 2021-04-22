
namespace MultitabledDataSet
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.btnUpdateDataBase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustID = new System.Windows.Forms.TextBox();
            this.btnGetOrderInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.RowHeadersWidth = 51;
            this.dataGridViewInventory.RowTemplate.Height = 27;
            this.dataGridViewInventory.Size = new System.Drawing.Size(782, 127);
            this.dataGridViewInventory.TabIndex = 0;
            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(12, 217);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.RowHeadersWidth = 51;
            this.dataGridViewCustomers.RowTemplate.Height = 27;
            this.dataGridViewCustomers.Size = new System.Drawing.Size(782, 133);
            this.dataGridViewCustomers.TabIndex = 1;
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(12, 402);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersWidth = 51;
            this.dataGridViewOrders.RowTemplate.Height = 27;
            this.dataGridViewOrders.Size = new System.Drawing.Size(782, 150);
            this.dataGridViewOrders.TabIndex = 2;
            // 
            // btnUpdateDataBase
            // 
            this.btnUpdateDataBase.Location = new System.Drawing.Point(622, 595);
            this.btnUpdateDataBase.Name = "btnUpdateDataBase";
            this.btnUpdateDataBase.Size = new System.Drawing.Size(158, 23);
            this.btnUpdateDataBase.TabIndex = 3;
            this.btnUpdateDataBase.Text = "Update Database";
            this.btnUpdateDataBase.UseVisualStyleBackColor = true;
            this.btnUpdateDataBase.Click += new System.EventHandler(this.btnUpdateDataBase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe 繁黑體 Std B", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current Inventory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Adobe 繁黑體 Std B", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(13, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Customers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Adobe 繁黑體 Std B", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(13, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Current Orders";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetOrderInfo);
            this.groupBox1.Controls.Add(this.txtCustID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(17, 559);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 82);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lookup Customer Order";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Customer ID:";
            // 
            // txtCustID
            // 
            this.txtCustID.Location = new System.Drawing.Point(116, 22);
            this.txtCustID.Name = "txtCustID";
            this.txtCustID.Size = new System.Drawing.Size(151, 25);
            this.txtCustID.TabIndex = 1;
            // 
            // btnGetOrderInfo
            // 
            this.btnGetOrderInfo.Location = new System.Drawing.Point(116, 53);
            this.btnGetOrderInfo.Name = "btnGetOrderInfo";
            this.btnGetOrderInfo.Size = new System.Drawing.Size(151, 23);
            this.btnGetOrderInfo.TabIndex = 2;
            this.btnGetOrderInfo.Text = "Get Order Details";
            this.btnGetOrderInfo.UseVisualStyleBackColor = true;
            this.btnGetOrderInfo.Click += new System.EventHandler(this.btnGetOrderInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 653);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdateDataBase);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.dataGridViewCustomers);
            this.Controls.Add(this.dataGridViewInventory);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button btnUpdateDataBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetOrderInfo;
        private System.Windows.Forms.TextBox txtCustID;
        private System.Windows.Forms.Label label4;
    }
}


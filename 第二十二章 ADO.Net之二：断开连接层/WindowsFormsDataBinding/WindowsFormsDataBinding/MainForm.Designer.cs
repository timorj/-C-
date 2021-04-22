
namespace WindowsFormsDataBinding
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
            this.carInventoryDridView = new System.Windows.Forms.DataGridView();
            this.labelDiscription = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRowRemove = new System.Windows.Forms.TextBox();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDisplayMakes = new System.Windows.Forms.Button();
            this.txtMakeToView = new System.Windows.Forms.TextBox();
            this.btnChangeMakes = new System.Windows.Forms.Button();
            this.dataGridViewYugosView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryDridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYugosView)).BeginInit();
            this.SuspendLayout();
            // 
            // carInventoryDridView
            // 
            this.carInventoryDridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.carInventoryDridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carInventoryDridView.Location = new System.Drawing.Point(18, 79);
            this.carInventoryDridView.Name = "carInventoryDridView";
            this.carInventoryDridView.RowHeadersWidth = 51;
            this.carInventoryDridView.RowTemplate.Height = 27;
            this.carInventoryDridView.Size = new System.Drawing.Size(770, 219);
            this.carInventoryDridView.TabIndex = 0;
            // 
            // labelDiscription
            // 
            this.labelDiscription.AutoSize = true;
            this.labelDiscription.Font = new System.Drawing.Font("Adobe Gothic Std B", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDiscription.Location = new System.Drawing.Point(12, 28);
            this.labelDiscription.Name = "labelDiscription";
            this.labelDiscription.Size = new System.Drawing.Size(352, 31);
            this.labelDiscription.TabIndex = 1;
            this.labelDiscription.Text = "Here is what we have in stock";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveRow);
            this.groupBox1.Controls.Add(this.txtRowRemove);
            this.groupBox1.Location = new System.Drawing.Point(18, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter ID of Car to Delete:";
            // 
            // txtRowRemove
            // 
            this.txtRowRemove.Location = new System.Drawing.Point(22, 47);
            this.txtRowRemove.Name = "txtRowRemove";
            this.txtRowRemove.Size = new System.Drawing.Size(150, 25);
            this.txtRowRemove.TabIndex = 0;
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(178, 47);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveRow.TabIndex = 1;
            this.btnRemoveRow.Text = "Delete!";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChangeMakes);
            this.groupBox2.Controls.Add(this.btnDisplayMakes);
            this.groupBox2.Controls.Add(this.txtMakeToView);
            this.groupBox2.Location = new System.Drawing.Point(442, 343);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enter Make to View:";
            // 
            // btnDisplayMakes
            // 
            this.btnDisplayMakes.Location = new System.Drawing.Point(178, 47);
            this.btnDisplayMakes.Name = "btnDisplayMakes";
            this.btnDisplayMakes.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayMakes.TabIndex = 1;
            this.btnDisplayMakes.Text = "View!";
            this.btnDisplayMakes.UseVisualStyleBackColor = true;
            this.btnDisplayMakes.Click += new System.EventHandler(this.btnDisplayMakes_Click);
            // 
            // txtMakeToView
            // 
            this.txtMakeToView.Location = new System.Drawing.Point(22, 47);
            this.txtMakeToView.Name = "txtMakeToView";
            this.txtMakeToView.Size = new System.Drawing.Size(150, 25);
            this.txtMakeToView.TabIndex = 0;
            // 
            // btnChangeMakes
            // 
            this.btnChangeMakes.Location = new System.Drawing.Point(260, 48);
            this.btnChangeMakes.Name = "btnChangeMakes";
            this.btnChangeMakes.Size = new System.Drawing.Size(75, 23);
            this.btnChangeMakes.TabIndex = 2;
            this.btnChangeMakes.Text = "Change!";
            this.btnChangeMakes.UseVisualStyleBackColor = true;
            this.btnChangeMakes.Click += new System.EventHandler(this.btnChangeMakes_Click);
            // 
            // dataGridViewYugosView
            // 
            this.dataGridViewYugosView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewYugosView.Location = new System.Drawing.Point(18, 526);
            this.dataGridViewYugosView.Name = "dataGridViewYugosView";
            this.dataGridViewYugosView.RowHeadersWidth = 51;
            this.dataGridViewYugosView.RowTemplate.Height = 27;
            this.dataGridViewYugosView.Size = new System.Drawing.Size(759, 150);
            this.dataGridViewYugosView.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Gothic Std B", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 470);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Only Yugos";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 753);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewYugosView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelDiscription);
            this.Controls.Add(this.carInventoryDridView);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryDridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYugosView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView carInventoryDridView;
        private System.Windows.Forms.Label labelDiscription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.TextBox txtRowRemove;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDisplayMakes;
        private System.Windows.Forms.TextBox txtMakeToView;
        private System.Windows.Forms.Button btnChangeMakes;
        private System.Windows.Forms.DataGridView dataGridViewYugosView;
        private System.Windows.Forms.Label label1;
    }
}


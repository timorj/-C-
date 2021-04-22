
namespace InventoryDALDisconnectedGUI
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
            this.labelDiscription = new System.Windows.Forms.Label();
            this.inventoryGrid = new System.Windows.Forms.DataGridView();
            this.btnUpdateInventory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDiscription
            // 
            this.labelDiscription.AutoSize = true;
            this.labelDiscription.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDiscription.Location = new System.Drawing.Point(12, 26);
            this.labelDiscription.Name = "labelDiscription";
            this.labelDiscription.Size = new System.Drawing.Size(178, 25);
            this.labelDiscription.TabIndex = 0;
            this.labelDiscription.Text = "Current Inventory";
            // 
            // inventoryGrid
            // 
            this.inventoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryGrid.Location = new System.Drawing.Point(12, 63);
            this.inventoryGrid.Name = "inventoryGrid";
            this.inventoryGrid.RowHeadersWidth = 51;
            this.inventoryGrid.RowTemplate.Height = 27;
            this.inventoryGrid.Size = new System.Drawing.Size(776, 138);
            this.inventoryGrid.TabIndex = 1;
            // 
            // btnUpdateInventory
            // 
            this.btnUpdateInventory.Location = new System.Drawing.Point(616, 415);
            this.btnUpdateInventory.Name = "btnUpdateInventory";
            this.btnUpdateInventory.Size = new System.Drawing.Size(172, 23);
            this.btnUpdateInventory.TabIndex = 2;
            this.btnUpdateInventory.Text = "Update Database";
            this.btnUpdateInventory.UseVisualStyleBackColor = true;
            this.btnUpdateInventory.Click += new System.EventHandler(this.btnUpdateInventory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdateInventory);
            this.Controls.Add(this.inventoryGrid);
            this.Controls.Add(this.labelDiscription);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDiscription;
        private System.Windows.Forms.DataGridView inventoryGrid;
        private System.Windows.Forms.Button btnUpdateInventory;
    }
}


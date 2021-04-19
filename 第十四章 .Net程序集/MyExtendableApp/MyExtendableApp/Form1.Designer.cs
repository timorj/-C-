
namespace MyExtendableApp
{
    partial class Form1
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.snapInModleToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.lstLoadedSnapIns = new System.Windows.Forms.ListBox();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snapInModleToolStrip});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(800, 28);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // snapInModleToolStrip
            // 
            this.snapInModleToolStrip.Name = "snapInModleToolStrip";
            this.snapInModleToolStrip.Size = new System.Drawing.Size(48, 24);
            this.snapInModleToolStrip.Text = "&File";
            this.snapInModleToolStrip.Click += new System.EventHandler(this.snapInModleToolStrip_Click);
            // 
            // lstLoadedSnapIns
            // 
            this.lstLoadedSnapIns.FormattingEnabled = true;
            this.lstLoadedSnapIns.ItemHeight = 15;
            this.lstLoadedSnapIns.Location = new System.Drawing.Point(75, 74);
            this.lstLoadedSnapIns.Name = "lstLoadedSnapIns";
            this.lstLoadedSnapIns.Size = new System.Drawing.Size(622, 229);
            this.lstLoadedSnapIns.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstLoadedSnapIns);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem snapInModleToolStrip;
        private System.Windows.Forms.ListBox lstLoadedSnapIns;
    }
}


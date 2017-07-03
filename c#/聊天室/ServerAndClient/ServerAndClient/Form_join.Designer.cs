namespace ServerAndClient
{
    partial class Form_join
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
            this.listBox_netname = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_netname
            // 
            this.listBox_netname.FormattingEnabled = true;
            this.listBox_netname.ItemHeight = 12;
            this.listBox_netname.Location = new System.Drawing.Point(23, 13);
            this.listBox_netname.Name = "listBox_netname";
            this.listBox_netname.Size = new System.Drawing.Size(210, 292);
            this.listBox_netname.TabIndex = 1;
            // 
            // Form_join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 318);
            this.Controls.Add(this.listBox_netname);
            this.Name = "Form_join";
            this.Text = "Form_join";
            this.Load += new System.EventHandler(this.Form_join_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_netname;
    }
}
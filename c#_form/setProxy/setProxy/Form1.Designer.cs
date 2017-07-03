namespace setProxy
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listView_Proxy = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_OpenFile = new System.Windows.Forms.Button();
            this.button_CheckProxy = new System.Windows.Forms.Button();
            this.button_DeleteError = new System.Windows.Forms.Button();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_SetProxy = new System.Windows.Forms.Button();
            this.textBox_ProxyNow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox_Show = new System.Windows.Forms.TextBox();
            this.button_StopProxy = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_Proxy
            // 
            this.listView_Proxy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView_Proxy.Location = new System.Drawing.Point(12, 37);
            this.listView_Proxy.Name = "listView_Proxy";
            this.listView_Proxy.Size = new System.Drawing.Size(342, 258);
            this.listView_Proxy.TabIndex = 0;
            this.listView_Proxy.UseCompatibleStateImageBehavior = false;
            this.listView_Proxy.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "代理IP";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "地区";
            this.columnHeader3.Width = 147;
            // 
            // button_OpenFile
            // 
            this.button_OpenFile.Location = new System.Drawing.Point(3, 20);
            this.button_OpenFile.Name = "button_OpenFile";
            this.button_OpenFile.Size = new System.Drawing.Size(75, 23);
            this.button_OpenFile.TabIndex = 1;
            this.button_OpenFile.Text = "导入";
            this.button_OpenFile.UseVisualStyleBackColor = true;
            this.button_OpenFile.Click += new System.EventHandler(this.button_OpenFile_Click);
            // 
            // button_CheckProxy
            // 
            this.button_CheckProxy.Location = new System.Drawing.Point(3, 78);
            this.button_CheckProxy.Name = "button_CheckProxy";
            this.button_CheckProxy.Size = new System.Drawing.Size(75, 23);
            this.button_CheckProxy.TabIndex = 2;
            this.button_CheckProxy.Text = "验证代理";
            this.button_CheckProxy.UseVisualStyleBackColor = true;
            this.button_CheckProxy.Click += new System.EventHandler(this.button_CheckProxy_Click);
            // 
            // button_DeleteError
            // 
            this.button_DeleteError.Location = new System.Drawing.Point(3, 136);
            this.button_DeleteError.Name = "button_DeleteError";
            this.button_DeleteError.Size = new System.Drawing.Size(75, 23);
            this.button_DeleteError.TabIndex = 3;
            this.button_DeleteError.Text = "删除不可用";
            this.button_DeleteError.UseVisualStyleBackColor = true;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "连接时间";
            // 
            // button_SetProxy
            // 
            this.button_SetProxy.Location = new System.Drawing.Point(3, 194);
            this.button_SetProxy.Name = "button_SetProxy";
            this.button_SetProxy.Size = new System.Drawing.Size(75, 23);
            this.button_SetProxy.TabIndex = 4;
            this.button_SetProxy.Text = "设置代理";
            this.button_SetProxy.UseVisualStyleBackColor = true;
            // 
            // textBox_ProxyNow
            // 
            this.textBox_ProxyNow.Location = new System.Drawing.Point(77, 10);
            this.textBox_ProxyNow.Name = "textBox_ProxyNow";
            this.textBox_ProxyNow.ReadOnly = true;
            this.textBox_ProxyNow.Size = new System.Drawing.Size(277, 21);
            this.textBox_ProxyNow.TabIndex = 5;
            this.textBox_ProxyNow.Text = "无";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "当前代理：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_StopProxy);
            this.groupBox1.Controls.Add(this.button_OpenFile);
            this.groupBox1.Controls.Add(this.button_CheckProxy);
            this.groupBox1.Controls.Add(this.button_DeleteError);
            this.groupBox1.Controls.Add(this.button_SetProxy);
            this.groupBox1.Location = new System.Drawing.Point(360, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(91, 292);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "代理IP列表.txt";
            // 
            // textBox_Show
            // 
            this.textBox_Show.Location = new System.Drawing.Point(12, 302);
            this.textBox_Show.Name = "textBox_Show";
            this.textBox_Show.ReadOnly = true;
            this.textBox_Show.Size = new System.Drawing.Size(439, 21);
            this.textBox_Show.TabIndex = 8;
            // 
            // button_StopProxy
            // 
            this.button_StopProxy.Location = new System.Drawing.Point(3, 252);
            this.button_StopProxy.Name = "button_StopProxy";
            this.button_StopProxy.Size = new System.Drawing.Size(75, 23);
            this.button_StopProxy.TabIndex = 5;
            this.button_StopProxy.Text = "停用代理";
            this.button_StopProxy.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 335);
            this.Controls.Add(this.textBox_Show);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ProxyNow);
            this.Controls.Add(this.listView_Proxy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_Proxy;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button_OpenFile;
        private System.Windows.Forms.Button button_CheckProxy;
        private System.Windows.Forms.Button button_DeleteError;
        private System.Windows.Forms.Button button_SetProxy;
        private System.Windows.Forms.TextBox textBox_ProxyNow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox_Show;
        private System.Windows.Forms.Button button_StopProxy;
    }
}


namespace Cookie_Qzone
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
            this.listView_QQList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_OpenCookies = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_ShowLog = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_Content = new System.Windows.Forms.TextBox();
            this.button_Begin = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.openFileDialog_Cookie = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_QQList
            // 
            this.listView_QQList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView_QQList.Location = new System.Drawing.Point(6, 49);
            this.listView_QQList.Name = "listView_QQList";
            this.listView_QQList.Size = new System.Drawing.Size(505, 290);
            this.listView_QQList.TabIndex = 0;
            this.listView_QQList.UseCompatibleStateImageBehavior = false;
            this.listView_QQList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            this.columnHeader1.Width = 47;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "QQ号";
            this.columnHeader2.Width = 65;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "cookies";
            this.columnHeader3.Width = 217;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "g_tk";
            this.columnHeader4.Width = 65;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "状态";
            this.columnHeader5.Width = 95;
            // 
            // button_OpenCookies
            // 
            this.button_OpenCookies.Location = new System.Drawing.Point(6, 20);
            this.button_OpenCookies.Name = "button_OpenCookies";
            this.button_OpenCookies.Size = new System.Drawing.Size(75, 23);
            this.button_OpenCookies.TabIndex = 1;
            this.button_OpenCookies.Text = "导入";
            this.button_OpenCookies.UseVisualStyleBackColor = true;
            this.button_OpenCookies.Click += new System.EventHandler(this.button_OpenCookies_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_OpenCookies);
            this.groupBox1.Controls.Add(this.listView_QQList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 350);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cookie：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_ShowLog);
            this.groupBox2.Location = new System.Drawing.Point(535, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 350);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "系统信息：";
            // 
            // textBox_ShowLog
            // 
            this.textBox_ShowLog.Location = new System.Drawing.Point(7, 20);
            this.textBox_ShowLog.Multiline = true;
            this.textBox_ShowLog.Name = "textBox_ShowLog";
            this.textBox_ShowLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_ShowLog.Size = new System.Drawing.Size(173, 319);
            this.textBox_ShowLog.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_Stop);
            this.groupBox3.Controls.Add(this.button_Begin);
            this.groupBox3.Controls.Add(this.textBox_Content);
            this.groupBox3.Location = new System.Drawing.Point(12, 369);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(709, 89);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发布说说：";
            // 
            // textBox_Content
            // 
            this.textBox_Content.Location = new System.Drawing.Point(7, 21);
            this.textBox_Content.Multiline = true;
            this.textBox_Content.Name = "textBox_Content";
            this.textBox_Content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Content.Size = new System.Drawing.Size(589, 62);
            this.textBox_Content.TabIndex = 0;
            // 
            // button_Begin
            // 
            this.button_Begin.Location = new System.Drawing.Point(602, 21);
            this.button_Begin.Name = "button_Begin";
            this.button_Begin.Size = new System.Drawing.Size(101, 23);
            this.button_Begin.TabIndex = 1;
            this.button_Begin.Text = "开始发布";
            this.button_Begin.UseVisualStyleBackColor = true;
            this.button_Begin.Click += new System.EventHandler(this.button_Begin_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(602, 60);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(101, 23);
            this.button_Stop.TabIndex = 2;
            this.button_Stop.Text = "停止线程";
            this.button_Stop.UseVisualStyleBackColor = true;
            // 
            // openFileDialog_Cookie
            // 
            this.openFileDialog_Cookie.FileName = "cookies.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 470);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_QQList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button_OpenCookies;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_ShowLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_Begin;
        private System.Windows.Forms.TextBox textBox_Content;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Cookie;
    }
}


namespace QQ_AddFriend_V0._1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_open = new System.Windows.Forms.Button();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.listView_QQ_List = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_QQ_Need_Add = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_begin = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_Show = new System.Windows.Forms.TextBox();
            this.openFileDialog_QQList = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button_OpenProxyFile = new System.Windows.Forms.Button();
            this.button_CheckProxy = new System.Windows.Forms.Button();
            this.button_SetProxy = new System.Windows.Forms.Button();
            this.button_CleanProxy = new System.Windows.Forms.Button();
            this.openFileDialog_ProxyList = new System.Windows.Forms.OpenFileDialog();
            this.button_setProxyCicle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_open);
            this.groupBox1.Controls.Add(this.textBox_FileName);
            this.groupBox1.Controls.Add(this.listView_QQ_List);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 291);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信封：";
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(288, 21);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 2;
            this.button_open.Text = "导入";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Location = new System.Drawing.Point(7, 21);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(275, 21);
            this.textBox_FileName.TabIndex = 1;
            // 
            // listView_QQ_List
            // 
            this.listView_QQ_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView_QQ_List.Location = new System.Drawing.Point(7, 43);
            this.listView_QQ_List.Name = "listView_QQ_List";
            this.listView_QQ_List.Size = new System.Drawing.Size(356, 242);
            this.listView_QQ_List.TabIndex = 0;
            this.listView_QQ_List.UseCompatibleStateImageBehavior = false;
            this.listView_QQ_List.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "QQ号";
            this.columnHeader2.Width = 98;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "密码";
            this.columnHeader3.Width = 127;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "状态";
            this.columnHeader4.Width = 64;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox_QQ_Need_Add);
            this.groupBox2.Location = new System.Drawing.Point(13, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 56);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "要加的号码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "QQ号：";
            // 
            // textBox_QQ_Need_Add
            // 
            this.textBox_QQ_Need_Add.Location = new System.Drawing.Point(53, 22);
            this.textBox_QQ_Need_Add.Name = "textBox_QQ_Need_Add";
            this.textBox_QQ_Need_Add.Size = new System.Drawing.Size(112, 21);
            this.textBox_QQ_Need_Add.TabIndex = 0;
            this.textBox_QQ_Need_Add.Text = "188808555";
            this.textBox_QQ_Need_Add.Leave += new System.EventHandler(this.textBox_QQ_Need_Add_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_stop);
            this.groupBox3.Controls.Add(this.button_begin);
            this.groupBox3.Location = new System.Drawing.Point(211, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 56);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "启动：";
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(88, 21);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 1;
            this.button_stop.Text = "停止";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_begin
            // 
            this.button_begin.Location = new System.Drawing.Point(7, 21);
            this.button_begin.Name = "button_begin";
            this.button_begin.Size = new System.Drawing.Size(75, 23);
            this.button_begin.TabIndex = 0;
            this.button_begin.Text = "启动";
            this.button_begin.UseVisualStyleBackColor = true;
            this.button_begin.Click += new System.EventHandler(this.button_begin_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_Show);
            this.groupBox4.Location = new System.Drawing.Point(390, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(187, 353);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "状态";
            // 
            // textBox_Show
            // 
            this.textBox_Show.Location = new System.Drawing.Point(8, 21);
            this.textBox_Show.Multiline = true;
            this.textBox_Show.Name = "textBox_Show";
            this.textBox_Show.ReadOnly = true;
            this.textBox_Show.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Show.Size = new System.Drawing.Size(171, 319);
            this.textBox_Show.TabIndex = 0;
            // 
            // openFileDialog_QQList
            // 
            this.openFileDialog_QQList.FileName = "QQ.txt";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listView1);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Location = new System.Drawing.Point(583, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(260, 353);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "代理列表";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(182, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "无";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前代理：";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.Location = new System.Drawing.Point(7, 49);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(247, 292);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "序号";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "IP";
            this.columnHeader6.Width = 132;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "状态";
            this.columnHeader7.Width = 47;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button_setProxyCicle);
            this.groupBox6.Controls.Add(this.button_CleanProxy);
            this.groupBox6.Controls.Add(this.button_SetProxy);
            this.groupBox6.Controls.Add(this.button_CheckProxy);
            this.groupBox6.Controls.Add(this.button_OpenProxyFile);
            this.groupBox6.Location = new System.Drawing.Point(852, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(90, 353);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            // 
            // button_OpenProxyFile
            // 
            this.button_OpenProxyFile.Location = new System.Drawing.Point(5, 20);
            this.button_OpenProxyFile.Name = "button_OpenProxyFile";
            this.button_OpenProxyFile.Size = new System.Drawing.Size(75, 23);
            this.button_OpenProxyFile.TabIndex = 0;
            this.button_OpenProxyFile.Text = "导入代理";
            this.button_OpenProxyFile.UseVisualStyleBackColor = true;
            // 
            // button_CheckProxy
            // 
            this.button_CheckProxy.Location = new System.Drawing.Point(5, 93);
            this.button_CheckProxy.Name = "button_CheckProxy";
            this.button_CheckProxy.Size = new System.Drawing.Size(75, 23);
            this.button_CheckProxy.TabIndex = 1;
            this.button_CheckProxy.Text = "验证代理";
            this.button_CheckProxy.UseVisualStyleBackColor = true;
            // 
            // button_SetProxy
            // 
            this.button_SetProxy.Location = new System.Drawing.Point(5, 166);
            this.button_SetProxy.Name = "button_SetProxy";
            this.button_SetProxy.Size = new System.Drawing.Size(75, 23);
            this.button_SetProxy.TabIndex = 2;
            this.button_SetProxy.Text = "设置代理";
            this.button_SetProxy.UseVisualStyleBackColor = true;
            // 
            // button_CleanProxy
            // 
            this.button_CleanProxy.Location = new System.Drawing.Point(5, 312);
            this.button_CleanProxy.Name = "button_CleanProxy";
            this.button_CleanProxy.Size = new System.Drawing.Size(75, 23);
            this.button_CleanProxy.TabIndex = 3;
            this.button_CleanProxy.Text = "清空代理";
            this.button_CleanProxy.UseVisualStyleBackColor = true;
            // 
            // openFileDialog_ProxyList
            // 
            this.openFileDialog_ProxyList.FileName = "Proxy.txt";
            // 
            // button_setProxyCicle
            // 
            this.button_setProxyCicle.Location = new System.Drawing.Point(7, 239);
            this.button_setProxyCicle.Name = "button_setProxyCicle";
            this.button_setProxyCicle.Size = new System.Drawing.Size(75, 23);
            this.button_setProxyCicle.TabIndex = 4;
            this.button_setProxyCicle.Text = "循环代理";
            this.button_setProxyCicle.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 373);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.ListView listView_QQ_List;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_QQ_Need_Add;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_begin;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_Show;
        private System.Windows.Forms.OpenFileDialog openFileDialog_QQList;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button_CleanProxy;
        private System.Windows.Forms.Button button_SetProxy;
        private System.Windows.Forms.Button button_CheckProxy;
        private System.Windows.Forms.Button button_OpenProxyFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog_ProxyList;
        private System.Windows.Forms.Button button_setProxyCicle;

    }
}


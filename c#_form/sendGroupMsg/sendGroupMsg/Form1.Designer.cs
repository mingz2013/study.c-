namespace sendGroupMsg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_login = new System.Windows.Forms.Button();
            this.linkLabel_verify = new System.Windows.Forms.LinkLabel();
            this.pictureBox_verifycode = new System.Windows.Forms.PictureBox();
            this.textBox_verifycode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_QQNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_GroupList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_Picture = new System.Windows.Forms.Button();
            this.button_send = new System.Windows.Forms.Button();
            this.richTextBox_Msg = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.openFileDialog_openimage = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_verifycode)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_login);
            this.groupBox1.Controls.Add(this.linkLabel_verify);
            this.groupBox1.Controls.Add(this.pictureBox_verifycode);
            this.groupBox1.Controls.Add(this.textBox_verifycode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Pwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_QQNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登陆";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(6, 181);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(168, 23);
            this.button_login.TabIndex = 8;
            this.button_login.Text = "登录";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // linkLabel_verify
            // 
            this.linkLabel_verify.AutoSize = true;
            this.linkLabel_verify.Location = new System.Drawing.Point(135, 128);
            this.linkLabel_verify.Name = "linkLabel_verify";
            this.linkLabel_verify.Size = new System.Drawing.Size(41, 12);
            this.linkLabel_verify.TabIndex = 7;
            this.linkLabel_verify.TabStop = true;
            this.linkLabel_verify.Text = "换一张";
            this.linkLabel_verify.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_verify_LinkClicked);
            // 
            // pictureBox_verifycode
            // 
            this.pictureBox_verifycode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_verifycode.Location = new System.Drawing.Point(6, 82);
            this.pictureBox_verifycode.Name = "pictureBox_verifycode";
            this.pictureBox_verifycode.Size = new System.Drawing.Size(122, 59);
            this.pictureBox_verifycode.TabIndex = 6;
            this.pictureBox_verifycode.TabStop = false;
            this.pictureBox_verifycode.Click += new System.EventHandler(this.pictureBox_verifycode_Click);
            // 
            // textBox_verifycode
            // 
            this.textBox_verifycode.Location = new System.Drawing.Point(58, 154);
            this.textBox_verifycode.Name = "textBox_verifycode";
            this.textBox_verifycode.Size = new System.Drawing.Size(116, 21);
            this.textBox_verifycode.TabIndex = 5;
            this.textBox_verifycode.Leave += new System.EventHandler(this.textBox_verifycode_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "验证码：";
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Location = new System.Drawing.Point(58, 52);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.PasswordChar = '*';
            this.textBox_Pwd.Size = new System.Drawing.Size(116, 21);
            this.textBox_Pwd.TabIndex = 3;
            this.textBox_Pwd.Leave += new System.EventHandler(this.textBox_Pwd_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密  码：";
            // 
            // textBox_QQNumber
            // 
            this.textBox_QQNumber.Location = new System.Drawing.Point(58, 20);
            this.textBox_QQNumber.Name = "textBox_QQNumber";
            this.textBox_QQNumber.Size = new System.Drawing.Size(116, 21);
            this.textBox_QQNumber.TabIndex = 1;
            this.textBox_QQNumber.Leave += new System.EventHandler(this.textBox_QQNumber_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "账  号：";
            // 
            // listView_GroupList
            // 
            this.listView_GroupList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView_GroupList.Location = new System.Drawing.Point(6, 19);
            this.listView_GroupList.Name = "listView_GroupList";
            this.listView_GroupList.Size = new System.Drawing.Size(150, 356);
            this.listView_GroupList.TabIndex = 1;
            this.listView_GroupList.UseCompatibleStateImageBehavior = false;
            this.listView_GroupList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "QQ群";
            this.columnHeader2.Width = 100;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView_GroupList);
            this.groupBox2.Location = new System.Drawing.Point(206, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 381);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QQ群";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_Picture);
            this.groupBox3.Controls.Add(this.button_send);
            this.groupBox3.Controls.Add(this.richTextBox_Msg);
            this.groupBox3.Location = new System.Drawing.Point(382, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(369, 381);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "消息";
            // 
            // button_Picture
            // 
            this.button_Picture.Location = new System.Drawing.Point(6, 17);
            this.button_Picture.Name = "button_Picture";
            this.button_Picture.Size = new System.Drawing.Size(75, 23);
            this.button_Picture.TabIndex = 2;
            this.button_Picture.Text = "插入图片";
            this.button_Picture.UseVisualStyleBackColor = true;
            this.button_Picture.Click += new System.EventHandler(this.button_Picture_Click);
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(6, 352);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(357, 23);
            this.button_send.TabIndex = 1;
            this.button_send.Text = "向所有群发送";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // richTextBox_Msg
            // 
            this.richTextBox_Msg.Location = new System.Drawing.Point(6, 46);
            this.richTextBox_Msg.Name = "richTextBox_Msg";
            this.richTextBox_Msg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox_Msg.Size = new System.Drawing.Size(357, 296);
            this.richTextBox_Msg.TabIndex = 0;
            this.richTextBox_Msg.Text = "哈哈";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_Log);
            this.groupBox4.Location = new System.Drawing.Point(13, 233);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(187, 161);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "系统日志";
            // 
            // textBox_Log
            // 
            this.textBox_Log.Location = new System.Drawing.Point(7, 20);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ReadOnly = true;
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Log.Size = new System.Drawing.Size(168, 135);
            this.textBox_Log.TabIndex = 0;
            // 
            // openFileDialog_openimage
            // 
            this.openFileDialog_openimage.FileName = "picture";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 406);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_verifycode)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.LinkLabel linkLabel_verify;
        private System.Windows.Forms.PictureBox pictureBox_verifycode;
        private System.Windows.Forms.TextBox textBox_verifycode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_QQNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_GroupList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.RichTextBox richTextBox_Msg;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.Button button_Picture;
        private System.Windows.Forms.OpenFileDialog openFileDialog_openimage;
    }
}


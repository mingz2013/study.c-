namespace Qzone_Add_Friend
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
            this.button_Login = new System.Windows.Forms.Button();
            this.linkLabel_Change_Verify = new System.Windows.Forms.LinkLabel();
            this.pictureBox_verify = new System.Windows.Forms.PictureBox();
            this.textBox_Verify = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.textBox_QQNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_ShowLog = new System.Windows.Forms.TextBox();
            this.textBox_Nick = new System.Windows.Forms.TextBox();
            this.textBox_otherQQ = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_AddFriend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_send = new System.Windows.Forms.Button();
            this.textBox_Msg = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_skey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_verify)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Login);
            this.groupBox1.Controls.Add(this.linkLabel_Change_Verify);
            this.groupBox1.Controls.Add(this.pictureBox_verify);
            this.groupBox1.Controls.Add(this.textBox_Verify);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Pwd);
            this.groupBox1.Controls.Add(this.textBox_QQNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录空间";
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(212, 87);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(171, 23);
            this.button_Login.TabIndex = 8;
            this.button_Login.Text = "登录";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // linkLabel_Change_Verify
            // 
            this.linkLabel_Change_Verify.AutoSize = true;
            this.linkLabel_Change_Verify.Location = new System.Drawing.Point(342, 69);
            this.linkLabel_Change_Verify.Name = "linkLabel_Change_Verify";
            this.linkLabel_Change_Verify.Size = new System.Drawing.Size(41, 12);
            this.linkLabel_Change_Verify.TabIndex = 7;
            this.linkLabel_Change_Verify.TabStop = true;
            this.linkLabel_Change_Verify.Text = "换一张";
            this.linkLabel_Change_Verify.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Change_Verify_LinkClicked);
            // 
            // pictureBox_verify
            // 
            this.pictureBox_verify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_verify.Location = new System.Drawing.Point(212, 17);
            this.pictureBox_verify.Name = "pictureBox_verify";
            this.pictureBox_verify.Size = new System.Drawing.Size(124, 64);
            this.pictureBox_verify.TabIndex = 6;
            this.pictureBox_verify.TabStop = false;
            this.pictureBox_verify.Click += new System.EventHandler(this.pictureBox_verify_Click);
            // 
            // textBox_Verify
            // 
            this.textBox_Verify.Location = new System.Drawing.Point(55, 87);
            this.textBox_Verify.Name = "textBox_Verify";
            this.textBox_Verify.Size = new System.Drawing.Size(141, 21);
            this.textBox_Verify.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "验证码：";
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Location = new System.Drawing.Point(54, 52);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.PasswordChar = '*';
            this.textBox_Pwd.Size = new System.Drawing.Size(142, 21);
            this.textBox_Pwd.TabIndex = 3;
            // 
            // textBox_QQNumber
            // 
            this.textBox_QQNumber.Location = new System.Drawing.Point(54, 17);
            this.textBox_QQNumber.Name = "textBox_QQNumber";
            this.textBox_QQNumber.Size = new System.Drawing.Size(142, 21);
            this.textBox_QQNumber.TabIndex = 2;
            this.textBox_QQNumber.Leave += new System.EventHandler(this.textBox_QQNumber_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "账  号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_ShowLog);
            this.groupBox2.Controls.Add(this.textBox_Nick);
            this.groupBox2.Location = new System.Drawing.Point(433, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 115);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "系统信息";
            // 
            // textBox_ShowLog
            // 
            this.textBox_ShowLog.Location = new System.Drawing.Point(7, 56);
            this.textBox_ShowLog.Multiline = true;
            this.textBox_ShowLog.Name = "textBox_ShowLog";
            this.textBox_ShowLog.ReadOnly = true;
            this.textBox_ShowLog.Size = new System.Drawing.Size(299, 47);
            this.textBox_ShowLog.TabIndex = 1;
            // 
            // textBox_Nick
            // 
            this.textBox_Nick.Location = new System.Drawing.Point(7, 16);
            this.textBox_Nick.Multiline = true;
            this.textBox_Nick.Name = "textBox_Nick";
            this.textBox_Nick.ReadOnly = true;
            this.textBox_Nick.Size = new System.Drawing.Size(299, 33);
            this.textBox_Nick.TabIndex = 0;
            // 
            // textBox_otherQQ
            // 
            this.textBox_otherQQ.Location = new System.Drawing.Point(72, 26);
            this.textBox_otherQQ.Name = "textBox_otherQQ";
            this.textBox_otherQQ.Size = new System.Drawing.Size(124, 21);
            this.textBox_otherQQ.TabIndex = 2;
            this.textBox_otherQQ.Leave += new System.EventHandler(this.textBox_otherQQ_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_AddFriend);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox_otherQQ);
            this.groupBox3.Location = new System.Drawing.Point(13, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 64);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "加好友";
            // 
            // button_AddFriend
            // 
            this.button_AddFriend.Location = new System.Drawing.Point(212, 25);
            this.button_AddFriend.Name = "button_AddFriend";
            this.button_AddFriend.Size = new System.Drawing.Size(170, 23);
            this.button_AddFriend.TabIndex = 4;
            this.button_AddFriend.Text = "加好友";
            this.button_AddFriend.UseVisualStyleBackColor = true;
            this.button_AddFriend.Click += new System.EventHandler(this.button_AddFriend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "对方号码：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_send);
            this.groupBox4.Controls.Add(this.textBox_Msg);
            this.groupBox4.Location = new System.Drawing.Point(13, 235);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(388, 125);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发布说说";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(308, 96);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 1;
            this.button_send.Text = "发布";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox_Msg
            // 
            this.textBox_Msg.Location = new System.Drawing.Point(6, 19);
            this.textBox_Msg.Multiline = true;
            this.textBox_Msg.Name = "textBox_Msg";
            this.textBox_Msg.Size = new System.Drawing.Size(376, 77);
            this.textBox_Msg.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "计算g_tk";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_skey
            // 
            this.textBox_skey.Location = new System.Drawing.Point(61, 28);
            this.textBox_skey.Name = "textBox_skey";
            this.textBox_skey.Size = new System.Drawing.Size(140, 21);
            this.textBox_skey.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "skey:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.textBox_skey);
            this.groupBox5.Location = new System.Drawing.Point(433, 148);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(312, 64);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "计算g_tk";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 399);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_verify)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.LinkLabel linkLabel_Change_Verify;
        private System.Windows.Forms.PictureBox pictureBox_verify;
        private System.Windows.Forms.TextBox textBox_Verify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.TextBox textBox_QQNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_ShowLog;
        private System.Windows.Forms.TextBox textBox_Nick;
        private System.Windows.Forms.TextBox textBox_otherQQ;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_AddFriend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_Msg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_skey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}


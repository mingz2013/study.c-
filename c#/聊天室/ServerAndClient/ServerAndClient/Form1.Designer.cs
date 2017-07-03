namespace ServerAndClient
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
            this.button_create = new System.Windows.Forms.Button();
            this.button_join = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_create
            // 
            this.button_create.Location = new System.Drawing.Point(104, 35);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(132, 52);
            this.button_create.TabIndex = 0;
            this.button_create.Text = "创建网络";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // button_join
            // 
            this.button_join.Location = new System.Drawing.Point(104, 131);
            this.button_join.Name = "button_join";
            this.button_join.Size = new System.Drawing.Size(132, 52);
            this.button_join.TabIndex = 1;
            this.button_join.Text = "加入网络";
            this.button_join.UseVisualStyleBackColor = true;
            this.button_join.Click += new System.EventHandler(this.button_join_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(104, 221);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(132, 52);
            this.button_exit.TabIndex = 2;
            this.button_exit.Text = "退出程序";
            this.button_exit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 321);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_join);
            this.Controls.Add(this.button_create);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_join;
        private System.Windows.Forms.Button button_exit;
    }
}


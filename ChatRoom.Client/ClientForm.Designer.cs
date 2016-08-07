namespace ChatRoom.Client
{
    public partial class ClientForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox_hide = new System.Windows.Forms.TextBox();
            this.label_hide = new System.Windows.Forms.Label();
            this.button_Register = new System.Windows.Forms.Button();
            this.button_Login = new System.Windows.Forms.Button();
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_CLIENT_MSG = new System.Windows.Forms.TextBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_CLIENT_SEND_MSG = new System.Windows.Forms.TextBox();
            this.comboBox_USER_LIST = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_SEND = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 179);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox_CLIENT_MSG);
            this.splitContainer1.Size = new System.Drawing.Size(697, 179);
            this.splitContainer1.SplitterDistance = 254;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox_hide);
            this.panel3.Controls.Add(this.label_hide);
            this.panel3.Controls.Add(this.button_Register);
            this.panel3.Controls.Add(this.button_Login);
            this.panel3.Controls.Add(this.textBox_Pwd);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.textBox_UserName);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 179);
            this.panel3.TabIndex = 0;
            // 
            // textBox_hide
            // 
            this.textBox_hide.Location = new System.Drawing.Point(106, 9);
            this.textBox_hide.Name = "textBox_hide";
            this.textBox_hide.ReadOnly = true;
            this.textBox_hide.Size = new System.Drawing.Size(100, 21);
            this.textBox_hide.TabIndex = 7;
            // 
            // label_hide
            // 
            this.label_hide.AutoSize = true;
            this.label_hide.Location = new System.Drawing.Point(47, 13);
            this.label_hide.Name = "label_hide";
            this.label_hide.Size = new System.Drawing.Size(65, 12);
            this.label_hide.TabIndex = 6;
            this.label_hide.Text = "当前用户：";
            // 
            // button_Register
            // 
            this.button_Register.Location = new System.Drawing.Point(155, 127);
            this.button_Register.Name = "button_Register";
            this.button_Register.Size = new System.Drawing.Size(60, 23);
            this.button_Register.TabIndex = 5;
            this.button_Register.Text = "注册";
            this.button_Register.UseVisualStyleBackColor = true;
            this.button_Register.Click += new System.EventHandler(this.button_Register_Click);
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(68, 127);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(60, 23);
            this.button_Login.TabIndex = 4;
            this.button_Login.Text = "登录";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Location = new System.Drawing.Point(69, 73);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.PasswordChar = '*';
            this.textBox_Pwd.Size = new System.Drawing.Size(147, 21);
            this.textBox_Pwd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密  码：";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(69, 34);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(147, 21);
            this.textBox_UserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户名：";
            // 
            // textBox_CLIENT_MSG
            // 
            this.textBox_CLIENT_MSG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_CLIENT_MSG.Location = new System.Drawing.Point(0, 0);
            this.textBox_CLIENT_MSG.Multiline = true;
            this.textBox_CLIENT_MSG.Name = "textBox_CLIENT_MSG";
            this.textBox_CLIENT_MSG.Size = new System.Drawing.Size(439, 179);
            this.textBox_CLIENT_MSG.TabIndex = 0;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(625, 273);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(60, 23);
            this.button_Cancel.TabIndex = 6;
            this.button_Cancel.Text = "退出";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_CLIENT_SEND_MSG);
            this.panel2.Location = new System.Drawing.Point(0, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 121);
            this.panel2.TabIndex = 1;
            // 
            // textBox_CLIENT_SEND_MSG
            // 
            this.textBox_CLIENT_SEND_MSG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_CLIENT_SEND_MSG.Location = new System.Drawing.Point(0, 0);
            this.textBox_CLIENT_SEND_MSG.Multiline = true;
            this.textBox_CLIENT_SEND_MSG.Name = "textBox_CLIENT_SEND_MSG";
            this.textBox_CLIENT_SEND_MSG.Size = new System.Drawing.Size(320, 121);
            this.textBox_CLIENT_SEND_MSG.TabIndex = 0;
            // 
            // comboBox_USER_LIST
            // 
            this.comboBox_USER_LIST.FormattingEnabled = true;
            this.comboBox_USER_LIST.Location = new System.Drawing.Point(390, 189);
            this.comboBox_USER_LIST.Name = "comboBox_USER_LIST";
            this.comboBox_USER_LIST.Size = new System.Drawing.Size(158, 20);
            this.comboBox_USER_LIST.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "TO:";
            // 
            // button_SEND
            // 
            this.button_SEND.Location = new System.Drawing.Point(349, 273);
            this.button_SEND.Name = "button_SEND";
            this.button_SEND.Size = new System.Drawing.Size(150, 23);
            this.button_SEND.TabIndex = 4;
            this.button_SEND.Text = "发送";
            this.button_SEND.UseVisualStyleBackColor = true;
            this.button_SEND.Click += new System.EventHandler(this.button_SEND_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 308);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_SEND);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_USER_LIST);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户端";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_CLIENT_SEND_MSG;
        private System.Windows.Forms.ComboBox comboBox_USER_LIST;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_SEND;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        System.Windows.Forms.TextBox textBox_CLIENT_MSG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Register;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.TextBox textBox_hide;
        private System.Windows.Forms.Label label_hide;
    }
}


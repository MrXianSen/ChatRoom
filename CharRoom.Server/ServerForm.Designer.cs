namespace ChatRoom.Server
{
    partial class ServerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox_MSG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_SERVER_IP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_SERVER_PORT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ONLINE_COUNT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox_ONLINE_COUNT);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_SERVER_PORT);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_SERVER_IP);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox_MSG);
            this.splitContainer1.Size = new System.Drawing.Size(549, 333);
            this.splitContainer1.SplitterDistance = 147;
            this.splitContainer1.TabIndex = 0;
            // 
            // textBox_MSG
            // 
            this.textBox_MSG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_MSG.Location = new System.Drawing.Point(0, 0);
            this.textBox_MSG.Multiline = true;
            this.textBox_MSG.Name = "textBox_MSG";
            this.textBox_MSG.ReadOnly = true;
            this.textBox_MSG.Size = new System.Drawing.Size(398, 333);
            this.textBox_MSG.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前IP地址：";
            // 
            // textBox_SERVER_IP
            // 
            this.textBox_SERVER_IP.Location = new System.Drawing.Point(10, 25);
            this.textBox_SERVER_IP.Name = "textBox_SERVER_IP";
            this.textBox_SERVER_IP.ReadOnly = true;
            this.textBox_SERVER_IP.Size = new System.Drawing.Size(123, 21);
            this.textBox_SERVER_IP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口：";
            // 
            // textBox_SERVER_PORT
            // 
            this.textBox_SERVER_PORT.Location = new System.Drawing.Point(44, 55);
            this.textBox_SERVER_PORT.Name = "textBox_SERVER_PORT";
            this.textBox_SERVER_PORT.ReadOnly = true;
            this.textBox_SERVER_PORT.Size = new System.Drawing.Size(89, 21);
            this.textBox_SERVER_PORT.TabIndex = 3;
            this.textBox_SERVER_PORT.Text = "9000";
            this.textBox_SERVER_PORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "当前在线人数：";
            // 
            // textBox_ONLINE_COUNT
            // 
            this.textBox_ONLINE_COUNT.Location = new System.Drawing.Point(92, 85);
            this.textBox_ONLINE_COUNT.Name = "textBox_ONLINE_COUNT";
            this.textBox_ONLINE_COUNT.ReadOnly = true;
            this.textBox_ONLINE_COUNT.Size = new System.Drawing.Size(41, 21);
            this.textBox_ONLINE_COUNT.TabIndex = 5;
            this.textBox_ONLINE_COUNT.Text = "0";
            this.textBox_ONLINE_COUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 333);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TextBox textBox_MSG;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox_SERVER_IP;
        public System.Windows.Forms.TextBox textBox_SERVER_PORT;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox_ONLINE_COUNT;
        public System.Windows.Forms.Label label3;
    }
}


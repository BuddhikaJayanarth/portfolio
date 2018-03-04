namespace megacoolnew
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.login_tb_username = new System.Windows.Forms.TextBox();
            this.login_tb_password = new System.Windows.Forms.TextBox();
            this.loginbtn = new System.Windows.Forms.Button();
            this.minimize = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(49, 128);
            this.username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(91, 20);
            this.username.TabIndex = 5;
            this.username.Text = "Username :";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(49, 214);
            this.password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(86, 20);
            this.password.TabIndex = 6;
            this.password.Text = "Password :";
            // 
            // login_tb_username
            // 
            this.login_tb_username.Location = new System.Drawing.Point(53, 168);
            this.login_tb_username.Margin = new System.Windows.Forms.Padding(4);
            this.login_tb_username.Name = "login_tb_username";
            this.login_tb_username.Size = new System.Drawing.Size(202, 22);
            this.login_tb_username.TabIndex = 7;
            // 
            // login_tb_password
            // 
            this.login_tb_password.Location = new System.Drawing.Point(53, 251);
            this.login_tb_password.Margin = new System.Windows.Forms.Padding(4);
            this.login_tb_password.Name = "login_tb_password";
            this.login_tb_password.PasswordChar = '●';
            this.login_tb_password.Size = new System.Drawing.Size(202, 22);
            this.login_tb_password.TabIndex = 8;
            this.login_tb_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.login_tb_password_KeyPress);
            // 
            // loginbtn
            // 
            this.loginbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbtn.Location = new System.Drawing.Point(88, 326);
            this.loginbtn.Margin = new System.Windows.Forms.Padding(4);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(121, 43);
            this.loginbtn.TabIndex = 9;
            this.loginbtn.Text = "Login";
            this.loginbtn.UseVisualStyleBackColor = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // minimize
            // 
            this.minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minimize.Image = ((System.Drawing.Image)(resources.GetObject("minimize.Image")));
            this.minimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.minimize.Location = new System.Drawing.Point(246, 0);
            this.minimize.Margin = new System.Windows.Forms.Padding(4);
            this.minimize.MaximumSize = new System.Drawing.Size(37, 34);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(26, 31);
            this.minimize.TabIndex = 14;
            this.minimize.TabStop = false;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            this.minimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.minimize_MouseDown);
            this.minimize.MouseLeave += new System.EventHandler(this.minimize_MouseLeave);
            this.minimize.MouseHover += new System.EventHandler(this.minimize_MouseHover);
            this.minimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.minimize_MouseUp);
            // 
            // close
            // 
            this.close.Image = global::megacoolnew.Properties.Resources.cl_nor;
            this.close.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.close.Location = new System.Drawing.Point(270, 0);
            this.close.Margin = new System.Windows.Forms.Padding(4);
            this.close.MaximumSize = new System.Drawing.Size(37, 34);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(26, 31);
            this.close.TabIndex = 15;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            this.close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.close_MouseDown);
            this.close.MouseLeave += new System.EventHandler(this.close_MouseLeave);
            this.close.MouseHover += new System.EventHandler(this.close_MouseHover);
            this.close.MouseUp += new System.Windows.Forms.MouseEventHandler(this.close_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.minimize);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 33);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 400);
            this.ControlBox = false;
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.login_tb_password);
            this.Controls.Add(this.login_tb_username);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox login_tb_password;
        private System.Windows.Forms.Button loginbtn;
        private System.Windows.Forms.PictureBox minimize;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox login_tb_username;

    }
}
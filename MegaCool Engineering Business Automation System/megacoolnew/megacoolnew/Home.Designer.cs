namespace megacoolnew
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panel1 = new System.Windows.Forms.Panel();
            this.minimize = new System.Windows.Forms.PictureBox();
            this.maximize = new System.Windows.Forms.PictureBox();
            this.restoredown = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logout = new System.Windows.Forms.LinkLabel();
            this.user = new System.Windows.Forms.Label();
            this.welcome = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sales = new System.Windows.Forms.Button();
            this.offside = new System.Windows.Forms.Button();
            this.repair = new System.Windows.Forms.Button();
            this.delivery = new System.Windows.Forms.Button();
            this.buisnessanalysis = new System.Windows.Forms.Button();
            this.stock = new System.Windows.Forms.Button();
            this.customer = new System.Windows.Forms.Button();
            this.staff = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.home_dgv_notification = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.notification = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoredown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.home_dgv_notification)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.minimize);
            this.panel1.Controls.Add(this.maximize);
            this.panel1.Controls.Add(this.restoredown);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            //this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // minimize
            // 
            resources.ApplyResources(this.minimize, "minimize");
            this.minimize.Name = "minimize";
            this.minimize.TabStop = false;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            this.minimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.minimize_MouseDown);
            this.minimize.MouseLeave += new System.EventHandler(this.minimize_MouseLeave);
            this.minimize.MouseHover += new System.EventHandler(this.minimize_MouseHover);
            this.minimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.minimize_MouseUp);
            // 
            // maximize
            // 
            resources.ApplyResources(this.maximize, "maximize");
            this.maximize.Name = "maximize";
            this.maximize.TabStop = false;
            this.maximize.Click += new System.EventHandler(this.maximize_Click);
            this.maximize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.maximize_MouseDown);
            this.maximize.MouseLeave += new System.EventHandler(this.maximize_MouseLeave);
            this.maximize.MouseHover += new System.EventHandler(this.maximize_MouseHover);
            this.maximize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.maximize_MouseUp);
            // 
            // restoredown
            // 
            resources.ApplyResources(this.restoredown, "restoredown");
            this.restoredown.Image = global::megacoolnew.Properties.Resources.res_nor;
            this.restoredown.Name = "restoredown";
            this.restoredown.TabStop = false;
            this.restoredown.Click += new System.EventHandler(this.restoredown_Click);
            this.restoredown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.restoredown_MouseDown);
            this.restoredown.MouseLeave += new System.EventHandler(this.restoredown_MouseLeave);
            this.restoredown.MouseHover += new System.EventHandler(this.restoredown_MouseHover);
            this.restoredown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.restoredown_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::megacoolnew.Properties.Resources.MCE;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // logout
            // 
            resources.ApplyResources(this.logout, "logout");
            this.logout.BackColor = System.Drawing.Color.Transparent;
            this.logout.Name = "logout";
            this.logout.TabStop = true;
            this.logout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logout_LinkClicked);
            // 
            // user
            // 
            resources.ApplyResources(this.user, "user");
            this.user.BackColor = System.Drawing.Color.Transparent;
            this.user.Name = "user";
            // 
            // welcome
            // 
            resources.ApplyResources(this.welcome, "welcome");
            this.welcome.BackColor = System.Drawing.Color.Transparent;
            this.welcome.Name = "welcome";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.sales);
            this.panel2.Controls.Add(this.offside);
            this.panel2.Controls.Add(this.repair);
            this.panel2.Controls.Add(this.delivery);
            this.panel2.Controls.Add(this.buisnessanalysis);
            this.panel2.Controls.Add(this.stock);
            this.panel2.Controls.Add(this.customer);
            this.panel2.Controls.Add(this.staff);
            this.panel2.Name = "panel2";
            // 
            // sales
            // 
            this.sales.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.sales, "sales");
            this.sales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sales.ForeColor = System.Drawing.Color.RoyalBlue;
            this.sales.Name = "sales";
            this.sales.UseVisualStyleBackColor = false;
            this.sales.Click += new System.EventHandler(this.sales_Click);
            // 
            // offside
            // 
            this.offside.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.offside, "offside");
            this.offside.Cursor = System.Windows.Forms.Cursors.Hand;
            this.offside.ForeColor = System.Drawing.Color.RoyalBlue;
            this.offside.Name = "offside";
            this.offside.UseVisualStyleBackColor = false;
            this.offside.Click += new System.EventHandler(this.offside_Click);
            // 
            // repair
            // 
            this.repair.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.repair, "repair");
            this.repair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.repair.ForeColor = System.Drawing.Color.RoyalBlue;
            this.repair.Name = "repair";
            this.repair.UseVisualStyleBackColor = false;
            this.repair.Click += new System.EventHandler(this.repair_Click);
            // 
            // delivery
            // 
            this.delivery.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.delivery, "delivery");
            this.delivery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delivery.ForeColor = System.Drawing.Color.RoyalBlue;
            this.delivery.Name = "delivery";
            this.delivery.UseVisualStyleBackColor = false;
            this.delivery.Click += new System.EventHandler(this.delivery_Click);
            // 
            // buisnessanalysis
            // 
            this.buisnessanalysis.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.buisnessanalysis, "buisnessanalysis");
            this.buisnessanalysis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buisnessanalysis.ForeColor = System.Drawing.Color.RoyalBlue;
            this.buisnessanalysis.Name = "buisnessanalysis";
            this.buisnessanalysis.UseVisualStyleBackColor = false;
            this.buisnessanalysis.Click += new System.EventHandler(this.buisnessanalysis_Click);
            // 
            // stock
            // 
            this.stock.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.stock, "stock");
            this.stock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stock.ForeColor = System.Drawing.Color.RoyalBlue;
            this.stock.Name = "stock";
            this.stock.UseVisualStyleBackColor = false;
            this.stock.Click += new System.EventHandler(this.stock_Click);
            // 
            // customer
            // 
            this.customer.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.customer, "customer");
            this.customer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customer.ForeColor = System.Drawing.Color.RoyalBlue;
            this.customer.Name = "customer";
            this.customer.UseVisualStyleBackColor = false;
            this.customer.Click += new System.EventHandler(this.customer_Click);
            // 
            // staff
            // 
            this.staff.BackColor = System.Drawing.Color.Transparent;
            this.staff.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.staff, "staff");
            this.staff.ForeColor = System.Drawing.Color.RoyalBlue;
            this.staff.Name = "staff";
            this.staff.UseVisualStyleBackColor = false;
            this.staff.Click += new System.EventHandler(this.staff_Click);
            // 
            // panel6
            // 
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Controls.Add(this.home_dgv_notification);
            this.panel6.Name = "panel6";
            // 
            // home_dgv_notification
            // 
            this.home_dgv_notification.AllowUserToAddRows = false;
            this.home_dgv_notification.AllowUserToDeleteRows = false;
            this.home_dgv_notification.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.home_dgv_notification.BackgroundColor = System.Drawing.Color.White;
            this.home_dgv_notification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.home_dgv_notification.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            resources.ApplyResources(this.home_dgv_notification, "home_dgv_notification");
            this.home_dgv_notification.MultiSelect = false;
            this.home_dgv_notification.Name = "home_dgv_notification";
            this.home_dgv_notification.ReadOnly = true;
            this.home_dgv_notification.RowHeadersVisible = false;
            this.home_dgv_notification.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.home_dgv_notification.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.home_dgv_notification_CellContentDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Notification";
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Category";
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Clearancelevel";
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BackgroundImage = global::megacoolnew.Properties.Resources.panel;
            this.panel3.Name = "panel3";
            // 
            // notification
            // 
            resources.ApplyResources(this.notification, "notification");
            this.notification.BackColor = System.Drawing.Color.Transparent;
            this.notification.Name = "notification";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Home
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::megacoolnew.Properties.Resources.bak2;
            this.ControlBox = false;
            this.Controls.Add(this.notification);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.user);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.welcome);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoredown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.home_dgv_notification)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.LinkLabel logout;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.Button sales;
        private System.Windows.Forms.Button offside;
        private System.Windows.Forms.Button repair;
        private System.Windows.Forms.Button delivery;
        private System.Windows.Forms.Button stock;
        private System.Windows.Forms.Button customer;
        private System.Windows.Forms.Button staff;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox restoredown;
        private System.Windows.Forms.PictureBox minimize;
        private System.Windows.Forms.PictureBox maximize;
        private System.Windows.Forms.Label notification;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView home_dgv_notification;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buisnessanalysis;
    }
}
namespace megacoolnew
{
    partial class customer
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
            this.tab_loyalitycard = new System.Windows.Forms.TabPage();
            this.gp_loyaltycard = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_loy_selectCardType = new System.Windows.Forms.ComboBox();
            this.dgv_loyalty_table = new System.Windows.Forms.DataGridView();
            this.gpb_cuc_loyalty = new System.Windows.Forms.GroupBox();
            this.btn_cusLoy_clear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_loymem_cardno = new System.Windows.Forms.Label();
            this.btn_loy_update = new System.Windows.Forms.Button();
            this.btn_loy_delete = new System.Windows.Forms.Button();
            this.btn_loy_add = new System.Windows.Forms.Button();
            this.cmb_loy_cardtype = new System.Windows.Forms.ComboBox();
            this.txt_loy_nic = new System.Windows.Forms.TextBox();
            this.lbl_loy_cardtype = new System.Windows.Forms.Label();
            this.lbl_loy_nic = new System.Windows.Forms.Label();
            this.tab_customermanagement = new System.Windows.Forms.TabPage();
            this.gb_cus_Management = new System.Windows.Forms.GroupBox();
            this.lbl_cus_searchkey = new System.Windows.Forms.Label();
            this.txt_cus_searchkey = new System.Windows.Forms.TextBox();
            this.dgv_cus_table = new System.Windows.Forms.DataGridView();
            this.btn_cus_demo = new System.Windows.Forms.Button();
            this.gb_cusdetails = new System.Windows.Forms.GroupBox();
            this.rtb_cus_address = new System.Windows.Forms.RichTextBox();
            this.txtb_cus_nic = new System.Windows.Forms.TextBox();
            this.btn_cus_clear = new System.Windows.Forms.Button();
            this.cmb_cus_type = new System.Windows.Forms.ComboBox();
            this.btn_cus_delete = new System.Windows.Forms.Button();
            this.txtb_cus_email = new System.Windows.Forms.TextBox();
            this.btn_cus_add = new System.Windows.Forms.Button();
            this.txtb_cus_mobileno = new System.Windows.Forms.TextBox();
            this.btn_cus_update = new System.Windows.Forms.Button();
            this.txtb_cus_name = new System.Windows.Forms.TextBox();
            this.lbl_cus_nic = new System.Windows.Forms.Label();
            this.lbl_cus_email = new System.Windows.Forms.Label();
            this.lbl_cus_type = new System.Windows.Forms.Label();
            this.lbl_cus_name = new System.Windows.Forms.Label();
            this.lbl_cus_address = new System.Windows.Forms.Label();
            this.lbl_cus_mobileno = new System.Windows.Forms.Label();
            this.tb_cus_tabcontroller = new System.Windows.Forms.TabControl();
            this.tab_email = new System.Windows.Forms.TabPage();
            this.cmb_email_nic = new System.Windows.Forms.ComboBox();
            this.btn_cusEmail_clear = new System.Windows.Forms.Button();
            this.lbl_email_nic = new System.Windows.Forms.Label();
            this.btn_email_demo = new System.Windows.Forms.Button();
            this.btn_cus_email_send = new System.Windows.Forms.Button();
            this.gp_cus_email2 = new System.Windows.Forms.GroupBox();
            this.rtb_cus_email_body = new System.Windows.Forms.RichTextBox();
            this.gp_cus_email1 = new System.Windows.Forms.GroupBox();
            this.txt_email_subject = new System.Windows.Forms.TextBox();
            this.txt_email_address = new System.Windows.Forms.TextBox();
            this.lbl_cus_email_address = new System.Windows.Forms.Label();
            this.lbl_cus_email_subject = new System.Windows.Forms.Label();
            this.lbl_cus_email_ = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCusRep2 = new System.Windows.Forms.Button();
            this.btnCusRep1 = new System.Windows.Forms.Button();
            this.tab_loyalitycard.SuspendLayout();
            this.gp_loyaltycard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_loyalty_table)).BeginInit();
            this.gpb_cuc_loyalty.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tab_customermanagement.SuspendLayout();
            this.gb_cus_Management.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cus_table)).BeginInit();
            this.gb_cusdetails.SuspendLayout();
            this.tb_cus_tabcontroller.SuspendLayout();
            this.tab_email.SuspendLayout();
            this.gp_cus_email2.SuspendLayout();
            this.gp_cus_email1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_loyalitycard
            // 
            this.tab_loyalitycard.Controls.Add(this.gp_loyaltycard);
            this.tab_loyalitycard.Controls.Add(this.gpb_cuc_loyalty);
            this.tab_loyalitycard.Location = new System.Drawing.Point(4, 32);
            this.tab_loyalitycard.Name = "tab_loyalitycard";
            this.tab_loyalitycard.Padding = new System.Windows.Forms.Padding(3);
            this.tab_loyalitycard.Size = new System.Drawing.Size(862, 602);
            this.tab_loyalitycard.TabIndex = 1;
            this.tab_loyalitycard.Text = "Loyality Card";
            this.tab_loyalitycard.UseVisualStyleBackColor = true;
            this.tab_loyalitycard.Click += new System.EventHandler(this.tab_loyalitycard_Click);
            // 
            // gp_loyaltycard
            // 
            this.gp_loyaltycard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gp_loyaltycard.Controls.Add(this.label1);
            this.gp_loyaltycard.Controls.Add(this.cmb_loy_selectCardType);
            this.gp_loyaltycard.Controls.Add(this.dgv_loyalty_table);
            this.gp_loyaltycard.Location = new System.Drawing.Point(16, 212);
            this.gp_loyaltycard.Name = "gp_loyaltycard";
            this.gp_loyaltycard.Size = new System.Drawing.Size(830, 330);
            this.gp_loyaltycard.TabIndex = 23;
            this.gp_loyaltycard.TabStop = false;
            this.gp_loyaltycard.Text = "Loyalty Card";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Select Card Type";
            // 
            // cmb_loy_selectCardType
            // 
            this.cmb_loy_selectCardType.FormattingEnabled = true;
            this.cmb_loy_selectCardType.Items.AddRange(new object[] {
            "All",
            "Gold Customers",
            "Silver Customers",
            "Bronze Customers"});
            this.cmb_loy_selectCardType.Location = new System.Drawing.Point(161, 24);
            this.cmb_loy_selectCardType.Name = "cmb_loy_selectCardType";
            this.cmb_loy_selectCardType.Size = new System.Drawing.Size(121, 28);
            this.cmb_loy_selectCardType.TabIndex = 31;
            this.cmb_loy_selectCardType.Text = "All";
            this.cmb_loy_selectCardType.SelectedIndexChanged += new System.EventHandler(this.combo_grid_SelectedIndexChanged);
            // 
            // dgv_loyalty_table
            // 
            this.dgv_loyalty_table.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_loyalty_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_loyalty_table.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_loyalty_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_loyalty_table.Location = new System.Drawing.Point(6, 58);
            this.dgv_loyalty_table.Name = "dgv_loyalty_table";
            this.dgv_loyalty_table.ReadOnly = true;
            this.dgv_loyalty_table.Size = new System.Drawing.Size(818, 266);
            this.dgv_loyalty_table.TabIndex = 21;
            this.dgv_loyalty_table.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_loyalty_table_RowHeaderMouseDoubleClick);
            // 
            // gpb_cuc_loyalty
            // 
            this.gpb_cuc_loyalty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpb_cuc_loyalty.Controls.Add(this.btn_cusLoy_clear);
            this.gpb_cuc_loyalty.Controls.Add(this.groupBox1);
            this.gpb_cuc_loyalty.Controls.Add(this.btn_loy_update);
            this.gpb_cuc_loyalty.Controls.Add(this.btn_loy_delete);
            this.gpb_cuc_loyalty.Controls.Add(this.btn_loy_add);
            this.gpb_cuc_loyalty.Controls.Add(this.cmb_loy_cardtype);
            this.gpb_cuc_loyalty.Controls.Add(this.txt_loy_nic);
            this.gpb_cuc_loyalty.Controls.Add(this.lbl_loy_cardtype);
            this.gpb_cuc_loyalty.Controls.Add(this.lbl_loy_nic);
            this.gpb_cuc_loyalty.Location = new System.Drawing.Point(16, 15);
            this.gpb_cuc_loyalty.Name = "gpb_cuc_loyalty";
            this.gpb_cuc_loyalty.Size = new System.Drawing.Size(830, 178);
            this.gpb_cuc_loyalty.TabIndex = 22;
            this.gpb_cuc_loyalty.TabStop = false;
            this.gpb_cuc_loyalty.Text = "Loyalty Details";
            this.gpb_cuc_loyalty.Enter += new System.EventHandler(this.gpb_cuc_loyalty_Enter);
            // 
            // btn_cusLoy_clear
            // 
            this.btn_cusLoy_clear.Location = new System.Drawing.Point(634, 28);
            this.btn_cusLoy_clear.Name = "btn_cusLoy_clear";
            this.btn_cusLoy_clear.Size = new System.Drawing.Size(75, 29);
            this.btn_cusLoy_clear.TabIndex = 39;
            this.btn_cusLoy_clear.Text = "CLEAR";
            this.btn_cusLoy_clear.UseVisualStyleBackColor = true;
            this.btn_cusLoy_clear.Click += new System.EventHandler(this.btn_cusLoy_clear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_loymem_cardno);
            this.groupBox1.Location = new System.Drawing.Point(20, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 57);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Card No";
            // 
            // lbl_loymem_cardno
            // 
            this.lbl_loymem_cardno.AutoSize = true;
            this.lbl_loymem_cardno.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_loymem_cardno.Location = new System.Drawing.Point(43, 22);
            this.lbl_loymem_cardno.Name = "lbl_loymem_cardno";
            this.lbl_loymem_cardno.Size = new System.Drawing.Size(47, 22);
            this.lbl_loymem_cardno.TabIndex = 0;
            this.lbl_loymem_cardno.Text = "click";
            this.lbl_loymem_cardno.Click += new System.EventHandler(this.lbl_loymem_cardno_Click);
            // 
            // btn_loy_update
            // 
            this.btn_loy_update.Location = new System.Drawing.Point(493, 122);
            this.btn_loy_update.Name = "btn_loy_update";
            this.btn_loy_update.Size = new System.Drawing.Size(75, 29);
            this.btn_loy_update.TabIndex = 31;
            this.btn_loy_update.Text = "UPDATE";
            this.btn_loy_update.UseVisualStyleBackColor = true;
            this.btn_loy_update.Click += new System.EventHandler(this.btn_loy_update_Click);
            // 
            // btn_loy_delete
            // 
            this.btn_loy_delete.Location = new System.Drawing.Point(493, 72);
            this.btn_loy_delete.Name = "btn_loy_delete";
            this.btn_loy_delete.Size = new System.Drawing.Size(75, 29);
            this.btn_loy_delete.TabIndex = 30;
            this.btn_loy_delete.Text = "DELETE";
            this.btn_loy_delete.UseVisualStyleBackColor = true;
            this.btn_loy_delete.Click += new System.EventHandler(this.btn_loy_delete_Click);
            // 
            // btn_loy_add
            // 
            this.btn_loy_add.Location = new System.Drawing.Point(493, 28);
            this.btn_loy_add.Name = "btn_loy_add";
            this.btn_loy_add.Size = new System.Drawing.Size(75, 29);
            this.btn_loy_add.TabIndex = 29;
            this.btn_loy_add.Text = "ADD";
            this.btn_loy_add.UseVisualStyleBackColor = true;
            this.btn_loy_add.Click += new System.EventHandler(this.btn_loy_add_Click);
            // 
            // cmb_loy_cardtype
            // 
            this.cmb_loy_cardtype.FormattingEnabled = true;
            this.cmb_loy_cardtype.Location = new System.Drawing.Point(98, 67);
            this.cmb_loy_cardtype.Name = "cmb_loy_cardtype";
            this.cmb_loy_cardtype.Size = new System.Drawing.Size(189, 28);
            this.cmb_loy_cardtype.TabIndex = 33;
            this.cmb_loy_cardtype.SelectedIndexChanged += new System.EventHandler(this.cmb_loy_cardtype_SelectedIndexChanged);
            this.cmb_loy_cardtype.Click += new System.EventHandler(this.cmb_loy_cardtype_Click);
            this.cmb_loy_cardtype.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmb_loy_cardtype_MouseClick);
            // 
            // txt_loy_nic
            // 
            this.txt_loy_nic.Location = new System.Drawing.Point(98, 23);
            this.txt_loy_nic.Name = "txt_loy_nic";
            this.txt_loy_nic.Size = new System.Drawing.Size(189, 26);
            this.txt_loy_nic.TabIndex = 32;
            this.txt_loy_nic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_loy_nic_MouseClick);
            this.txt_loy_nic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loy_nic_KeyDown);
            this.txt_loy_nic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_loy_nic_KeyPress);
            // 
            // lbl_loy_cardtype
            // 
            this.lbl_loy_cardtype.AutoSize = true;
            this.lbl_loy_cardtype.Location = new System.Drawing.Point(16, 75);
            this.lbl_loy_cardtype.Name = "lbl_loy_cardtype";
            this.lbl_loy_cardtype.Size = new System.Drawing.Size(71, 20);
            this.lbl_loy_cardtype.TabIndex = 21;
            this.lbl_loy_cardtype.Text = "Card Type";
            // 
            // lbl_loy_nic
            // 
            this.lbl_loy_nic.AutoSize = true;
            this.lbl_loy_nic.Location = new System.Drawing.Point(16, 28);
            this.lbl_loy_nic.Name = "lbl_loy_nic";
            this.lbl_loy_nic.Size = new System.Drawing.Size(30, 20);
            this.lbl_loy_nic.TabIndex = 13;
            this.lbl_loy_nic.Text = "NIC";
            // 
            // tab_customermanagement
            // 
            this.tab_customermanagement.Controls.Add(this.gb_cus_Management);
            this.tab_customermanagement.Controls.Add(this.btn_cus_demo);
            this.tab_customermanagement.Controls.Add(this.gb_cusdetails);
            this.tab_customermanagement.Location = new System.Drawing.Point(4, 32);
            this.tab_customermanagement.Name = "tab_customermanagement";
            this.tab_customermanagement.Padding = new System.Windows.Forms.Padding(3);
            this.tab_customermanagement.Size = new System.Drawing.Size(862, 602);
            this.tab_customermanagement.TabIndex = 0;
            this.tab_customermanagement.Text = "Customer Management";
            this.tab_customermanagement.UseVisualStyleBackColor = true;
            this.tab_customermanagement.Click += new System.EventHandler(this.tab_customermanagement_Click);
            // 
            // gb_cus_Management
            // 
            this.gb_cus_Management.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_cus_Management.Controls.Add(this.lbl_cus_searchkey);
            this.gb_cus_Management.Controls.Add(this.txt_cus_searchkey);
            this.gb_cus_Management.Controls.Add(this.dgv_cus_table);
            this.gb_cus_Management.Location = new System.Drawing.Point(12, 193);
            this.gb_cus_Management.Name = "gb_cus_Management";
            this.gb_cus_Management.Size = new System.Drawing.Size(830, 298);
            this.gb_cus_Management.TabIndex = 8;
            this.gb_cus_Management.TabStop = false;
            this.gb_cus_Management.Enter += new System.EventHandler(this.gb_cus_Management_Enter);
            // 
            // lbl_cus_searchkey
            // 
            this.lbl_cus_searchkey.AutoSize = true;
            this.lbl_cus_searchkey.Location = new System.Drawing.Point(14, 34);
            this.lbl_cus_searchkey.Name = "lbl_cus_searchkey";
            this.lbl_cus_searchkey.Size = new System.Drawing.Size(167, 20);
            this.lbl_cus_searchkey.TabIndex = 5;
            this.lbl_cus_searchkey.Text = "Search Key ( NIC / Name )";
            // 
            // txt_cus_searchkey
            // 
            this.txt_cus_searchkey.Location = new System.Drawing.Point(184, 28);
            this.txt_cus_searchkey.Name = "txt_cus_searchkey";
            this.txt_cus_searchkey.Size = new System.Drawing.Size(168, 26);
            this.txt_cus_searchkey.TabIndex = 4;
            this.txt_cus_searchkey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cus_searchkey_KeyPress);
            // 
            // dgv_cus_table
            // 
            this.dgv_cus_table.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_cus_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_cus_table.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_cus_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cus_table.Location = new System.Drawing.Point(6, 75);
            this.dgv_cus_table.Name = "dgv_cus_table";
            this.dgv_cus_table.ReadOnly = true;
            this.dgv_cus_table.Size = new System.Drawing.Size(818, 244);
            this.dgv_cus_table.TabIndex = 3;
            this.dgv_cus_table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_cus_CellContentClick);
            this.dgv_cus_table.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_cus_table_RowHeaderMouseDoubleClick);
            // 
            // btn_cus_demo
            // 
            this.btn_cus_demo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cus_demo.Location = new System.Drawing.Point(755, 537);
            this.btn_cus_demo.Name = "btn_cus_demo";
            this.btn_cus_demo.Size = new System.Drawing.Size(75, 29);
            this.btn_cus_demo.TabIndex = 4;
            this.btn_cus_demo.Text = "DEMO";
            this.btn_cus_demo.UseVisualStyleBackColor = true;
            this.btn_cus_demo.Click += new System.EventHandler(this.btn_cus_demo_Click);
            // 
            // gb_cusdetails
            // 
            this.gb_cusdetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_cusdetails.Controls.Add(this.rtb_cus_address);
            this.gb_cusdetails.Controls.Add(this.txtb_cus_nic);
            this.gb_cusdetails.Controls.Add(this.btn_cus_clear);
            this.gb_cusdetails.Controls.Add(this.cmb_cus_type);
            this.gb_cusdetails.Controls.Add(this.btn_cus_delete);
            this.gb_cusdetails.Controls.Add(this.txtb_cus_email);
            this.gb_cusdetails.Controls.Add(this.btn_cus_add);
            this.gb_cusdetails.Controls.Add(this.txtb_cus_mobileno);
            this.gb_cusdetails.Controls.Add(this.btn_cus_update);
            this.gb_cusdetails.Controls.Add(this.txtb_cus_name);
            this.gb_cusdetails.Controls.Add(this.lbl_cus_nic);
            this.gb_cusdetails.Controls.Add(this.lbl_cus_email);
            this.gb_cusdetails.Controls.Add(this.lbl_cus_type);
            this.gb_cusdetails.Controls.Add(this.lbl_cus_name);
            this.gb_cusdetails.Controls.Add(this.lbl_cus_address);
            this.gb_cusdetails.Controls.Add(this.lbl_cus_mobileno);
            this.gb_cusdetails.Location = new System.Drawing.Point(12, 6);
            this.gb_cusdetails.Name = "gb_cusdetails";
            this.gb_cusdetails.Size = new System.Drawing.Size(830, 181);
            this.gb_cusdetails.TabIndex = 7;
            this.gb_cusdetails.TabStop = false;
            this.gb_cusdetails.Text = "Customer Details";
            // 
            // rtb_cus_address
            // 
            this.rtb_cus_address.Location = new System.Drawing.Point(92, 96);
            this.rtb_cus_address.Name = "rtb_cus_address";
            this.rtb_cus_address.Size = new System.Drawing.Size(189, 26);
            this.rtb_cus_address.TabIndex = 4;
            this.rtb_cus_address.Text = "";
            // 
            // txtb_cus_nic
            // 
            this.txtb_cus_nic.Location = new System.Drawing.Point(92, 19);
            this.txtb_cus_nic.Name = "txtb_cus_nic";
            this.txtb_cus_nic.Size = new System.Drawing.Size(189, 26);
            this.txtb_cus_nic.TabIndex = 14;
            this.txtb_cus_nic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_cus_nic_KeyPress);
            // 
            // btn_cus_clear
            // 
            this.btn_cus_clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_cus_clear.Location = new System.Drawing.Point(650, 146);
            this.btn_cus_clear.Name = "btn_cus_clear";
            this.btn_cus_clear.Size = new System.Drawing.Size(75, 29);
            this.btn_cus_clear.TabIndex = 5;
            this.btn_cus_clear.Text = "CLEAR";
            this.btn_cus_clear.UseVisualStyleBackColor = true;
            this.btn_cus_clear.Click += new System.EventHandler(this.btn_cus_clear_Click);
            // 
            // cmb_cus_type
            // 
            this.cmb_cus_type.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmb_cus_type.FormattingEnabled = true;
            this.cmb_cus_type.Location = new System.Drawing.Point(536, 58);
            this.cmb_cus_type.Name = "cmb_cus_type";
            this.cmb_cus_type.Size = new System.Drawing.Size(189, 28);
            this.cmb_cus_type.TabIndex = 13;
            // 
            // btn_cus_delete
            // 
            this.btn_cus_delete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_cus_delete.Location = new System.Drawing.Point(549, 147);
            this.btn_cus_delete.Name = "btn_cus_delete";
            this.btn_cus_delete.Size = new System.Drawing.Size(75, 29);
            this.btn_cus_delete.TabIndex = 6;
            this.btn_cus_delete.Text = "DELETE";
            this.btn_cus_delete.UseVisualStyleBackColor = true;
            this.btn_cus_delete.Click += new System.EventHandler(this.btn_cus_delete_Click);
            // 
            // txtb_cus_email
            // 
            this.txtb_cus_email.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtb_cus_email.Location = new System.Drawing.Point(536, 24);
            this.txtb_cus_email.Name = "txtb_cus_email";
            this.txtb_cus_email.Size = new System.Drawing.Size(189, 26);
            this.txtb_cus_email.TabIndex = 11;
            // 
            // btn_cus_add
            // 
            this.btn_cus_add.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_cus_add.Location = new System.Drawing.Point(348, 147);
            this.btn_cus_add.Name = "btn_cus_add";
            this.btn_cus_add.Size = new System.Drawing.Size(75, 29);
            this.btn_cus_add.TabIndex = 0;
            this.btn_cus_add.Text = "ADD";
            this.btn_cus_add.UseVisualStyleBackColor = true;
            this.btn_cus_add.Click += new System.EventHandler(this.btn_cus_add_Click);
            // 
            // txtb_cus_mobileno
            // 
            this.txtb_cus_mobileno.Location = new System.Drawing.Point(92, 141);
            this.txtb_cus_mobileno.Name = "txtb_cus_mobileno";
            this.txtb_cus_mobileno.Size = new System.Drawing.Size(189, 26);
            this.txtb_cus_mobileno.TabIndex = 10;
            this.txtb_cus_mobileno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_cus_mobileno_KeyPress);
            // 
            // btn_cus_update
            // 
            this.btn_cus_update.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_cus_update.Location = new System.Drawing.Point(450, 147);
            this.btn_cus_update.Name = "btn_cus_update";
            this.btn_cus_update.Size = new System.Drawing.Size(75, 29);
            this.btn_cus_update.TabIndex = 1;
            this.btn_cus_update.Text = "UPDATE";
            this.btn_cus_update.UseVisualStyleBackColor = true;
            this.btn_cus_update.Click += new System.EventHandler(this.btn_cus_update_Click);
            // 
            // txtb_cus_name
            // 
            this.txtb_cus_name.Location = new System.Drawing.Point(92, 60);
            this.txtb_cus_name.Name = "txtb_cus_name";
            this.txtb_cus_name.Size = new System.Drawing.Size(189, 26);
            this.txtb_cus_name.TabIndex = 8;
            // 
            // lbl_cus_nic
            // 
            this.lbl_cus_nic.AutoSize = true;
            this.lbl_cus_nic.Location = new System.Drawing.Point(14, 27);
            this.lbl_cus_nic.Name = "lbl_cus_nic";
            this.lbl_cus_nic.Size = new System.Drawing.Size(30, 20);
            this.lbl_cus_nic.TabIndex = 0;
            this.lbl_cus_nic.Text = "NIC";
            // 
            // lbl_cus_email
            // 
            this.lbl_cus_email.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_cus_email.AutoSize = true;
            this.lbl_cus_email.Location = new System.Drawing.Point(461, 27);
            this.lbl_cus_email.Name = "lbl_cus_email";
            this.lbl_cus_email.Size = new System.Drawing.Size(42, 20);
            this.lbl_cus_email.TabIndex = 4;
            this.lbl_cus_email.Text = "Email";
            this.lbl_cus_email.Click += new System.EventHandler(this.lbl_cus_email_Click);
            // 
            // lbl_cus_type
            // 
            this.lbl_cus_type.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_cus_type.AutoSize = true;
            this.lbl_cus_type.Location = new System.Drawing.Point(464, 66);
            this.lbl_cus_type.Name = "lbl_cus_type";
            this.lbl_cus_type.Size = new System.Drawing.Size(39, 20);
            this.lbl_cus_type.TabIndex = 5;
            this.lbl_cus_type.Text = "Type";
            // 
            // lbl_cus_name
            // 
            this.lbl_cus_name.AutoSize = true;
            this.lbl_cus_name.Location = new System.Drawing.Point(14, 63);
            this.lbl_cus_name.Name = "lbl_cus_name";
            this.lbl_cus_name.Size = new System.Drawing.Size(44, 20);
            this.lbl_cus_name.TabIndex = 1;
            this.lbl_cus_name.Text = "Name";
            this.lbl_cus_name.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_cus_address
            // 
            this.lbl_cus_address.AutoSize = true;
            this.lbl_cus_address.Location = new System.Drawing.Point(14, 104);
            this.lbl_cus_address.Name = "lbl_cus_address";
            this.lbl_cus_address.Size = new System.Drawing.Size(60, 20);
            this.lbl_cus_address.TabIndex = 2;
            this.lbl_cus_address.Text = "Address";
            // 
            // lbl_cus_mobileno
            // 
            this.lbl_cus_mobileno.AutoSize = true;
            this.lbl_cus_mobileno.Location = new System.Drawing.Point(14, 147);
            this.lbl_cus_mobileno.Name = "lbl_cus_mobileno";
            this.lbl_cus_mobileno.Size = new System.Drawing.Size(71, 20);
            this.lbl_cus_mobileno.TabIndex = 3;
            this.lbl_cus_mobileno.Text = "Mobile No";
            // 
            // tb_cus_tabcontroller
            // 
            this.tb_cus_tabcontroller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_cus_tabcontroller.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tb_cus_tabcontroller.Controls.Add(this.tab_customermanagement);
            this.tb_cus_tabcontroller.Controls.Add(this.tab_loyalitycard);
            this.tb_cus_tabcontroller.Controls.Add(this.tab_email);
            this.tb_cus_tabcontroller.Controls.Add(this.tabPage1);
            this.tb_cus_tabcontroller.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_cus_tabcontroller.Location = new System.Drawing.Point(2, 1);
            this.tb_cus_tabcontroller.Name = "tb_cus_tabcontroller";
            this.tb_cus_tabcontroller.SelectedIndex = 0;
            this.tb_cus_tabcontroller.Size = new System.Drawing.Size(870, 638);
            this.tb_cus_tabcontroller.TabIndex = 0;
            this.tb_cus_tabcontroller.Tag = "";
            // 
            // tab_email
            // 
            this.tab_email.Controls.Add(this.cmb_email_nic);
            this.tab_email.Controls.Add(this.btn_cusEmail_clear);
            this.tab_email.Controls.Add(this.lbl_email_nic);
            this.tab_email.Controls.Add(this.btn_email_demo);
            this.tab_email.Controls.Add(this.btn_cus_email_send);
            this.tab_email.Controls.Add(this.gp_cus_email2);
            this.tab_email.Controls.Add(this.gp_cus_email1);
            this.tab_email.Controls.Add(this.lbl_cus_email_);
            this.tab_email.Location = new System.Drawing.Point(4, 32);
            this.tab_email.Name = "tab_email";
            this.tab_email.Padding = new System.Windows.Forms.Padding(3);
            this.tab_email.Size = new System.Drawing.Size(862, 602);
            this.tab_email.TabIndex = 2;
            this.tab_email.Text = "Email";
            this.tab_email.UseVisualStyleBackColor = true;
            this.tab_email.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // cmb_email_nic
            // 
            this.cmb_email_nic.FormattingEnabled = true;
            this.cmb_email_nic.Location = new System.Drawing.Point(148, 6);
            this.cmb_email_nic.Name = "cmb_email_nic";
            this.cmb_email_nic.Size = new System.Drawing.Size(196, 28);
            this.cmb_email_nic.TabIndex = 12;
            // 
            // btn_cusEmail_clear
            // 
            this.btn_cusEmail_clear.Location = new System.Drawing.Point(665, 525);
            this.btn_cusEmail_clear.Name = "btn_cusEmail_clear";
            this.btn_cusEmail_clear.Size = new System.Drawing.Size(75, 30);
            this.btn_cusEmail_clear.TabIndex = 11;
            this.btn_cusEmail_clear.Text = "CLEAR";
            this.btn_cusEmail_clear.UseVisualStyleBackColor = true;
            this.btn_cusEmail_clear.Click += new System.EventHandler(this.btn_cusEmail_clear_Click);
            // 
            // lbl_email_nic
            // 
            this.lbl_email_nic.AutoSize = true;
            this.lbl_email_nic.Location = new System.Drawing.Point(30, 3);
            this.lbl_email_nic.Name = "lbl_email_nic";
            this.lbl_email_nic.Size = new System.Drawing.Size(91, 20);
            this.lbl_email_nic.TabIndex = 9;
            this.lbl_email_nic.Text = "Customer NIC";
            // 
            // btn_email_demo
            // 
            this.btn_email_demo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_email_demo.Location = new System.Drawing.Point(746, 525);
            this.btn_email_demo.Name = "btn_email_demo";
            this.btn_email_demo.Size = new System.Drawing.Size(78, 30);
            this.btn_email_demo.TabIndex = 8;
            this.btn_email_demo.Text = "Demo";
            this.btn_email_demo.UseVisualStyleBackColor = true;
            this.btn_email_demo.Click += new System.EventHandler(this.btn_email_demo_Click);
            // 
            // btn_cus_email_send
            // 
            this.btn_cus_email_send.Location = new System.Drawing.Point(20, 525);
            this.btn_cus_email_send.Name = "btn_cus_email_send";
            this.btn_cus_email_send.Size = new System.Drawing.Size(86, 30);
            this.btn_cus_email_send.TabIndex = 7;
            this.btn_cus_email_send.Text = "Send";
            this.btn_cus_email_send.UseVisualStyleBackColor = true;
            this.btn_cus_email_send.Click += new System.EventHandler(this.btn_cus_email_send_Click);
            // 
            // gp_cus_email2
            // 
            this.gp_cus_email2.Controls.Add(this.rtb_cus_email_body);
            this.gp_cus_email2.Location = new System.Drawing.Point(20, 197);
            this.gp_cus_email2.Name = "gp_cus_email2";
            this.gp_cus_email2.Size = new System.Drawing.Size(900, 320);
            this.gp_cus_email2.TabIndex = 6;
            this.gp_cus_email2.TabStop = false;
            this.gp_cus_email2.Text = "Message Content";
            // 
            // rtb_cus_email_body
            // 
            this.rtb_cus_email_body.Location = new System.Drawing.Point(14, 31);
            this.rtb_cus_email_body.Name = "rtb_cus_email_body";
            this.rtb_cus_email_body.Size = new System.Drawing.Size(870, 299);
            this.rtb_cus_email_body.TabIndex = 0;
            this.rtb_cus_email_body.Text = " ";
            // 
            // gp_cus_email1
            // 
            this.gp_cus_email1.Controls.Add(this.txt_email_subject);
            this.gp_cus_email1.Controls.Add(this.txt_email_address);
            this.gp_cus_email1.Controls.Add(this.lbl_cus_email_address);
            this.gp_cus_email1.Controls.Add(this.lbl_cus_email_subject);
            this.gp_cus_email1.Location = new System.Drawing.Point(20, 44);
            this.gp_cus_email1.Name = "gp_cus_email1";
            this.gp_cus_email1.Size = new System.Drawing.Size(900, 159);
            this.gp_cus_email1.TabIndex = 5;
            this.gp_cus_email1.TabStop = false;
            this.gp_cus_email1.Text = "New Message";
            // 
            // txt_email_subject
            // 
            this.txt_email_subject.Location = new System.Drawing.Point(128, 103);
            this.txt_email_subject.Name = "txt_email_subject";
            this.txt_email_subject.Size = new System.Drawing.Size(755, 26);
            this.txt_email_subject.TabIndex = 6;
            // 
            // txt_email_address
            // 
            this.txt_email_address.Location = new System.Drawing.Point(128, 39);
            this.txt_email_address.Name = "txt_email_address";
            this.txt_email_address.Size = new System.Drawing.Size(755, 26);
            this.txt_email_address.TabIndex = 5;
            this.txt_email_address.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_email_address_MouseClick);
            // 
            // lbl_cus_email_address
            // 
            this.lbl_cus_email_address.AutoSize = true;
            this.lbl_cus_email_address.Location = new System.Drawing.Point(11, 40);
            this.lbl_cus_email_address.Name = "lbl_cus_email_address";
            this.lbl_cus_email_address.Size = new System.Drawing.Size(97, 20);
            this.lbl_cus_email_address.TabIndex = 0;
            this.lbl_cus_email_address.Text = "Email Address";
            // 
            // lbl_cus_email_subject
            // 
            this.lbl_cus_email_subject.AutoSize = true;
            this.lbl_cus_email_subject.Location = new System.Drawing.Point(11, 104);
            this.lbl_cus_email_subject.Name = "lbl_cus_email_subject";
            this.lbl_cus_email_subject.Size = new System.Drawing.Size(54, 20);
            this.lbl_cus_email_subject.TabIndex = 1;
            this.lbl_cus_email_subject.Text = "Subject";
            // 
            // lbl_cus_email_
            // 
            this.lbl_cus_email_.AutoSize = true;
            this.lbl_cus_email_.Location = new System.Drawing.Point(49, 338);
            this.lbl_cus_email_.Name = "lbl_cus_email_";
            this.lbl_cus_email_.Size = new System.Drawing.Size(57, 20);
            this.lbl_cus_email_.TabIndex = 2;
            this.lbl_cus_email_.Text = "Contetnt";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCusRep2);
            this.tabPage1.Controls.Add(this.btnCusRep1);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(862, 602);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Report";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCusRep2
            // 
            this.btnCusRep2.Location = new System.Drawing.Point(419, 154);
            this.btnCusRep2.Name = "btnCusRep2";
            this.btnCusRep2.Size = new System.Drawing.Size(193, 68);
            this.btnCusRep2.TabIndex = 1;
            this.btnCusRep2.Text = "Customer Loyality Card Report";
            this.btnCusRep2.UseVisualStyleBackColor = true;
            this.btnCusRep2.Click += new System.EventHandler(this.btnCusRep2_Click);
            // 
            // btnCusRep1
            // 
            this.btnCusRep1.Location = new System.Drawing.Point(156, 154);
            this.btnCusRep1.Name = "btnCusRep1";
            this.btnCusRep1.Size = new System.Drawing.Size(181, 68);
            this.btnCusRep1.TabIndex = 0;
            this.btnCusRep1.Text = "Customer Management Report";
            this.btnCusRep1.UseVisualStyleBackColor = true;
            this.btnCusRep1.Click += new System.EventHandler(this.btnCusRep1_Click);
            // 
            // customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(854, 600);
            this.Controls.Add(this.tb_cus_tabcontroller);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "customer";
            this.Text = "customer";
            this.Load += new System.EventHandler(this.customer_Load);
            this.tab_loyalitycard.ResumeLayout(false);
            this.gp_loyaltycard.ResumeLayout(false);
            this.gp_loyaltycard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_loyalty_table)).EndInit();
            this.gpb_cuc_loyalty.ResumeLayout(false);
            this.gpb_cuc_loyalty.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tab_customermanagement.ResumeLayout(false);
            this.gb_cus_Management.ResumeLayout(false);
            this.gb_cus_Management.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cus_table)).EndInit();
            this.gb_cusdetails.ResumeLayout(false);
            this.gb_cusdetails.PerformLayout();
            this.tb_cus_tabcontroller.ResumeLayout(false);
            this.tab_email.ResumeLayout(false);
            this.tab_email.PerformLayout();
            this.gp_cus_email2.ResumeLayout(false);
            this.gp_cus_email1.ResumeLayout(false);
            this.gp_cus_email1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_loy_nic;
        private System.Windows.Forms.TabPage tab_customermanagement;
        private System.Windows.Forms.GroupBox gb_cus_Management;
        private System.Windows.Forms.Button btn_cus_delete;
        private System.Windows.Forms.Button btn_cus_clear;
        private System.Windows.Forms.Button btn_cus_demo;
        private System.Windows.Forms.DataGridView dgv_cus_table;
        private System.Windows.Forms.Button btn_cus_update;
        private System.Windows.Forms.Button btn_cus_add;
        private System.Windows.Forms.GroupBox gb_cusdetails;
        private System.Windows.Forms.ComboBox cmb_cus_type;
        private System.Windows.Forms.TextBox txtb_cus_email;
        private System.Windows.Forms.TextBox txtb_cus_mobileno;
        private System.Windows.Forms.TextBox txtb_cus_name;
        private System.Windows.Forms.Label lbl_cus_nic;
        private System.Windows.Forms.Label lbl_cus_email;
        private System.Windows.Forms.Label lbl_cus_type;
        private System.Windows.Forms.Label lbl_cus_name;
        private System.Windows.Forms.Label lbl_cus_address;
        private System.Windows.Forms.Label lbl_cus_mobileno;
        private System.Windows.Forms.GroupBox gpb_cuc_loyalty;
        private System.Windows.Forms.Label lbl_loy_cardtype;
        private System.Windows.Forms.DataGridView dgv_loyalty_table;
        private System.Windows.Forms.Button btn_loy_update;
        private System.Windows.Forms.Button btn_loy_delete;
        private System.Windows.Forms.Button btn_loy_add;
        private System.Windows.Forms.TextBox txtb_cus_nic;
        private System.Windows.Forms.ComboBox cmb_loy_cardtype;
        private System.Windows.Forms.GroupBox gp_loyaltycard;
        private System.Windows.Forms.TabPage tab_email;
        private System.Windows.Forms.Label lbl_cus_email_;
        private System.Windows.Forms.Label lbl_cus_email_subject;
        private System.Windows.Forms.Label lbl_cus_email_address;
        private System.Windows.Forms.Button btn_cus_email_send;
        private System.Windows.Forms.GroupBox gp_cus_email2;
        private System.Windows.Forms.RichTextBox rtb_cus_email_body;
        private System.Windows.Forms.GroupBox gp_cus_email1;
        private System.Windows.Forms.Button btn_email_demo;
        private System.Windows.Forms.RichTextBox rtb_cus_address;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_cus_searchkey;
        private System.Windows.Forms.TextBox txt_cus_searchkey;
        private System.Windows.Forms.Label lbl_email_nic;
        private System.Windows.Forms.TextBox txt_email_address;
        private System.Windows.Forms.TextBox txt_email_subject;
        private System.Windows.Forms.Label lbl_loymem_cardno;
        private System.Windows.Forms.ComboBox cmb_loy_selectCardType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cusLoy_clear;
        private System.Windows.Forms.Button btn_cusEmail_clear;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabControl tb_cus_tabcontroller;
        public System.Windows.Forms.TabPage tab_loyalitycard;
        public System.Windows.Forms.TextBox txt_loy_nic;
        private System.Windows.Forms.ComboBox cmb_email_nic;
        private System.Windows.Forms.Button btnCusRep2;
        private System.Windows.Forms.Button btnCusRep1;

    }
}
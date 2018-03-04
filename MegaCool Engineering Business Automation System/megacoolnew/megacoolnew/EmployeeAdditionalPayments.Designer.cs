namespace megacoolnew
{
    partial class EmployeeAdditionalPayments
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
            this.eap_dgv_payemts = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eap_lb_reason = new System.Windows.Forms.Label();
            this.eap_tb_reason = new System.Windows.Forms.TextBox();
            this.eap_tb_amount = new System.Windows.Forms.TextBox();
            this.eap_lb_amount = new System.Windows.Forms.Label();
            this.eap_btn_clear = new System.Windows.Forms.Button();
            this.eap_btn_add = new System.Windows.Forms.Button();
            this.eap_btn_delete = new System.Windows.Forms.Button();
            this.eap_btn_done = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eap_dgv_payemts)).BeginInit();
            this.SuspendLayout();
            // 
            // eap_dgv_payemts
            // 
            this.eap_dgv_payemts.AllowUserToAddRows = false;
            this.eap_dgv_payemts.AllowUserToDeleteRows = false;
            this.eap_dgv_payemts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eap_dgv_payemts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eap_dgv_payemts.BackgroundColor = System.Drawing.Color.White;
            this.eap_dgv_payemts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eap_dgv_payemts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.eap_dgv_payemts.Location = new System.Drawing.Point(28, 27);
            this.eap_dgv_payemts.Margin = new System.Windows.Forms.Padding(4);
            this.eap_dgv_payemts.Name = "eap_dgv_payemts";
            this.eap_dgv_payemts.ReadOnly = true;
            this.eap_dgv_payemts.Size = new System.Drawing.Size(603, 155);
            this.eap_dgv_payemts.TabIndex = 0;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "id";
            this.Column5.HeaderText = "id";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "EmployeeID";
            this.Column1.HeaderText = "Employee ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Date";
            this.Column2.HeaderText = "Date";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Reason";
            this.Column3.HeaderText = "Reason";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Amount";
            this.Column4.HeaderText = "Amount";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // eap_lb_reason
            // 
            this.eap_lb_reason.AutoSize = true;
            this.eap_lb_reason.Location = new System.Drawing.Point(25, 256);
            this.eap_lb_reason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.eap_lb_reason.Name = "eap_lb_reason";
            this.eap_lb_reason.Size = new System.Drawing.Size(56, 16);
            this.eap_lb_reason.TabIndex = 1;
            this.eap_lb_reason.Text = "Reason";
            // 
            // eap_tb_reason
            // 
            this.eap_tb_reason.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.eap_tb_reason.Location = new System.Drawing.Point(119, 253);
            this.eap_tb_reason.Margin = new System.Windows.Forms.Padding(4);
            this.eap_tb_reason.Name = "eap_tb_reason";
            this.eap_tb_reason.Size = new System.Drawing.Size(196, 22);
            this.eap_tb_reason.TabIndex = 2;
            // 
            // eap_tb_amount
            // 
            this.eap_tb_amount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eap_tb_amount.Location = new System.Drawing.Point(435, 253);
            this.eap_tb_amount.Margin = new System.Windows.Forms.Padding(4);
            this.eap_tb_amount.Name = "eap_tb_amount";
            this.eap_tb_amount.Size = new System.Drawing.Size(196, 22);
            this.eap_tb_amount.TabIndex = 4;
            this.eap_tb_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eap_tb_amount_KeyPress);
            // 
            // eap_lb_amount
            // 
            this.eap_lb_amount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.eap_lb_amount.AutoSize = true;
            this.eap_lb_amount.Location = new System.Drawing.Point(355, 256);
            this.eap_lb_amount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.eap_lb_amount.Name = "eap_lb_amount";
            this.eap_lb_amount.Size = new System.Drawing.Size(53, 16);
            this.eap_lb_amount.TabIndex = 3;
            this.eap_lb_amount.Text = "Amount";
            // 
            // eap_btn_clear
            // 
            this.eap_btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.eap_btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eap_btn_clear.Location = new System.Drawing.Point(371, 303);
            this.eap_btn_clear.Margin = new System.Windows.Forms.Padding(4);
            this.eap_btn_clear.Name = "eap_btn_clear";
            this.eap_btn_clear.Size = new System.Drawing.Size(91, 35);
            this.eap_btn_clear.TabIndex = 7;
            this.eap_btn_clear.Text = "Clear";
            this.eap_btn_clear.UseVisualStyleBackColor = true;
            this.eap_btn_clear.Click += new System.EventHandler(this.eap_btn_clear_Click);
            // 
            // eap_btn_add
            // 
            this.eap_btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eap_btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eap_btn_add.Location = new System.Drawing.Point(540, 302);
            this.eap_btn_add.Margin = new System.Windows.Forms.Padding(4);
            this.eap_btn_add.Name = "eap_btn_add";
            this.eap_btn_add.Size = new System.Drawing.Size(91, 35);
            this.eap_btn_add.TabIndex = 8;
            this.eap_btn_add.Text = "Add";
            this.eap_btn_add.UseVisualStyleBackColor = true;
            this.eap_btn_add.Click += new System.EventHandler(this.eap_btn_add_Click);
            // 
            // eap_btn_delete
            // 
            this.eap_btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eap_btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eap_btn_delete.Location = new System.Drawing.Point(540, 199);
            this.eap_btn_delete.Margin = new System.Windows.Forms.Padding(4);
            this.eap_btn_delete.Name = "eap_btn_delete";
            this.eap_btn_delete.Size = new System.Drawing.Size(91, 35);
            this.eap_btn_delete.TabIndex = 9;
            this.eap_btn_delete.Text = "Delete";
            this.eap_btn_delete.UseVisualStyleBackColor = true;
            this.eap_btn_delete.Click += new System.EventHandler(this.eap_btn_delete_Click);
            // 
            // eap_btn_done
            // 
            this.eap_btn_done.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eap_btn_done.Location = new System.Drawing.Point(540, 367);
            this.eap_btn_done.Name = "eap_btn_done";
            this.eap_btn_done.Size = new System.Drawing.Size(91, 35);
            this.eap_btn_done.TabIndex = 10;
            this.eap_btn_done.Text = "Done";
            this.eap_btn_done.UseVisualStyleBackColor = true;
            this.eap_btn_done.Click += new System.EventHandler(this.eap_btn_done_Click);
            // 
            // EmployeeAdditionalPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(675, 414);
            this.ControlBox = false;
            this.Controls.Add(this.eap_btn_done);
            this.Controls.Add(this.eap_btn_delete);
            this.Controls.Add(this.eap_btn_add);
            this.Controls.Add(this.eap_btn_clear);
            this.Controls.Add(this.eap_tb_amount);
            this.Controls.Add(this.eap_lb_amount);
            this.Controls.Add(this.eap_tb_reason);
            this.Controls.Add(this.eap_lb_reason);
            this.Controls.Add(this.eap_dgv_payemts);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(691, 424);
            this.Name = "EmployeeAdditionalPayments";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Additional Payments";
            ((System.ComponentModel.ISupportInitialize)(this.eap_dgv_payemts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView eap_dgv_payemts;
        private System.Windows.Forms.Label eap_lb_reason;
        private System.Windows.Forms.TextBox eap_tb_reason;
        private System.Windows.Forms.TextBox eap_tb_amount;
        private System.Windows.Forms.Label eap_lb_amount;
        private System.Windows.Forms.Button eap_btn_clear;
        private System.Windows.Forms.Button eap_btn_add;
        private System.Windows.Forms.Button eap_btn_delete;
        private System.Windows.Forms.Button eap_btn_done;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
namespace Lab04_Nhom
{
    partial class frmNhanVien
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
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label hoTenLabel;
            System.Windows.Forms.Label luongLabel;
            System.Windows.Forms.Label maNVLabel;
            System.Windows.Forms.Label matKhauLabel;
            System.Windows.Forms.Label tenDNLabel;
            this.nhanVienDataGridView = new System.Windows.Forms.DataGridView();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.hoTenTextBox = new System.Windows.Forms.TextBox();
            this.luongTextBox = new System.Windows.Forms.TextBox();
            this.maNVTextBox = new System.Windows.Forms.TextBox();
            this.matKhauTextBox = new System.Windows.Forms.TextBox();
            this.tenDNTextBox = new System.Windows.Forms.TextBox();
            this.themButton = new System.Windows.Forms.Button();
            this.luuButton = new System.Windows.Forms.Button();
            this.nhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xoaButton = new System.Windows.Forms.Button();
            emailLabel = new System.Windows.Forms.Label();
            hoTenLabel = new System.Windows.Forms.Label();
            luongLabel = new System.Windows.Forms.Label();
            maNVLabel = new System.Windows.Forms.Label();
            matKhauLabel = new System.Windows.Forms.Label();
            tenDNLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nhanVienDataGridView
            // 
            this.nhanVienDataGridView.AutoGenerateColumns = false;
            this.nhanVienDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nhanVienDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.nhanVienDataGridView.DataSource = this.nhanVienBindingSource;
            this.nhanVienDataGridView.Location = new System.Drawing.Point(12, 172);
            this.nhanVienDataGridView.Name = "nhanVienDataGridView";
            this.nhanVienDataGridView.Size = new System.Drawing.Size(547, 458);
            this.nhanVienDataGridView.TabIndex = 1;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(314, 52);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 1;
            emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nhanVienBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(376, 49);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(173, 20);
            this.emailTextBox.TabIndex = 2;
            // 
            // hoTenLabel
            // 
            hoTenLabel.AutoSize = true;
            hoTenLabel.Location = new System.Drawing.Point(314, 26);
            hoTenLabel.Name = "hoTenLabel";
            hoTenLabel.Size = new System.Drawing.Size(46, 13);
            hoTenLabel.TabIndex = 3;
            hoTenLabel.Text = "Ho Ten:";
            // 
            // hoTenTextBox
            // 
            this.hoTenTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nhanVienBindingSource, "HoTen", true));
            this.hoTenTextBox.Location = new System.Drawing.Point(376, 23);
            this.hoTenTextBox.Name = "hoTenTextBox";
            this.hoTenTextBox.Size = new System.Drawing.Size(173, 20);
            this.hoTenTextBox.TabIndex = 4;
            // 
            // luongLabel
            // 
            luongLabel.AutoSize = true;
            luongLabel.Location = new System.Drawing.Point(314, 78);
            luongLabel.Name = "luongLabel";
            luongLabel.Size = new System.Drawing.Size(40, 13);
            luongLabel.TabIndex = 5;
            luongLabel.Text = "Luong:";
            // 
            // luongTextBox
            // 
            this.luongTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nhanVienBindingSource, "Luong", true));
            this.luongTextBox.Location = new System.Drawing.Point(376, 75);
            this.luongTextBox.Name = "luongTextBox";
            this.luongTextBox.Size = new System.Drawing.Size(173, 20);
            this.luongTextBox.TabIndex = 6;
            // 
            // maNVLabel
            // 
            maNVLabel.AutoSize = true;
            maNVLabel.Location = new System.Drawing.Point(29, 26);
            maNVLabel.Name = "maNVLabel";
            maNVLabel.Size = new System.Drawing.Size(43, 13);
            maNVLabel.TabIndex = 7;
            maNVLabel.Text = "Ma NV:";
            // 
            // maNVTextBox
            // 
            this.maNVTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nhanVienBindingSource, "MaNV", true));
            this.maNVTextBox.Location = new System.Drawing.Point(91, 23);
            this.maNVTextBox.Name = "maNVTextBox";
            this.maNVTextBox.Size = new System.Drawing.Size(173, 20);
            this.maNVTextBox.TabIndex = 8;
            // 
            // matKhauLabel
            // 
            matKhauLabel.AutoSize = true;
            matKhauLabel.Location = new System.Drawing.Point(29, 78);
            matKhauLabel.Name = "matKhauLabel";
            matKhauLabel.Size = new System.Drawing.Size(56, 13);
            matKhauLabel.TabIndex = 9;
            matKhauLabel.Text = "Mat Khau:";
            // 
            // matKhauTextBox
            // 
            this.matKhauTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nhanVienBindingSource, "MatKhau", true));
            this.matKhauTextBox.Location = new System.Drawing.Point(91, 75);
            this.matKhauTextBox.Name = "matKhauTextBox";
            this.matKhauTextBox.Size = new System.Drawing.Size(173, 20);
            this.matKhauTextBox.TabIndex = 10;
            // 
            // tenDNLabel
            // 
            tenDNLabel.AutoSize = true;
            tenDNLabel.Location = new System.Drawing.Point(29, 52);
            tenDNLabel.Name = "tenDNLabel";
            tenDNLabel.Size = new System.Drawing.Size(48, 13);
            tenDNLabel.TabIndex = 11;
            tenDNLabel.Text = "Ten DN:";
            // 
            // tenDNTextBox
            // 
            this.tenDNTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nhanVienBindingSource, "TenDN", true));
            this.tenDNTextBox.Location = new System.Drawing.Point(91, 49);
            this.tenDNTextBox.Name = "tenDNTextBox";
            this.tenDNTextBox.Size = new System.Drawing.Size(173, 20);
            this.tenDNTextBox.TabIndex = 12;
            // 
            // themButton
            // 
            this.themButton.Location = new System.Drawing.Point(346, 124);
            this.themButton.Name = "themButton";
            this.themButton.Size = new System.Drawing.Size(75, 23);
            this.themButton.TabIndex = 13;
            this.themButton.Text = "Thêm mới";
            this.themButton.UseVisualStyleBackColor = true;
            this.themButton.Click += new System.EventHandler(this.themButton_Click);
            // 
            // luuButton
            // 
            this.luuButton.Location = new System.Drawing.Point(474, 124);
            this.luuButton.Name = "luuButton";
            this.luuButton.Size = new System.Drawing.Size(75, 23);
            this.luuButton.TabIndex = 14;
            this.luuButton.Text = "Lưu";
            this.luuButton.UseVisualStyleBackColor = true;
            this.luuButton.Click += new System.EventHandler(this.luuButton_Click);
            // 
            // nhanVienBindingSource
            // 
            this.nhanVienBindingSource.DataSource = typeof(Lab04_Nhom.Entity.NhanVien);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaNV";
            this.dataGridViewTextBoxColumn1.HeaderText = "MaNV";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "HoTen";
            this.dataGridViewTextBoxColumn2.HeaderText = "HoTen";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn3.HeaderText = "Email";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Luong";
            this.dataGridViewTextBoxColumn4.HeaderText = "Luong";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TenDN";
            this.dataGridViewTextBoxColumn5.HeaderText = "TenDN";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MatKhau";
            this.dataGridViewTextBoxColumn6.HeaderText = "MatKhau";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // xoaButton
            // 
            this.xoaButton.Location = new System.Drawing.Point(265, 124);
            this.xoaButton.Name = "xoaButton";
            this.xoaButton.Size = new System.Drawing.Size(75, 23);
            this.xoaButton.TabIndex = 15;
            this.xoaButton.Text = "Xóa";
            this.xoaButton.UseVisualStyleBackColor = true;
            this.xoaButton.Click += new System.EventHandler(this.xoaButton_Click);
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 650);
            this.Controls.Add(this.xoaButton);
            this.Controls.Add(this.luuButton);
            this.Controls.Add(this.themButton);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(hoTenLabel);
            this.Controls.Add(this.hoTenTextBox);
            this.Controls.Add(luongLabel);
            this.Controls.Add(this.luongTextBox);
            this.Controls.Add(maNVLabel);
            this.Controls.Add(this.maNVTextBox);
            this.Controls.Add(matKhauLabel);
            this.Controls.Add(this.matKhauTextBox);
            this.Controls.Add(tenDNLabel);
            this.Controls.Add(this.tenDNTextBox);
            this.Controls.Add(this.nhanVienDataGridView);
            this.Name = "frmNhanVien";
            this.Text = "frmNhanVien";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource nhanVienBindingSource;
        private System.Windows.Forms.DataGridView nhanVienDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox hoTenTextBox;
        private System.Windows.Forms.TextBox luongTextBox;
        private System.Windows.Forms.TextBox maNVTextBox;
        private System.Windows.Forms.TextBox matKhauTextBox;
        private System.Windows.Forms.TextBox tenDNTextBox;
        private System.Windows.Forms.Button themButton;
        private System.Windows.Forms.Button luuButton;
        private System.Windows.Forms.Button xoaButton;
    }
}
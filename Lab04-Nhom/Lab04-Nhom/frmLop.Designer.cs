namespace Lab04_Nhom
{
    partial class frmLop
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
            System.Windows.Forms.Label maLopLabel;
            System.Windows.Forms.Label maNVLabel;
            System.Windows.Forms.Label tenLopLabel;
            this.lopDataGridView = new System.Windows.Forms.DataGridView();
            this.maLopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenLopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.maLopTextBox = new System.Windows.Forms.TextBox();
            this.tenLopTextBox = new System.Windows.Forms.TextBox();
            this.luuButton = new System.Windows.Forms.Button();
            this.xoaButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.nhanVienPublicDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.themButton = new System.Windows.Forms.Button();
            maLopLabel = new System.Windows.Forms.Label();
            maNVLabel = new System.Windows.Forms.Label();
            tenLopLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lopDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienPublicDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // maLopLabel
            // 
            maLopLabel.AutoSize = true;
            maLopLabel.Location = new System.Drawing.Point(19, 17);
            maLopLabel.Name = "maLopLabel";
            maLopLabel.Size = new System.Drawing.Size(46, 13);
            maLopLabel.TabIndex = 1;
            maLopLabel.Text = "Mã Lớp:";
            // 
            // maNVLabel
            // 
            maNVLabel.AutoSize = true;
            maNVLabel.Location = new System.Drawing.Point(19, 69);
            maNVLabel.Name = "maNVLabel";
            maNVLabel.Size = new System.Drawing.Size(43, 13);
            maNVLabel.TabIndex = 3;
            maNVLabel.Text = "Ma NV:";
            // 
            // tenLopLabel
            // 
            tenLopLabel.AutoSize = true;
            tenLopLabel.Location = new System.Drawing.Point(19, 43);
            tenLopLabel.Name = "tenLopLabel";
            tenLopLabel.Size = new System.Drawing.Size(50, 13);
            tenLopLabel.TabIndex = 5;
            tenLopLabel.Text = "Ten Lop:";
            // 
            // lopDataGridView
            // 
            this.lopDataGridView.AutoGenerateColumns = false;
            this.lopDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lopDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maLopDataGridViewTextBoxColumn,
            this.tenLopDataGridViewTextBoxColumn,
            this.maNVDataGridViewTextBoxColumn});
            this.lopDataGridView.DataSource = this.lopBindingSource;
            this.lopDataGridView.Location = new System.Drawing.Point(12, 122);
            this.lopDataGridView.Name = "lopDataGridView";
            this.lopDataGridView.Size = new System.Drawing.Size(695, 312);
            this.lopDataGridView.TabIndex = 0;
            // 
            // maLopDataGridViewTextBoxColumn
            // 
            this.maLopDataGridViewTextBoxColumn.DataPropertyName = "MaLop";
            this.maLopDataGridViewTextBoxColumn.HeaderText = "MaLop";
            this.maLopDataGridViewTextBoxColumn.Name = "maLopDataGridViewTextBoxColumn";
            // 
            // tenLopDataGridViewTextBoxColumn
            // 
            this.tenLopDataGridViewTextBoxColumn.DataPropertyName = "TenLop";
            this.tenLopDataGridViewTextBoxColumn.HeaderText = "TenLop";
            this.tenLopDataGridViewTextBoxColumn.Name = "tenLopDataGridViewTextBoxColumn";
            // 
            // maNVDataGridViewTextBoxColumn
            // 
            this.maNVDataGridViewTextBoxColumn.DataPropertyName = "MaNV";
            this.maNVDataGridViewTextBoxColumn.HeaderText = "MaNV";
            this.maNVDataGridViewTextBoxColumn.Name = "maNVDataGridViewTextBoxColumn";
            // 
            // lopBindingSource
            // 
            this.lopBindingSource.DataSource = typeof(Lab04_Nhom.Entity.Lop);
            // 
            // maLopTextBox
            // 
            this.maLopTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lopBindingSource, "MaLop", true));
            this.maLopTextBox.Location = new System.Drawing.Point(75, 14);
            this.maLopTextBox.Name = "maLopTextBox";
            this.maLopTextBox.Size = new System.Drawing.Size(281, 20);
            this.maLopTextBox.TabIndex = 2;
            // 
            // tenLopTextBox
            // 
            this.tenLopTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lopBindingSource, "TenLop", true));
            this.tenLopTextBox.Location = new System.Drawing.Point(75, 40);
            this.tenLopTextBox.Name = "tenLopTextBox";
            this.tenLopTextBox.Size = new System.Drawing.Size(281, 20);
            this.tenLopTextBox.TabIndex = 6;
            // 
            // luuButton
            // 
            this.luuButton.Location = new System.Drawing.Point(632, 17);
            this.luuButton.Name = "luuButton";
            this.luuButton.Size = new System.Drawing.Size(75, 23);
            this.luuButton.TabIndex = 7;
            this.luuButton.Text = "Lưu";
            this.luuButton.UseVisualStyleBackColor = true;
            this.luuButton.Click += new System.EventHandler(this.luuButton_Click);
            // 
            // xoaButton
            // 
            this.xoaButton.Location = new System.Drawing.Point(528, 17);
            this.xoaButton.Name = "xoaButton";
            this.xoaButton.Size = new System.Drawing.Size(75, 23);
            this.xoaButton.TabIndex = 8;
            this.xoaButton.Text = "Xóa";
            this.xoaButton.UseVisualStyleBackColor = true;
            this.xoaButton.Click += new System.EventHandler(this.xoaButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.lopBindingSource, "MaNV", true));
            this.comboBox1.DataSource = this.nhanVienPublicDTOBindingSource;
            this.comboBox1.DisplayMember = "DisplayString";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(75, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(281, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.ValueMember = "MaNV";
            // 
            // nhanVienPublicDTOBindingSource
            // 
            this.nhanVienPublicDTOBindingSource.DataSource = typeof(Lab04_Nhom.DTO.NhanVienDTO);
            // 
            // themButton
            // 
            this.themButton.Location = new System.Drawing.Point(447, 17);
            this.themButton.Name = "themButton";
            this.themButton.Size = new System.Drawing.Size(75, 23);
            this.themButton.TabIndex = 10;
            this.themButton.Text = "Thêm";
            this.themButton.UseVisualStyleBackColor = true;
            this.themButton.Click += new System.EventHandler(this.themButton_Click);
            // 
            // frmLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 446);
            this.Controls.Add(this.themButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.xoaButton);
            this.Controls.Add(this.luuButton);
            this.Controls.Add(maLopLabel);
            this.Controls.Add(this.maLopTextBox);
            this.Controls.Add(maNVLabel);
            this.Controls.Add(tenLopLabel);
            this.Controls.Add(this.tenLopTextBox);
            this.Controls.Add(this.lopDataGridView);
            this.Name = "frmLop";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lopDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienPublicDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView lopDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenLopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNVDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource lopBindingSource;
        private System.Windows.Forms.TextBox maLopTextBox;
        private System.Windows.Forms.TextBox tenLopTextBox;
        private System.Windows.Forms.Button luuButton;
        private System.Windows.Forms.Button xoaButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource nhanVienPublicDTOBindingSource;
        private System.Windows.Forms.Button themButton;
    }
}
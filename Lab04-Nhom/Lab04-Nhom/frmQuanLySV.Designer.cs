namespace Lab04_Nhom
{
    partial class frmQuanLySV
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
            this.helloLabel = new System.Windows.Forms.Label();
            this.sinhVienFrmButton = new System.Windows.Forms.Button();
            this.lopFrmButton = new System.Windows.Forms.Button();
            this.bangDiemFrmButton = new System.Windows.Forms.Button();
            this.nhanVienFrmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // helloLabel
            // 
            this.helloLabel.AutoSize = true;
            this.helloLabel.Location = new System.Drawing.Point(13, 9);
            this.helloLabel.Name = "helloLabel";
            this.helloLabel.Size = new System.Drawing.Size(35, 13);
            this.helloLabel.TabIndex = 0;
            this.helloLabel.Text = "label1";
            // 
            // sinhVienFrmButton
            // 
            this.sinhVienFrmButton.Location = new System.Drawing.Point(141, 72);
            this.sinhVienFrmButton.Name = "sinhVienFrmButton";
            this.sinhVienFrmButton.Size = new System.Drawing.Size(94, 45);
            this.sinhVienFrmButton.TabIndex = 1;
            this.sinhVienFrmButton.Text = "QL Sinh Viên";
            this.sinhVienFrmButton.UseVisualStyleBackColor = true;
            this.sinhVienFrmButton.Click += new System.EventHandler(this.sinhVienFrmButton_Click);
            // 
            // lopFrmButton
            // 
            this.lopFrmButton.Location = new System.Drawing.Point(265, 72);
            this.lopFrmButton.Name = "lopFrmButton";
            this.lopFrmButton.Size = new System.Drawing.Size(94, 45);
            this.lopFrmButton.TabIndex = 2;
            this.lopFrmButton.Text = "QL Lớp";
            this.lopFrmButton.UseVisualStyleBackColor = true;
            this.lopFrmButton.Click += new System.EventHandler(this.lopFrmButton_Click);
            // 
            // bangDiemFrmButton
            // 
            this.bangDiemFrmButton.Location = new System.Drawing.Point(390, 72);
            this.bangDiemFrmButton.Name = "bangDiemFrmButton";
            this.bangDiemFrmButton.Size = new System.Drawing.Size(94, 45);
            this.bangDiemFrmButton.TabIndex = 3;
            this.bangDiemFrmButton.Text = "QL Bảng Điểm";
            this.bangDiemFrmButton.UseVisualStyleBackColor = true;
            this.bangDiemFrmButton.Click += new System.EventHandler(this.bangDiemFrmButton_Click);
            // 
            // nhanVienFrmButton
            // 
            this.nhanVienFrmButton.Location = new System.Drawing.Point(16, 72);
            this.nhanVienFrmButton.Name = "nhanVienFrmButton";
            this.nhanVienFrmButton.Size = new System.Drawing.Size(94, 45);
            this.nhanVienFrmButton.TabIndex = 4;
            this.nhanVienFrmButton.Text = "QL Nhân Viên";
            this.nhanVienFrmButton.UseVisualStyleBackColor = true;
            this.nhanVienFrmButton.Click += new System.EventHandler(this.nhanVienFrmButton_Click);
            // 
            // frmQuanLySV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 156);
            this.Controls.Add(this.nhanVienFrmButton);
            this.Controls.Add(this.bangDiemFrmButton);
            this.Controls.Add(this.lopFrmButton);
            this.Controls.Add(this.sinhVienFrmButton);
            this.Controls.Add(this.helloLabel);
            this.Name = "frmQuanLySV";
            this.Text = "frmQuanLySV";
            this.Load += new System.EventHandler(this.frmQuanLySV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label helloLabel;
        private System.Windows.Forms.Button sinhVienFrmButton;
        private System.Windows.Forms.Button lopFrmButton;
        private System.Windows.Forms.Button bangDiemFrmButton;
        private System.Windows.Forms.Button nhanVienFrmButton;
    }
}
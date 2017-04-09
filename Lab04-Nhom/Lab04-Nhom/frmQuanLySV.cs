using Lab04_Nhom.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_Nhom
{
    public partial class frmQuanLySV : Form
    {
        NhanVienDTO curNhanVien { get; set; }
        string privateKey { get; set; }
        public frmQuanLySV()
        {
            InitializeComponent();
        }

        public frmQuanLySV(NhanVienDTO nv, string privateKey)
        {
            InitializeComponent();
            this.curNhanVien = nv;
            this.privateKey = privateKey;
        }

        private void sinhVienFrmButton_Click(object sender, EventArgs e)
        {
            var frm = new frmSinhVien(curNhanVien);
            frm.Show();
        }

        private void lopFrmButton_Click(object sender, EventArgs e)
        {
            var frm = new frmLop();
            frm.Show();
        }

        private void bangDiemFrmButton_Click(object sender, EventArgs e)
        {
            var frm = new frmBangDiem(curNhanVien, privateKey);
            frm.Show();
        }

        private void frmQuanLySV_Load(object sender, EventArgs e)
        {
            helloLabel.Text = "Xin chào ! " + curNhanVien.HoTen;
        }
    }
}

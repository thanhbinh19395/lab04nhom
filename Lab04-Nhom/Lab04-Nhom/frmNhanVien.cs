using DatabaseLib;
using Lab04_Nhom.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04_Nhom.CryptoExtension;
namespace Lab04_Nhom
{
    public partial class frmNhanVien : Form
    {
        SqlDatabase DbLib;

        List<NhanVien> ListNhanVien
        {
            get { return nhanVienBindingSource.DataSource as List<NhanVien>; }
            set { nhanVienBindingSource.DataSource = value; }
        }
        public frmNhanVien()
        {
            InitializeComponent();
            DbLib = new SqlDatabase();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            var list = DbLib.GetList<NhanVien>("SP_SEL_PUBLIC_ENCRYPT_NHANVIEN");
            list.ForEach(item => item.Luong = item.Luong.GetAES256DecryptString());
            ListNhanVien = list;
        }

        private void themButton_Click(object sender, EventArgs e)
        {
            ListNhanVien.Add(new NhanVien());
            nhanVienBindingSource.ResetBindings(false);
            nhanVienBindingSource.MoveLast();
        }

        private void luuButton_Click(object sender, EventArgs e)
        {
            ListNhanVien.ForEach(this.SaveHandler);
            MessageBox.Show("Thao tác thành công!");
        }
        private void SaveHandler(NhanVien item) {
            if (String.IsNullOrWhiteSpace(item.Luong) || String.IsNullOrWhiteSpace(item.MatKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho nhân viên " + item.MaNV);
                return;
            }

            var existItem = DbLib.GetOne<NhanVien>("SP_GETBYMANV_NHANVIEN", new List<SqlParameter> {
                new SqlParameter {ParameterName= "MaNV", Value = item.MaNV }
            });
            if (existItem != null)
            {
                if (existItem.MatKhau != item.MatKhau)
                {
                    item.MatKhau = item.MatKhau.GetSHA1Hash();
                }
                if (existItem.Luong != item.Luong)
                {
                    item.Luong = item.Luong.GetAES256EncryptString();
                }
                DbLib.ExecuteNonQuery("SP_UPD_ENCRYPT_NHANVIEN", item.ToSqlParameter());
            }
            else
            {
                item.MatKhau = item.MatKhau.GetMd5Hash();
                item.Luong = item.Luong.GetAES256EncryptString();
                DbLib.ExecuteNonQuery("SP_INS_PUBLIC_ENCRYPT_NHANVIEN", item.ToSqlParameter());
                
            }
            
            ReloadGrid();

        }

        private void xoaButton_Click(object sender, EventArgs e)
        {
            var curItem = nhanVienBindingSource.Current;
            if (curItem != null)
            {
                DbLib.Delete(curItem);
                this.ReloadGrid();
            }
        }
        public void ReloadGrid() {
            frmNhanVien_Load(null, null);
        }

    }
}

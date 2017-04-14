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
using Lab04_Nhom.DTO;

namespace Lab04_Nhom
{
    public partial class frmNhanVien : Form
    {
        SqlDatabase DbLib;
        NhanVien nhanVienDangNhap;
        string password;
        RSACryptography rsaCryptoService;
        List<NhanVien> ListNhanVien
        {
            get { return nhanVienBindingSource.DataSource as List<NhanVien>; }
            set { nhanVienBindingSource.DataSource = value; }
        }
        public frmNhanVien()
        {
            InitializeComponent();
            DbLib = new SqlDatabase();
            this.rsaCryptoService = new RSACryptography();
        }
        public frmNhanVien(NhanVien nv, string password) {
            InitializeComponent();
            DbLib = new SqlDatabase();

            this.nhanVienDangNhap = nv;
            this.password = password;
            this.rsaCryptoService = new RSACryptography();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            var list = DbLib.GetList<NhanVien>("SP_SEL_PUBLIC_ENCRYPT_NHANVIEN");

            var nv = list.First(p => p.MaNV == this.nhanVienDangNhap.MaNV);
            handleDecryptLuong(nv);
            ListNhanVien = list;
        }
        private void handleDecryptLuong(NhanVien item)
        {
            var priKey = KeyRepository.GetPrivateKey(this.nhanVienDangNhap.PubKey, password);
            if (!String.IsNullOrEmpty(priKey))
            {
                item.Luong = rsaCryptoService.Decrypt(priKey, item.Luong);
            }
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
            ReloadGrid();
        }
        private void SaveHandler(NhanVien item) {
            if (String.IsNullOrWhiteSpace(item.Luong) || String.IsNullOrWhiteSpace(item.MatKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho nhân viên " + item.MaNV);
                return;
            }

            var existItem = DbLib.GetOne<NhanVien>("SP_GETBYMANV_PUBLIC_ENCRYPT_NHANVIEN", new List<SqlParameter> {
                new SqlParameter {ParameterName= "MaNV", Value = item.MaNV }
            });
            if (existItem != null)
            {
                //ko duoc cap nhat
            }
            //Insert
            else
            {
                item.PubKey = item.MaNV;
                var keyPairs = rsaCryptoService.GenerateKeys();
                KeyRepository.StoreKeyPairs(item.PubKey, keyPairs, item.MatKhau);
                item.MatKhau = item.MatKhau.GetSHA1Hash();

                item.Luong = rsaCryptoService.Encrypt(keyPairs.publicKey, item.Luong);
                DbLib.ExecuteNonQuery("SP_INS_PUBLIC_ENCRYPT_NHANVIEN", item.ToSqlParameter());
            }
        }
        
        private void xoaButton_Click(object sender, EventArgs e)
        {
            var curItem = nhanVienBindingSource.Current as NhanVien;

            if(curItem.MaNV == nhanVienDangNhap.MaNV)
            {
                MessageBox.Show("Không được xóa nhân viên đang đăng nhập");
                return;
            }

            if (curItem != null)
            {
                var result = DbLib.Delete(curItem);
                if(result != 0)
                {
                    this.ReloadGrid();
                    KeyRepository.DeleteKeyPairs(curItem.PubKey);
                }
            }
        }
        public void ReloadGrid() {
            frmNhanVien_Load(null, null);
        }

    }
}

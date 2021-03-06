﻿using DatabaseLib;
using Lab04_Nhom.DTO;
using Lab04_Nhom.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04_Nhom.CryptoExtension;
namespace Lab04_Nhom
{
    public partial class frmSinhVien : Form
    {
        private NhanVien CurNhanVien { get; set; }
        SqlDatabase DbLib;
        List<SinhVien> ListSinhVien
        {
            get { return sinhVienBindingSource.DataSource as List<SinhVien>; }
            set { sinhVienBindingSource.DataSource = value; }
        }
        public frmSinhVien()
        {
            InitializeComponent();
        }
        public frmSinhVien(NhanVien curnv)
        {
            InitializeComponent();
            this.CurNhanVien = curnv;
            DbLib = new SqlDatabase();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            lopBindingSource.DataSource = DbLib.GetList<Lop>(String.Format("select * from Lop", CurNhanVien.MaNV));

        }

        private void lopBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = lopBindingSource.Current as Lop;
            if (cur != null)
            {
                sinhVienBindingSource.DataSource = DbLib.GetList<SinhVien>(String.Format("select MaSV,HoTen ,NgaySinh,DiaChi,MaLop,TenDN, CONVERT(varchar(max), MatKhau) as MatKhau from SinhVien where MaLop = '{0}'", cur.MaLop));
            }
        }

        private void luuButton_Click(object sender, EventArgs e)
        {
            var list = sinhVienBindingSource.DataSource as List<SinhVien>;
            list.ForEach(this.SaveSinhVienHandler);
            RefreshData();
        }
        private void SaveSinhVienHandler(SinhVien item)
        {
            item.MaLop = (lopBindingSource.Current as Lop).MaLop;
            var existItem = DbLib.GetOne<SinhVien>(String.Format("select convert(varchar(500),MatKhau) as MatKhau from SinhVien where MaSV ='{0}'", item.MaSV));
            if (existItem != null)
            {
                if (item.MatKhau != existItem.MatKhau)
                {
                    item.MatKhau = item.MatKhau.GetSHA1Hash();
                }
                var parameters = item.ToSqlParameter();
                DbLib.ExecuteNonQuery("SP_UPD_ENCRYPTED_SINHVIEN", parameters);
            }
            else
            {
                item.MatKhau = item.MatKhau.GetSHA1Hash();
                DbLib.ExecuteNonQuery("SP_INS_ENCRYPTED_SINHVIEN", item.ToSqlParameter());
            }
        }

        private void xoaButton_Click(object sender, EventArgs e)
        {
            var cur = sinhVienBindingSource.Current;
            if (cur != null)
            {
                DbLib.Delete(cur);
                RefreshData();
            }
        }
        private void RefreshData()
        {
            this.frmSinhVien_Load(null, null);
        }

        private void themButton_Click(object sender, EventArgs e)
        {
            ListSinhVien.Add(new SinhVien());
            sinhVienBindingSource.ResetBindings(false);
            sinhVienBindingSource.MoveLast();
        }
    }
}

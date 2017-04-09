using DatabaseLib;
using Lab04_Nhom.DTO;
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

namespace Lab04_Nhom
{
    public partial class frmBangDiem : Form
    {
        SqlDatabase DbLib;
        NhanVienDTO curNhanVien { get; set; }
        string privateKey { get; set; }
        public frmBangDiem()
        {
            InitializeComponent();
            DbLib = new SqlDatabase();
        }
        public frmBangDiem(NhanVienDTO nv, string privateKey)
        {
            InitializeComponent();
            DbLib = new SqlDatabase();
            this.curNhanVien = nv;
            this.privateKey = privateKey;
        }
        private void frmBangDiem_Load(object sender, EventArgs e)
        {
            lopBindingSource.DataSource = DbLib.GetList<Lop>("select * from Lop");
            hocPhanBindingSource.DataSource = DbLib.GetList<HocPhan>("select * from HocPhan");
        }

        private void lopBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = lopBindingSource.Current as Lop;
            if (cur != null)
            {
                sinhVienBindingSource.DataSource = DbLib.GetList<SinhVien>(String.Format("select MaSV,HoTen ,NgaySinh,DiaChi,MaLop,TenDN, CONVERT(varchar(max),MatKhau,2) as MatKhau from SinhVien where MaLop = '{0}'", cur.MaLop));
            }
        }


        private void luuButton_Click(object sender, EventArgs e)
        {
            var list = bangDiemBindingSource.DataSource as List<BangDiem>;
            list.ForEach(this.SaveBangDiemHandler);
        }
        private void SaveBangDiemHandler(BangDiem item)
        {
            item.MaSV = (sinhVienBindingSource.Current as SinhVien).MaSV;
            var existItem = DbLib.GetOne<BangDiem>(String.Format("select MaSV, MaHP from BangDiem where MaSV = '{0}' AND MaHP = '{1}' ", item.MaSV, item.MaHP));
            var sqlParams = item.ToSqlParameter();
            sqlParams.Add(new SqlParameter { ParameterName = "PubKey", Value = this.curNhanVien.MaNV });
            if (existItem != null)
            {
                DbLib.ExecuteNonQuery("SP_BANGDIEM_Update", sqlParams);
            }
            else
            {
                DbLib.ExecuteNonQuery("SP_BANGDIEM_Insert", sqlParams);
            }
        }

        private void sinhVienBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var cur = sinhVienBindingSource.Current as SinhVien;
            if (cur != null && cur.MaSV != null)
            {
                List<SqlParameter> listParams = new List<SqlParameter>
                {
                    new SqlParameter {ParameterName = "PubKey", Value = this.curNhanVien.MaNV },
                    new SqlParameter {ParameterName = "PrivateKey", Value = this.privateKey  },
                    new SqlParameter {ParameterName ="MaSV", Value = cur.MaSV }
                };
                bangDiemBindingSource.DataSource = DbLib.GetList<BangDiem>("SP_BANGDIEM_GetDecryptedListByMaSV", listParams);
            }
        }

        private void xoaButton_Click(object sender, EventArgs e)
        {
            var cur = bangDiemBindingSource.Current;
            if (cur != null)
            {
                DbLib.Delete(cur);
            }
            this.sinhVienBindingSource_CurrentChanged(null, null);
        }
    }
}

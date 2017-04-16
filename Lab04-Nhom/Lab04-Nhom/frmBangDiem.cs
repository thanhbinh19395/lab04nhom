using DatabaseLib;
using Lab04_Nhom.CryptoExtension;
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
        NhanVien curNhanVien { get; set; }
        SinhVien curSinhVien { get; set; }
        string privateKey { get; set; }
        List<BangDiem> listBangDiemByMaSV
        {
            get { return bangDiemBindingSource.DataSource as List<BangDiem>; }
            set { bangDiemBindingSource.DataSource = value; }
        }
        RSACryptography rsaCryptoService;
        public frmBangDiem()
        {
            InitializeComponent();
            DbLib = new SqlDatabase();
            this.rsaCryptoService = new RSACryptography();
        }
        public frmBangDiem(NhanVien nv, string privateKey)
        {
            InitializeComponent();
            DbLib = new SqlDatabase();
            this.curNhanVien = nv;
            this.privateKey = privateKey;
            this.rsaCryptoService = new RSACryptography();
        }
        private void frmBangDiem_Load(object sender, EventArgs e)
        {
            lopBindingSource.DataSource = DbLib.GetList<Lop>(String.Format("select * from Lop where MaNV = '{0}'", curNhanVien.MaNV));
            hocPhanBindingSource.DataSource = DbLib.GetList<HocPhan>("select * from HOCPHAN");
            Reload();
        }
        private void Reload()
        {
            curSinhVien = sinhVienBindingSource.Current as SinhVien;
            if(curSinhVien != null)
            {
                var curLop = lopBindingSource.Current as Lop;
                var list = DbLib.GetList<BangDiem>(String.Format("select MaSV,MaHP, CONVERT(varchar(250), DiemThi) as DiemThi from BangDiem where MaSV = '{0}'", curSinhVien.MaSV));
                if (curSinhVien != null && curSinhVien.MaSV != null && curLop.MaNV == curNhanVien.MaNV)
                {
                    foreach (BangDiem item in list)
                    {
                        handleDecryptBangDiem(item);
                    }

                }
                listBangDiemByMaSV = list;
            }
            
        }

        private void handleDecryptBangDiem(BangDiem item)
        {
            if (!String.IsNullOrEmpty(privateKey))
            {
                item.DiemThi =  rsaCryptoService.Decrypt(privateKey, item.DiemThi.ToString());
            }
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
            listBangDiemByMaSV = bangDiemBindingSource.DataSource as List<BangDiem>;
            listBangDiemByMaSV.ForEach(this.SaveBangDiemHandler);
        }
        private void SaveBangDiemHandler(BangDiem item)
        {
            item.MaSV = (sinhVienBindingSource.Current as SinhVien).MaSV;
            var existItem = DbLib.GetOne<BangDiem>(String.Format("select MaSV, MaHP from BangDiem where MaSV = '{0}' AND MaHP = '{1}' ", item.MaSV, item.MaHP));
            if (existItem != null)
            {
                //Cập nhật điểm của sinh viên
                //DbLib.ExecuteNonQuery("SP_BANGDIEM_Update", sqlParams);
            }
            else
            {
                //Lưu điểm mới của sinh viên
                //Lấy public key của nhân viên đang đăng nhập
                var publicKey = KeyRepository.GetPublicKey(curNhanVien.PubKey);
                //Thực hiện mã hóa điểm
                item.DiemThi = rsaCryptoService.Encrypt(publicKey, item.DiemThi);
                var sqlParams = item.ToSqlParameter();
                DbLib.ExecuteNonQuery("SP_INS_ENCRYPT_BANGDIEM", sqlParams);
            }
        }

        private void sinhVienBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Reload();
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

        private void themButton_Click(object sender, EventArgs e)
        {
            listBangDiemByMaSV.Add(new BangDiem());
            bangDiemBindingSource.ResetBindings(false);
            bangDiemBindingSource.MoveLast();
        }
    }
}

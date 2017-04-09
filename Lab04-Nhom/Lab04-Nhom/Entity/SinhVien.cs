using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_Nhom.Entity
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string MaLop { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public SinhVien() {
            NgaySinh = DateTime.Now ;
        }
    }
}

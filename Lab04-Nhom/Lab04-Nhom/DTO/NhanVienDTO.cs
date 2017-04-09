using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_Nhom.DTO
{
    public class NhanVienDTO
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string TenDN { get; set; }
        public string Luong { get; set; }
        public string DisplayString { get { return ToString(); } }
        public override string ToString()
        {
            return String.Format("{0} - {1} - {2}", MaNV, HoTen, TenDN);
        }
    }
}

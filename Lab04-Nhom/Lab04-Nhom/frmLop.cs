using DatabaseLib;
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

namespace Lab04_Nhom
{
    public partial class frmLop : Form
    {
        SqlDatabase DbLib;
        List<Lop> ListLop
        {
            get { return lopBindingSource.DataSource as List<Lop>; }
            set { lopBindingSource.DataSource = value; }
        }
        public frmLop()
        {
            InitializeComponent();
            DbLib = new SqlDatabase();
        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            lopBindingSource.DataSource = DbLib.GetList<Lop>("select * from Lop");
            nhanVienPublicDTOBindingSource.DataSource = DbLib.GetList<NhanVienDTO>("select MaNV, HoTen, TenDN from NhanVien");
        }

        private void luuButton_Click(object sender, EventArgs e)
        {
            var list = lopBindingSource.DataSource as List<Lop>;
            list.ForEach(this.SaveLopHandler);
            ReloadGrid();
        }
        private void SaveLopHandler(Lop item)
        {
            if (String.IsNullOrWhiteSpace(item.MaLop))
            {
                MessageBox.Show("Vui long dien MaLop");
                return;
            }
            var existItem = DbLib.GetOne<Lop>(String.Format("select * from Lop where MaLop = '{0}'", item.MaLop));
            if (existItem != null)
            {
                DbLib.Update(item);
            }
            else
            {
                DbLib.Insert(item);
            }
        }
        private void ReloadGrid()
        {
            frmLop_Load(null, null);
        }

        private void xoaButton_Click(object sender, EventArgs e)
        {
            var curItem = lopBindingSource.Current;
            if (curItem != null)
            {
                DbLib.Delete(curItem);
                this.ReloadGrid();
            }
        }

        private void themButton_Click(object sender, EventArgs e)
        {
            ListLop.Add(new Lop());
            lopBindingSource.ResetBindings(false);
            lopBindingSource.MoveLast();
        }
    }
}

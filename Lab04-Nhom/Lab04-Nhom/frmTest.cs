using Lab04_Nhom.CryptoExtension;
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
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSACryptography rsa = new RSACryptography();
            var rsaKey = rsa.GenerateKeys();
            KeyRepository.StorePublicKey(textBox1.Text, rsaKey.publicKey);
            //KeyRepository.StorePrivateKey(textBox1.Text, rsaKey.privateKey);

        }
    }
}

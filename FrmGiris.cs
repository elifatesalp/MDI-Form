using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama01
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            OrnekDBEntities db = new OrnekDBEntities();
            Kullanici k = db.Kullanicis.FirstOrDefault(a => a.KullaniciEmail == kAdi && a.KullaniciSifre == sifre);

            if (k !=null)
            {
                FrmMain frmMain = new FrmMain(k);
                frmMain.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FrmFakulte : Form
    {
        Kullanici girenK { get; set; }
        public FrmFakulte(Kullanici k)
        {
            InitializeComponent();
            this.girenK = k;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Fakulte f = new Fakulte();
            f.FakulteAdi = textBox1.Text;
            f.FakulteEkleyenID = girenK.KullaniciID;


            OrnekDBEntities db = new OrnekDBEntities();
            db.Fakultes.Add(f);
            db.SaveChanges();

            
        }

        private void FrmFakulte_Load(object sender, EventArgs e)
        {

        }
    }
}

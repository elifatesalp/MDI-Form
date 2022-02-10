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
    public partial class FrmBolum : Form
    {
        public Kullanici Giren { get; set; }
        public int SecilenFakulteID{ get; set; }
        public FrmBolum(Kullanici k, int fID)
        {
            InitializeComponent();
            this.Giren = k;
            this.SecilenFakulteID = fID;
        }

        private void FrmBolum_Load(object sender, EventArgs e)
        {    
            OrnekDBEntities db = new OrnekDBEntities();
            comboBox1.ValueMember = "FakulteID";
            comboBox1.DisplayMember = "FakulteAdi";
            comboBox1.DataSource = db.Fakultes.ToList();

            comboBox1.SelectedValue = SecilenFakulteID;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            OrnekDBEntities db = new OrnekDBEntities();

            Bolum b = new Bolum();
            b.BolumAdi = textBox1.Text;
            b.BolumFakulteID = SecilenFakulteID;
            b.BolumEkleyenID = Giren.KullaniciID;
            db.Bolums.Add(b);
            db.SaveChanges();
        }
    }
}

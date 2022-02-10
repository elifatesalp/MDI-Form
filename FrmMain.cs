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
    public partial class FrmMain : Form
    {
        Kullanici GirenKullanici { get; set; }
        public FrmMain(Kullanici k)
        {
            InitializeComponent();
            this.GirenKullanici = k;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Hoşgeldin, " + GirenKullanici.KullaniciAdi + " " + GirenKullanici.KullaniciSoyadi;

            FakulteDoldur();
        }

        void FakulteDoldur()
        {
            
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            OrnekDBEntities db = new OrnekDBEntities();
            dataGridView1.DataSource = db.Fakultes.ToList();
        }

        void BolumDoldur(int fakulteID)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();

            OrnekDBEntities db = new OrnekDBEntities();
            dataGridView2.DataSource = db.Bolums.Where(a => a.BolumFakulteID == fakulteID).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow secilenSatir = dataGridView1.Rows[e.RowIndex];

            //int fakulteID = (int)secilenSatir.Cells[0].Value;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow secilenSatir = dataGridView1.Rows[e.RowIndex];
            int fakulteID = (int)secilenSatir.Cells[0].Value;

            BolumDoldur(fakulteID);
        }

        private void btnFakulteEkle_Click(object sender, EventArgs e)
        {
            FrmFakulte fakulteForm = new FrmFakulte(GirenKullanici);
            if(fakulteForm.ShowDialog()==DialogResult.OK)
            {
                FakulteDoldur();
            }
        }

        private void btnBolumEkle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int fakulteID = (int)row.Cells[0].Value;
            FrmBolum bolumForm = new FrmBolum(GirenKullanici, fakulteID);

            if(bolumForm.ShowDialog()==DialogResult.OK)
            {
                BolumDoldur(fakulteID);
            }
            
        }
    }
}

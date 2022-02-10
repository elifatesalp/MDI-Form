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
    public partial class FrmAcilis : Form
    {
        public FrmAcilis()
        {
            InitializeComponent();
        }

        private void FrmAcilis_Load(object sender, EventArgs e)
        {
            timer1.Interval = 3000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FrmGiris fGiris = new FrmGiris();
            fGiris.Show();
            this.Hide();

            timer1.Stop();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

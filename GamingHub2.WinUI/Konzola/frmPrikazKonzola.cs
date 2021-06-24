using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Konzola
{
    public partial class frmPrikazKonzola : Form
    {
        APIService _service = new APIService("Konzola"); 

        public frmPrikazKonzola()
        {
            InitializeComponent();
        }

        private async void frmPrikazKonzola_Load(object sender, EventArgs e)
        {
            dgvKonzole.DataSource = await _service.Get<List<Model.Konzola>>(null);
        }

        private async void dgvKonzole_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var KonzolaId = int.Parse(dgvKonzole.SelectedRows[0].Cells[0].Value.ToString());

            frmKonzolaDodajUredi frm = new frmKonzolaDodajUredi(KonzolaId);
            var result = frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                dgvKonzole.DataSource = await _service.Get<List<Model.Konzola>>(null);
            }
        }

        private async void btnDodajKonzolu_Click(object sender, EventArgs e)
        {
            frmKonzolaDodajUredi frm = new frmKonzolaDodajUredi();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                dgvKonzole.DataSource = await _service.Get<List<Model.Konzola>>(null);
            }
        }
    }
}

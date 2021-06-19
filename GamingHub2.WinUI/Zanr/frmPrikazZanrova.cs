using GamingHub2.Model;
using GamingHub2.WinUI.Zanr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Zanrovi
{
    public partial class frmPrikazZanrova : Form
    {
        APIService _service = new APIService("Zanr"); //Zanr
        public frmPrikazZanrova()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            ZanrSearchRequest request = new ZanrSearchRequest()
            {
                Naziv = txtNaziv.Text
            };
            dgvZanrovi.DataSource = await _service.Get<List<Model.Zanr>>(request);
        }

        private async void frmPrikazZanrova_Load(object sender, EventArgs e)
        {
            dgvZanrovi.DataSource = await _service.Get<List<Model.Zanr>>(null);
        }

        private async void dgvZanrovi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var ZanrId = int.Parse(dgvZanrovi.SelectedRows[0].Cells[0].Value.ToString());

            frmZanrDodajUredi frm = new frmZanrDodajUredi(ZanrId);
            // frm.Show();
            var result = frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                dgvZanrovi.DataSource = await _service.Get<List<Model.Zanr>>(null);
            }
        }
    }
}

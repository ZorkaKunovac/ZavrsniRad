using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Korisnik
{
    public partial class frmPrikazKorisnika : Form
    {
        APIService _service = new APIService("Korisnici");
        public frmPrikazKorisnika()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            KorisnikSearchRequest request = new KorisnikSearchRequest()
            {
                Ime = txtIme.Text
            };
          //  dgvKorisnici.DataSource = await _service.Get<List<Model.Korisnici>>(request);

            var result = await _service.Get<List<Model.Korisnici>>(request);
            //foreach (var item in result)
            //{
            //    item.Uloge = "";
            //    foreach (var x in item.KorisniciUloge)
            //    {
            //        item.Uloge += $"{x.Uloga.Naziv} ";
            //    }
            //}
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = result;
        }

        private async void frmPrikazKorisnika_Load(object sender, EventArgs e)
        {
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = await _service.Get<List<Model.Korisnici>>(null);
        }

        private async void dgvKorisnici_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = dgvKorisnici.SelectedRows[0].DataBoundItem;
            frmKorisnikDetalji frm = new frmKorisnikDetalji(item as Model.Korisnici);
            frm.ShowDialog();

            //var korisnikId = int.Parse(dgvKorisnici.SelectedRows[0].Cells[0].Value.ToString());

            //frmKorisnikDetalji frm = new frmKorisnikDetalji(korisnikId);
            //var result = frm.ShowDialog();
            //if (frm.DialogResult == DialogResult.OK)
            //{
            //    dgvKorisnici.DataSource = await _service.Get<List<Model.Korisnik>>(null);
            //}

        }

        private void btnNoviKorisnik_Click(object sender, EventArgs e)
        {
            frmKorisnikDetalji frm = new frmKorisnikDetalji();
            frm.ShowDialog();
        }
    }
}

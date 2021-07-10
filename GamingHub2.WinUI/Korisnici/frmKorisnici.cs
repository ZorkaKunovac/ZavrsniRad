using GamingHub2.Model.Requests;
using GamingHub2.WinUI.Helper;
using GamingHub2.WinUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Korisnici
{
    public partial class frmKorisnici : Form
    {
        private readonly APIService _korisniciService = new APIService("Korisnici");

        public frmKorisnici()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new KorisnikSearchRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                KorisnickoIme = txtKorisnickoIme.Text
            };

            var result = await _korisniciService.Get<List<Model.Korisnici>>(search);
            foreach (var item in result)
            {
                item.Uloge = "";
                foreach (var x in item.KorisniciUloge)
                {
                    item.Uloge += $"{x.Uloga.Naziv} ";
                }

                if (item.Slika == null || item.Slika.Length == 0)
                {
                    item.Slika = ImageHelper.ImageToByteArray(Resources.default_profile);
                }
            }

            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = result;
        }

        private async void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;
            frmKorisniciDetalji frm = new frmKorisniciDetalji(int.Parse(id.ToString()));
            var result = frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                var result2 = await _korisniciService.Get<List<Model.Korisnici>>(null);
                foreach (var item in result2)
                {
                    item.Uloge = "";
                    foreach (var x in item.KorisniciUloge)
                    {
                        item.Uloge += $"{x.Uloga.Naziv} ";
                    }
                }
                dgvKorisnici.AutoGenerateColumns = false;
                dgvKorisnici.DataSource = result2;
            }
        }

        private async void btnNoviKorisnik_Click(object sender, EventArgs e)
        {
            frmKorisniciDetalji frm = new frmKorisniciDetalji();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                dgvKorisnici.DataSource = await _korisniciService.Get<List<Model.Korisnici>>(null);
            }

        }

    }
}

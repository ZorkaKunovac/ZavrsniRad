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

namespace GamingHub2.WinUI.Recenzija
{
    public partial class frmPrikazRecenzija : Form
    {
        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _igraService = new APIService("Igra");
        private readonly APIService _recenzijaService = new APIService("Recenzija");
        public frmPrikazRecenzija()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            RecenzijaSearchRequest request = new RecenzijaSearchRequest()
            {
                Naslov = txtNaslov.Text
            };
            var objKorisnici = cmbKorisnici.SelectedValue;
            request.KorisnikId = int.Parse(objKorisnici?.ToString() ?? "0");

            var result = await _recenzijaService.Get<List<Model.Recenzija>>(request);

            dgvRecenzije.AutoGenerateColumns = false;
            dgvRecenzije.DataSource = result;
        }


        private async Task LoadKorisnici()
        {
            var result = await _korisniciService.Get<List<Model.Korisnici>>(null);
            result.Insert(0, new Model.Korisnici());

            cmbKorisnici.DataSource = result;
            cmbKorisnici.DisplayMember = "KorisnickoIme";
            cmbKorisnici.ValueMember = "KorisnikId"; //Ili je Id
        }

    }
}

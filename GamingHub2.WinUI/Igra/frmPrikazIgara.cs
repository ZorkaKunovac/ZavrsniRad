using GamingHub2.Model.Requests;
using GamingHub2.WinUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Igra
{
    public partial class frmPrikazIgara : Form
    {
        APIService _service = new APIService("Igra");
        APIService _konzolaService = new APIService("Konzola");
        APIService _zanrService = new APIService("Zanr");
        public frmPrikazIgara()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            IgraSearchRequest request = new IgraSearchRequest()
            {
                Naziv = txtNaziv.Text
            };
            dgvIgre.DataSource = await _service.Get<List<Model.Igra>>(request);
        }

        private async void frmIgre_Load(object sender, EventArgs e)
        {
            //dgvKorisnici.AutoGenerateColumns = false;

            //var result = await _service.Get<List<Model.Igra>>(null);
            //dgvIgre.DataSource = result;
            dgvIgre.DataSource = await _service.Get<List<Model.Igra>>(null);

        }


        //  IgraUpsertRequest request = new IgraUpsertRequest();

        //private async void btnSave_Click(object sender, EventArgs e)
        //{
        //    //if (ValidateChildren())
        //    //{
        //        var konzole = clbKonzole.CheckedItems.Cast<Model.Konzola>().Select(x => x.ID).ToList();
        //        var zanrovi = clbZanrovi.CheckedItems.Cast<Model.Zanr>().Select(x => x.ID).ToList();

        //        request.Naziv = txtNaziv.Text;
        //        request.Developer = txtDeveloper.Text;
        //        request.Izdavac = txtIzdavac.Text;
        //        request.DatumIzlaska = dtpDatumIzlaska.Value;
        //        request.VideoLink = txtVideoLink.Text;
        //        request.Konzole = konzole;
        //        request.Zanrovi = zanrovi;

        //       // await _service.Insert<Model.Proizvod>(request);
        //        Model.Igra entity = null;
        //        if (!_id.HasValue)
        //        {
        //            entity = await _service.Insert<Model.Igra>(request);
        //        }
        //        else
        //        {
        //            entity = await _service.Update<Model.Igra>(_id.Value, request);
        //        }

        //        if (entity != null)
        //        {
        //            MessageBox.Show("Uspješno izvršeno");
        //            this.Close();
        //            dgvIgre.DataSource = await _service.Get<List<Model.Igra>>(null);
        //        }
        //    //}
        //}


        private async void dgvIgre_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var igraId = int.Parse(dgvIgre.SelectedRows[0].Cells[0].Value.ToString());

            frmIgraDodajUredi frm = new frmIgraDodajUredi(igraId);
            var result = frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                dgvIgre.DataSource = await _service.Get<List<Model.Korisnik>>(null);
            }

        }
           
    }
}

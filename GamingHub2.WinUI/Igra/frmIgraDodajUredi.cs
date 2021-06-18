using GamingHub2.Model.Requests;
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
    public partial class frmIgraDodajUredi : Form
    {
        APIService _service = new APIService("Igra");
        APIService _konzolaService = new APIService("Konzola");
        APIService _zanrService = new APIService("Zanr");

        private int? _id = null;
        public frmIgraDodajUredi(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async Task LoadKonzole()
        {
            //var konzole = await _konzolaService.Get<List<Model.Konzola>>();
            //clbKonzole.DataSource = konzole;
            //clbKonzole.DisplayMember = "Naziv";
            var konzoleList = await _konzolaService.Get<List<Model.Konzola>>(null);
            clbKonzole.DataSource = konzoleList;
            clbKonzole.DisplayMember = "Naziv";
            clbKonzole.ValueMember = "Id";
        }
        private async void frmIgraDodajUredi_Load(object sender, EventArgs e)
        {

            //var konzole = await _konzolaService.Get<List<Model.Konzola>>(null);
            await LoadKonzole();
            var zanrovi = await _zanrService.Get<List<Model.Zanr>>(null);
            //var konzole = await _konzolaService.Get<List<Model.Konzola>>();
            clbZanrovi.DataSource = zanrovi;
            clbZanrovi.DisplayMember = "Naziv";

            if (_id.HasValue)
            {
                var igra = await _service.GetById<Model.Igra>(_id);

                txtNaziv.Text = igra.Naziv;
                txtDeveloper.Text = igra.Developer;
                txtIzdavac.Text = igra.Izdavac;
                dtpDatumIzlaska.Value = (DateTime)igra.DatumIzlaska;
                // txtVideoLink.Text=igra.vi
                foreach (var item in igra.IgraKonzola)
                {
                    for (int i = 0; i < clbKonzole.Items.Count; i++)
                    {
                        Model.Konzola trenutni = (Model.Konzola)clbKonzole.Items[i];
                        if (trenutni.ID == item.KonzolaID)
                        {
                            clbKonzole.SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                }

                //foreach (var item in igra.IgraZanr)
                //{
                //    for (int i = 0; i < clbZanrovi.Items.Count; i++)
                //    {
                //        Model.Zanr trenutni = (Model.Zanr)clbZanrovi.Items[i];
                //        if (trenutni.ID == item.ZanrID)
                //        {
                //            clbZanrovi.SetItemCheckState(i, CheckState.Checked);
                //        }
                //    }
                //}

            }
        }

        IgraUpsertRequest request = new IgraUpsertRequest();
        private async void btnSave_Click(object sender, EventArgs e)
        {

            if (ValidateChildren())
            {
                var konzole = clbKonzole.CheckedItems.Cast<Model.Konzola>().Select(x => x.ID).ToList();
                var zanrovi = clbZanrovi.CheckedItems.Cast<Model.Zanr>().Select(x => x.ID).ToList();

                request.Naziv = txtNaziv.Text;
                request.Developer = txtDeveloper.Text;
                request.Izdavac = txtIzdavac.Text;
                request.DatumIzlaska = dtpDatumIzlaska.Value;
                request.VideoLink = txtVideoLink.Text;
                request.Konzole = konzole;
                request.Zanrovi = zanrovi;

                // await _service.Insert<Model.Proizvod>(request);
                Model.Igra entity = null;
                if (!_id.HasValue)
                {
                    entity = await _service.Insert<Model.Igra>(request);
                }
                else
                {
                    entity = await _service.Update<Model.Igra>(_id.Value, request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                    this.Close();
                    //  dgvIgre.DataSource = await _service.Get<List<Model.Igra>>(null);
                }

            }

            //var konzole = clbKonzole.CheckedItems.Cast<Model.Konzola>().Select(x => x.ID).ToList();
            //var zanrovi = clbZanrovi.CheckedItems.Cast<Model.Zanr>().Select(x => x.ID).ToList();
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filename = openFileDialog.FileName;
                var file = File.ReadAllBytes(filename);

                request.SlikaLink = file;

                txtSlika.Text = filename;

                Image image = Image.FromFile(filename);
                pictureBox1.Image = image;
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            //prvo slovo veliko, min duzina 5, max 50 slova
            // Regex reg = new Regex(@"^[A-Z][a-z]{1,19}$");
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.ObavezanUnosPolja);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[\w \t:]{5,50}$"))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                //ili errorProvider.SetError(txtNaziv, null);
                errorProvider.Clear();
            }
        }
        private void txtDeveloper_Validating(object sender, CancelEventArgs e)
        {
            //prvo slovo veliko, min duzina 5, max 50 slova
            // Regex reg = new Regex(@"^[A-Z][a-z]{1,19}$");
            if (string.IsNullOrWhiteSpace(txtDeveloper.Text))
            {
                errorProvider.SetError(txtDeveloper, Properties.Resources.ObavezanUnosPolja);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtDeveloper.Text, @"^[\w \t:.]{3,50}$"))
            {
                errorProvider.SetError(txtDeveloper, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                //ili errorProvider.SetError(txtNaziv, null);
                errorProvider.Clear();
            }
        }

        private void txtIzdavac_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIzdavac.Text))
            {
                errorProvider.SetError(txtIzdavac, Properties.Resources.ObavezanUnosPolja);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtIzdavac.Text, @"^[\w \t:.]{3,50}$"))
            {
                errorProvider.SetError(txtIzdavac, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                //ili errorProvider.SetError(txtNaziv, null);
                errorProvider.Clear();
            }
        }
    }
}

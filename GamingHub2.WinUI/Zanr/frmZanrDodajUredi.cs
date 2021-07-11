using GamingHub2.Model.Requests;
using GamingHub2.WinUI.Properties;
using GamingHub2.WinUI.Zanrovi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Zanr
{
    public partial class frmZanrDodajUredi : Form
    {
        private readonly APIService _service = new APIService("Zanr");
        private int? _id = null;

        public frmZanrDodajUredi(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }
        private async void frmZanrDodajUredi_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var zanr = await _service.GetById<Model.Zanr>(_id);

                txtNaziv.Text = zanr.Naziv;
                rtbOpis.Text = zanr.Opis;
            }
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            ZanrUpsertRequest request = new ZanrUpsertRequest()
            {
                Naziv = txtNaziv.Text,
                Opis = rtbOpis.Text
            };

            Model.Zanr entity = null;
            if (!_id.HasValue)
                entity = await _service.Insert<Model.Zanr>(request);
            else
                entity = await _service.Update<Model.Zanr>(_id, request);

            if (entity != null)
            {
                MessageBox.Show("Uspješno izvršeno");
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[A-za-z \t]{3,40}$"))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
            }
        }
        private void rtbOpis_Validating(object sender, CancelEventArgs e)
        {
            if (rtbOpis.Text.Length > 499)
            {
                e.Cancel = true;
                errorProvider.SetError(rtbOpis, Resources.PrekoracenjeKaraktera);
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}

using GamingHub2.Model.Requests;
using GamingHub2.WinUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Konzola
{
    public partial class frmKonzolaDodajUredi : Form
    {
        private readonly APIService _service = new APIService("Konzola");
        private int? _id = null;

        public frmKonzolaDodajUredi(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmKonzolaDodajUredi_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var konzola = await _service.GetById<Model.Konzola>(_id);

                txtNaziv.Text = konzola.Naziv;
                rtbDetalji.Text = konzola.Detalji;
            }
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            KonzolaUpsertRequest request = new KonzolaUpsertRequest()
            {
                Naziv = txtNaziv.Text,
                Detalji = rtbDetalji.Text
            };

            Model.Konzola entity = null;
            if (!_id.HasValue)
                entity = await _service.Insert<Model.Konzola>(request);
            else
                entity = await _service.Update<Model.Konzola>(_id, request);

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
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[\w \t]{2,40}$"))
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

        private void rtbDetalji_Validating(object sender, CancelEventArgs e)
        {
            if (rtbDetalji.Text.Length > 499)
            {
                e.Cancel = true;
                errorProvider.SetError(rtbDetalji, Resources.PrekoracenjeKaraktera);
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}

using GamingHub2.Model.Requests;
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

namespace GamingHub2.WinUI.Korisnik
{
    public partial class frmRoleManager : Form
    {
        APIService _service = new APIService("Uloge");
        public frmRoleManager()
        {
            InitializeComponent();
        }

        private async void btnDodajUlogu_Click(object sender, EventArgs e)
        {
            UlogaInsertRequest request = new UlogaInsertRequest()
            {
                Naziv = txtNaziv.Text
            };
            Model.Uloge entity = null;
            entity = await _service.Insert<Model.Uloge>(request);

            if (entity != null)
            {
                MessageBox.Show("Uspješno izvršeno");
                DialogResult = DialogResult.OK;
                if (this.DialogResult == DialogResult.OK)
                {
                    dgvUloge.DataSource = await _service.Get<List<Model.Uloge>>(null);
                }
            }
        }

        private async void frmRoleManager_Load(object sender, EventArgs e)
        {
            dgvUloge.AutoGenerateColumns = false;
            dgvUloge.DataSource = await _service.Get<List<Model.Uloge>>(null);
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[A-Z][a-z]{3,40}$"))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}

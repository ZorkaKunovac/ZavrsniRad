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
    public partial class frmRoleManager : Form
    {
        APIService _service = new APIService("Uloga");
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
            Model.Uloga entity = null;
            entity = await _service.Insert<Model.Uloga>(request);

            if (entity != null)
            {
                MessageBox.Show("Uspješno izvršeno");
                DialogResult = DialogResult.OK;
                if (this.DialogResult == DialogResult.OK)
                {
                    dgvUloge.DataSource = await _service.Get<List<Model.Uloga>>(null);
                }
            }
        }

        private async void frmRoleManager_Load(object sender, EventArgs e)
        {
            dgvUloge.AutoGenerateColumns = false;
            dgvUloge.DataSource = await _service.Get<List<Model.Uloga>>(null);
        }

    }
}

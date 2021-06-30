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

namespace GamingHub2.WinUI.Proizvod
{
    public partial class frmProizvodDodaj : Form
    {
        APIService _service = new APIService("Proizvod");
        APIService _igrakonzolaservice = new APIService("IgraKonzola");

        private int? _id = null;
        public frmProizvodDodaj(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async Task LoadIgraKonzola()
        {
            var proizvodi = await _service.Get<List<Model.Proizvod>>(null);
            var igraKonzole = await _igrakonzolaservice.Get<List<Model.IgraKonzola>>(null);
            var result = igraKonzole.Where(ik => !proizvodi.Any(p => p.IgraKonzolaID == ik.ID)).Distinct().ToList();

            cmbIgraKonzola.DataSource = result;
            cmbIgraKonzola.DisplayMember = "Naziv";
            cmbIgraKonzola.ValueMember = "ID";
        }

        private async void frmProizvodDodajUredi_Load(object sender, EventArgs e)
        {
            await LoadIgraKonzola();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Model.Proizvod entity = null;

                if (!_id.HasValue)
                {
                    ProizvodInsertRequest request = new ProizvodInsertRequest()
                    {
                        IgraKonzolaID = int.Parse(cmbIgraKonzola.SelectedValue.ToString()),
                        
                        NazivProizvoda = cmbIgraKonzola.Text,
                        ProdajnaCijena = numCijena.Value,
                        Popust = numPopust.Value,
                        Status = chbStatus.Checked
                    };
                    entity = await _service.Insert<Model.Proizvod>(request);
                }
                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

    }
}

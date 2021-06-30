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
    public partial class frmProizvodDodajUredi : Form
    {
        APIService _service = new APIService("Proizvod");
        APIService _igrakonzolaservice = new APIService("IgraKonzola");

        private int? _id = null;
        public frmProizvodDodajUredi(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async Task LoadIgraKonzola()
        {
            var result = await _igrakonzolaservice.Get<List<Model.IgraKonzola>>(null);
          //  result.Insert(0, new Model.IgraKonzola());
            cmbIgraKonzola.DataSource = result;
            cmbIgraKonzola.DisplayMember = "Naziv";
            cmbIgraKonzola.ValueMember = "ID";
        }

        private async void frmProizvodDodajUredi_Load(object sender, EventArgs e)
        {
            await LoadIgraKonzola();

            if (_id.HasValue)
            {
                var proizvod = await _service.GetById<Model.Proizvod>(_id.Value);

                cmbIgraKonzola.SelectedValue = proizvod.IgraKonzolaID;
                numCijena.Value = (decimal)proizvod.ProdajnaCijena;
                numPopust.Value = (decimal)proizvod.Popust;
                chbStatus.Checked = (bool)(proizvod.Status);
            }
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
                        NazivProizvoda = cmbIgraKonzola.DisplayMember,
                        ProdajnaCijena = (float)numCijena.Value,
                        Popust = (float)numPopust.Value,
                        Status = chbStatus.Checked
                    };
                    entity = await _service.Insert<Model.Proizvod>(request);
                }
                else
                {
                    ProizvodUpdateRequest request = new ProizvodUpdateRequest()
                    {
                        NazivProizvoda = cmbIgraKonzola.DisplayMember,
                        ProdajnaCijena = (float)numCijena.Value,
                        Popust = (float)numPopust.Value,
                        Status = chbStatus.Checked
                    };
                    entity = await _service.Update<Model.Proizvod>(_id.Value, request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                    this.Close();
                }
            }
        }


    }
}

﻿using GamingHub2.Model.Requests;
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
    public partial class frmProizvodUredi : Form
    {
        APIService _service = new APIService("Proizvod");
        APIService _igrakonzolaservice = new APIService("IgraKonzola");

        private int? _id = null;

        public frmProizvodUredi(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmProizvodUredi_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var proizvod = await _service.GetById<Model.Proizvod>(_id.Value);

                txtNazivProizvoda.Text = proizvod.NazivProizvoda;
                numCijena.Value = proizvod.ProdajnaCijena;
                numPopust.Value = proizvod.Popust;
                chbStatus.Checked = (bool)(proizvod.Status);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Model.Proizvod entity = null;

                if (_id.HasValue)
                {
                    ProizvodUpdateRequest request = new ProizvodUpdateRequest()
                    {
                        NazivProizvoda = txtNazivProizvoda.Text,
                        ProdajnaCijena = numCijena.Value,
                        Popust = numPopust.Value,
                        Status = chbStatus.Checked
                    };
                    entity = await _service.Update<Model.Proizvod>(_id.Value, request);
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

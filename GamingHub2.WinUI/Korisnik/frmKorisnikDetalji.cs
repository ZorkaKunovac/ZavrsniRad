using GamingHub2.Model.Requests;
using GamingHub2.WinUI.Properties;
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
    public partial class frmKorisnikDetalji : Form
    {
        private readonly APIService _service = new APIService("Korisnik");
        APIService _ulogaService = new APIService("Uloga");

        private int? _id = null;
        public frmKorisnikDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }
        //private async Task LoadUloge()
        //{
        //    var ulogeList = await _ulogaService.Get<List<Model.Uloga>>(null);
        //    clbUloge.DataSource = ulogeList;
        //    clbUloge.DisplayMember = "Naziv";
        //    clbUloge.ValueMember = "Id";
        //}

        private async void frmKorisnikDetalji_Load(object sender, EventArgs e)
        {
            //var ulogeList = await _ulogaService.Get<List<Model.Uloga>>(null);
            //clbUloge.DataSource = ulogeList;
            //clbUloge.DisplayMember = "Naziv";
            //clbUloge.ValueMember = "Id";
            //var uloge = await _ulogaService.Get<List<Model.Uloga>>(null);
            //clbUloge.DataSource = uloge;
            //clbUloge.DisplayMember = "Naziv";


            if (_id.HasValue)
            {
                var korisnik = await _service.GetById<Model.Korisnik>(_id);

                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtKorisnickoIme.Text = korisnik.KorisnickoIme;
                txtEmail.Text = korisnik.Email;
                txtTelefon.Text = korisnik.Telefon;
                //foreach (var item in korisnik.KorisnikUloga)
                //{
                //    for (int i = 0; i < clbUloge.Items.Count; i++)
                //    {
                //        Model.Uloga trenutni = (Model.Uloga)clbUloge.Items[i];
                //        if (trenutni.Id == item.UlogaId)
                //        {
                //            clbUloge.SetItemCheckState(i, CheckState.Checked);
                //        }
                //    }
                //}
            }
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                //var uloge = clbUloge.CheckedItems.Cast<Model.Uloga>().Select(x => x.Id).ToList();

                Model.Korisnik entity = null;
                if (!_id.HasValue)
                {
                    KorisnikInsertRequest request = new KorisnikInsertRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        Email = txtEmail.Text,
                        Telefon = txtTelefon.Text,
                        KorisnickoIme = txtKorisnickoIme.Text,
                        Password = txtPassword.Text,
                        PasswordPotvrda = txtPasswordPotvrda.Text,
                        //Uloge = uloge
                    };

                   entity=  await _service.Insert<Model.Korisnik>(request);
                }
                else
                {
                    KorisnikUpdateRequest request = new KorisnikUpdateRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        Telefon = txtTelefon.Text,
                        Password = txtPassword.Text,
                        PasswordPotvrda = txtPasswordPotvrda.Text,
                        //Uloge = uloge
                    };
                    entity = await _service.Update<Model.Korisnik>(_id.Value, request);
                }
                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                    DialogResult = DialogResult.OK;//sada možeš vidjeti
                    this.Close();
                    //  dgvIgre.DataSource = await _service.Get<List<Model.Igra>>(null);
                }
            }
            //MessageBox.Show("Uspješno izvršeno");
            //DialogResult = DialogResult.OK;//sada možeš vidjeti
            //this.Close();
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text) || txtKorisnickoIme.Text.Length < 3)
            {
                errorProvider.SetError(txtEmail, Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }


    }
}

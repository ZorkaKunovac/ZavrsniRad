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
        private int? _id = null;
        public frmKorisnikDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmKorisnikDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var korisnik = await _service.GetById<Model.Korisnik>(_id);

                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtKorisnickoIme.Text = korisnik.KorisnickoIme;
                txtEmail.Text = korisnik.Email;
                txtTelefon.Text = korisnik.Telefon;
                //txtPassword.Text=korisnik.
            }
        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
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
                        PasswordPotvrda = txtPasswordPotvrda.Text
                    };

                    await _service.Insert<Model.Korisnik>(request);
                }
                else
                {
                    KorisnikUpdateRequest request = new KorisnikUpdateRequest()
                    {
                        Ime = txtIme.Text,
                        Prezime = txtPrezime.Text,
                        Telefon = txtTelefon.Text,
                        Password = txtPassword.Text,
                        PasswordPotvrda = txtPasswordPotvrda.Text

                    };
                    await _service.Update<Model.Korisnik>(_id.Value, request);
                }
            }
            MessageBox.Show("Uspješno izvršeno");
            DialogResult = DialogResult.OK;//sada možeš vidjeti
            this.Close();
           // frmPrikazKorisnika frmPrikazKorisnika = new frmPrikazKorisnika();
            //frmPrikazKorisnika.
          // frmPrikazKorisnika.dgvKorisnici.DataSource = await _service.Get<List<Model.Korisnik>>(null);
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtIme, Resources.ObaveznoPolje);
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
                e.Cancel = true;
                errorProvider.SetError(txtPrezime, Resources.ObaveznoPolje);
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
                e.Cancel = true;
                errorProvider.SetError(txtEmail, Resources.ObaveznoPolje);
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
                e.Cancel = true;
                errorProvider.SetError(txtEmail, Resources.ObaveznoPolje);
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }
    }
}

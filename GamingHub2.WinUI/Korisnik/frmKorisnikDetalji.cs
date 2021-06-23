using GamingHub2.Model;
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
        APIService _service = new APIService("Korisnici");
        APIService _ulogaService = new APIService("Uloge");

        // private int? _id = null;
        private Model.Korisnici _korisnik;
        public frmKorisnikDetalji(Model.Korisnici korisnik = null)
        {
            InitializeComponent();
            _korisnik = korisnik;
            
        }
        private async Task LoadUloge()
        {
            var ulogeList = await _ulogaService.Get<List<Model.Uloge>>(null);
            clbUloge.DataSource = ulogeList;
            clbUloge.DisplayMember = "Naziv";
            //clbUloge.ValueMember = "Id";
        }

        private async void frmKorisnikDetalji_Load(object sender, EventArgs e)
        {
            await LoadUloge();

            if (_korisnik!=null)
            {

                var korisnik = await _service.GetById<Model.Korisnici>(_korisnik.KorisnikId);

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
                var roleList = clbUloge.CheckedItems.Cast<Model.Uloge>().Select(x => x.UlogaId).ToList();
                var request = new KorisniciUpsertRequest()
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Email = txtEmail.Text,
                    Telefon = txtTelefon.Text,
                    KorisnickoIme = txtKorisnickoIme.Text,
                    Password = txtPassword.Text,
                    PasswordPotvrda = txtPasswordPotvrda.Text,
                   // Status = cbStatus.Checked,
                    Uloge = roleList
                };

                Model.Korisnici entity = null;
                try
                {
                    if (_korisnik == null)
                    {

                        entity = await _service.Update<Model.Korisnici>(_korisnik.KorisnikId, request);
                        //if (entity.KorisnickoIme.Equals(APIService.Username))
                        //{
                        //    APIService.Password = request.Password;
                        //}
                    }
                    else
                    {
                        entity = await _service.Insert<Model.Korisnici>(request);
                    }
                }
                catch (Exception err)
                {

                    MessageBox.Show(err.Message);
                }
                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                }
                this.Close();

                //var uloge = clbUloge.CheckedItems.Cast<Model.Uloga>().Select(x => x.Id).ToList();
                //var ulogeList = clbUloge.CheckedItems.Cast<Model.Uloga>().Select(x => x.Id).ToList();

                // Model.Korisnik entity = null;
                /* if (_korisnik == null)
                 {
                     var ulogeList = clbUloge.CheckedItems.Cast<Uloge>();
                     var ulogeIdList = ulogeList.Select(x => x.UlogaId).ToList();

                     //    KorisnikInsertRequest request = new KorisnikInsertRequest()
                     //    {
                     //        Ime = txtIme.Text,
                     //        Prezime = txtPrezime.Text,
                     //        Email = txtEmail.Text,
                     //        Telefon = txtTelefon.Text,
                     //        KorisnickoIme = txtKorisnickoIme.Text,
                     //        Password = txtPassword.Text,
                     //        PasswordPotvrda = txtPasswordPotvrda.Text,
                     //        Uloge = ulogeIdList
                     //    };

                     //    var korisnik =  await _service.Insert<Model.Korisnik>(request);
                     //}
                     //else
                     //{
                     //    KorisnikUpdateRequest request = new KorisnikUpdateRequest()
                     //    {
                     //        Ime = txtIme.Text,
                     //        Prezime = txtPrezime.Text,
                     //        Telefon = txtTelefon.Text,
                     //        Password = txtPassword.Text,
                     //        PasswordPotvrda = txtPasswordPotvrda.Text,
                     //        //Uloge = uloge
                     //    };
                     //    var korisnik = await _service.Update<Model.Korisnik>(_korisnik.Id, request);
                     //}
                     //if (entity != null)
                     //{
                     //    MessageBox.Show("Uspješno izvršeno");
                     // //   DialogResult = DialogResult.OK;//sada možeš vidjeti
                     //    this.Close();
                     //    //  dgvIgre.DataSource = await _service.Get<List<Model.Igra>>(null);
                     //}
                 }*/
            }
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

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

namespace GamingHub2.WinUI
{
    public partial class frmLogin : Form
    {
        APIService _korisniciService = new APIService("Korisnici");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Text;
            try
            {
                var TrenutniKorisnik = await _korisniciService.Get<Model.Korisnici>(null, "MojProfil");

                if (TrenutniKorisnik != null)
                {
                    bool isAdmin = TrenutniKorisnik.KorisniciUloge.Any(x => x.Uloga.Naziv == "Administrator");
                    bool isModerator = TrenutniKorisnik.KorisniciUloge.Any(x => x.Uloga.Naziv == "Moderator");
                    if(!isAdmin && !isModerator)
                    {
                        MessageBox.Show("Pristup aplikaciji je dozovljen samo administratorima i moderatorima.", "Pristup zabranjen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    APIService.TrenutniKorisnik = TrenutniKorisnik;
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {

            }


            //try
            //{
            //    APIService.Username = txtUsername.Text;
            //    APIService.Password = txtPassword.Text;
            //    await _korisniciService.Get<dynamic>(null);

            //    List<Model.Korisnici> listKorisnici = await _korisniciService.Get<List<Model.Korisnici>>(new KorisnikSearchRequest() { KorisnickoIme = APIService.Username });
            //    Model.Korisnici korisnik = listKorisnici.Where(x => x.KorisnickoIme == APIService.Username).FirstOrDefault();
            //    if (korisnik != null)
            //    {
            //        frmPocetna frm = new frmPocetna();
            //        frm.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Pogrešno korisničko ime ili lozinka!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}

        }
    }
}

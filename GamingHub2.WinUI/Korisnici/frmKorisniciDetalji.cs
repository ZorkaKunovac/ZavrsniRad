using GamingHub2.Model.Requests;
using GamingHub2.WinUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Korisnici
{
    public partial class frmKorisniciDetalji : Form
    {
        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _ulogeService = new APIService("Uloge");
        private int? _id = null;
        private byte[] slikaTemp;

        public frmKorisniciDetalji(int? korisnikId = null)
        {
            InitializeComponent();
            _id = korisnikId;
        }

        KorisniciUpsertRequest request = new KorisniciUpsertRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() && txtSlika_Validating())
            {
                var roleList = clbUloge.CheckedItems.Cast<Model.Uloge>().Select(x => x.UlogaId).ToList();
           
                request.Ime = txtIme.Text;
                request.Prezime = txtPrezime.Text;
                request.Email = txtEmail.Text;
                request.Telefon = txtTelefon.Text;
                request.KorisnickoIme = txtKorisnickoIme.Text;
                request.Password = txtLozinka.Text;
                request.PasswordPotvrda = txtPotvrdaLozinke.Text;
                request.Uloge = roleList;
                if (txtSlika.Text != string.Empty)//Slika
                {
                    var file = File.ReadAllBytes(txtSlika.Text);
                    request.Slika = file;
                }
                else
                {
                    request.Slika = slikaTemp;
                }

                Model.Korisnici entity = null;
                try
                {
                    if (_id.HasValue)
                    {

                        entity = await _korisniciService.Update<Model.Korisnici>(_id.Value, request);
                        if (entity.KorisnickoIme.Equals(APIService.Username))
                        {
                            APIService.Password = request.Password;
                        }
                    }
                    else
                    {
                        entity = await _korisniciService.Insert<Model.Korisnici>(request);
                    }
                }
                catch (Exception err)
                {

                    MessageBox.Show(err.Message);
                }
                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                    DialogResult = DialogResult.OK;
                }
                this.Close();
            }
        }
        private async void frmKorisniciDetalji_Load(object sender, EventArgs e)
        {
            var ulogeList = await _ulogeService.Get<List<Model.Uloge>>(null);
            clbUloge.DataSource = ulogeList;
            clbUloge.DisplayMember = "Naziv";


            if (_id.HasValue)
            {
                var result = await _korisniciService.GetById<Model.Korisnici>(_id);
                txtIme.Text = result.Ime;
                txtPrezime.Text = result.Prezime;
                txtEmail.Text = result.Email;
                txtTelefon.Text = result.Telefon;
                txtKorisnickoIme.Text = result.KorisnickoIme;
                slikaTemp = result.Slika;
                if (result.Slika.Length != 0)
                {
                    pbSlika.Image = ImageHelper.BytesToImage(result.Slika);
                }

                foreach (var item in result.KorisniciUloge)
                {
                    for (int i = 0; i < clbUloge.Items.Count; i++)
                    {
                        Model.Uloge trenutni = (Model.Uloge)clbUloge.Items[i];
                        if (trenutni.UlogaId == item.UlogaId)
                        {
                            clbUloge.SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                }
            }
        }
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filename = openFileDialog.FileName;
                var file = File.ReadAllBytes(filename);

                request.Slika = file;

                txtSlika.Text = filename;

                Image image = Image.FromFile(filename);
                pbSlika.Image = image;
            }
        }
    
        private bool txtSlika_Validating()
        {
            if (string.IsNullOrWhiteSpace(txtSlika.Text) && !_id.HasValue)
            {
                errorProvider.SetError(txtSlika, Properties.Resources.ObaveznoPolje);
                return false;
            }
            else
            {
                errorProvider.SetError(txtSlika, null);
            }
            return true;
        }
        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtIme.Text, @"^[A-Z][A-Za-z \t-]{2,50}$"))
            {
                errorProvider.SetError(txtIme, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtPrezime.Text, @"^[A-Z][A-Za-z \t-]{2,50}$"))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.ObaveznoPolje);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-z]+[-+.'\w]+@[a-z]+\.[-.\w]+$", RegexOptions.IgnoreCase))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.NeispravanFormat);
                e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
           if (!Regex.IsMatch(txtTelefon.Text, @"^[+]?\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3,4}$", RegexOptions.IgnoreCase))
            {
                errorProvider.SetError(txtTelefon, "Format telefona je: +387 61 000 111");
                e.Cancel = true;
            }
            else
            {
                errorProvider.Clear();
            }
        }

     
    }
}

using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Recenzija
{
    public partial class frmDodajUrediRecenzija : Form
    {

        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _igraService = new APIService("Igra");
        private readonly APIService _recenzijaService = new APIService("Recenzija");

        private int? _id = null;
        private byte[] slikaTemp;

        public frmDodajUrediRecenzija(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async Task LoadIgre()
        {
            var result = await _igraService.Get<List<Model.Igra>>(null);
            result.Insert(0, new Model.Igra());
            cmbIgra.DataSource = result;
            cmbIgra.DisplayMember = "Naziv";
            cmbIgra.ValueMember = "Id";
        }

        private async void frmDodajUrediRecenzija_Load(object sender, EventArgs e)
        {
            await LoadIgre();

            if (_id.HasValue)
            {
                var recenzija = await _recenzijaService.GetById<Model.Recenzija>(_id.Value);

                txtNaslov.Text = recenzija.Naslov;
                cmbIgra.SelectedValue = recenzija.IgraId;
                txtVideoRecenzija.Text = recenzija.VideoRecenzija;
                slikaTemp = recenzija.Slika;
                rtbSadrzaj.Text = recenzija.Sadrzaj;
                if (recenzija.Slika.Length != 0)
                    pbSlika.Image = BytesToImage(recenzija.Slika);

            }
        }

        public Image BytesToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            return Image.FromStream(ms);
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        
        private async void btnSave_Click(object sender, EventArgs e)
        {
            var korisniklist = await _korisniciService.Get<List<Model.Korisnici>>(new KorisnikSearchRequest() { KorisnickoIme = APIService.Username });
            var korisnik = korisniklist.Where(x => x.KorisnickoIme == APIService.Username).FirstOrDefault();


            if (ValidateChildren() && txtSlika_Validating())
            {
                RecenzijaUpsertRequest request = new RecenzijaUpsertRequest()
                {
                    KorisnikId=korisnik.KorisnikId,
                    IgraId = int.Parse(cmbIgra.SelectedValue.ToString()),
                    DatumObjave = DateTime.Now,
                    Naslov = txtNaslov.Text,
                    Sadrzaj = rtbSadrzaj.Text,
                    VideoRecenzija = txtVideoRecenzija.Text
                };

                if (txtSlika.Text != string.Empty)//Slika
                {
                    var file = File.ReadAllBytes(txtSlika.Text);
                    request.Slika = file;
                }
                else
                    request.Slika = slikaTemp;

                Model.Recenzija entity = null;
                if (!_id.HasValue)
                    entity = await _recenzijaService.Insert<Model.Recenzija>(request);
                else
                    entity = await _recenzijaService.Update<Model.Recenzija>(_id.Value, request);


                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                    this.Close();
                }
            }

        }
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                txtSlika.Text = fileName;
                Image image = Image.FromFile(fileName);
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

    }  
}

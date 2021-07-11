using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingHub2.WinUI.Izvjestaj
{
    public partial class frmIzvjestaj : Form
    {
        private readonly APIService _serviceNarudzba = new APIService("Narudzba");
        private readonly APIService _serviceNarudzbaStavka = new APIService("NarudzbaStavka");

        public frmIzvjestaj()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private async void btnProizvodi_Click(object sender, EventArgs e)
        {

            if (dtpDatumDo.Enabled == true && dtpDatumOd.Enabled == true)
            {

                var request = new Model.Requests.NarudzbaSearchRequest
                {
                    Status = true
                };

                var listaNarudzbi = await _serviceNarudzba.Get<List<Model.Narudzba>>(request);
                List<Model.NarudzbaIzvjestaj> result = new List<Model.NarudzbaIzvjestaj>();
                UkupnoIznos = listaNarudzbi.Sum(x => x.Iznos);

                foreach (var item in listaNarudzbi)
                {
                    if (dtpDatumOd.Value < item.Datum && item.Datum <= dtpDatumDo.Value)
                    {
                        result.Add(new Model.NarudzbaIzvjestaj
                        {
                            BrojNarudzbe = item.NarudzbaId,
                            Datum = item.Datum,
                            Iznos = item.Iznos
                        });
                    }
                }
                dataGridView1.DataSource = result;
            }
        }


        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 70);
            e.Graphics.DrawString("Korisnik: " + APIService.TrenutniKorisnik.Ime + " " + APIService.TrenutniKorisnik.Prezime, new Font(FontFamily.GenericSansSerif, 12),
     Brushes.Black, 10, 10, new StringFormat { });
            e.Graphics.DrawString("Datum: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), new Font(FontFamily.GenericSansSerif, 12),
     Brushes.Black, 10, 40, new StringFormat { });
            e.Graphics.DrawString("Ukupni iznos: $" + UkupnoIznos.ToString("0.00"), new Font(FontFamily.GenericSansSerif, 12),
     Brushes.Black, 10, 70 + dataGridView1.Height + 25, new StringFormat { });
        }

        Bitmap bmp;


        private void btnPrintaj_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));

            dataGridView1.Height = height;
            printPreviewDialog.ShowDialog();


        }

        public decimal UkupnoIznos { get; set; }

    }
}

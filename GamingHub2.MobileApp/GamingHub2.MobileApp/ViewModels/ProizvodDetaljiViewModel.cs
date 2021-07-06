using GamingHub2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamingHub2.MobileApp.ViewModels
{
    public class ProizvodDetaljiViewModel:BaseViewModel
    {
        public ProizvodDetaljiViewModel()
        {
            PovecajKolicinuCommand = new Command(() => Kolicina += 1);
           // NaruciCommand = new Command(Naruci);
        }
        public Proizvod Proizvod { get; set; }

        int _kolicina = 0;
        public int Kolicina
        {
            get { return _kolicina; }
            set { SetProperty(ref _kolicina, value); }
        }
        public ICommand PovecajKolicinuCommand { get; set; }
        public ICommand NaruciCommand { get; set; }

    }
}

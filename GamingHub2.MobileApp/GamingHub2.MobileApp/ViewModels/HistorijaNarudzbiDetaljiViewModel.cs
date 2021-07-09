using GamingHub2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace GamingHub2.MobileApp.ViewModels
{
    public class HistorijaNarudzbiDetaljiViewModel
    {
        private readonly APIService _service = new APIService("NarudzbaStavka");

        public HistorijaNarudzbiDetaljiViewModel()
        {
        }
        public Narudzba Narudzba { get; set; }
        public ObservableCollection<NarudzbaStavka> NarudzbaStavkaList { get; set; } = new ObservableCollection<NarudzbaStavka>();

        public async Task Init()
        {
            var lista = await _service.Get<IEnumerable<NarudzbaStavka>>(null);
            NarudzbaStavkaList.Clear();
            foreach (var item in lista)
            {
                if (item.NarudzbaId == Narudzba.NarudzbaId)
                {
                    NarudzbaStavkaList.Add(item);
                }
            }

        }
    }
}

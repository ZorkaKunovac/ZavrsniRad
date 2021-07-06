using GamingHub2.MobileApp.Services;
using GamingHub2.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GamingHub2.MobileApp.ViewModels
{
    public class NarudzbaViewModel : BaseViewModel
    {
        public ObservableCollection<ProizvodDetaljiViewModel> ProizvodiList { get; set; } = new ObservableCollection<ProizvodDetaljiViewModel>();

        public void Init()
        {
            ProizvodiList.Clear();
            foreach(var item in CartService.Cart)
            {
                ProizvodiList.Add(item.Value);
            }
        }
    }
}

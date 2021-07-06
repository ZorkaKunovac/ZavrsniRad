using GamingHub2.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.MobileApp.Services
{
    public static class CartService
    {
        public static Dictionary<int, ProizvodDetaljiViewModel> Cart { get; set; } = new Dictionary<int, ProizvodDetaljiViewModel>();
    }
}

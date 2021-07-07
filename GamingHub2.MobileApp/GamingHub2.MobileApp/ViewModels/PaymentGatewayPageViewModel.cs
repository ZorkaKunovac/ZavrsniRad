using Acr.UserDialogs;
using GamingHub2.MobileApp.Services;
using GamingHub2.Model;
using Prism.Mvvm;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamingHub2.MobileApp.ViewModels
{
    [QueryProperty(nameof(NarudzbaId), nameof(NarudzbaId))]
    public class PaymentGatewayPageViewModel : BindableBase
    {
        private readonly APIService _serviceNarudzba = new APIService("Narudzba");
        private readonly APIService _servicKupac = new APIService("Kupac");

        #region Variable

        private CreditCardModel _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private bool _isError_CardNumber;
        private bool _isError_Month;
        private bool _isError_Year;

        public async Task Init()
        {
            List<Kupac> kupac = await GetKupacByKorisnikid();
            if (kupac != null && kupac.Count > 0)
            {
                var KupacData = kupac[0];

                var CCM = new CreditCardModel();

                CCM.AddressCity = KupacData.Grad;
                CCM.AddressCountry = KupacData.Drzava;
                CCM.AddressLine1 = KupacData.Adresa1;
                CCM.AddressLine2 = KupacData.Adresa2;
                CCM.AddressZip = KupacData.PostanskiBroj;
                CCM.FirstName = KupacData.Ime;
                CCM.LastName = KupacData.Prezime;
                CCM.PhoneNumber = KupacData.BrojTelefona;
                CCM.EmailAddress = KupacData.Email;

                CreditCardModel = CCM;
            }
        }

        private bool _isError_Cvv;
        private string _expMonth;
        private string _expYear;
        private string _title;
        private decimal _iznos = 0;


        private int _narudzbaId;

        #endregion Variable

        #region Public Property


        public int NarudzbaId
        {
            get { return _narudzbaId; }
            set { SetProperty(ref _narudzbaId, value); _narudzbaId = value; }
        }


        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }

        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }

        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }
        
        public bool IsError_CardNumber
        {
            get { return _isError_CardNumber; }
            set { SetProperty(ref _isError_CardNumber, value); }
        }
        public bool IsError_Month
        {
            get { return _isError_Month; }
            set { SetProperty(ref _isError_Month, value); }
        }
        public bool IsError_Year
        {
            get { return _isError_Year; }
            set { SetProperty(ref _isError_Year, value); }
        }
        public bool IsError_Cvv
        {
            get { return _isError_Cvv; }
            set { SetProperty(ref _isError_Cvv, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }

        public decimal Iznos
        {
            get { return _iznos; }
            set { SetProperty(ref _iznos, value); }
        }
        public CreditCardModel CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }

        #endregion Public Property

        #region Constructor

        public PaymentGatewayPageViewModel()
        {
            CreditCardModel = new CreditCardModel();
            Title = "Card Details";
        }

        #endregion Constructor

        #region Command

        public ICommand SubmitCommand => new Command(async () =>
        {
            CreditCardModel.ExpMonth = Convert.ToInt64(ExpMonth);
            CreditCardModel.ExpYear = Convert.ToInt64(ExpYear);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                UserDialogs.Instance.ShowLoading("Payment processing..");
                await Task.Run(async () =>
                {

                    var Token = CreateToken();
                    Console.Write("Payment Gateway" + "Token :" + Token);
                    if (Token != null)
                    {
                        IsTransectionSuccess = await MakePayment();
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Bad card credentials", null, "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
                Console.Write("Payment Gatway" + ex.Message);
            }
            finally
            {
                if (IsTransectionSuccess)
                {
                    Console.Write("Payment Gateway" + "Payment Successful ");
                    UserDialogs.Instance.Alert("Payment successful", null, "OK");

                    UserDialogs.Instance.HideLoading();

                    CartService.Cart.Clear();
                    await Shell.Current.GoToAsync("//AboutPage");
                }
                else
                {

                    UserDialogs.Instance.HideLoading();
                    Console.Write("Payment Gateway" + "Payment Failure ");
                }
            }

        });

        #endregion Command

        #region Method


        private string CreateToken()
        {
            try
            {
                var service = new ChargeService();
                var Tokenoptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = CreditCardModel.FirstName + " " + CreditCardModel.LastName,
                        
                        AddressLine1 = CreditCardModel.AddressLine1,
                        AddressLine2 = CreditCardModel.AddressLine2,
                        AddressCity = CreditCardModel.AddressCity,
                        AddressZip = CreditCardModel.AddressZip,
                        AddressState = CreditCardModel.AddressState,
                        AddressCountry = CreditCardModel.AddressCountry,
                        Currency = "usd",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> MakePayment()
        {
            var Narudzba = await _serviceNarudzba.GetById<Narudzba>(NarudzbaId);
            if (Narudzba == null)
                return false;

            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = ((long)Narudzba.Iznos) * 100,
                    Currency = "usd",
                    Description = "Charge for " + APIService.TrenutniKorisnik.Email,
                    Source = stripeToken.Id,
                    StatementDescriptor = "Custom descriptor",
                    Capture = true,
                    ReceiptEmail = "zorka.kunovac@edu.fit.ba",
                };
                //Make Payment
                var service = new ChargeService();
                Charge charge = service.Create(options);

                if(charge.Captured)
                {
                    await _serviceNarudzba.Update<Narudzba>(NarudzbaId, new Model.Requests.NarudzbaUpdateRequest
                    {
                        Status = true,
                        Otkazano = Narudzba.Otkazano
                    });

                    await CreateOrUpdateKupac();
                }
                return true; 
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gatway (CreateCharge)" + ex.Message);
                throw ex;
            }
        }

        private async Task CreateOrUpdateKupac()
        {

            var request = new Model.Requests.KupacUpsertRequest
            {
                Adresa1 = CreditCardModel.AddressLine1,
                Adresa2 = CreditCardModel.AddressLine2,
                BrojTelefona = CreditCardModel.PhoneNumber,
                Drzava = CreditCardModel.AddressCountry,
                Email = CreditCardModel.EmailAddress,
                Grad = CreditCardModel.AddressCity,
                Ime = CreditCardModel.FirstName,
                Prezime = CreditCardModel.LastName,
                PostanskiBroj = CreditCardModel.AddressZip,
                KorisnikId = APIService.TrenutniKorisnik.KorisnikId
            };
            List<Kupac> kupac = await GetKupacByKorisnikid();

            if (kupac != null && kupac.Count > 0)
            {
                await _servicKupac.Update<Model.Kupac>(kupac[0].ID, request);
            }
            else
            {
                await _servicKupac.Insert<Model.Kupac>(request);
            }
        }

        private async Task<List<Kupac>> GetKupacByKorisnikid()
        {
            return await _servicKupac.Get<List<Model.Kupac>>(new Model.Requests.KupacSearchRequest
            {
                KorisnikId = APIService.TrenutniKorisnik.KorisnikId
            });
        }

        private bool ValidateCard()
        {
            if (CreditCardModel.Number.Length == 16 && ExpMonth.Length == 2 && ExpYear.Length == 2 && CreditCardModel.Cvc.Length == 3)
            {
            }
            return true;
        }

        #endregion Method
    }
}

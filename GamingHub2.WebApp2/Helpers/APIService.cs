using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GamingHub2.Model;

namespace GamingHub2.WebApp2.Helper
{
    public class APIService
    {

        public static string Username { get; set; }
        public static string Password { get; set; }
        public static Model.Korisnici TrenutniKorisnik { get; set; }

        private string _route = null;
#if DEBUG
        private string _apiURL = "http://localhost:25001/api";
        //    "https://localhost:5001/api/";
#endif
#if RELEASE
        private string _apiURL = "https://mywebsite/api/";
#endif

        public APIService(string route) //Kontroler
        {
            _route = route;
        }

        public async Task<T> Get<T>(object searchRequest = null, string endpointName = null)
        {
            string url;
            if (endpointName == null)
            {
                url = $"{_apiURL}/{_route}";
            }
            else
            {
                url = $"{_apiURL}/{_route}/{endpointName}";
            }

            try
            {
                if (searchRequest != null)
                {
                    url += "?";
                    url += await searchRequest?.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    // ovo ce se pozvati ukoliko login ne uspije, jer ce vratiti exception, nece vratiti null u loginVM
                    throw new Exception("Pogrešno korisničko ime ili lozinka!");
                    //Userexception?
                    //  await Application.Current.MainPage.DisplayAlert("Greska", "Pogrešno korisničko ime ili lozinka!", "OK");

                }
                if (ex.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    throw new Exception("Pristup zabranjen!");
                }
                return default(T);
            }
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiURL}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request, string endpointName = null)
        {
            try
            {
                string url;
                if (endpointName == null)
                {
                    url = $"{_apiURL}/{_route}";
                }
                else
                {
                    url = $"{_apiURL}/{_route}/{endpointName}";
                }

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Niste autorizovani!");

                }
                if (ex.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    throw new Exception("Pristup zabranjen!");
                }

                return default(T);
            }
        }

        public async Task<T> Update<T>(object id, object request, string endpointName = null)
        {
            try
            {
                string url;
                if (endpointName == null)
                {
                    url = $"{_apiURL}/{_route}/{id}";
                }
                else
                {
                    url = $"{_apiURL}/{_route}/{endpointName}";
                }

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Niste autorizovani!");

                }
                if (ex.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    throw new Exception("Pristup zabranjen!");
                }
                return default(T);
            }
        }




        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:25001/");
            return client;
        }
    }
}

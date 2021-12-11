using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GamingHub2.Model;
using GamingHub2.WebApp2.Exceptions;
using Microsoft.AspNetCore.Http;
using GamingHub2.WebApp2.Helpers;

namespace GamingHub2.WebApp2.Helper
{
    public class APIService
    {

        public static string Username { get; set; }
        public static string Password { get; set; }
        public static Model.Korisnici TrenutniKorisnik { get; set; }

        private static HttpContext _httpContext => new HttpContextAccessor().HttpContext;

        private string _route = null;
        private string _apiURL = "http://localhost:25001/api";
        //    "https://localhost:5001/api/";

        public APIService(string route) //Kontroler
        {
            _route = route;
        }

        public async Task<T> Get<T>(object searchRequest = null, string endpointName = null)
        {
            TryAuthToken();

            string url = $"{_apiURL}/{_route}";
            if (endpointName != null)
            {
                url += $"/{endpointName}";
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
                return HandleApiException<T>(ex);
            }
        }

        private static void TryAuthToken()
        {
            if (_httpContext is null)
                return;

            if (!string.IsNullOrEmpty(_httpContext.GetTrenutniToken()) && Username is null && Password is null)
            {
                Username = "authtoken";
                Password = _httpContext.GetTrenutniToken();
            }
        }

        public async Task<T> Delete<T>(int id)
        {
            TryAuthToken();

            var url = $"{_apiURL}/{_route}/{id}";
            try
            {
                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                return HandleApiException<T>(ex);
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            TryAuthToken();

            var url = $"{_apiURL}/{_route}/{id}";
            try
            {
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                return HandleApiException<T>(ex);
            }
        }
        public async Task<T> Insert<T>(object request, string endpointName = null)
        {
            TryAuthToken();

            try
            {
                string url = $"{_apiURL}/{_route}";
                if (endpointName != null)
                {
                    url += $"/{endpointName}";
                }

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                return HandleApiException<T>(ex);
            }
        }

        public async Task<T> Update<T>(object id, object request, string endpointName = null)
        {
            TryAuthToken();

            try
            {
                string url = $"{_apiURL}/{_route}";
                if (endpointName != null)
                {
                    url += $"/{endpointName}";
                }
                url += $"/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                return HandleApiException<T>(ex);
            }
        }

        private static T HandleApiException<T>(FlurlHttpException ex)
        {
            switch (ex.StatusCode)
            {
                case (int)HttpStatusCode.Unauthorized:
                    throw new ApiAuthenticationException();
                case (int)HttpStatusCode.Forbidden:
                    throw new ApiAuthorizationException();
                default:
                    return default;
            }
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Flurl.Http;
using Flurl;
using System.Threading.Tasks;
using GamingHub2.Model;

namespace GamingHub2.WinUI
{
    public class APIService
    {
        private string _route = null;
        public string endpoint = $"{Properties.Settings.Default.ApiURL}";
        public APIService(string route) //Kontroler
        {
            _route = route;
        }

        public async Task<T> Get<T>(object searchRequest=null)
        {
            var query = "";
            if (searchRequest!=null)
                query += await searchRequest?.ToQueryString();
            var endpointt = $"{endpoint}/{_route}?{query}";
            //var end = "https://localhost:5001/api/Zanr";


            var result = await $"{endpoint}/{_route}?{query}".GetJsonAsync<T>();
            return result;
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{endpoint}/{_route}/{id}";
            return await url.GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{endpoint}/{_route}";

            var result = await url.PostJsonAsync(request).ReceiveJson<T>();
            return result;
        }
        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{endpoint}/{_route}/{id}";
            var result = await url.PutJsonAsync(request).ReceiveJson<T>();
            return result;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Flurl.Http;
using Flurl;
using System.Threading.Tasks;
using GamingHub2.Model;
using System.Windows.Forms;
using System.Net;

namespace GamingHub2.WinUI
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private string _route = null;
        public string endpoint = $"{Properties.Settings.Default.ApiURL}";
        public APIService(string route) //Kontroler
        {
            _route = route;
        }

        //public async Task<T> Get<T>(object search)
        //{
        //    var url = $"{Properties.Settings.Default.ApiURL}/{_route}";

        //    try
        //    {

        //        if (search != null)
        //        {
        //            url += "?";
        //            url += await search.ToQueryString();
        //        }

        //        return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        //    }
        //    catch (FlurlHttpException ex)
        //    {
        //        if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
        //        {
        //            throw new Exception("Niste authetificirani!");
        //        }
        //        throw;
        //    }

        //}

        public async Task<T> Get<T>(object searchRequest = null)
        {
            try
            {
                var query = "";
                if (searchRequest != null)
                    query += await searchRequest?.ToQueryString();

                return await $"{endpoint}/{_route}?{query}".WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                     MessageBox.Show(ex.Message + "\nNiste autorizovani", "Niste autorizovani", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    MessageBox.Show(ex.Message + "\nNemate privilegije", "Pristup zabranjen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return default;
            }
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{endpoint}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{endpoint}/{_route}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                throw new Exception(ex.Message);
            }
            //var url = $"{endpoint}/{_route}";

            //var result = await url.PostJsonAsync(request).ReceiveJson<T>();
            //return result;

            //try
            //{
            //    return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            //}
            //catch (FlurlHttpException ex)
            //{
            //    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

            //    var stringBuilder = new StringBuilder();
            //    foreach (var error in errors)
            //    {
            //        stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
            //    }

            //    MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return default(T);
            //}
        }
        public async Task<T> Update<T>(object id, object request)
        {

            try
            {
            var url = $"{endpoint}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                throw new Exception(ex.Message);
            }

            //var result = await url.PutJsonAsync(request).ReceiveJson<T>();
            //return result;

            //Amel
            //try
            //{
            //    return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            //}
            //catch (FlurlHttpException ex)
            //{
            //    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

            //    var stringBuilder = new StringBuilder();
            //    foreach (var error in errors)
            //    {
            //        stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
            //    }

            //    MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return default(T);
            //}
        }
    }
}

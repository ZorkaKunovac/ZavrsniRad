using GamingHub2.WebApp2.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Helpers
{
    public static class Autentifikacija
    {
        private static APIService _service = new APIService("Korisnici");
        private static APIService _serviceAuthToken = new APIService("AutorizacijskiToken");
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static async Task SetLogiraniKorisnik(this HttpContext context, Model.Korisnici korisnik)
        {
            string stariToken = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (stariToken != null)
            {
                var obrisati = await _serviceAuthToken.Get<List<Model.AutorizacijskiToken>>(new Model.Requests.AutorizacijskiTokenSearchRequest
                {
                    Vrijednost = stariToken
                });
                if (obrisati != null && obrisati.Count > 0)
                {
                    await _serviceAuthToken.Delete<Model.AutorizacijskiToken>(obrisati[0].Id);
                }
            }

            if (korisnik != null)
            {

                string token = Guid.NewGuid().ToString();
                await _serviceAuthToken.Insert<Model.AutorizacijskiToken>(new Model.Requests.AutorizacijskiTokenInsertRequest
                {
                    Vrijednost = token,
                    KorisnikId = korisnik.KorisnikId,
                    VrijemeEvidentiranja = DateTime.Now
                });
                context.Response.SetCookieJson(LogiraniKorisnik, token);
            }
        }

        public static string GetTrenutniToken(this HttpContext context)
        {
            return context.Request.GetCookieJson<string>(LogiraniKorisnik);
        }

        public static async Task<Model.Korisnici> GetLogiraniKorisnik(this HttpContext context)
{
            string token = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (token == null)
                return null;

            var sesija = await _serviceAuthToken.Get<List<Model.AutorizacijskiToken>>(new Model.Requests.AutorizacijskiTokenSearchRequest
            {
                Vrijednost = token
            });
            if (sesija.Count == 0 || sesija[0].Korisnik == null)
                return null;

            return sesija[0].Korisnik;
        }

        public static async Task<Model.Korisnici> Authenticiraj(string username, string pass)
        {
            try
            {
                APIService.Username = username;
                APIService.Password = pass;
                var entity = await _service.Get<Model.Korisnici>(null, "MojProfil");
                return entity;
            }
            catch (UnauthorizedAccessException ex)
            {
                return null;
            }

        }

    }
}
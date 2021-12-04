using GamingHub2.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public interface IIgraZanrService
    {
        //List<Model.IgraZanrPrikazVM> Get();
        //Model.IgraZanrPrikazVM GetById(int id);
        //Model.IgraZanrPrikazVM Insert(IgraZanrDodajVM request);
        Model.IgraZanrPrikazVM GetIgraZanr(int IgraID);
        //IActionResult Get(int IgraID);
    }
}

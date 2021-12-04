using GamingHub2.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public interface IIgraZanrService2
    {
        //List<Model.IgraZanrPrikazVM> Get();
        //Model.IgraZanrPrikazVM GetById(int id);
        //Model.IgraZanrPrikazVM Insert(IgraZanrDodajVM request);
        Model.IgraZanrPrikazVM GetIZ(int IgraID);
        //IActionResult Get(int IgraID);
    }
}

using SmartCondominium.Dao;
using SmartCondominium.Filters;
using SmartCondominium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SmartCondominium.Controllers
{

    public class HomeController : Controller
    {
        //
        // GET: /Home/
       // [AutorizacaoFilter]
        public ActionResult Index()
        {
            


            return View();
        }

              

        
        public ActionResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

       

        

    }
}
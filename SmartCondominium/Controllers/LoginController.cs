using SmartCondominium.Dao;
using SmartCondominium.Infra;
using SmartCondominium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartCondominium.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult Autentica(string Login, string Senha)
        {
            UsuarioDao ud = new UsuarioDao();
            if (ud.Busca(Login.ToLower()) != null)
            {
                Usuario usuario = ud.Busca(Login.ToLower());

                if (Criptografia.Compara(Senha, usuario.Password))
                {
                    Session["usuario"] = usuario;
                    Session["admin"] = usuario.Adm;
                    Session["FotoPerfil"] = usuario.CaminhoFoto;
                    Session["login"] = usuario.Login;
                    Session["nome"] = usuario.Nome;
                    Session["CodVendedor"] = usuario.CodVendedor;
                    Session["edita"] = (usuario.Edita ? "SIM" : "NAO");
                    Session["pcp"] = (usuario.Pcp ? "SIM" : "NAO");


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("login.invalido", "Usuário ou Senha invalida!");
                    return View("Index");
                }
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Usuário ou senha invalida!");
                return View("Index");
            }


        }

    }
}
using SmartCondominium.Dao;
using SmartCondominium.Filters;
using SmartCondominium.Infra;
using SmartCondominium.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SmartCondominium.Controllers
{
   // [AutorizacaoFilter]
    public class UsuarioController : Controller
    {

        // GET: /Usuario/

        [AutorizacaoFilter]
        public ActionResult Index()
        {
            bool isAdm = Convert.ToBoolean(Session["admin"]);

            if (isAdm)
            {
                UsuarioDao ud = new UsuarioDao();
                ViewBag.usuarios = ud.Lista();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


       // [AutorizacaoFilter]
        public ActionResult Adiciona(Usuario usuario)
        {
            string tSenha;
            UsuarioDao ud = new UsuarioDao();
            Email mail = new Email();

            if (ud.Busca(usuario.Login.ToLower()) == null) //Verifica se já existe o login cadastrado.
            {
                try
                {

                    if (usuario.Perfil != null && usuario.Perfil.ContentLength > 0)
                    {
                        string caminho = Path.Combine(Server.MapPath("~/Uploads/Usuarios/"), usuario.Perfil.FileName);
                        usuario.Perfil.SaveAs(caminho);
                        usuario.CaminhoFoto = usuario.Perfil.FileName;
                    }

                    tSenha = usuario.Password;
                    usuario.Login = usuario.Login.ToLower();
                    usuario.Password = Criptografia.Codifica(usuario.Password);
                    ud.Adiciona(usuario);
                    //mail.EnviarEmail(usuario.Email, "Dados de Login  ", " Prezado(a) "
                      //            + usuario.Nome
                        //            + ", <p/>  Seguem os dados para acesso ao sistema.<br>Usuario: "
                         //           + usuario.Login
                          //          + "<br>Senha: "
                           //         + tSenha
                           //         + " "
                           //         + "<br>Endereço de acesso: http://192.168.0.5:7070/login "
                             //       );

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("usuario,Invalido", e.Message);
                    return RedirectToAction("Index", "Usuario");
                }
            }
            else
            {

                ModelState.AddModelError("usuario.invalido", "Login já cadastrado");
                return View("Form");
            }
        }
        public ActionResult AlteraSenha(Usuario usuario)
        {
            string tSenha = Request.Form["Nsenha"];
            usuario.Password = tSenha;
            usuario.Password = Criptografia.Codifica(usuario.Password);
            UsuarioDao ud = new UsuarioDao();
            ud.Atualiza(usuario);
            return RedirectToAction("Index", "Usuario");
        }


        //[AutorizacaoFilter]
        public ActionResult Evento()
        {
            String evento = Request.Form["evento"].Trim().ToUpper();
            String sId = Request.Form["ID"];
            if (evento == "INCLUIR")
                return RedirectToAction("FormInclui");
            else if (evento == "ALTERAR" && sId != null)
                return RedirectToAction("FormAltera/" + sId, "Usuario");
            else if (evento == "EXCLUIR" && sId != null)
                return RedirectToAction("FormExclui/" + sId, "Usuario");
            else if (evento == "VISUALIZAR" && sId != null)
                return RedirectToAction("FormVisualiza/" + sId, "Usuario");
            else if (evento == "TROCASENHA" && sId != null)
                return RedirectToAction("TrocaSenha/" + sId, "Usuario");
            else
                return RedirectToAction("Index", "Usuario");
        }



       // [AutorizacaoFilter]
        public ActionResult FormVisualiza(int id)
        {
            UsuarioDao ud = new UsuarioDao();
            Usuario usuario = ud.BuscaPorId(id);
            ViewBag.usuario = usuario;
            return View(usuario);
        }

        //[AutorizacaoFilter]
        public ActionResult FormInclui()
        {
            

            return View();

        }
        //[AutorizacaoFilter]
        public ActionResult FormAltera(int id)
        {


           
            UsuarioDao ud = new UsuarioDao();
            Usuario usuario = ud.BuscaPorId(id);
            //ud.Lock(usuario);
            ViewBag.usuario = usuario;



            return View(usuario);
        }

        //[AutorizacaoFilter]
        public ActionResult FormExclui(int id)
        {
            UsuarioDao ud = new UsuarioDao();
            Usuario usuario = ud.BuscaPorId(id);
            return View(usuario);
        }
        public ActionResult TrocaSenha(int id)
        {
            UsuarioDao ud = new UsuarioDao();
            Usuario usuario = ud.BuscaPorId(id);
            ViewBag.usuario = usuario;
            return View(usuario);


        }

        //[AutorizacaoFilter]
        public ActionResult Exclui(Usuario usuario)
        {
            UsuarioDao ud = new UsuarioDao();
            ud.Exclui(usuario);
            return RedirectToAction("Index", "Usuario");
        }


        //[AutorizacaoFilter]
        public ActionResult Altera(Usuario usuario)
        {

            if (usuario.Perfil != null && usuario.Perfil.ContentLength > 0)
            {
                string caminho = Path.Combine(Server.MapPath("~/Uploads/Usuarios/"), usuario.Perfil.FileName);
                usuario.Perfil.SaveAs(caminho);
                usuario.CaminhoFoto = usuario.Perfil.FileName;
            }

            UsuarioDao ud = new UsuarioDao();
            ud.Atualiza(usuario);
            return RedirectToAction("Index", "Usuario");
        }




        public ActionResult FotoPerfil(string login)
        {
            UsuarioDao ud = new UsuarioDao();
            Usuario usuario = ud.Busca(login);
            ViewBag.usuario = usuario;

            return View(usuario);
        }
        public ActionResult TrocaFoto(Usuario usuario)
        {
            UsuarioDao ud = new UsuarioDao();

            if (usuario.Perfil != null && usuario.Perfil.ContentLength > 0)
            {
                string caminho = Path.Combine(Server.MapPath("~/Uploads/Usuarios/"), usuario.Perfil.FileName);
                usuario.Perfil.SaveAs(caminho);
                usuario.CaminhoFoto = usuario.Perfil.FileName;
            }

            ud.Atualiza(usuario);
            Session["FotoPerfil"] = usuario.CaminhoFoto;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


    }
}
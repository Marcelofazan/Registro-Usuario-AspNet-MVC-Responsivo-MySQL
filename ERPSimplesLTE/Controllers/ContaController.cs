using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPSimplesLTE.Aplicacao;
using ERPSimplesLTE.Models;

namespace ERPSimplesLTE.Controllers
{
    public class ContaController : Controller
    {
        private readonly ContaAplicacao contaAplicacao;
        public ContaController()
        {
            contaAplicacao = new ContaAplicacao();
        }
        public ActionResult Index()
        {
            return RedirectToAction("Login","Conta");
        }
        public ActionResult Login(string email, string senha)
        {
            if (email != null && senha != null)
            {
                var objusuario = contaAplicacao.ValidarLogin(email, senha);
                if (objusuario == null)
                    return View();

                return RedirectToAction("Inicio", "Home");
            }

            return View();
        }

        public ActionResult Registrar(string nome, string email, string senha, string senhaconfirmar)
        {

            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                usuario.Nome = nome;
                usuario.Email = email;
                usuario.Senha = senha;
                usuario.SenhaConfirmar = senhaconfirmar;

                string Msg = "";
                try { if (string.IsNullOrWhiteSpace(usuario.Nome))  Msg += "Nome invalido"; }  catch (Exception) { usuario.Nome = ""; }
                try { if (string.IsNullOrWhiteSpace(usuario.Email)) Msg += "Email invalido"; } catch (Exception) { usuario.Email = ""; }
                try { if (string.IsNullOrWhiteSpace(usuario.Senha)) Msg += "Senha invalida"; } catch (Exception) { usuario.Senha = ""; }
                try { if (string.IsNullOrWhiteSpace(usuario.SenhaConfirmar)) Msg += "Senha Confirmar invalida"; } catch (Exception) { usuario.SenhaConfirmar = ""; }

                if (Msg == "") 
                {

                    string existemail = EmailJaExiste(usuario.Email);

                    if (!string.IsNullOrWhiteSpace(existemail) && (existemail != null) && (existemail != "")) { ViewBag.RetornoEmailJaCadastrado = existemail; } else { }

                    string comparasenha = ComparaSenhas(usuario.Email, usuario.Senha, usuario.SenhaConfirmar);

                    if (!string.IsNullOrWhiteSpace(comparasenha) && (comparasenha != null) && (comparasenha != "")) { ViewBag.RetornoComparaSenha = comparasenha; } else { }

                    if (existemail == "" && comparasenha == "")
                    {
                        contaAplicacao.Inserir(usuario);
                        return RedirectToAction("Inicio", "Home");
                    }

                }
            }

            return View();
        }

        public ActionResult RecuperarSenha(Usuario usuario)
        {
            if (usuario.Email != null )
            {
                var objusuario = contaAplicacao.RecupérarSenha(usuario.Email);
                if (objusuario == null)
                    return View();

                TempData["cEmail"] = objusuario.Email;

                return RedirectToAction("InformarSenha", "Conta");
            }

            return View();
        }

        public ActionResult InformarSenha(string email, string senha, string senhaconfirmar)
        {

            string Msg = "";
            try { if (string.IsNullOrWhiteSpace(email)) Msg += "Email invalida"; } catch (Exception) { email = ""; }
            try { if (string.IsNullOrWhiteSpace(senha)) Msg += "Senha invalida"; } catch (Exception) { senha = ""; }
            try { if (string.IsNullOrWhiteSpace(senhaconfirmar)) Msg += "Senha Confirmar invalida"; } catch (Exception) { senhaconfirmar = ""; }
            if (Msg == "")
            {
                contaAplicacao.AlterarSenha(email, senha);
                return RedirectToAction("Login", "Conta");
            }
            else
            {
                if ((!string.IsNullOrWhiteSpace(email)) || (!string.IsNullOrWhiteSpace(senha)) || (!string.IsNullOrWhiteSpace(senhaconfirmar))) { return RedirectToAction("Login", "Conta");  } else { return View(); }
            }
        }

        public ActionResult EmailNaoCadastrado(string email)
        {
            if (email != null)
            {
                var stringemail = contaAplicacao.ValidarEmail(email);
                if (stringemail == null)
                    return RedirectToAction("RecuperarSenha", "Conta", null);
            }

            return View();
        }

        public string EmailJaExiste(string email)
        {
            string Msg = "";
            if (email != null)
            {
                try { if (!string.IsNullOrWhiteSpace(email)) Msg += "Email ja cadastrado"; } catch (Exception) { email = ""; }

                var stringemail = contaAplicacao.ValidarEmail(email);
                if (stringemail == null)
                    return "";
            }
            return Msg;
        }

        public string ComparaSenhas(string email, string senha, string senhaconfirmar)
        {
            string Msg = "";
            if (senha != null && senhaconfirmar != null)
            {
                if (senha == senhaconfirmar )
                {
                    var stringsenha = contaAplicacao.ConfirmarSenha(email, senha, senhaconfirmar);
                    if (stringsenha == null)
                        return "";
                }
                else
                {
                   Msg += "As senhas nao conferem";
                }
            }
            return Msg;
        }
    }
}
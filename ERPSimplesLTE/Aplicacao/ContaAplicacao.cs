using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSimplesLTE.Models;
using ERPSimplesLTE.Repositorio;
using ERPSimplesLTE.Aplicacao;

namespace ERPSimplesLTE.Aplicacao
{
    public class ContaAplicacao
    {
        private readonly Contexto contexto;

        public ContaAplicacao()
        {
            contexto = new Contexto();
        }

        public Usuario ValidarLogin(string email, string senha)
        {
            var usuarios = new List<Usuario>();
            const string strQuery = "SELECT Email, Senha FROM Usuarios WHERE Email = @email AND Senha = @senha";

            var parametros = new Dictionary<string, object>
                {
                    {"Email", email},
                    {"Senha", senha}
                };

            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempUsuario = new Usuario
                {
                    Email = row["Email"]
                };
                usuarios.Add(tempUsuario);
            }

            return usuarios.FirstOrDefault();
        }

        public int Inserir(Usuario usuario)
        {
            const string commandText = " INSERT INTO Usuarios (Nome, Email, Senha, SenhaConfirmar) VALUES (@Nome, @Email, @Senha, @SenhaConfirmar) ";

            var parameters = new Dictionary<string, object>
            {
                {"Nome", usuario.Nome},
                {"Email", usuario.Email},
                {"Senha", usuario.Senha},
                {"SenhaConfirmar", usuario.SenhaConfirmar}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public Usuario RecupérarSenha(string email)
        {
            var usuarios = new List<Usuario>();
            const string strQuery = "SELECT Email, Senha FROM Usuarios WHERE Email = @email";

            var parametros = new Dictionary<string, object>
                {
                    {"Email", email}
                };

            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempUsuario = new Usuario
                {
                    Email = row["Email"],
                    Senha = row["Senha"]
                };
                usuarios.Add(tempUsuario);
            }

            return usuarios.FirstOrDefault();
        }

        public int AlterarSenha(string sEmail, string sSenha)
        {

            var commandText = " UPDATE Usuarios SET ";
            commandText    += " Senha = '" + sSenha + "',";
            commandText    += " SenhaConfirmar = '" + sSenha + "'";
            commandText    += " WHERE Email = '" + sEmail + "'";

            var parameters = new Dictionary<string, object>
            {
                {"Email", sEmail},
                {"Senha", sSenha},
                {"SenhaConfirmar", sSenha}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public Usuario ValidarEmail(string email)
        {
            var usuarios = new List<Usuario>();
            const string strQuery = "SELECT Email FROM Usuarios WHERE Email = @email";

            var parametros = new Dictionary<string, object>
                {
                    {"Email", email}
                };

            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempUsuario = new Usuario
                {
                    Email = row["Email"]
                };
                usuarios.Add(tempUsuario);
            }

            return usuarios.FirstOrDefault();
        }
        public Usuario ConfirmarSenha(string email, string senha, string senhaconfirmar)
        {
            var usuarios = new List<Usuario>();
            const string strQuery = "SELECT Senha, SenhaConfirmar FROM Usuarios WHERE Email = @email";

            var parametros = new Dictionary<string, object>
                {
                    {"Email", email},
                    {"Senha", senha},
                    {"SenhaConfirmar", senhaconfirmar}
                };

            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempUsuario = new Usuario
                {
                    Senha = row["Senha"],
                    SenhaConfirmar = row["SenhaConfirmar"]
                };
                usuarios.Add(tempUsuario);
            }

            return usuarios.FirstOrDefault();
        }

    }
}
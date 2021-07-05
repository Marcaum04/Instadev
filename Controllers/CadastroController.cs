using System;
using System.IO;
using Instadev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instadev.Controllers
{
    [Route("Cadastro")]
    public class CadastroController : Controller
    {
        Usuario UsuarioModel = new Usuario();
        public IActionResult Index()
        {
            ViewBag.Usuarios = UsuarioModel.ListarUsuarios();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Usuario NovoUsuario = new Usuario();
            NovoUsuario.Nome = form["NomeCompleto"];
            NovoUsuario.Email = form["E-Mail"];
            NovoUsuario.SetarSenha(form["Senha"]);
            NovoUsuario.NomeUsuario = (form["NomeUsuario"]);
            NovoUsuario.Id = 1;

              if(form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Usuarios");

                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                NovoUsuario.ImagemPerfil = file.FileName;                
            }
            else
            {
                NovoUsuario.ImagemPerfil = "padrao.png";
            }

            UsuarioModel.CadastrarUsuario(NovoUsuario);            
            ViewBag.Usuarios = UsuarioModel.ListarUsuarios();

             return LocalRedirect("~/Cadastro");
        }
    }
}
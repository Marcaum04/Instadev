using System.Collections.Generic;
using Instadev.Models;

namespace Instadev.Interfaces
{
    public interface IUsuario
    {
         void CadastrarUsuario(Usuario u);
         void DeletarUsuario (Usuario u);
         void EditarUsuario(int Id);
         List<Usuario> ListarUsuarios();
    }
}
using System.Collections.Generic;
using System.IO;
using Instadev.Interfaces;

namespace Instadev.Models
{
    public class Usuario : InstadevBase, IUsuario
    {
        private string Nome { get; set; }
        private string Email { get; set; }
        private string Senha { get; set; }
        private string NomeUsuario { get; set; }
        private int NumSeguidores { get; set; }
        public int NumSeguindo { get; set; }
        private int Id { get; set; }
        private string ImagemPerfil { get; set; }
        List<Usuario> ListaUsers = new List<Usuario>();
        List<int> id = new List<int>();
        private bool Logado { get; set; }
        public const string CAMINHO = "Database/Usuario";
        public Usuario()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        public void CadastrarUsuario(Usuario u)
        {
            string[] linha = { PrepararLinhas(u) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void DeletarUsuario(int Id)
        {
            List<string> JogadorDeletar = LerTodasLinhasCSV(CAMINHO);
            JogadorDeletar.RemoveAll(x => x.Split(";")[6] == Id.ToString());
            ReescreverCSV(CAMINHO, JogadorDeletar);
        }

        public void EditarUsuario(Usuario u)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[6] == u.Id.ToString());
            linhas.Add(PrepararLinhas(u));
            ReescreverCSV(CAMINHO, linhas);
        }
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string[] linhas = File.ReadAllLines(CAMINHO);
            Usuario user = new Usuario();

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                user.Nome = linha[0];
                user.Email = linha[1];
                user.Senha = linha[2];
                user.NomeUsuario = linha[3];
                user.NumSeguidores = int.Parse(linha[4]);
                user.NumSeguindo = int.Parse(linha[5]);
                user.Id = int.Parse(linha[6]);
                user.ImagemPerfil = linha[7];

                usuarios.Add(user);
            }
            return usuarios;
        }
        public string PrepararLinhas(Usuario u)
        {
            return $"{u.Nome};{u.Email};{u.Senha};{u.NomeUsuario};{u.NumSeguidores};{u.NumSeguindo};{u.Id};{u.ImagemPerfil}";
        }
    }
}
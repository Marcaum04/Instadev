using System.Collections.Generic;
using System.IO;
using Instadev.Interfaces;

namespace Instadev.Models
{
    public class Usuario : InstadevBase, IUsuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        private string Senha { get; set; }
        public string NomeUsuario { get; set; }
        public int NumSeguidores { get; set; }
        public int NumSeguindo { get; set; }
        public int Id { get; set; }
        public string ImagemPerfil { get; set; }
        List<Usuario> ListaUsers = new List<Usuario>();
        List<int> id = new List<int>();
        private bool Logado { get; set; }
        public const string CAMINHO = "Database/Usuario.csv";
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
            List<string> UsuarioDeletar = LerTodasLinhasCSV(CAMINHO);
            UsuarioDeletar.RemoveAll(x => x.Split(";")[6] == Id.ToString());
            ReescreverCSV(CAMINHO, UsuarioDeletar);
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
                // user.Email = linha[1];
                // user.Senha = linha[2];
                // user.NomeUsuario = linha[3];
                // user.NumSeguidores = int.Parse(linha[4]);
                // user.NumSeguindo = int.Parse(linha[5]);
                user.Id = int.Parse(linha[6]);
                user.ImagemPerfil = linha[7];
            }
            return usuarios;
        }
        public string PrepararLinhas(Usuario u)
        {
            return $"{u.Nome};{u.Email};{u.Senha};{u.NomeUsuario};{u.NumSeguidores};{u.NumSeguindo};{u.Id};{u.ImagemPerfil}";
        }

        public void SetarSenha(string Senha_){
            Senha = Senha_;
        }
    }
}
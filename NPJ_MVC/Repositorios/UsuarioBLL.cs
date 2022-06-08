using NPJ_MVC.Data;
using NPJ_MVC.Models;

namespace NPJ_MVC.Repositorios
{
    public class UsuarioBLL
    {
        private UsuarioDAL usuarioDAL;

        public UsuarioBLL(AgendaNPJContext contexto)
        {
            usuarioDAL = new UsuarioDAL(contexto);
        }

        public bool SetCadastro (UsuarioModel model)
        {
            return usuarioDAL.SetCadastro(model);
        }
    }
}

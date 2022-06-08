using NPJ_MVC.Data;
using NPJ_MVC.Models;

namespace NPJ_MVC.Repositorios
{
    public class AssistidoBLL
    {
        private AssistidoDAL assistidoDAL;

        public AssistidoBLL(AgendaNPJContext contexto)
        {
            assistidoDAL = new AssistidoDAL(contexto);
        }

        public bool SetCadastro (AssistidoModel model,UsuarioModel m)
        {
            return assistidoDAL.SetCadastroAssistido(model,m);
        }
    }
}

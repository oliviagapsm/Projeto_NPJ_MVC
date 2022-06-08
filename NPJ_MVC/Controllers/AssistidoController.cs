using Microsoft.AspNetCore.Mvc;
using NPJ_MVC.Data;
using NPJ_MVC.Models;
using NPJ_MVC.Repositorios;

namespace NPJ_MVC.Controllers
{
    public class Assistido : Controller
    {
        private AssistidoBLL assistidoBLL;
        public Assistido()
        {
            AgendaNPJContext contexto = new AgendaNPJContext();
            assistidoBLL = new AssistidoBLL(contexto);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarAssistido(UsuarioModel usuario,AssistidoModel assistido)
        {
            string msgErro = String.Empty;

            if (ModelState.IsValid)
            {
                if (assistidoBLL.SetCadastro(assistido,usuario))
                {
                    ViewBag.CadastroUsuarioSucesso = "Usuário cadastrado com sucesso!";
                    return View();
                }
                else
                {
                    msgErro = "Ocorreu algum erro ao cadastrar o funcionário. Contate a equipe de suporte.";
                }
            }

            ViewBag.msgErro = msgErro;
            return View(assistido);
        }

        [HttpGet]
        public IActionResult CriarAssistido()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Apagar()
        {
            return View();
        }
    }
}

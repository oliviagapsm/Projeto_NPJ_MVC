using Microsoft.AspNetCore.Mvc;
using NPJ_MVC.Data;
using NPJ_MVC.Models;
using NPJ_MVC.Repositorios;

namespace NPJ_MVC.Controllers
{
    public class Cadastro : Controller
    {
        private UsuarioBLL usuarioBLL;
        public Cadastro()
        {
            AgendaNPJContext contexto = new AgendaNPJContext();
            usuarioBLL = new UsuarioBLL(contexto);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            string msgErro = String.Empty;

            if (ModelState.IsValid)
            {
                if (usuarioBLL.SetCadastro(usuario))
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
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Criar()
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

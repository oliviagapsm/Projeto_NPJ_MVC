using Microsoft.AspNetCore.Mvc;
using NPJ_MVC.Data;
using NPJ_MVC.Models;
using NPJ_MVC.Repositorios;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace MVCTeste.Controllers
{
    public class UsuarioController : Controller 
    {

        //private UsuarioRepositorio usuarioRepositorio;

        //public UsuarioController(AgendaNPJContext context)
        //{
        //    usuarioRepositorio = new UsuarioRepositorio(context);
        //}

        public IActionResult Index()
        {
            return View();
        }
        /* public IActionResult Criar()
         {
             List<UsuarioModel> usuarios = _usuarioRepositorio.Adicionar();

             return View(usuarios);
         }*/

        /*[HttpGet]
        public ActionResult Criar()
        {

            PreencherViewBag();

            return View();
        }

        private void PreencherViewBag()
        {
            var model = new Data.Assistido;
        }*/
            /*public IActionResult Editar(int id)
            {
                UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(Id);
                return View(usuario);
            }

            public IActionResult ApagarConfirmacao(int id)
            {
                UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(id);
                return View(usuario);
            }*/

            /* public IActionResult Apagar(int id)
             {
                 try
                 {
                     bool apagado = _usuarioRepositorio.Apagar(id);

                     if (apagado) TempData["MensagemSucesso"] = "Contato apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu contato, tente novamante!";
                     return RedirectToAction("Index");
                 }
                 catch (Exception erro)
                 {
                     TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                     return RedirectToAction("Index");
                 }
             }*/

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        var cadastroUsuario = usuarioRepositorio.SetCadastro(usuario);

            //        TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
            //        return RedirectToAction("Index");
            //    }

            //    return View(usuario);
            //}
            //catch (Exception erro)
            //{
            //    TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamante, detalhe do erro: {erro.Message}";
            //    return RedirectToAction("Index");
            //}

            return View(usuario);
        }

        //[HttpPost]
       /* public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }*/
        }
    }




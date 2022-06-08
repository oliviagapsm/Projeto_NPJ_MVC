using Microsoft.EntityFrameworkCore;
using NPJ_MVC.Data;
using NPJ_MVC.Models;
using NPJ_MVC.Utils;

namespace NPJ_MVC.Repositorios
{
    public class AssistidoDAL
    {
        private readonly AgendaNPJContext _bancoContext;
        public AssistidoDAL(AgendaNPJContext banco)
        {
            _bancoContext = banco;
        }
        public bool SetCadastroAssistido(AssistidoModel assistido, UsuarioModel usuario)
        {
            //VERIFICAR O PROJETO DE AGENDAMENTO DE EXAMES PARA VER A QUESTÃO DE ATRIBUIÇÃO CONTROLER - MODEL - CONTEXT

            try
            {
                using (var context = _bancoContext)
                {

                    Usuario novoUsuario = new Usuario
                    {
                        CoSenha = usuario.coSenha, //REGISTRO VEM DA TELA
                        DeLocalResidencia = usuario.deLocalResidencia, //REGISTRO VEM DA TELA
                        DtAlteracao = DateTime.Now, //DATA ATUAL
                        IcAdministrador = false, //AO CADASTRAR, VAI SER ADMINISTRADOR? SE SIM PASSA TRUE, SE NÃO PASSA FALSE
                        IcColaborador = true, //AO CADASTRAR, VAI SER COLABORADOR? SE SIM PASSA TRUE, SE NÃO PASSA FALSE
                        NmUsuario = usuario.nmUsuario, //REGISTRO VEM DA TELA
                        NuCpf = LibraryUtils.ClearMask(usuario.nuCPF), //CRIADO UMA CLASSE LIBRARYUTILS PARA INSERIR MÉTODOS QUE PODEM SER ÚTEIS EM VÁRIOS LUGARES //REGISTRO VEM DA TELA
                        NuIdentidade = usuario.nuIdentidade, //REGISTRO VEM DA TELA
                        IcAtivo = true //REGISTRO ATIVO
                        
                    };

                    context.Usuario.Add(novoUsuario);
                    context.SaveChanges();

                    Assistido novoAssistido = new Assistido
                    {
                        IdUsuario = novoUsuario.IdUsuario,
                        DtAceiteTermo = DateTime.Now,
                        DtCadastro = DateTime.Now,
                        EdIpassistido = "",
                  
                    };


                    context.Assistido.Add(novoAssistido);
                    context.SaveChanges();
                }

                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        
    }
}

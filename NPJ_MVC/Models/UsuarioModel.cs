
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace NPJ_MVC.Models
{
    
    public class UsuarioModel
    {              
        [Display(Name = "Nome Completo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe seu nome completo.")]
        [RegularExpression(@"^([a-zA-Zà-úÀ-Ú]|_|\s)+$", ErrorMessage ="Números e caracteres especiais não são permitidos no nome.")]
        public string nmUsuario { get; set; }

        [Display(Name ="Número do CPF")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe seu CPF.")]
        public string nuCPF { get; set; }

        [Display(Name ="Número do RG")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "Por favor, informe seu RG.")]
        public string nuIdentidade { get; set; }

        [Display(Name ="Senha")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Por favor, entre com uma senha maior que 6 caractéres.")]
        [MinLength(6, ErrorMessage ="Por favor, entre com uma senha maior que 6 caractéres.")]
        public string coSenha { get; set; }

        [Display(Name ="Local de Residência")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Por favor, informe seu local de residência")]
        public string deLocalResidencia { get; set; }
    }
}

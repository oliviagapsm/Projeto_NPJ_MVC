using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            Assistidos = new HashSet<Assistido>();
        }

        public int IdUsuario { get; set; }
        public string CoSenha { get; set; } = null!;
        public string DeLocalResidencia { get; set; } = null!;
        public DateTime? DtAlteracao { get; set; }
        public bool IcAdministrador { get; set; }
        public bool IcColaborador { get; set; }
        public string NmUsuario { get; set; } = null!;
        public string NuCpf { get; set; } = null!;
        public string NuIdentidade { get; set; } = null!;
        public bool IcAtivo { get; set; }

        public virtual ICollection<Assistido> Assistidos { get; set; }
    }
}

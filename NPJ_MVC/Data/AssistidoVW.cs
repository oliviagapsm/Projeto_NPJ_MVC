using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class AssistidoVW
    {
        public int IdAssitido { get; set; }
        public DateTime? DtAceiteTermo { get; set; }
        public DateTime DtCadastro { get; set; }
        public string? EdIpassistido { get; set; }
        public int IdUsuario { get; set; }
        public string CoSenha { get; set; } = null!;
        public string DeLocalResidencia { get; set; } = null!;
        public DateTime? DtAlteracao { get; set; }
        public bool IcAdministrador { get; set; }
        public bool IcAtivo { get; set; }
        public bool IcColaborador { get; set; }
        public string NmUsuario { get; set; } = null!;
        public string NuCpf { get; set; } = null!;
        public string NuIdentidade { get; set; } = null!;
    }
}

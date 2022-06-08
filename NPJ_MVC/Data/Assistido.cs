using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class Assistido
    {
        public Assistido()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

        public int IdAssitido { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? DtAceiteTermo { get; set; }
        public DateTime DtCadastro { get; set; }
        public string? EdIpassistido { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}

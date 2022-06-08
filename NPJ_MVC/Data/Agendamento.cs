using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class Agendamento
    {
        public int IdAgendamento { get; set; }
        public int IdAgenda { get; set; }
        public int IdAssitido { get; set; }
        public DateTime DtAgendamento { get; set; }
        public bool IcAtivo { get; set; }

        public virtual Agenda IdAgendaNavigation { get; set; } = null!;
        public virtual Assistido IdAssitidoNavigation { get; set; } = null!;
    }
}

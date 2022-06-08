using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class Agenda
    {
        public Agenda()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

        public int IdAgenda { get; set; }
        public int IdDisponibilidadeHorario { get; set; }
        public DateTime DtAgenda { get; set; }
        public bool IcAtivo { get; set; }

        public virtual DisponibilidadeHorario IdDisponibilidadeHorarioNavigation { get; set; } = null!;
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}

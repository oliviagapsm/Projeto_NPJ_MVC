using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class DisponibilidadeHorario
    {
        public DisponibilidadeHorario()
        {
            Agenda = new HashSet<Agenda>();
        }

        public int IdDisponibilidadeHorario { get; set; }
        public int IdAreaJuridicaNucleoJuridico { get; set; }
        public int IdHorario { get; set; }
        public bool IcAtivo { get; set; }

        public virtual AreaJuridicaNucleoJuridico IdAreaJuridicaNucleoJuridicoNavigation { get; set; } = null!;
        public virtual Horario IdHorarioNavigation { get; set; } = null!;
        public virtual ICollection<Agenda> Agenda { get; set; }
    }
}

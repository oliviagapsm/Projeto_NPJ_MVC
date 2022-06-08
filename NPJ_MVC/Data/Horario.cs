using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class Horario
    {
        public Horario()
        {
            DisponibilidadeHorarios = new HashSet<DisponibilidadeHorario>();
        }

        public int IdHorario { get; set; }
        public short IdNucleoJuridico { get; set; }
        public TimeSpan HrInicio { get; set; }
        public TimeSpan HrFim { get; set; }
        public short NuQtdeVagas { get; set; }
        public bool IcAtivo { get; set; }

        public virtual NucleoJuridico IdNucleoJuridicoNavigation { get; set; } = null!;
        public virtual ICollection<DisponibilidadeHorario> DisponibilidadeHorarios { get; set; }
    }
}

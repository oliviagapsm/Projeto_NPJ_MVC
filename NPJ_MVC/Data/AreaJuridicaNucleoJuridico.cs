using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class AreaJuridicaNucleoJuridico
    {
        public AreaJuridicaNucleoJuridico()
        {
            DisponibilidadeHorarios = new HashSet<DisponibilidadeHorario>();
        }

        public int IdAreaJuridicaNucleoJuridico { get; set; }
        public byte IdAreaJuridica { get; set; }
        public short IdNucleoJuridico { get; set; }
        public bool IcAtivo { get; set; }

        public virtual AreaJuridica IdAreaJuridicaNavigation { get; set; } = null!;
        public virtual NucleoJuridico IdNucleoJuridicoNavigation { get; set; } = null!;
        public virtual ICollection<DisponibilidadeHorario> DisponibilidadeHorarios { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class NucleoJuridico
    {
        public NucleoJuridico()
        {
            AreaJuridicaNucleoJuridicos = new HashSet<AreaJuridicaNucleoJuridico>();
            Horarios = new HashSet<Horario>();
        }

        public short IdNucleoJuridico { get; set; }
        public short IdLocalAtendimento { get; set; }
        public string EdEmail { get; set; } = null!;
        public string NmNucleoJuridico { get; set; } = null!;
        public string NuTelefone { get; set; } = null!;
        public bool IcAtivo { get; set; }

        public virtual LocalAtendimento IdLocalAtendimentoNavigation { get; set; } = null!;
        public virtual ICollection<AreaJuridicaNucleoJuridico> AreaJuridicaNucleoJuridicos { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
    }
}

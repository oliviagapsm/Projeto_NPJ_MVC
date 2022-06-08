using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class AreaJuridica
    {
        public AreaJuridica()
        {
            AreaJuridicaNucleoJuridicos = new HashSet<AreaJuridicaNucleoJuridico>();
        }

        public byte IdAreaJuridica { get; set; }
        public string NmAreaJuridica { get; set; } = null!;
        public bool IcAtivo { get; set; }

        public virtual ICollection<AreaJuridicaNucleoJuridico> AreaJuridicaNucleoJuridicos { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class LocalAtendimento
    {
        public LocalAtendimento()
        {
            NucleoJuridicos = new HashSet<NucleoJuridico>();
        }

        public short IdLocalAtendimento { get; set; }
        public string DeEndereco { get; set; } = null!;
        public string NmLocalAtendimento { get; set; } = null!;
        public bool IcAtivo { get; set; }

        public virtual ICollection<NucleoJuridico> NucleoJuridicos { get; set; }
    }
}

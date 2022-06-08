using System;
using System.Collections.Generic;

namespace NPJ_MVC.Data
{
    public partial class AgendaVW
    {
        public int IdAgenda { get; set; }
        public DateTime DtAgenda { get; set; }
        public bool IcAtivoAgenda { get; set; }
        public int IdDisponibilidadeHorario { get; set; }
        public bool IcAtivoDisponibilidadeHorario { get; set; }
        public int IdAreaJuridicaNucleoJuridico { get; set; }
        public bool IcAtivoAreaJuridicaNucleoJuridico { get; set; }
        public byte IdAreaJuridica { get; set; }
        public string NmAreaJuridica { get; set; } = null!;
        public bool IcAtivoAreaJuridica { get; set; }
        public short IdNucleoJuridico { get; set; }
        public string EdEmail { get; set; } = null!;
        public string NmNucleoJuridico { get; set; } = null!;
        public string NuTelefone { get; set; } = null!;
        public bool IcAtivoNucleoJuridico { get; set; }
        public int IdHorario { get; set; }
        public short IdNucleoJuridicoHorario { get; set; }
        public TimeSpan HrInicio { get; set; }
        public TimeSpan HrFim { get; set; }
        public short NuQtdeVagas { get; set; }
        public bool IcAtivoHorario { get; set; }
        public short IdLocalAtendimento { get; set; }
        public string DeEndereco { get; set; } = null!;
        public string NmLocalAtendimento { get; set; } = null!;
        public bool IcAtivoLocalAtendimento { get; set; }
        public int NuQtdeAgendamento { get; set; }
    }
}

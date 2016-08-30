using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Contratos
{
    public interface ICandidatoTecnologia
    {
        Guid CandidatoId { get; }
        Guid TecnologiaId { get; }
        int NivelConhecimento { get; }
        int Peso { get; }

        void SetPeso(int peso);
    }
}

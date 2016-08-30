using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Contratos
{
    public interface ICandidato
    {
        Guid Id { get; }
        Guid VagaId { get; }
        string Nome { get; }
        int Pontuacao { get; }
        ICollection<ICandidatoTecnologia> CandidatoTecnologias { get; }

        void AddCandidatoTecnologia(ICandidatoTecnologia candidatoTecnologia);
    }
}

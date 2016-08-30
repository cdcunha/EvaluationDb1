using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Contratos
{
    public interface IVaga
    {
        Guid Id { get; }
        string Descricao { get; }
        ICollection<ITecnologia> Tecnologias { get; }
        ICollection<ICandidato> Candidatos { get; }

        void AdicionaTecnologia(ITecnologia tecnologia);
        void AdicionaCandidato(IList<ICandidato> candidatos);
    }
}

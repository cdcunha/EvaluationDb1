using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Contratos
{
    public interface ITecnologia
    {
        Guid Id { get; }
        string Descricao { get; }
    }
}

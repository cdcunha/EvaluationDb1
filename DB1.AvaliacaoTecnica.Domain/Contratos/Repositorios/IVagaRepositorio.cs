using DB1.AvaliacaoTecnica.Domain.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Contracts.Repositorios
{
    public interface IVagaRepositorio
    {        
        void Criar(IVaga vagas);
        IVaga Ler(Guid id);
        void Atualizar(IVaga vagas);
        void Deletar(IVaga vagas);
    }
}

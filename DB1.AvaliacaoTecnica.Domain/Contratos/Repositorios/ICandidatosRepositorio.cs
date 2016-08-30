using DB1.AvaliacaoTecnica.Domain.Contracts.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Contratos.Repositorios
{
    interface ICandidatosRepositorio
    {
        void Adicionar(ICandidatoRepositorio candidato);
        List<ICandidatoRepositorio> Listar();
        void Atualizar(ICandidato candidato);
        void Remover(ICandidatoRepositorio candidato);
    }
}

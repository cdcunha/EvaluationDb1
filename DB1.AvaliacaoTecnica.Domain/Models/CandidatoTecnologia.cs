using DB1.AvaliacaoTecnica.Domain.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class CandidatoTecnologia : ICandidatoTecnologia
    {
        //Contrutor para ser usado pelo EntityFramework
        public CandidatoTecnologia() { }

        public CandidatoTecnologia(Guid candidatoId, Guid tecnologiaId, int nivelConhecimento)
        {
            CandidatoId = candidatoId;
            TecnologiaId = tecnologiaId;
            NivelConhecimento = nivelConhecimento;
        }

        public Guid CandidatoId { get; private set; }
        public Guid TecnologiaId { get; private set; }
        public int NivelConhecimento { get; private set; }
        public int Peso { get; private set; }
        
        public void SetPeso(int peso)
        {
            Peso = peso;
        }
    }
}

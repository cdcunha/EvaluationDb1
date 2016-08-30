using DB1.AvaliacaoTecnica.Domain.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class Candidato : ICandidato
    {
        //Contrutor para ser usado pelo EntityFramework
        public Candidato(){}

        public Candidato(Guid vagaId, string nome, IList<ICandidatoTecnologia> candidatoTecnologias)
        {
            this.VagaId = vagaId;
            this.Nome = nome;
            this.CandidatoTecnologias = candidatoTecnologias;
        }

        #region Propriedades
        public Guid Id { get; private set; }
        public Guid VagaId { get; private set; }
        public string Nome { get; private set; }

        private IList<ICandidatoTecnologia> _candidatoTecnologias;
        public ICollection<ICandidatoTecnologia> CandidatoTecnologias
        {
            get { return _candidatoTecnologias; }
            private set { _candidatoTecnologias = new List<ICandidatoTecnologia>(value); }
        }

        #region Calcula Pontuação
        public int Pontuacao
        {
            get
            {
                int total = 0;

                foreach (var candidatoTec in _candidatoTecnologias)
                {
                    total += candidatoTec.Peso * candidatoTec.NivelConhecimento;
                }

                return total;
            }
        }
        #endregion
        #endregion

        #region Métodos
        public void AddCandidatoTecnologia(ICandidatoTecnologia candidatoTecnologia)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

using DB1.AvaliacaoTecnica.Domain.Contratos;
using DB1.AvaliacaoTecnica.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class Vaga : IVaga
    {
        //Contrutor para ser usado pelo EntityFramework
        public Vaga() { }

        public Vaga(string descricao, IList<ITecnologia> tecnologias)
        {
            this.Descricao = descricao;
            this._tecnologias = tecnologias;
        }

        #region Propriedades
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }

        private IList<ITecnologia> _tecnologias;
        public ICollection<ITecnologia> Tecnologias
        {
            get { return _tecnologias; }
            private set { _tecnologias = new List<ITecnologia>(value); }
        }

        private IList<ICandidato> _candidatos;
        public ICollection<ICandidato> Candidatos
        {
            get { return _candidatos; }
            private set { _candidatos = new List<ICandidato>(value); }
        }
        public EVagaSituacao Situacao { get; private set; }
        #endregion

        #region Métodos
        public void AdicionaTecnologia(ITecnologia tecnologia)
        {
            _tecnologias.Add(tecnologia);
        }

        public void AdicionaCandidato(IList<ICandidato> candidatos)
        {
            this.Candidatos = candidatos;
        }
        #endregion
    }
}

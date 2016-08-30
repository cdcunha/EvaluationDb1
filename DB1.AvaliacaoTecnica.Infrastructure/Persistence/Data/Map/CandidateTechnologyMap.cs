using DB1.AvaliacaoTecnica.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DB1.AvaliacaoTecnica.Infrastructure.Persistence.Data.Map
{
    public class CandidateTechnologyMap : EntityTypeConfiguration<CandidateTechnology>
    {
        public CandidateTechnologyMap()
        {
            ToTable("CandidateTechnology");

            HasKey(x => x.Id);

            Property(x => x.KnowledgeLevel)
                .IsRequired();
        }
    }
}

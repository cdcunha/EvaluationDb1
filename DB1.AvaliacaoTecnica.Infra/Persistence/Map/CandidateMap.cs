using DB1.AvaliacaoTecnica.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB1.AvaliacaoTecnica.Infrastructure.Persistence.Map
{
    public class CandidateMap : EntityTypeConfiguration<Candidate>
    {
        public CandidateMap()
        {
            ToTable("Candidate");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}

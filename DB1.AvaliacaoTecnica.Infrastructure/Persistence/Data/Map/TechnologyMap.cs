using DB1.AvaliacaoTecnica.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DB1.AvaliacaoTecnica.Infrastructure.Persistence.Data.Map
{
    public class TechnologyMap : EntityTypeConfiguration<Technology>
    {
        public TechnologyMap()
        {
            ToTable("Technology");

            HasKey(x => x.Id);

            Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}

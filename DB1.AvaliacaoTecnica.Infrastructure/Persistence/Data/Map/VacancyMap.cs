using DB1.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Infrastructure.Persistence.Data.Map
{
    public class VacancyMap : EntityTypeConfiguration<Vacancy>
    {
        public VacancyMap()
        {
            ToTable("Vacancy");

            HasKey(x => x.Id);

            Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.Status)
                .IsRequired();
        }
    }
}

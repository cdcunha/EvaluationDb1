using DB1.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Infrastructure.Persistence.Data.Map
{
    public class VacancyTechnologyMap : EntityTypeConfiguration<VacancyTechnology>
    {
        public VacancyTechnologyMap()
        {
            ToTable("VacancyTechnology");

            HasKey(x => x.Id);
        }
    }
}

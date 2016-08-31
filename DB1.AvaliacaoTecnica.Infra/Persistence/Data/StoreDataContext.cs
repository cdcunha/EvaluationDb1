namespace DB1.AvaliacaoTecnica.Infrastructure.Data
{
    using Domain.Models;
    using Persistence.Map;
    using System.Data.Entity;

    public class StoreDataContext : DbContext
    {
        // Your context has been configured to use a 'StoreDataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DB1.AvaliacaoTecnica.Infrastructure.StoreDataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StoreDataContext' 
        // connection string in the application configuration file.
        public StoreDataContext()
            : base("name=StoreDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateTechnology> CandidateTechnologies { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyTechnology> VacancyTechnologies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TechnologyMap());
            modelBuilder.Configurations.Add(new VacancyMap());
            modelBuilder.Configurations.Add(new VacancyTechnologyMap());
            modelBuilder.Configurations.Add(new CandidateMap());
            modelBuilder.Configurations.Add(new CandidateTechnologyMap());
        }
    }
}
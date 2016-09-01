namespace DB1.AvaliacaoTecnica.Domain.Commands.VacancyTechnologyCommands
{
    public class CreateVacancyTechnologyCommand
    {
        public CreateVacancyTechnologyCommand(int technologyId)
        {
            this.TechnologyId = technologyId;
        }

        public int TechnologyId { get; set; }
    }
}

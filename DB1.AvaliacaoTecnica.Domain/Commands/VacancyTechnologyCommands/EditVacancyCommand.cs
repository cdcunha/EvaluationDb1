namespace DB1.AvaliacaoTecnica.Domain.Commands.VacancyTechnologyCommands
{
    public class EditVacancyCommand
    {
        public EditVacancyCommand(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}

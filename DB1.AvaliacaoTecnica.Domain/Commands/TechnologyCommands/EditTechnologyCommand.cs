namespace DB1.AvaliacaoTecnica.Domain.Commands.TechnologyCommands
{
    public class EditTechnologyCommand
    {
        public EditTechnologyCommand(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}

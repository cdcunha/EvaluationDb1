namespace DB1.AvaliacaoTecnica.Domain.Commands.VacancyTechnologyCommands
{
    public class CreateCandidateTechnologyCommand
    {
        public CreateCandidateTechnologyCommand(int knowledgeLevel)
        {
            this.KnowledgeLevel = knowledgeLevel;
        }

        public int KnowledgeLevel { get; set; }
    }
}

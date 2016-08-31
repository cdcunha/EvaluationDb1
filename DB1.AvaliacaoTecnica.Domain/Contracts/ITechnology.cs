namespace DB1.AvaliacaoTecnica.Domain.Contracts
{
    public interface ITechnology
    {
        int Id { get; }
        string Description { get; }

        bool CanAdd();
    }
}

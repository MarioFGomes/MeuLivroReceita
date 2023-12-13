

namespace MeuLivroDeReceitas.Domain.Entidade;

public class EntidadeBase
{
    public Guid Id { get; set; }
    public DateTime DataRegisto { get; set; }
    public int Status { get; set; }
    public DateTime LastUpdate { get; set; }

    public EntidadeBase()
    {
        Id=Guid.NewGuid();
        DataRegisto = DateTime.UtcNow;
        LastUpdate= DateTime.UtcNow;
        Status =1;
    }
}

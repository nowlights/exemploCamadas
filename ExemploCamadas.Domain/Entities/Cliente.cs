namespace ExemploCamadas.Domain.Entities;

public class Cliente
{
    public int IdCliente { get; set; }
    public string Nome { get; set; } = null!;
    public string Sobrenome { get; set; } = null!;
}
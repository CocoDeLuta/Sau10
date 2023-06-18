public class Cargo
{
    public int? Id { get; set; }
    public string Nome { get; set; }

    public Cargo()
    {

    }

    public Cargo(string nome)
    {
        Nome = nome;
    }

    public void NomeCargoToString()
    {
        Console.WriteLine(Nome);
    }
}
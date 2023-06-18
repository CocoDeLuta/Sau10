public class Internamento
{
    public int Id { get; set; }
    public DateOnly DataEntrada { get; set; }
    public DateOnly? DataSaida { get; set; }
    public string Motivo { get; set; }

    public Internamento(DateOnly dataEntrada, string motivo)
    {
        DataEntrada = dataEntrada;
        Motivo = motivo;
    }

    public Internamento(DateOnly dataEntrada, DateOnly dataSaida, string motivo)
    {
        DataEntrada = dataEntrada;
        DataSaida = dataSaida;
        Motivo = motivo;
    }

    public Internamento()
    {

    }

    public void ToString()
    {
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Data de Entrada: " + DataEntrada);
        Console.WriteLine("Data de Saida: " + DataSaida);
        Console.WriteLine("Motivo do Internamento: " + Motivo);
    }

}
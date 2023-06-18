public class Internamento
{
    public int Id { get; set; }
    public DateOnly DataEntrada { get; set; }
    public DateOnly? DataSaida { get; set; }
    public int PacienteId { get; set; }
    public int FuncionarioId { get; set; }
    public int NumeroQuarto { get; set; }
    public string Motivo { get; set; }

    public Internamento(DateOnly dataEntrada, string motivo, int pacienteId, int funcionarioId, int numeroQuarto)
    {
        DataEntrada = dataEntrada;
        Motivo = motivo;
        PacienteId = pacienteId;
        FuncionarioId = funcionarioId;
        NumeroQuarto = numeroQuarto;
    }

    public Internamento()
    {

    }

    public string Status()
    {
        if (DataSaida == null)
        {
            return "Internado";
        }
        else
        {
            return Convert.ToString(DataSaida);
        }
    }

}
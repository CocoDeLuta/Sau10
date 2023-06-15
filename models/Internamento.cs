public class Internamento {
    public int Id { get; set; }
    public int IdPaciente { get; set; }
    public int IdFuncionario { get; set; }
    public DateOnly DataEntrada { get; set; }
    public DateOnly ?DataSaida { get; set; }
    public string Motivo { get; set; }
    public Internamento(int paciente, int funcionario, DateOnly dataEntrada, DateOnly dataSaida, string motivo)
    {
        IdPaciente = paciente;
        IdFuncionario = funcionario;
        DataEntrada = dataEntrada;
        DataSaida = dataSaida;
        Motivo = motivo;
    }
}
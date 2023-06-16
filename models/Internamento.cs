public class Internamento {
    public int Id { get; set; }
    public List<Paciente> Pacientes { get; set; }
    public List<Funcionario> Funcionarios { get; set; }
    public DateOnly DataEntrada { get; set; }
    public DateOnly ?DataSaida { get; set; }
    public string Motivo { get; set; }
    
    public Internamento(DateOnly dataEntrada, string motivo) {
        DataEntrada = dataEntrada;
        Motivo = motivo;
    }

    public Internamento(DateOnly dataEntrada, DateOnly dataSaida, string motivo) {
        DataEntrada = dataEntrada;
        DataSaida = dataSaida;
        Motivo = motivo;
    }
    
}
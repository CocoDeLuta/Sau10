public class Consulta
{
    public int Id { get; set; }
    public string Data { get; set; }
    public string Hora { get; set; }
    public string Descricao { get; set; }
    public string Status { get; set; }
    public int IdPaciente { get; set; }
    public int IdFuncionario { get; set; }
    public Consulta(string data, string hora, string descricao, string status, int idPaciente, int idFuncionario)
    {
        Data = data;
        Hora = hora;
        Descricao = descricao;
        Status = status;
        IdPaciente = idPaciente;
        IdFuncionario = idFuncionario;
    }
}
public class Consulta
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public string Descricao { get; set; }
    //public List<Paciente> Pacientes { get; set; }
    public List<Funcionario> Funcionarios { get; set; }

    //Construtor
    public Consulta(DateTime dateTime, string descricao)
    {
        DateTime = dateTime;
        Descricao = descricao;
    }

    public Consulta(){

    }
}
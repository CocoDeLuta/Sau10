public class Paciente : Pessoa
{
    public DateOnly DataNascimento { get; set; }
    public List<Consulta> Consultas { get; set; }
    public List<Internamento> Internamentos { get; set; }

    //Construtor
    public Paciente(string nome, string sobrenome, string telefone, string cpf, DateOnly dataNascimento)
    : base(nome, sobrenome, telefone, cpf)
    {
        DataNascimento = dataNascimento;
    }

    public Paciente()
    {

    }
}
public class Paciente : Pessoa
{
    public DateOnly DataNascimento { get; set; }

    //Construtor
    public Paciente(string nome, string sobrenome, string telefone, string cpf, DateOnly dataNascimento)
    : base(nome, sobrenome, telefone, cpf)
    {
        DataNascimento = dataNascimento;
    }

    public Paciente()
    {

    }

    public string ToStringNomeCompleto()
    {   
        string nome = Nome + " " + SobreNome;
        return nome;
    }

}
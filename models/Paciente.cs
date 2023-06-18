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

    public void ToStringNomeCompleto()
    {
        Console.WriteLine("Paciente: " + Nome + " " + SobreNome);
    }

    public void ToString()
    {
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Sobrenome: " + SobreNome);
        Console.WriteLine("Telefone: " + Telefone);
        Console.WriteLine("CPF: " + Cpf);
        Console.WriteLine("Data de Nascimento: " + DataNascimento);
    }
}
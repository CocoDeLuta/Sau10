public class Funcionario : Pessoa
{
    public string Cargo { get; set; }
    public double Salario { get; set; }

    public List<Consulta> Consultas { get; set; }
    public List<Internamento> Internamentos { get; set; }
    public Funcionario(string nome, string sobreNome, string telefone, string cpf, string cargo, double salario) : base(nome, sobreNome, telefone, cpf)
    {
        Cargo = cargo;
        Salario = salario;
    }

    public void ToString()
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Id: " + Id);
        Console.WriteLine($"Nome: {Nome} {SobreNome}");
        Console.WriteLine("Cargo: " + Cargo);
        Console.WriteLine("Salário: " + Salario);
        Console.WriteLine("Telefone: " + Telefone);
        Console.WriteLine("CPF: " + Cpf);
    }

    public void ToStringNomeCompleto()
    {
        Console.WriteLine(Nome + " " + SobreNome);
    }
}
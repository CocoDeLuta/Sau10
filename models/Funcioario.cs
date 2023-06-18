public class Funcionario : Pessoa
{
    public int? CargoId { get; set; }
    public double Salario { get; set; }

    public Funcionario(string nome, string sobreNome, 
    string telefone, string cpf, int cargo, double salario)
     : base(nome, sobreNome, telefone, cpf)
    {
        CargoId = cargo;
        Salario = salario;
    }

    public Funcionario()
    {

    }

    public void ToString()
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Id: " + Id);
        Console.WriteLine($"Nome: {Nome} {SobreNome}");
        Console.WriteLine("Salário: " + Salario);
        Console.WriteLine("Telefone: " + Telefone);
        Console.WriteLine("CPF: " + Cpf);
    }

    public void ToStringNomeCompleto()
    {
        Console.WriteLine(Nome + " " + SobreNome);
    }
}
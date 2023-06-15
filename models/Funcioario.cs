public class Funcionario : Pessoa
{
    public string Cargo { get; set; }
    public double Salario { get; set; }
    public Funcionario(string nome, string sobrenome, string telefone, string cpf, string cargo, double salario) : base(nome, sobrenome, telefone, cpf)
    {
        Cargo = cargo;
        Salario = salario;
    }
}
public class Funcionario : Pessoa
{
    public Funcionario(string nome, string sobreNome, string telefone, string cpf) : base(nome, sobreNome, telefone, cpf)
    {
        
    }


    public string Cargo { get; set; }
    public double Salario { get; set; }
    

    
}
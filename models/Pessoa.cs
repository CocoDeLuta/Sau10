public class Pessoa
{
    private object value;


    public int Id { get; set; }
    public string ?Nome { get; set; }
    public string ?SobreNome { get; set; }
    public string ?Telefone { get; set; }
    public string ?Cpf { get; set; }
    public Pessoa(string nome, string sobreNome, string telefone, string cpf)
    {
        Nome = nome;
        this.SobreNome = sobreNome;
        Telefone = telefone;
        Cpf = cpf;
    }


    public Pessoa(){
        
    }

}
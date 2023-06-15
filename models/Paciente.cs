public class Paciente : Pessoa
{
    public DateOnly DataNascimento { get; set; }

    public Paciente(string nome, string sobrenome, string telefone, string cpf, DateOnly dataNascimento) : base(nome, sobrenome, telefone, cpf)
    {
        DataNascimento = dataNascimento;
    }
}
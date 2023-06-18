public class Funcionario : Pessoa
{
    public int CargoId { get; set; }
    public double Salario { get; set; }
    public bool Ativo { get; set; }
    public string Usuario { get; set; }
    public string Senha { get; set; }
    public int Permissao { get; set; }


    public Funcionario(string user, string senha, int permissao, string nome, string sobreNome,
    string telefone, string cpf, int cargo, double salario, bool ativo)
     : base(nome, sobreNome, telefone, cpf)
    {
        Usuario = user;
        Senha = senha;
        Permissao = permissao;
        CargoId = cargo;
        Salario = salario;
        Ativo = ativo;
    }

    public Funcionario()
    {

    }

    public string ToStringNomeCompleto()
    {
        string nome = Nome + " " + SobreNome;
        return nome;
    }

    public string NivelAcesso()
    {
        switch (Permissao)
        {
            case 2:
                return "Médico";
            case 3:
                return "Administrador";
            case 1:
                return "Enfermeiro";
            default:
                return "Usuário";
        }
    }
}

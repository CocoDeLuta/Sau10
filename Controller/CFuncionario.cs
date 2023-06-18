public class CFuncionario : Repository<Funcionario>, IFuncionario
{
    public Funcionario Login(string usuario, string senha, CFuncionario controller)
    {   
        var utils = new Utils();
        List<Funcionario> funcionarios = controller.ObterTodos();
        foreach (var item in funcionarios)
        {
            if (item.Usuario == usuario)
            {
                if (item.Senha == senha)
                {
                    return item;
                }
            }
        }
        utils.ErrorMessage("Usuário ou senha incorretos!");
        return null;
    }
}
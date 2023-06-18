//comandos relacionados aos internamentos, como adicionar, remover, editar e listar.
public class InternamentoUI
{
    public void MenuInternamento(Funcionario user)
    {
        var utils = new Utils();
        int opcao = 999;
        while (opcao != 0)
        {
            utils.TituloMenu("MENU INTERNAMENTO");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Listar Internamentos");
            Console.WriteLine("2 - Novo Internamento");
            Console.WriteLine("3 - Atualizar Internamento");
            Console.WriteLine("0 - Voltar");
            Console.WriteLine("");
            Console.Write("Opção: ");
            if (int.TryParse(Console.ReadLine(), out opcao) == false)
            {
                utils.ErrorMessage("Opção inválida!");
            }
            else
            {
                switch (opcao)
                {
                    case 1:
                        Listar();
                        utils.Enter();
                        opcao = 999;
                        break;
                    case 2:
                        NovoInternamento(user);
                        opcao = 999;
                        break;
                    case 3:
                        AtualizarInternamento(user);
                        opcao = 999;
                        break;
                    case 0:
                        //Voltando para o menu anterior
                        break;
                    default:
                        utils.ErrorMessage("Opção inválida!");
                        opcao = 999;
                        break;
                }
            }
        }
    }

    public void Listar()
    {

    }

    void NovoInternamento(Funcionario user)
    {

    }

    void AtualizarInternamento(Funcionario user)
    {

    }
}
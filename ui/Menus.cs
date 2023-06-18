public class Menus
{

    public void Login()
    {
        Console.Clear();
        var utils = new Utils();
        var funcController = new CFuncionario();
        //login

        bool logged = false;
        Funcionario user = null;
        while (!logged)
        {
            Console.Write("Digite o usuário: ");
            string usuario = Console.ReadLine();
            Console.Write("Digite a senha: ");
            string senha = Console.ReadLine();

            try
            {
                user = funcController.Login(usuario, senha, funcController);
                if (user != null)
                {
                    logged = true;
                    utils.SuccessMessage("Login efetuado com sucesso!");
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                utils.ErrorMessage("Erro ao efetuar login.");
                utils.Enter();
                return;
            }
        }

        MenuPrincipal(user);

    }


    public void MenuPrincipal(Funcionario user)
    {
        var ConsultaUI = new ConsultaUI();
        var FuncionarioUI = new FuncionarioUI();
        var InternamentoUI = new InternamentoUI();
        var PacienteUI = new PacienteUI();
        var CargoUI = new CargoUI();
        var utils = new Utils();

        //Menu principal
        int opcao = 9;
        while (opcao != 0)
        {
            utils.TituloMenu("MENU PRINCIPAL");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Gerenciar pacientes");
            Console.WriteLine("2 - Gerenciar internamentos");
            Console.WriteLine("3 - Gerenciar funcionarios");
            Console.WriteLine("4 - Gerenciar consultas");
            Console.WriteLine("5 - Gerenciar cargos");
            Console.WriteLine("0 - Sair / Trocar usuário");
            Console.WriteLine("");
            Console.Write("Opção: ");
            if (int.TryParse(Console.ReadLine(), out opcao) == false)
            {
                utils.ErrorMessage("Opção inválida! Tente novamente.");
                opcao = 999;
            }
            else
            {
                switch (opcao)
                {
                    case 1:
                        PacienteUI.MenuPaciente(user);
                        opcao = 999;
                        break;
                    case 2:
                        InternamentoUI.MenuInternamento(user);
                        opcao = 999;
                        break;
                    case 3:
                        FuncionarioUI.MenuFuncionario(user);
                        opcao = 999;
                        break;
                    case 4:
                        ConsultaUI.MenuConsulta(user);
                        opcao = 999;
                        break;
                    case 5:
                        CargoUI.MenuCargo(user);
                        opcao = 999;
                        break;
                    case 0:
                        Console.WriteLine("Obrigado por usar o Sau10!");
                        break;
                    default:
                        utils.ErrorMessage("Opção inválida!");
                        opcao = 999;
                        break;
                }
            }
        }
    }
}
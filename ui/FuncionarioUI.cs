//comandos relacionados aos funcionarios como adicionar, remover, editar e listar.
using ConsoleTables;
using Microsoft.Identity.Client;

public class FuncionarioUI
{
    public void MenuFuncionario()
    {

        //Menu Funcionario
        var utils = new Utils();
        int opcao = 999;
        while (opcao != 0)
        {
            utils.TituloMenu("MENU FUNCIONARIO");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Listar Funcionario");
            Console.WriteLine("2 - Cadastrar Funcionario");
            Console.WriteLine("3 - Remover Funcionario");
            Console.WriteLine("4 - Atualizar Funcionario");
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
                        break;
                    case 2:
                        AdicionarFuncionarios();
                        break;
                    case 3:
                        RemoverFuncionarios();
                        break;
                    case 4:
                        AtualizarFuncionarios();
                        break;
                    case 0:
                        //Voltando para o menu principal
                        break;
                    default:
                        utils.ErrorMessage("Opção inválida!");
                        break;
                }
            }


        }
    }

    public void Listar()
    {
        var utils = new Utils();
        Console.Clear();
        CFuncionario controller = new CFuncionario();
        List<Funcionario> funcionarios = controller.ObterTodos();

        var tabela = new ConsoleTable("ID", "Nome", "Sobrenome", "Telefone", "CPF", "Cargo", "Salario");
        foreach (var item in funcionarios)
        {
            tabela.AddRow(Convert.ToString(item.Id),
            item.Nome,
            item.SobreNome,
            item.Telefone,
            item.Cpf,
            item.CargoId,
            Convert.ToString(item.Salario));
        }
        tabela.Write();

    }

    public void AdicionarFuncionarios()
    {
        var utils = new Utils();

        utils.TituloMenu("CADASTRAR FUNCIONARIO");

        Console.WriteLine("Digite o primeiro nome do funcionario:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o sobrenome do funcionario:");
        string sobrenome = Console.ReadLine();
        Console.Write("Digite o telefone do funcionario:");
        string telefone = Console.ReadLine();
        Console.WriteLine("Digite o CPF do funcionario:");
        string cpf = Console.ReadLine();

        Console.WriteLine("");
        Console.WriteLine("Agora programa irá listar os cargos.");
        Console.WriteLine("Verifique o ID do cargo que deseja atualizar.");
        utils.Enter();




        /////////////////////////////////////////////////////////////////



        Console.WriteLine("Digite o cargo do funcionario:");
        if (int.TryParse(Console.ReadLine(), out int cargoId) == false)
        {
            utils.ErrorMessage("ID inválido!");
        }

        Console.WriteLine("Digite o salario do funcionario:");
        double salario;

        if (double.TryParse(Console.ReadLine(), out salario) == false)
        {
            utils.ErrorMessage("Salapio inválido!");
        }
        else
        {
            var funcionario = new Funcionario(nome, sobrenome, telefone, cpf, cargoId, salario);
            CFuncionario controller = new CFuncionario();
            controller.Inserir(funcionario);
            utils.Green();
            Console.WriteLine("Funcionário cadastrado com sucesso!");
            utils.Enter();
        }

    }

    public void RemoverFuncionarios()
    {
        var utils = new Utils();
        CFuncionario controller = new CFuncionario();

        utils.TituloMenu("REMOVER FUNCIONARIO");

        Console.WriteLine("O programa irá listar os funcionários.");
        Console.WriteLine("Verifique o ID do funcionário que deseja excluir.");
        utils.Enter();
        Listar();

        Console.WriteLine("Digite o Id do funcionário que deseja excluir:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            utils.ErrorMessage("ID inválido!");
            return;
        }

        //Verificar se o funcionario existe
        var funcionario = controller.ObterPorId(id);
        if (funcionario == null)
        {
            utils.ErrorMessage("Funcionário não encontrado!	");
            return;
        }

        try
        {
            controller.Excluir(funcionario);
            utils.Green();
            Console.WriteLine("Funcionário excluído com sucesso!");
        }
        catch
        {
            utils.ErrorMessage("Id inválido!");
        }
    }

    public void AtualizarFuncionarios()
    {
        var utils = new Utils();

        utils.TituloMenu("ATUALIZAR FUNCIONARIO");

        Console.WriteLine("O programa irá listar os funcionários.");
        Console.WriteLine("Verifique o ID do funcionário que deseja atualizar.");
        utils.Enter();
        Listar();
        Console.WriteLine("Digite o Id do funcionário que deseja atualizar:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            utils.ErrorMessage("Id inválido!");
        }
        else
        {
            CFuncionario controller = new CFuncionario();
            try
            {
                var atualizar = controller.ObterPorId(id);
                Console.WriteLine("Digite o primeiro nome do funcionario:");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite o sobrenome do funcionario:");
                string sobrenome = Console.ReadLine();
                Console.Write("Digite o telefone do funcionario:");
                string telefone = Console.ReadLine();
                Console.WriteLine("Digite o CPF do funcionario:");
                string cpf = Console.ReadLine();


                Console.WriteLine("");
                Console.WriteLine("Agora programa irá listar os cargos.");
                Console.WriteLine("Verifique o ID do cargo que deseja atualizar.");
                utils.Enter();
                
                /////////////////////////////////////////////////////////////////

                Console.WriteLine("Digite o cargo do funcionario:");
                if (int.TryParse(Console.ReadLine(), out int cargoId) == false)
                {
                    utils.Red();
                    Console.WriteLine("Id inválido! Tente novamente.");
                    utils.Enter();
                }

                Console.WriteLine("");
                Console.WriteLine("Digite o salario do funcionario:");

                if (double.TryParse(Console.ReadLine(), out double salario) == false)
                {
                    utils.ErrorMessage("Opção inválida!");
                }
                else
                {
                    atualizar.Nome = nome;
                    atualizar.SobreNome = sobrenome;
                    atualizar.Telefone = telefone;
                    atualizar.Cpf = cpf;
                    atualizar.CargoId = cargoId;
                    atualizar.Salario = salario;
                    controller.Atualizar(atualizar);
                    utils.Green();
                    Console.WriteLine("Funcionário atualizado com sucesso!");
                    utils.Enter();
                }
            }
            catch
            {
                utils.ErrorMessage("Id inválido!");
            }
        }
    }
}


//comandos relacionados aos funcionarios como adicionar, remover, editar e listar.
using ConsoleTables;
using Microsoft.Identity.Client;

public class FuncionarioUI
{
    public void MenuFuncionario()
    {

        //Menu Funcionario
        var utils = new Utils();
        int opcao = 0;
        while (opcao != 5)
        {
            Console.Clear();
            utils.Yellow();
            Console.WriteLine("MENU FUNCIONÁRIO");
            Console.WriteLine("");
            utils.White();
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Listar Funcionario");
            Console.WriteLine("2 - Adicionar Funcionario");
            Console.WriteLine("3 - Remover Funcionario");
            Console.WriteLine("4 - Atualizar Funcionario");
            Console.WriteLine("5 - Voltar");
            Console.WriteLine("");
            Console.Write("Opção: ");
            if (int.TryParse(Console.ReadLine(), out opcao) == false)
            {
                utils.OpcaoInvalida();
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
                    case 5:
                        //Voltando para o menu principal
                        break;
                    default:
                        utils.OpcaoInvalida();
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
            item.Cargo, 
            Convert.ToString(item.Salario));
        }
        tabela.Write();

    }

    public void AdicionarFuncionarios()
    {
        var utils = new Utils();
        Console.Clear();
        Console.WriteLine("Digite o primeiro nome do funcionario:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o sobrenome do funcionario:");
        string sobrenome = Console.ReadLine();
        Console.Write("Digite o telefone do funcionario:");
        string telefone = Console.ReadLine();
        Console.WriteLine("Digite o CPF do funcionario:");
        string cpf = Console.ReadLine();
        Console.WriteLine("Digite o cargo do funcionario:");
        string cargo = Console.ReadLine();
        Console.WriteLine("Digite o salario do funcionario:");
        double salario;

        if (double.TryParse(Console.ReadLine(), out salario) == false)
        {
            utils.Red();
            Console.WriteLine("Salario inválido! Tente novamente.");
            utils.Enter();
        }
        else
        {
            var funcionario = new Funcionario(nome, sobrenome, telefone, cpf, cargo, salario);
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
        Console.Clear();
        Console.WriteLine("O programa irá listar os funcionários.");
        Console.WriteLine("Verifique o ID do funcionário que deseja excluir.");
        utils.Enter();
        Listar();
        Console.WriteLine("Digite o Id do funcionário que deseja excluir:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            utils.Red();
            Console.WriteLine("Id inválido! Tente novamente.");
            utils.Enter();
        }
        else
        {
            CFuncionario controller = new CFuncionario();
            try
            {
                var excluir = controller.ObterPorId(id);
                controller.Excluir(excluir);
                utils.Green();
                Console.WriteLine("Funcionário excluído com sucesso!");
            }
            catch
            {
                utils.Red();
                Console.WriteLine("Id inválido! Tente novamente.");
            }
        }


        utils.Enter();
    }

    public void AtualizarFuncionarios()
    {
        var utils = new Utils();
        Console.Clear();
        Console.WriteLine("O programa irá listar os funcionários.");
        Console.WriteLine("Verifique o ID do funcionário que deseja atualizar.");
        utils.Enter();
        Listar();
        Console.WriteLine("Digite o Id do funcionário que deseja atualizar:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            utils.Red();
            Console.WriteLine("Id inválido! Tente novamente.");
            utils.Enter();
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
                Console.WriteLine("Digite o cargo do funcionario:");
                string cargo = Console.ReadLine();
                Console.WriteLine("Digite o salario do funcionario:");
                double salario;

                if (double.TryParse(Console.ReadLine(), out salario) == false)
                {
                    utils.Red();
                    Console.WriteLine("Salario inválido! Tente novamente.");
                    utils.Enter();
                }
                else
                {
                    atualizar.Nome = nome;
                    atualizar.SobreNome = sobrenome;
                    atualizar.Telefone = telefone;
                    atualizar.Cpf = cpf;
                    atualizar.Cargo = cargo;
                    atualizar.Salario = salario;
                    controller.Atualizar(atualizar);
                    utils.Green();
                    Console.WriteLine("Funcionário atualizado com sucesso!");
                    utils.Enter();
                }
            }
            catch
            {
                utils.Red();
                Console.WriteLine("Id inválido! Tente novamente.");
                utils.Enter();
            }
        }
    }
}


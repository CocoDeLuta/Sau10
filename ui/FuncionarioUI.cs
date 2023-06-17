//comandos relacionados aos funcionarios como adicionar, remover, editar e listar.
using Microsoft.Identity.Client;

public class FuncionarioUI
{


    public void MenuFuncionario()
    {

        //Menu Funcionario
        int opcao = 0;
        while (opcao != 5)
        {
            Console.Clear();
            Yellow();
            Console.WriteLine("MENU FUNCIONÁRIO");
            Console.WriteLine("");
            White();
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
                OpcaoInvalida();
            }
            else
            {
                switch (opcao)
                {
                    case 1:
                        Listar();
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
                        OpcaoInvalida();
                        break;
                }
            }


        }
    }

    public void Listar()
    {
        Console.Clear();
        CFuncionario func = new CFuncionario();
        List<Funcionario> funcionarios = func.ObterTodos();
        foreach (var item in funcionarios)
        {
            item.ToString();
        }
        Enter();
    }

    public void AdicionarFuncionarios()
    {
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
            Red();
            Console.WriteLine("Salario inválido! Tente novamente.");
            Enter();
        }
        else
        {
            var funcionario = new Funcionario(nome, sobrenome, telefone, cpf, cargo, salario);
            CFuncionario func = new CFuncionario();
            func.Inserir(funcionario);
            Green();
            Console.WriteLine("Funcionário cadastrado com sucesso!");
            Enter();
        }

    }

    public void RemoverFuncionarios()
    {
        Console.Clear();
        Console.WriteLine("O programa irá listar os funcionários.");
        Console.WriteLine("Verifique o ID do funcionário que deseja excluir.");
        Enter();
        Listar();
        Console.WriteLine("Digite o Id do funcionário que deseja excluir:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Red();
            Console.WriteLine("Id inválido! Tente novamente.");
            Enter();
        }
        else
        {
            CFuncionario func = new CFuncionario();
            try
            {
                var excluir = func.ObterPorId(id);
                func.Excluir(excluir);
                Green();
                Console.WriteLine("Funcionário excluído com sucesso!");
            }
            catch
            {
                Red();
                Console.WriteLine("Id inválido! Tente novamente.");
            }
        }


        Enter();
    }

    public void AtualizarFuncionarios(){
        Console.Clear();
        Console.WriteLine("O programa irá listar os funcionários.");
        Console.WriteLine("Verifique o ID do funcionário que deseja atualizar.");
        Enter();
        Listar();
        Console.WriteLine("Digite o Id do funcionário que deseja atualizar:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            Red();
            Console.WriteLine("Id inválido! Tente novamente.");
            Enter();
        }
        else
        {
            CFuncionario func = new CFuncionario();
            try
            {
                var atualizar = func.ObterPorId(id);
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
                    Red();
                    Console.WriteLine("Salario inválido! Tente novamente.");
                    Enter();
                }
                else
                {
                    atualizar.Nome = nome;
                    atualizar.SobreNome = sobrenome;
                    atualizar.Telefone = telefone;
                    atualizar.Cpf = cpf;
                    atualizar.Cargo = cargo;
                    atualizar.Salario = salario;
                    func.Atualizar(atualizar);
                    Green();
                    Console.WriteLine("Funcionário atualizado com sucesso!");
                    Enter();
                }
            }
            catch
            {
                Red();
                Console.WriteLine("Id inválido! Tente novamente.");
                Enter();
            }
        }
    }
    void Enter()
    {
        Cyan();
        Console.WriteLine("");
        Console.WriteLine("Pressione ENTER para continuar...");
        White();
        Console.ReadLine();
        Console.Clear();
    }

    void OpcaoInvalida()
    {
        Red();
        Console.WriteLine("Opção inválida!");
        Console.WriteLine("Tente novamente.");
        Enter();
        White();
    }

    void Red()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    void White()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }

    void Green()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }

    void Cyan()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    void Yellow()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }

}


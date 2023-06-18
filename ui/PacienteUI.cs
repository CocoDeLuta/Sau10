//Comandos relacionados aos pacientes, como adicionar, remover, editar e listar.
using ConsoleTables;

public class PacienteUI
{
    public void MenuPaciente()
    {
        //Menu Funcionario
        var utils = new Utils();
        int opcao = 0;
        while (opcao != 5)
        {
            Console.Clear();
            utils.Yellow();
            Console.WriteLine("MENU PACIENTE");
            Console.WriteLine("");
            utils.White();
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Listar pacientes");
            Console.WriteLine("2 - Cadastrar pacientes");
            Console.WriteLine("3 - Remover registro do paciente");
            Console.WriteLine("4 - Atualizar registro do paciente");
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
                        CadastrarPaciente();
                        break;
                    case 3:
                        RemoverPaciente();
                        break;
                    case 4:
                        AtualizarPaciente();
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

    void Listar()
    {
        var utils = new Utils();
        Console.Clear();
        CPaciente controller = new CPaciente();
        List<Paciente> lista = controller.ObterTodos();
        var tabela = new ConsoleTable("ID", "Nome", "Sobrenome", "Telefone", "CPF", "Nascimento");

        foreach (var item in lista)
        {
            tabela.AddRow(Convert.ToString(item.Id),
            item.Nome,
            item.SobreNome,
            item.Telefone,
            item.Cpf,
            Convert.ToString(item.DataNascimento));
        }
        tabela.Write();

    }

    void CadastrarPaciente()
    {

        var controller = new CPaciente();
        var utils = new Utils();
        Console.Clear();

        utils.Yellow();
        Console.WriteLine("CADASTRAR PACIENTE");
        Console.WriteLine("");
        utils.White();
        Console.WriteLine("Digite o primeiro nome do paciente:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o sobrenome do paciente:");
        string sobrenome = Console.ReadLine();
        Console.WriteLine("Digite o telefone do paciente:");
        string telefone = Console.ReadLine();
        Console.WriteLine("Digite o CPF do paciente:");
        string cpf = Console.ReadLine();
        Console.WriteLine("Digite a data de nascimento do paciente (YYYY-MM-DD):");
        DateOnly dataNascimento;
        if (DateOnly.TryParse(Console.ReadLine(), out dataNascimento) == false)
        {
            utils.Red();
            Console.WriteLine("Data inválida, tente novamente");
            utils.Enter();
        }
        else
        {
            try
            {
                Paciente paciente = new Paciente(nome, sobrenome, telefone, cpf, dataNascimento);
                controller.Inserir(paciente);

                utils.Green();
                Console.WriteLine("Paciente cadastrado com sucesso!");
                utils.Enter();
            }
            catch (Exception e)
            {
                utils.Red();
                Console.WriteLine("Erro ao cadastrar paciente, tente novamente");
                utils.Enter();
            }
        }
    }

    void RemoverPaciente()
    {
        var controller = new CPaciente();
        var utils = new Utils();
        Console.Clear();

        utils.Yellow();
        Console.WriteLine("REMOVER PACIENTE");
        Console.WriteLine("");
        utils.White();
        Console.WriteLine("O programa vai listar os pacientes cadastrados.");
        Console.WriteLine("Verifique o ID do paciente que deseja excluir:");
        utils.Enter();

        Listar();

        Console.WriteLine("Digite o ID do paciente que deseja excluir:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            utils.Red();
            Console.WriteLine("Id inválido! Tente novamente.");
            utils.Enter();
        }
        else
        {
            //Verificando se o paciente existe
            var paciente = controller.ObterPorId(id);
            if (paciente == null)
            {
                utils.Red();
                Console.WriteLine("Paciente não encontrado!");
                utils.Enter();
                return;
            }

            try
            {
                var excluir = controller.ObterPorId(id);
                controller.Excluir(excluir);

                utils.Green();
                Console.WriteLine("Paciente removido com sucesso!");
                utils.Enter();
            }
            catch (Exception e)
            {
                utils.Red();
                Console.WriteLine("Erro ao remover paciente, tente novamente");
                utils.Enter();
            }
        }


    }

    void AtualizarPaciente()
    {
        var utils = new Utils();
        var controller = new CPaciente();
        Console.Clear();

        utils.Yellow();
        Console.WriteLine("ATUALIZAR PACIENTE");
        Console.WriteLine("");
        utils.White();
        Console.WriteLine("O programa vai listar os pacientes cadastrados.");
        Console.WriteLine("Verifique o ID do paciente que deseja atualizar:");
        utils.Enter();

        Listar();

        Console.WriteLine("Digite o ID do paciente que deseja atualizar:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            utils.Red();
            Console.WriteLine("Id inválido! Tente novamente.");
            utils.Enter();
        }
        else
        {
            try
            {
                //Verificando se o paciente existe
                var paciente = controller.ObterPorId(id);
                if (paciente == null)
                {
                    utils.Red();
                    Console.WriteLine("Paciente não encontrado!");
                    utils.Enter();
                    return;
                }

                Console.WriteLine("Digite o primeiro nome do paciente:");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite o sobrenome do paciente:");
                string sobrenome = Console.ReadLine();
                Console.WriteLine("Digite o telefone do paciente:");
                string telefone = Console.ReadLine();
                Console.WriteLine("Digite o CPF do paciente:");
                string cpf = Console.ReadLine();
                Console.WriteLine("Digite a data de nascimento do paciente (YYYY-MM-DD):");
                DateOnly dataNascimento;
                if (DateOnly.TryParse(Console.ReadLine(), out dataNascimento) == false)
                {
                    utils.Red();
                    Console.WriteLine("Data inválida! Tente novamente.");
                    utils.Enter();
                }
                else
                {
                    paciente.Nome = nome;
                    paciente.SobreNome = sobrenome;
                    paciente.Telefone = telefone;
                    paciente.Cpf = cpf;
                    paciente.DataNascimento = dataNascimento;

                    controller.Atualizar(paciente);

                    utils.Green();
                    Console.WriteLine("Paciente atualizado com sucesso!");
                    utils.Enter();

                }
            }
            catch (Exception e)
            {
                utils.Red();
                Console.WriteLine("Erro ao atualizar paciente, tente novamente");
                utils.Enter();
            }
        }
    }
}
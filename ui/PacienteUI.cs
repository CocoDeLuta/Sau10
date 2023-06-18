//Comandos relacionados aos pacientes, como adicionar, remover, editar e listar.
using ConsoleTables;

public class PacienteUI
{
    public void MenuPaciente(Funcionario user)
    {
        //Menu Funcionario
        var utils = new Utils();
        int opcao = 999;
        while (opcao != 0)
        {
            utils.TituloMenu("MENU PACIENTE");

            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Listar pacientes");
            Console.WriteLine("2 - Cadastrar pacientes");
            Console.WriteLine("3 - Atualizar registro do paciente");
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
                        CadastrarPaciente(user);
                        break;
                    case 3:
                        AtualizarPaciente(user);
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

    public void CadastrarPaciente(Funcionario user)
    {

        var controller = new CPaciente();
        var utils = new Utils();

        if (!utils.Permissao(user.Permissao, 1))
        {
            return;
        }

        utils.TituloMenu("CADASTRAR PACIENTE");

        Console.WriteLine("Digite o primeiro nome do paciente:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o sobrenome do paciente:");
        string sobrenome = Console.ReadLine();
        Console.WriteLine("Digite o telefone do paciente:");
        string telefone = Console.ReadLine();
        Console.WriteLine("Digite o CPF do paciente:");
        string cpf = Console.ReadLine();
        Console.WriteLine("Digite a data de nascimento do paciente (aaaa-mm-dd).");
        Console.WriteLine("Exemplo: 1990-01-01");
        DateOnly dataNascimento;

        if (DateOnly.TryParse(Console.ReadLine(), out dataNascimento) == false)
        {
            utils.ErrorMessage("Data inválida!");
        }

        try
        {
            Paciente paciente = new Paciente(nome, sobrenome, telefone, cpf, dataNascimento);
            controller.Inserir(paciente);

            utils.SuccessMessage("Paciente cadastrado com sucesso!");
        }
        catch (Exception e)
        {
            utils.ErrorMessage("Erro ao cadastrar paciente.");
            return;
        }
    }

    /*void RemoverPaciente(Funcionario user)
    {
        var controller = new CPaciente();
        var utils = new Utils();

        if (!utils.Permissao(user.Permissao, 1))
        {
            return;
        }

        utils.TituloMenu("REMOVER PACIENTE");

        Console.WriteLine("O programa vai listar os pacientes cadastrados.");
        Console.WriteLine("Verifique o ID do paciente que deseja excluir:");
        utils.Enter();

        Listar();

        Console.WriteLine("Digite o ID do paciente que deseja excluir:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            utils.ErrorMessage("ID inválido!");
        }
        else
        {
            //Verificando se o paciente existe
            var paciente = controller.ObterPorId(id);
            if (paciente == null)
            {
                utils.ErrorMessage("Paciente não encontrado!");
                return;
            }

            try
            {
                var excluir = controller.ObterPorId(id);
                controller.Excluir(excluir);

                utils.SuccessMessage("Paciente removido com sucesso!");
            }
            catch (Exception e)
            {
                utils.ErrorMessage("Erro ao remover paciente.");
                return;
            }
        }
    }*/

    void AtualizarPaciente(Funcionario user)
    {
        var utils = new Utils();
        var controller = new CPaciente();

        if (!utils.Permissao(user.Permissao, 1))
        {
            return;
        }

        utils.TituloMenu("ATUALIZAR PACIENTE");

        Console.WriteLine("O programa vai listar os pacientes cadastrados.");
        Console.WriteLine("Verifique o ID do paciente que deseja atualizar:");
        utils.Enter();

        Listar();

        Console.WriteLine("Digite o ID do paciente que deseja atualizar:");
        int id;
        if (int.TryParse(Console.ReadLine(), out id) == false)
        {
            utils.ErrorMessage("Id inválido!");
            return;
        }

        try
        {
            //Verificando se o paciente existe
            var paciente = controller.ObterPorId(id);
            if (paciente == null)
            {
                utils.ErrorMessage("Paciente não encontrado!");
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
                utils.ErrorMessage("Data inválida!");
                return;
            }
            paciente.Nome = nome;
            paciente.SobreNome = sobrenome;
            paciente.Telefone = telefone;
            paciente.Cpf = cpf;
            paciente.DataNascimento = dataNascimento;

            controller.Atualizar(paciente);
            utils.SuccessMessage("Paciente atualizado com sucesso!");
        }
        catch (Exception e)
        {
            utils.ErrorMessage("Erro ao atualizar o paciente!");
            return;
        }
    }
}
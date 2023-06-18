using ConsoleTables;

public class CargoUI
{
    public void MenuCargo(Funcionario user)
    {
        var utils = new Utils();

        int opcao = 155;
        while (opcao != 0)
        {
            utils.TituloMenu("MENU CARGO");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Listar Cargo");
            Console.WriteLine("2 - Adicionar Cargo");
            Console.WriteLine("3 - Remover Cargo");
            Console.WriteLine("4 - Atualizar Cargo");
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
                        AdicionarCargo(user);
                        break;
                    case 3:
                        RemoverCargo(user);
                        break;
                    case 4:
                        AtualizarCargo(user);
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
        var controller = new CCargo();
        var utils = new Utils();
        Console.Clear();

        var tabela = new ConsoleTable("ID", "Cargo");
        List<Cargo> lista = controller.ObterTodos();
        foreach (var item in lista)
        {
            tabela.AddRow(Convert.ToString(item.Id),
            item.Nome);
        }
        tabela.Write();
    }

    void AdicionarCargo(Funcionario user)
    {
        var controller = new CCargo();
        var utils = new Utils();

        if (!utils.Permissao(user.Permissao, 3))
        {
            return;
        }

        utils.TituloMenu("ADICIONAR CARGO");

        Console.Write("Digite o nome do cargo:");
        string nome = Console.ReadLine();
        Cargo cargo = new Cargo(nome);

        //Verifica se o cargo já existe
        var cargoExistente = controller.ObterPorNome(nome);
        if (cargoExistente != null)
        {
            utils.ErrorMessage("Cargo já existe!");
            return;
        }

        try
        {
            controller.Inserir(cargo);
            utils.SuccessMessage("Cargo adicionado com sucesso!");
        }
        catch (Exception e)
        {
            utils.ErrorMessage("Erro ao adicionar cargo.");
        }
    }

    void RemoverCargo(Funcionario user)
    {
        var utils = new Utils();
        var controller = new CCargo();

        if (!utils.Permissao(user.Permissao, 3))
        {
            return;
        }

        utils.TituloMenu("REMOVER CARGO");

        Console.Write("O programa irá listar os cargos cadastrados.");
        Console.WriteLine("Verifique o ID do cargo que deseja remover.");
        Listar();
        Console.WriteLine("Digite o ID do cargo que deseja remover:");
        if (int.TryParse(Console.ReadLine(), out int id) == false)
        {
            utils.ErrorMessage("Opção inválida!");
            return;
        }

        //Verifica se o cargo existe
        var cargo = controller.ObterPorId(id);
        if (cargo == null)
        {
            utils.ErrorMessage("Cargo não encontrado!");
            return;
        }

        try
        {
            controller.Excluir(cargo);
            utils.SuccessMessage("Cargo removido com sucesso!");
        }
        catch (Exception e)
        {
            utils.Red();
            Console.WriteLine("Erro ao remover cargo, tente novamente.");
            utils.White();
        }


    }

    void AtualizarCargo(Funcionario user)
    {
        var utils = new Utils();
        var controller = new CCargo();

        if (!utils.Permissao(user.Permissao, 3))
        {
            return;
        }

        utils.TituloMenu("ATUALIZAR CARGO");

        Console.Write("O programa irá listar os cargos cadastrados.");
        Console.WriteLine("Verifique o ID do cargo que deseja atualizar.");
        Listar();
        Console.WriteLine("");
        Console.WriteLine("Digite o ID do cargo que deseja atualizar:");
        if (int.TryParse(Console.ReadLine(), out int id) == false)
        {
            utils.ErrorMessage("ID inválido!");
            return;
        }

        //Verifica se o cargo existe
        var cargo = controller.ObterPorId(id);
        if (cargo == null)
        {
            utils.ErrorMessage("Cargo não encontrado!");
            return;
        }

        Console.WriteLine("Digite o novo nome do cargo:");
        string nome = Console.ReadLine();
        try
        {
            cargo.Nome = nome;
            controller.Atualizar(cargo);
            utils.SuccessMessage("Cargo atualizado com sucesso!");
        }
        catch (Exception e)
        {
            utils.ErrorMessage("Erro ao atualizar o cargo.");
        }
    }

}
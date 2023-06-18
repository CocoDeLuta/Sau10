//comandos relacionados aos internamentos, como adicionar, remover, editar e listar.
using ConsoleTables;

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
        var utils = new Utils();
        var controller = new CInternamento();

        utils.TituloMenu("LISTAR INTERNAMENTOS");

        List<Internamento> lista = controller.ObterTodos();
        if (lista.Count == 0)
        {
            utils.ErrorMessage("Nenhum internamento encontrado!");
            return;
        }

        var tabela = new ConsoleTable("ID", "Paciente", "Motivo", "Data Entrada", "Data Saida", "Quarto", "Funcionario");
        foreach (Internamento internamento in lista)
        {
            var pacienteController = new CPaciente();
            var funcController = new CFuncionario();

            var paciente = pacienteController.ObterPorId(internamento.PacienteId);
            var funcionario = funcController.ObterPorId(internamento.FuncionarioId);

            tabela.AddRow(
                internamento.Id,
                paciente.ToStringNomeCompleto(),
                internamento.Motivo,
                internamento.DataEntrada,
                internamento.Status(),
                Convert.ToString(internamento.NumeroQuarto),
                funcionario.ToStringNomeCompleto()
            );
        }
        tabela.Write();
    }

    void NovoInternamento(Funcionario user)
    {
        var utils = new Utils();
        var controller = new CInternamento();
        var pacienteUI = new PacienteUI();

        if (!utils.Permissao(user.Permissao, 1))
        {
            return;
        }

        utils.TituloMenu("NOVO INTERNAMENTO");

        Console.WriteLine("O programa exibirá os pacientes cadastrados.");
        Console.WriteLine("Verifique o ID do paciente que deseja internar.");
        Console.WriteLine("Caso o paciente não esteja cadastrado, digite uma letra para voltar ao menu anterior.");
        Console.WriteLine("E então cadastre o paciente no menu Gerenciar Pacientes.");
        utils.Enter();
        pacienteUI.Listar();
        Console.WriteLine("Digite o ID do paciente (ou uma letra para sair):");
        if (int.TryParse(Console.ReadLine(), out int pacienteId) == false)
        {
            utils.ErrorMessage("ID inválido!");
            return;
        }

        var pacienteController = new CPaciente();
        var paciente = pacienteController.ObterPorId(pacienteId);
        if (paciente == null)
        {
            utils.ErrorMessage("Paciente não encontrado!");
            return;
        }

        //verificar se o paciente ainda está internado
        List<Internamento> lista = controller.ObterTodos();
        foreach (Internamento internamento in lista)
        {
            if (internamento.PacienteId == pacienteId && internamento.Status() == "Internado")
            {
                utils.ErrorMessage("Paciente já está internado!");
                return;
            }
        }

        Console.WriteLine("Digite o número do quarto:");
        if (int.TryParse(Console.ReadLine(), out int quarto) == false)
        {
            utils.ErrorMessage("Número de quarto inválido!");
            return;
        }

        //verificar se o quarto ja esta ocupado
        foreach (Internamento internamento in lista)
        {
            if (internamento.NumeroQuarto == quarto && internamento.Status() == "Internado")
            {
                utils.ErrorMessage("Quarto já ocupado!");
                return;
            }
        }

        Console.WriteLine("Digite a data de entrada (aaaa-mm-dd).");
        Console.WriteLine("Exemplo: 2020-01-01:");
        if (DateOnly.TryParse(Console.ReadLine(), out DateOnly dataEntrada) == false)
        {
            utils.ErrorMessage("Data inválida!");
            return;
        }

        Console.WriteLine("Digite o motivo do internamento:");
        string motivo = Console.ReadLine();
        if (motivo == null)
        {
            utils.ErrorMessage("O internamento precisa de um motivo!");
            return;
        }
        try
        {
            Internamento internamento = new Internamento(dataEntrada, motivo, pacienteId, user.Id, quarto);
            controller.Inserir(internamento);
            utils.SuccessMessage("Internamento cadastrado com sucesso!");
            return;
        }
        catch (Exception ex)
        {
            utils.ErrorMessage("Erro ao cadastrar internamento!");
            return;
        }
    }

    void AtualizarInternamento(Funcionario user)
    {
        var utils = new Utils();
        var controller = new CInternamento();

        if (!utils.Permissao(user.Permissao, 1))
        {
            return;
        }

        utils.TituloMenu("ATUALIZAR INTERNAMENTO");

        Console.WriteLine("O programa exibirá os internamentos cadastrados.");
        Console.WriteLine("Verifique o ID do internamento que deseja atualizar.");
        Console.WriteLine("Caso o internamento não esteja cadastrado, digite uma letra para voltar ao menu anterior.");
        utils.Enter();
        Listar();

        Console.WriteLine("Digite o ID do internamento (ou uma letra para sair):");
        if (int.TryParse(Console.ReadLine(), out int internamentoId) == false)
        {
            utils.ErrorMessage("ID inválido!");
            return;
        }

        var internamento = controller.ObterPorId(internamentoId);
        if (internamento == null)
        {
            utils.ErrorMessage("Internamento não encontrado!");
            return;
        }

        Console.WriteLine("O paciente recebeu alta?");
        Console.WriteLine("1 - Sim");
        Console.WriteLine("2 - Não");
        if (int.TryParse(Console.ReadLine(), out int opcao) == false)
        {
            utils.ErrorMessage("Opção inválida!");
            return;
        }

        if (opcao == 1)
        {
            Console.WriteLine("Digite a data de saída (aaaa-mm-dd).");
            Console.WriteLine("Exemplo: 2020-01-01:");
            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly dataSaida) == false)
            {
                utils.ErrorMessage("Data inválida!");
                return;
            }
            internamento.DataSaida = dataSaida;
            try
            {
                controller.Atualizar(internamento);
                utils.SuccessMessage("Internamento atualizado com sucesso!");
                return;
            }
            catch (Exception ex)
            {
                utils.ErrorMessage("Erro ao atualizar internamento!");
                return;
            }
        }
        else if (opcao == 2)
        {
            Console.WriteLine("Digite o número do quarto:");
            if (int.TryParse(Console.ReadLine(), out int quarto) == false)
            {
                utils.ErrorMessage("Número de quarto inválido!");
                return;
            }

            //verificar se o quarto ja esta ocupado
            List<Internamento> lista = controller.ObterTodos();
            foreach (Internamento i in lista)
            {
                if (i.NumeroQuarto == quarto && internamento.Status() == "Internado")
                {
                    utils.ErrorMessage("Quarto já ocupado!");
                    return;
                }
            }

            Console.WriteLine("Digite a data de entrada (aaaa/mm/dd).");
            Console.WriteLine("Exemplo: 2020/01/01:");
            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly dataEntrada) == false)
            {
                utils.ErrorMessage("Data inválida!");
                return;
            }

            Console.WriteLine("Digite o motivo do internamento:");
            string motivo = Console.ReadLine();
            if (motivo == null)
            {
                utils.ErrorMessage("O internamento precisa de um motivo!");
                return;
            }
            try
            {
                internamento.DataEntrada = dataEntrada;
                internamento.Motivo = motivo;
                internamento.NumeroQuarto = quarto;
                controller.Atualizar(internamento);
                utils.SuccessMessage("Internamento atualizado com sucesso!");
                return;
            }
            catch (Exception ex)
            {
                utils.ErrorMessage("Erro ao atualizar internamento!");
                return;
            }
        }
        else
        {
            utils.ErrorMessage("Opção inválida!");
            return;
        }
    }
}
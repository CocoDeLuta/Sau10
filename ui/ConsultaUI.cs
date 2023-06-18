using ConsoleTables;
using Microsoft.EntityFrameworkCore;

public class ConsultaUI
{
    public void MenuConsulta(Funcionario user)
    {
        //Menu Funcionario
        var utils = new Utils();
        int opcao = 999;
        while (opcao != 0)
        {
            utils.TituloMenu("MENU CONSULTA");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Listar Consultas");
            Console.WriteLine("2 - Nova Consulta");
            Console.WriteLine("3 - Atualizar Consultas");
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
                        NovaConsulta(user);
                        break;
                    case 3:
                        AtualizarConsulta(user);
                        break;
                    case 0:
                        //Voltando para o menu anterior
                        break;
                    default:
                        utils.ErrorMessage("Opção inválida!");
                        break;
                }
            }
        }

    }

    void Listar()
    {
        var controller = new CConsulta();
        var funcionario = new CFuncionario();
        var Cpaciente = new CPaciente();
        var utils = new Utils();
        Console.Clear();

        utils.TituloMenu("LISTAR CONSULTAS");
        List<Consulta> consultas;
        try
        {
            consultas = controller.ObterTodos();
        }
        catch (Exception ex)
        {
            utils.ErrorMessage("Nenhuma consulta encontrada ");
            return;
        }

        var tabela = new ConsoleTable("ID", "Data", "Descrição", "Paciente", "Médico");
        foreach (var consulta in consultas)
        {
            var medico = funcionario.ObterPorId(consulta.MedicoId);
            var paciente = Cpaciente.ObterPorId(consulta.PacienteId);
            tabela.AddRow(
            consulta.Id,
            Convert.ToString(consulta.Data),
            consulta.Descricao,
            paciente.ToStringNomeCompleto(),
            medico.ToStringNomeCompleto()
            );

        }
        tabela.Write();
    }

    void NovaConsulta(Funcionario user)
    {
        var utils = new Utils();

        // Verifica se o usuário tem permissão para acessar o menu
        if (!utils.Permissao(user.Permissao, 2))
        {
            return;
        }

        var controller = new CConsulta();

        utils.TituloMenu("NOVA CONSULTA");

        Console.Write("Digite a data da consulta (formato ano-mes-dia): ");
        if (DateOnly.TryParse(Console.ReadLine(), out DateOnly data) == false)
        {
            utils.ErrorMessage("Data inválida!");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O programa exibirá os pacientes cadastrados.");
        Console.WriteLine("Verifique o ID do paciente que está sendo consultado. ");
        Console.WriteLine("Caso o paciente não esteja cadastrado, digite uma letra para voltar ao menu anterior.");
        utils.Enter();
        var PacienteUI = new PacienteUI();
        PacienteUI.Listar();
        Console.WriteLine("Digite o ID do paciente para continuar ou uma letra para voltar ao menu:");
        if (int.TryParse(Console.ReadLine(), out int pacienteId) == false)
        {
            utils.ErrorMessage("ID inválido!");
            return;
        }

        // Verifica se o paciente existe
        var controllerPaciente = new CPaciente();
        var existePaciente = controllerPaciente.ObterPorId(pacienteId);
        if (existePaciente == null)
        {
            utils.ErrorMessage("Paciente não encontrado!");
            return;
        }


        Console.WriteLine("");
        Console.WriteLine("Descreva como foi a consulta, observações, etc:");
        string descricao = Console.ReadLine();

        try
        {
            var consulta = new Consulta(data, descricao, existePaciente.Id, 5);
            controller.Inserir(consulta);
            utils.SuccessMessage("Consulta cadastrada com sucesso!");
            return;
        }
        catch (Exception ex)
        {
            utils.ErrorMessage("Erro ao cadastrar consulta: " + ex.Message);
            return;
        }

    }


    void AtualizarConsulta(Funcionario user)
    {
        var utils = new Utils();
        var controller = new CConsulta();

        if (!utils.Permissao(user.Permissao, 2))
        {
            return;
        }

        utils.TituloMenu("ATUALIZAR CONSULTA");

        Console.WriteLine("O programa exibirá as consultas cadastradas.");
        Console.WriteLine("Verifique o ID da consulta que deseja atualizar. ");
        utils.Enter();
        Listar();
        Console.WriteLine("Digite o ID da consulta que deseja atualizar:");
        if (int.TryParse(Console.ReadLine(), out int consultaId) == false)
        {
            utils.ErrorMessage("ID inválido!");
            return;
        }

        // Verifica se a consulta existe
        var existeConsulta = controller.ObterPorId(consultaId);
        if (existeConsulta == null)
        {
            utils.ErrorMessage("Consulta não encontrada!");
            return;
        }

        Console.WriteLine("Digite a data da consulta (formato ano-mes-dia): ");
        if (DateOnly.TryParse(Console.ReadLine(), out DateOnly data) == false)
        {
            utils.ErrorMessage("Data inválida!");
            return;
        }

        Console.WriteLine("");
        Console.WriteLine("Descreva como foi a consulta, observações, etc:");
        string descricao = Console.ReadLine();

        try
        {
            existeConsulta.Data = data;
            existeConsulta.Descricao = descricao;
            controller.Atualizar(existeConsulta);
            utils.SuccessMessage("Consulta atualizada com sucesso!");
            return;
        }
        catch (Exception ex)
        {
            utils.ErrorMessage("Erro ao atualizar consulta");
            return;
        }

    }
}
using Microsoft.EntityFrameworkCore;

public class ConsultaUI
{
    public void MenuConsulta()
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
            Console.WriteLine("3 - Remover Consultas");
            Console.WriteLine("4 - Atualizar Consultas");
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
                        break;
                    case 2:
                        NovaConsulta();
                        break;
                    case 3:
                        RemoverConsulta();
                        break;
                    case 4:
                        AtualizarConsulta();
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

    void Listar()
    {
        var utils = new Utils();
        var context = new AppDbContext();
        Console.Clear();
        CConsulta consulta = new CConsulta();
        CPaciente controllerPaciente = new CPaciente();
        List<Consulta> lista = consulta.ObterTodos();
        foreach (Consulta item in lista)
        {
            int pacienteId = consulta.ObterIdPaciente(item.Id, context);
            Console.WriteLine("Id: " + item.Id);
            Console.WriteLine("Id: " + pacienteId);
            try
            {
                var paciente = controllerPaciente.ObterPorId(-pacienteId);
                item.ToString();
                paciente.ToStringNomeCompleto();
            }
            catch (Exception e)
            {
                utils.Red();
                Console.WriteLine("Erro ao obter paciente da consulta: " + e.Message);
                utils.White();
            }
            //executar comandos sql para obter o id do paciente da tabela consulta



        }
        utils.Enter();
    }

    void NovaConsulta()
    {
        var controller = new CConsulta();
        var utils = new Utils();

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

        var PacienteUI = new PacienteUI();
        PacienteUI.Listar();
        Console.WriteLine("Digite o ID do paciente para continuar ou uma letra para voltar ao menu:");
        if (int.TryParse(Console.ReadLine(), out int pacienteId) == false)
        {
            utils.ErrorMessage("ID inválido!");
            return;
        }

        Console.WriteLine("");
        Console.WriteLine("Descreva como foi a consulta, observações, etc:");
        string descricao = Console.ReadLine();

        var consulta = new Consulta(data, descricao);
        controller.Inserir(consulta);
    }

    void RemoverConsulta()
    {
        var utils = new Utils();
    }

    void AtualizarConsulta()
    {
        var utils = new Utils();
    }
}
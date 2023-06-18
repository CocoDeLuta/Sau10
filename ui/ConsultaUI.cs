using Microsoft.EntityFrameworkCore;

public class ConsultaUI
{
    public void MenuConsulta()
    {
        //Menu Funcionario
        var utils = new Utils();
        int opcao = 0;
        while (opcao != 5)
        {
            Console.Clear();
            utils.Yellow();
            Console.WriteLine("MENU Consulta");
            Console.WriteLine("");
            utils.White();
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Listar Consultas");
            Console.WriteLine("2 - Nova Consulta");
            Console.WriteLine("3 - Remover Consultas");
            Console.WriteLine("4 - Atualizar Consultas");
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
        CConsulta consulta = new CConsulta();
        CPaciente controllerPaciente = new CPaciente();
        List<Consulta> lista = consulta.ObterTodos();
        foreach (Consulta item in lista)
        {
            var context = new AppDbContext();
            var pacienteId = context.Database.ExecuteSqlRaw(
                "SELECT PacienteId FROM consultas WHERE Id = " + item.Id);
            Console.WriteLine("Id: " + item.Id);
            Console.WriteLine("Id: " + -pacienteId);
            try
            {
                var paciente = controllerPaciente.ObterPorId(pacienteId);
                paciente.ToString();
                item.ToString();
                //paciente.ToStringNomeCompleto();
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
        Console.Clear();

        utils.Yellow();
        Console.WriteLine("CADASTRAR CONSULTA");
        utils.White();
        Console.WriteLine("");
        
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
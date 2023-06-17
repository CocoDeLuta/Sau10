using Microsoft.EntityFrameworkCore;


var ConsultaUI = new ConsultaUI();
var FuncionarioUI = new FuncionarioUI();
var InternamentoUI = new InternamentoUI();
var PacienteUI = new PacienteUI();


Console.Clear();
Console.WriteLine("Seja bem vindo ao Sau10!");
Console.WriteLine("");
Console.WriteLine("O Sau10 tem funcionalidades para gerenciar clinicas e hospitais, como:");
Console.WriteLine("Gerenciar pacientes, internamentos, funcionarios e consultas.");
Console.WriteLine("");
Enter();

//Menu principal
int opcao = 0;
while (opcao != 5)
{
    Console.Clear();
    Yellow();
    Console.WriteLine("MENU PRINCIPAL");
    Console.WriteLine("");
    White();
    Console.WriteLine("Selecione uma opção:");
    Console.WriteLine("1 - Gerenciar pacientes");
    Console.WriteLine("2 - Gerenciar internamentos");
    Console.WriteLine("3 - Gerenciar funcionarios");
    Console.WriteLine("4 - Gerenciar consultas");
    Console.WriteLine("5 - Sair");
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
                //GerenciarPacientes();
                opcao = 0;
                break;
            case 2:
                //GerenciarInternamentos();
                opcao = 0;
                break;
            case 3:
                FuncionarioUI.MenuFuncionario();
                opcao = 0;
                break;
            case 4:
                //GerenciarConsultas();
                opcao = 0;
                break;
            case 5:
                Console.WriteLine("Obrigado por usar o Sau10!");
                break;
            default:
                OpcaoInvalida();
                break;
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

//mudar a cor do texto para vermelho
void Red()
{
    Console.ForegroundColor = ConsoleColor.Red;
}

//mudar a cor do texto para branco 
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
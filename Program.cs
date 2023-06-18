using Microsoft.EntityFrameworkCore;

var utils = new Utils();
var menu = new Menus();

Console.Clear();
Console.WriteLine("Seja bem vindo ao Sau10!");
Console.WriteLine("");
Console.WriteLine("O Sau10 tem funcionalidades para gerenciar clinicas e hospitais, como:");
Console.WriteLine("Gerenciar pacientes, internamentos, funcionarios e consultas.");
Console.WriteLine("");

utils.Enter();

//Menu inicial
int opcao = 9;
while (opcao != 0)
{
    utils.TituloMenu("SAU10");

    Console.WriteLine("Para começar a usar o Sau10, primeiro efetue o login.");
    Console.WriteLine("Caso não possua um usuário, entre em contato com um administrador.");
    Console.WriteLine("Selecione uma opção:");
    Console.WriteLine("1 - Login");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("");
    Console.Write("Opção: ");
    if (int.TryParse(Console.ReadLine(), out opcao) == false)
    {
        utils.ErrorMessage("Opção inválida! Tente novamente.");
        opcao = 999;
    }
    else
    {
        switch (opcao)
        {
            case 1:
                menu.Login();
                opcao = 999;
                break;
            case 0:
                utils.Cyan();
                Console.WriteLine("Obrigado por usar o Sau10!");
                utils.White();
                break;
            default:
                utils.ErrorMessage("Opção inválida!");
                opcao = 999;
                break;
        }
    }
}


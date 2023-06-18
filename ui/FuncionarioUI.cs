//comandos relacionados aos funcionarios como adicionar, remover, editar e listar.
using System.Runtime.Intrinsics.X86;
using ConsoleTables;
using Microsoft.Identity.Client;

public class FuncionarioUI
{
    public void MenuFuncionario(Funcionario user)
    {

        //Menu Funcionario
        var utils = new Utils();
        int opcao = 999;
        while (opcao != 0)
        {
            utils.TituloMenu("MENU FUNCIONARIO");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Listar Funcionario");
            Console.WriteLine("2 - Cadastrar Funcionario");
            Console.WriteLine("3 - Atualizar Funcionario");
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
                        AdicionarFuncionarios(user);
                        break;
                    case 3:
                        AtualizarFuncionarios(user);
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
        CFuncionario controller = new CFuncionario();
        List<Funcionario> funcionarios = controller.ObterTodos();

        var tabela = new ConsoleTable("ID", "Nome", "Sobrenome", "Telefone", "CPF", "Cargo", "Salario", "Ativo", "Nível de Acesso");
        foreach (var item in funcionarios)
        {
            var cargoController = new CCargo();
            var cargo = cargoController.ObterPorId(item.CargoId);
            string atv;
            if (item.Ativo)
            {
                atv = "Sim";
            }
            else
            {
                atv = "Não";
            }

            tabela.AddRow(Convert.ToString(item.Id),
            item.Nome,
            item.SobreNome,
            item.Telefone,
            item.Cpf,
            cargo.Nome,
            Convert.ToString(item.Salario),
            atv,
            item.NivelAcesso()
            );
        }
        tabela.Write();
    }

    public void AdicionarFuncionarios(Funcionario user)
    {
        var utils = new Utils();

        //Apenas adms podem acessar este menu, entao permissao = 3
        if (!utils.Permissao(user.Permissao, 3))
        {
            return;
        }

        utils.TituloMenu("CADASTRAR FUNCIONARIO");

        Console.WriteLine("Digite o primeiro nome do funcionario:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o sobrenome do funcionario:");
        string sobrenome = Console.ReadLine();
        Console.Write("Digite o telefone do funcionario:");
        string telefone = Console.ReadLine();
        Console.WriteLine("Digite o CPF do funcionario:");
        string cpf = Console.ReadLine();

        Console.WriteLine("");
        Console.WriteLine("Agora programa irá listar os cargos.");
        Console.WriteLine("Verifique o ID do cargo que deseja atualizar.");
        utils.Enter();

        var CargoUI = new CargoUI();
        CargoUI.Listar();
        Console.WriteLine("Digite o ID cargo do funcionario:");

        if (int.TryParse(Console.ReadLine(), out int cargoId) == false)
        {
            utils.ErrorMessage("ID inválido!");
            return;
        }

        //Verificar se o cargo existe
        var cargoController = new CCargo();
        var cargo = cargoController.ObterPorId(cargoId);
        if (cargo == null)
        {
            utils.ErrorMessage("Cargo não encontrado!");
            return;
        }

        Console.WriteLine("Digite o salario do funcionario:");
        double salario;

        if (double.TryParse(Console.ReadLine(), out salario) == false)
        {
            utils.ErrorMessage("Salario inválido!");
            return;
        }

        Console.WriteLine("Digite o nível de acesso do funcionario:");
        Console.WriteLine("0 - Usuarios gerais");
        Console.WriteLine("1 - Enfermeiros");
        Console.WriteLine("2 - Médicos");
        Console.WriteLine("3 - Administradores");
        int nivelAcesso;
        if (int.TryParse(Console.ReadLine(), out nivelAcesso) == false)
        {
            utils.ErrorMessage("Opção inválida!");
            return;
        }

        Console.Write("Digite o nome de usuário para login:");
        string login = Console.ReadLine();
        Console.WriteLine("Digite a senha para login:");
        string senha = Console.ReadLine();

        var funcionario = new Funcionario(login, senha, nivelAcesso, nome, sobrenome, telefone, cpf, cargoId, salario, true);
        CFuncionario controller = new CFuncionario();
        controller.Inserir(funcionario);
        utils.SuccessMessage("Cadastro realizado com sucesso!");
    }

    /* public void RemoverFuncionarios()
     {
         var utils = new Utils();
         CFuncionario controller = new CFuncionario();

         utils.TituloMenu("REMOVER FUNCIONARIO");

         Console.WriteLine("O programa irá listar os funcionários.");
         Console.WriteLine("Verifique o ID do funcionário que deseja excluir.");
         utils.Enter();
         Listar();

         Console.WriteLine("Digite o Id do funcionário que deseja excluir:");
         int id;
         if (int.TryParse(Console.ReadLine(), out id) == false)
         {
             utils.ErrorMessage("ID inválido!");
             return;
         }

         //Verificar se o funcionario existe
         var funcionario = controller.ObterPorId(id);
         if (funcionario == null)
         {
             utils.ErrorMessage("Funcionário não encontrado!	");
             return;
         }

         try
         {
             controller.Excluir(funcionario);
             utils.Green();
             Console.WriteLine("Funcionário excluído com sucesso!");
         }
         catch
         {
             utils.ErrorMessage("Id inválido!");
             return;
         }
     }*/

    public void AtualizarFuncionarios(Funcionario user)
    {
        var utils = new Utils();

        if (!utils.Permissao(user.Permissao, 3))
        {
            return;
        }

        CFuncionario controller = new CFuncionario();
        utils.TituloMenu("ATUALIZAR FUNCIONARIO");

        Console.WriteLine("O programa irá listar os funcionários.");
        Console.WriteLine("Verifique o ID do funcionário que deseja atualizar.");
        utils.Enter();
        Listar();
        Console.WriteLine("Digite o Id do funcionário que deseja atualizar:");

        if (int.TryParse(Console.ReadLine(), out int id) == false)
        {
            utils.ErrorMessage("Id inválido!");
            return;
        }

        //Verificar se o funcionario existe
        var funcionarioExiste = controller.ObterPorId(id);
        if (funcionarioExiste == null)
        {
            utils.ErrorMessage("Funcionário não encontrado!");
            return;
        }

        //verificar se o funcionario está ativo
        Console.WriteLine("O funcionário foi demitido ou recontratado?");
        Console.WriteLine("1 - Demitido");
        Console.WriteLine("2 - Recontratado");
        Console.WriteLine("0 - Nenhuma das opções (apenas alterar dados)");
        if (int.TryParse(Console.ReadLine(), out int opcao) == false)
        {
            utils.ErrorMessage("Opção inválida!");
            return;
        }

        switch (opcao)
        {
            case 1:
                controller.ObterPorId(id);
                funcionarioExiste.Ativo = false;
                controller.Atualizar(funcionarioExiste);
                utils.SuccessMessage("Funcionário demitido com sucesso!");
                return;
            case 2:
                controller.ObterPorId(id);
                funcionarioExiste.Ativo = true;
                controller.Atualizar(funcionarioExiste);
                utils.SuccessMessage("Funcionário recontratado com sucesso!");
                return;
            case 0:
                break;
        }
        try
        {
            var atualizar = controller.ObterPorId(id);
            Console.WriteLine("Digite o primeiro nome do funcionario:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o sobrenome do funcionario:");
            string sobrenome = Console.ReadLine();
            Console.Write("Digite o telefone do funcionario:");
            string telefone = Console.ReadLine();
            Console.WriteLine("Digite o CPF do funcionario:");
            string cpf = Console.ReadLine();


            Console.WriteLine("");
            Console.WriteLine("Agora programa irá listar os cargos.");
            Console.WriteLine("Verifique o ID do cargo que deseja atualizar.");
            utils.Enter();

            var CargoUI = new CargoUI();
            CargoUI.Listar();
            Console.WriteLine("Digite o ID cargo do funcionario:");

            if (int.TryParse(Console.ReadLine(), out int cargoId) == false)
            {
                utils.ErrorMessage("ID inválido!");
                return;
            }

            //Verificar se o cargo existe
            var cargoController = new CCargo();
            var cargo = cargoController.ObterPorId(cargoId);
            if (cargo == null)
            {
                utils.ErrorMessage("Cargo não encontrado!");
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("Digite o salario do funcionario:");

            if (double.TryParse(Console.ReadLine(), out double salario) == false)
            {
                utils.ErrorMessage("Opção inválida!");
                return;
            }


            atualizar.Nome = nome;
            atualizar.SobreNome = sobrenome;
            atualizar.Telefone = telefone;
            atualizar.Cpf = cpf;
            atualizar.CargoId = cargoId;
            atualizar.Salario = salario;
            controller.Atualizar(atualizar);
            utils.Green();
            Console.WriteLine("Funcionário atualizado com sucesso!");
            utils.Enter();

        }
        catch
        {
            utils.ErrorMessage("Id inválido!");
            return;
        }
    }
}


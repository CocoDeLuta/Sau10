public class Utils
{
    // a classe Utils contem metodos que podem ser usados em qualquer parte do codigo
    // sao metodos auxiliares para facilitar a leitura do codigo e evitar repeticao de codigo

    public Utils()
    {

    }

    public void TituloMenu(string titulo)
    {
        Console.Clear();
        Yellow();
        Console.WriteLine("=======================================");
        Console.WriteLine(titulo);
        Console.WriteLine("=======================================");
        White();
        Console.WriteLine("");
    }

    //metodo para verificar a permissao do usuario
    public bool Permissao(int user, int permissao)
    {
        if (user < permissao)
        {
            ErrorMessage("Você não tem permissão para acessar essa opção!");
            return false;
        }
        return true;
    }

    //metodo para aguardar o usuario pressionar enter
    public void Enter()
    {
        Cyan();
        Console.WriteLine("");
        Console.WriteLine("Pressione ENTER para continuar...");
        White();
        Console.ReadLine();
        Console.Clear();
    }

    //metodo para mostrar uma mensagem de sucesso
    public void SuccessMessage(string message)
    {
        Green();
        Console.WriteLine(message);
        Enter();
    }

    //metodo para mostrar uma mensagem de erro
    public void ErrorMessage(string message)
    {
        Red();
        Console.WriteLine(message);
        Console.WriteLine("Tente novamente...");
        Enter();
    }

    //mudar a cor do texto para vermelho
    public void Red()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    //mudar a cor do texto para branco 
    public void White()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }

    //mudar a cor do texto para verde
    public void Green()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }

    //
    public void Cyan()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    //mudar a cor do texto para amarelo
    public void Yellow()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
}
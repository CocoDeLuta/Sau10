using Microsoft.EntityFrameworkCore;

Console.Clear();
Console.WriteLine("Seja bem vindo ao Sau10!");
Console.WriteLine("");
Console.WriteLine("O Sau10 tem funcionalidades para gerenciar clinicas e hospitais, como:");
Console.WriteLine("Gerenciar pacientes, internamentos, funcionarios e consultas.");
Console.WriteLine("");
Enter();

//Teste de conexão com o banco de dados
Console.WriteLine("Testando conexão com o banco de dados...");
Console.WriteLine("");
var contexto = new DataBaseContext();
try{
    contexto.Database.OpenConnection();
    Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso!");
    Console.WriteLine("");
    Enter();
}catch(Exception e){
    Console.WriteLine("Erro ao conectar com o banco de dados!");
    Console.WriteLine("Erro: " + e.Message);
    Console.WriteLine("");
    Enter();
    Environment.Exit(0);
}

Enter();

//Teste para verificar se as tabelas existem no banco de dados
Console.WriteLine("Verificando se as tabelas existem no banco de dados...");
Console.WriteLine("");
try{
    contexto.Database.ExecuteSqlRaw("SELECT * FROM teste");
    Console.WriteLine("Tabela paciente encontrada!");
    Console.WriteLine("");
    Enter();
}catch(Exception e){
    Console.WriteLine("Tabela paciente não encontrada!");
    Console.WriteLine("Erro: " + e.Message);
    Console.WriteLine("");
    Enter();
}

//teste de criacao de tabela
Console.WriteLine("Criando tabela...");
Console.WriteLine("");
try{
    contexto.Database.ExecuteSqlRaw("CREATE TABLE teste (id int)");
    Console.WriteLine("Tabela criada com sucesso!");
    Console.WriteLine("");
    Enter();
}catch(Exception e){
    Console.WriteLine("Erro ao criar tabela!");
    Console.WriteLine("Erro: " + e.Message);
    Console.WriteLine("");
    Enter();
    Environment.Exit(0);
}


void Enter(){
    Console.WriteLine("");
    Console.WriteLine("Pressione ENTER para continuar...");
    Console.ReadLine();
}
using Microsoft.EntityFrameworkCore;

public class DataBaseContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {   
        string connectionString = "server=localhost;database=hospital;user=root;password=;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }


    //Criar uma tabela no banco de dados
   // public DbSet<Paciente>? Pacientes { get; set; }
    public DbSet<Consulta>? Consultas { get; set; }
   // public DbSet<Funcionario>? Funcionarios { get; set; }
    //public DbSet<Internamento>? Internamentos { get; set; }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;



public class AppDbContext : DbContext
{
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Internamento> Internamentos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "server=localhost;database=hospital;user=root;password=;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

}
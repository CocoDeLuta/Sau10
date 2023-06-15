using Microsoft.EntityFrameworkCore;

public class Dbcontext : DbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
}
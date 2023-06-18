using Microsoft.EntityFrameworkCore;

public class CConsulta : Repository<Consulta>, IConsulta
{

    public int ObterIdPaciente(int idConsulta, AppDbContext context)
    {
         return context.Database.ExecuteSqlRaw(
                "SELECT PacienteId FROM consultas WHERE Id = " + idConsulta + ";");
    }

    public int ObterIdFuncionario(int idConsulta, AppDbContext context)
    {
        return context.Database.ExecuteSqlRaw(
                "SELECT FuncionarioId FROM consultas WHERE Id = " + idConsulta);
    }
}
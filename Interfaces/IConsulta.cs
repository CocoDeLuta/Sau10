public interface IConsulta
{
    public int ObterIdPaciente(int idConsulta, AppDbContext context);

    public int ObterIdFuncionario(int idConsulta, AppDbContext context);
}
public class CCargo : Repository<Cargo>, ICargo
{
    public Cargo ObterPorNome(string nome)
    {
        List<Cargo> lista = ObterTodos();
        foreach (var item in lista)
        {
            if (item.Nome == nome)
            {
                return item;
            }
        }
        return null;
    }
}
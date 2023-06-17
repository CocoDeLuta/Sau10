using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    public AppDbContext Context = new AppDbContext();
    
    public T ObterPorId(int id)
    {
        return Context.Set<T>().Find(id);
    }

    public List<T> ObterTodos()
    {
        return Context.Set<T>().ToList();
    }

    public void Inserir(T entity)
    {
        Context.Set<T>().Add(entity);
        Context.SaveChanges();
    }

    public void Atualizar(T entity)
    {
        Context.Set<T>().Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
    }

    public void Excluir(T entity)
    {
        Context.Set<T>().Remove(entity);
        Context.SaveChanges();
    }
}


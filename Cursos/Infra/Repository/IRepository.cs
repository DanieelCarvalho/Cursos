namespace Cursos.Infra.Repository;

public interface IRepository<TEntity>
{
    Task<IEnumerable<TEntity>> FindAll(int offset, int size);


    Task<TEntity> FindById(int ID); 

    Task Save (TEntity entity);

    Task<TEntity> Update(int id, TEntity newEntity);

    Task Delete(int id);

}

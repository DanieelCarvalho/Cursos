namespace Cursos.Infra.Repository;

public interface IRepository<TEntity>
{
    Task<IEnumerable<TEntity>> FindAll();


    Task<TEntity> FindById(int ID); 

    Task Save(TEntity entity);

    Task<TEntity> Update(int id, TEntity newEntity);

    Task<TEntity> Delete(int id);

}

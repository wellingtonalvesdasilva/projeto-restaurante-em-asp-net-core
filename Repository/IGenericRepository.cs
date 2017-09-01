using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public interface IGenericRepository<TContext, TEntity> where TContext : class where TEntity : class
    {
        void Incluir(TEntity entity);

        void Alterar(TEntity entity);

        void Excluir(TEntity entity);

        void Salvar();

        IQueryable<TEntity> ObterTodos();

        TEntity ObterPorId(long id);

        IQueryable<TEntity> Obter(Expression<Func<TEntity, bool>> predicate);

        TEntity Primeiro(Expression<Func<TEntity, bool>> predicate);
    }
}

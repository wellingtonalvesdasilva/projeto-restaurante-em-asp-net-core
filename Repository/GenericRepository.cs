using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class GenericRepository<TContext, TEntity> : IGenericRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : EntityBase
    {
        private TContext contexto;

        public GenericRepository(TContext contexto)
        {
            this.contexto = contexto;
        }

        private DbSet<TEntity> ObterDbSet()
        {
            var nomeDaEntidade = typeof(TEntity).FullName;
            if (nomeDaEntidade == null)
                throw new ArgumentException("Tipo inválido para obter DbSet");
            return contexto.Set<TEntity>() as DbSet<TEntity>;
        }

        public void Excluir(TEntity entity)
        {
            ObterDbSet().Remove(entity);
            Salvar();
        }

        public IQueryable<TEntity> Obter(Expression<Func<TEntity, bool>> predicate)
        {
            return ObterDbSet().Where(predicate);
        }

        public TEntity ObterPorId(long id)
        {
            return ObterDbSet().SingleOrDefault(c => c.Id == id);
        }

        public TEntity Primeiro(Expression<Func<TEntity, bool>> predicate)
        {
            return ObterDbSet().SingleOrDefault(predicate);
        }

        public IQueryable<TEntity> ObterTodos()
        {
            return ObterDbSet();
        }

        public void Incluir(TEntity entity)
        {
            ObterDbSet().Add(entity);
            Salvar();
        }

        public void Salvar()
        {
            contexto.SaveChanges();
        }

        public void Alterar(TEntity entity)
        {
            ObterDbSet().Update(entity);
            Salvar();
        }
    }
}

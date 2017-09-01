using Microsoft.EntityFrameworkCore;
using Models;
using Repository;
using Util;

namespace Business
{
    public class BusinessCrudGenerico<TContext, TEntity> : IBusiness<TEntity>
        where TContext : DbContext
        where TEntity : EntityBase
    {
        protected readonly GenericRepository<TContext, TEntity> repositorio;

        public BusinessCrudGenerico(TContext context)
        {
            repositorio = new GenericRepository<TContext, TEntity>(context);
        }

        public virtual TEntity Incluir(TEntity entidade)
        {
            ValidarRegrasDeNegocio(entidade, Enumeracao.ECrudOperacao.Criar);
            repositorio.Incluir(entidade);
            return entidade;
        }

        public virtual void Alterar(TEntity entidade)
        {
            ValidarRegrasDeNegocio(entidade, Enumeracao.ECrudOperacao.Editar);
            repositorio.Alterar(entidade);
        }

        public virtual void Excluir(TEntity entidade)
        {
            ValidarRegrasDeNegocio(entidade, Enumeracao.ECrudOperacao.Excluir);
            repositorio.Excluir(entidade);
        }

        public virtual void ValidarRegrasDeNegocio(TEntity entidade, Enumeracao.ECrudOperacao operacao)
        {

        }
    }
}

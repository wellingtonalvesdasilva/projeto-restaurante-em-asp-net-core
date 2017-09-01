using Models;
using Util;

namespace Business
{
    public interface IBusiness<TEntity> where TEntity : EntityBase
    {
        TEntity Incluir(TEntity entidade);
        void Alterar(TEntity entidade);
        void Excluir(TEntity entidade);
        void ValidarRegrasDeNegocio(TEntity entidade, Enumeracao.ECrudOperacao operacao);
    }
}

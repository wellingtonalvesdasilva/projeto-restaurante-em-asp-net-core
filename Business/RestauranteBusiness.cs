using Microsoft.EntityFrameworkCore;
using Models;
using Repository;
using System;
using System.Linq;
using Util;

namespace Business
{
    public class RestauranteBusiness<TContext> : BusinessCrudGenerico<TContext, Restaurante>
        where TContext : DbContext
    {
        //TODO: poderia ser trocado pelo Facade juntamente com singleton
        protected readonly GenericRepository<TContext, Prato> repositorioPrato;

        public RestauranteBusiness(TContext context) : base(context)
        {
            repositorioPrato = new GenericRepository<TContext, Prato>(context);
        }

        public override void ValidarRegrasDeNegocio(Restaurante entidade, Enumeracao.ECrudOperacao operacao)
        {
            if(operacao == Enumeracao.ECrudOperacao.Criar)
            {
                if(repositorio.Primeiro(r => r.Nome.ToLower() == entidade.Nome.ToLower()) != null)
                    throw new Exception("Esse restaurante já está cadastrado");
            }
        }

        public override void Excluir(Restaurante entidade)
        {
            ValidarRegrasDeNegocio(entidade, Enumeracao.ECrudOperacao.Excluir);

            // aqui poderia utilizar um transaction scope ou criar um attribute de transaction para garantir a transação completa
            var pratos = repositorioPrato.Obter(p => p.Restaurante.Id == entidade.Id).ToList();
            pratos.ForEach(repositorioPrato.Excluir);
            repositorio.Excluir(entidade);
        }
    }
}

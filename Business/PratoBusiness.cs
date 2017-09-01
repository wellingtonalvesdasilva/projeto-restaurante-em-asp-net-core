using Microsoft.EntityFrameworkCore;
using Models;
using System;
using Util;

namespace Business
{
    public class PratoBusiness<TContext> : BusinessCrudGenerico<TContext, Prato>
        where TContext : DbContext
    {
        public PratoBusiness(TContext context) : base(context)
        { }

        public override void ValidarRegrasDeNegocio(Prato entidade, Enumeracao.ECrudOperacao operacao)
        {
            if (operacao == Enumeracao.ECrudOperacao.Criar)
            {
                if (repositorio.Primeiro(r => r.Nome.ToLower() == entidade.Nome.ToLower() && r.RestauranteId == entidade.RestauranteId) != null)
                    throw new Exception("Esse prato já está cadastrado para esse restaurante");
            }
        }
    }
}

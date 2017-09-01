using Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/restaurante")]
    public class RestauranteController : APIBase<SistemaDeRestauranteContext, Restaurante>
    {
        public RestauranteController(SistemaDeRestauranteContext context) : base(context, new RestauranteBusiness<SistemaDeRestauranteContext>(context))
        { }

        //TODO: substituir por um automapper ou de preferencia expressmapper
        protected override Restaurante AtualizarDadosParaEdicao(Restaurante entityDaBase, Restaurante entityAtual)
        {
            entityDaBase.DataHoraAlteracao = DateTime.Now;
            entityDaBase.Nome = entityAtual.Nome;
            return entityDaBase;
        }

        [HttpGet("porNome/{nome}")]
        public IEnumerable<Restaurante> Get(string nome)
        {
            return repositorio.Obter(r => r.Nome.ToLower().Contains(nome.ToLower()));
        }
    }
}

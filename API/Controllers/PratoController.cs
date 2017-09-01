using Business;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/prato")]
    public class PratoController : APIBase<SistemaDeRestauranteContext, Prato>
    {
        //TODO: poderia ser trocado pelo Facade juntamente com singleton
        protected readonly GenericRepository<SistemaDeRestauranteContext, Restaurante> repositorioRestaurante;

        //TODO: possívelmente utilizar injeção de dependência para o Business
        public PratoController(SistemaDeRestauranteContext context) : base(context, new PratoBusiness<SistemaDeRestauranteContext>(context))
        {
            repositorioRestaurante = new GenericRepository<SistemaDeRestauranteContext, Restaurante>(context);
        }

        //TODO: substituir por expressmapper ou automapper
        protected override Prato AtualizarDadosParaEdicao(Prato entityDaBase, Prato entityAtual)
        {
            entityDaBase.DataHoraAlteracao = DateTime.Now;
            entityDaBase.Nome = entityAtual.Nome;
            entityDaBase.Preco = entityAtual.Preco;
            return entityDaBase;
        }

        [HttpGet]
        public override IEnumerable<Prato> Get()
        {
            return repositorio.ObterTodos().ToList().Select(p => MontarRetorno(p));
        }

        [HttpGet("{id}")]
        public override IActionResult Get(long id)
        {
            var prato = repositorio.ObterPorId(id);
            if (prato == null)
                return NotFound();
            return new ObjectResult(MontarRetorno(prato));
        }

        //TODO: substituir por um automapper ou de preferencia expressmapper
        public Prato MontarRetorno(Prato prato)
        {
            var restaurante = repositorioRestaurante.ObterPorId(prato.RestauranteId);
            return new Prato
            {
                Id = prato.Id,
                RestauranteId = prato.RestauranteId,
                Nome = prato.Nome,
                Preco = prato.Preco,
                Restaurante = new Restaurante
                {
                    Nome = restaurante.Nome
                }
            };
        }

    }
}

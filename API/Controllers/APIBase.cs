using Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    public class APIBase<TContext, TEntity> : Controller
        where TContext : DbContext
        where TEntity : EntityBase
    {
        protected readonly GenericRepository<TContext, TEntity> repositorio;
        protected readonly BusinessCrudGenerico<TContext, TEntity> regraDeNegocio;

        public APIBase(TContext context, BusinessCrudGenerico<TContext, TEntity> business)
        {
            repositorio = new GenericRepository<TContext, TEntity>(context);
            regraDeNegocio = business;
        }

        [HttpGet]
        public virtual IEnumerable<TEntity> Get()
        {
            return repositorio.ObterTodos();
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(long id)
        {
            var entidade = repositorio.ObterPorId(id);
            if (entidade == null)
                return NotFound();
            return new ObjectResult(entidade);
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] TEntity entidade)
        {
            if (entidade == null)
                return BadRequest();

            entidade.DataHoraInsercao = DateTime.Now;
            regraDeNegocio.Incluir(entidade);

            return new ObjectResult(entidade);
        }

        [HttpPut("{id}")]
        public virtual IActionResult Put(long id, [FromBody] TEntity entidade)
        {
            if (entidade == null || entidade.Id != id)
                return BadRequest();

            var entidadeDaBase = repositorio.ObterPorId(id);
            if (entidadeDaBase == null)
                return NotFound();

            regraDeNegocio.Alterar(AtualizarDadosParaEdicao(entidadeDaBase, entidade));
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            var entidade = repositorio.ObterPorId(id);
            if (entidade == null)
                return NotFound();

            regraDeNegocio.Excluir(entidade);

            return new NoContentResult();
        }

        protected virtual TEntity AtualizarDadosParaEdicao(TEntity entityDaBase, TEntity entityAtual)
        {
            return entityDaBase;
        }
    }
}

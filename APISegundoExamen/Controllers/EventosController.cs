using APISegundoExamen.Models;
using APISegundoExamen.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISegundoExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private RepositoryEventos repo;

        public EventosController(RepositoryEventos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Evento>> GetEventos()
        {
            return this.repo.GetEventos();
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<Evento> FindEvento(int id)
        {
            return this.repo.FindEvento(id);
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Categoria>> GetCategorias()
        {
            return this.repo.GetCategorias();
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<List<Evento>> GetEventosCategoria(int id)
        {
            return this.repo.GetEventosCategoria(id);
        }
        [HttpPost]
        public ActionResult Create(Evento evento)
        {
            this.repo.InsertEveto(evento);
            return Ok();
        }
        [HttpPut]
        public ActionResult Edit(Evento evento)
        {
            this.repo.ModificarEvento(evento.IdEvento,evento.Nombre,evento.Artista,evento.IdCategoria);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            this.repo.DeleteEvento(id);
            return Ok();
        }


    }
}

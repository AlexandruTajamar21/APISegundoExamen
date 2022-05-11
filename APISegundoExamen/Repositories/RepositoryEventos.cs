using APISegundoExamen.Data;
using APISegundoExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISegundoExamen.Repositories
{
    public class RepositoryEventos
    {
        private EventosContext context;

        public RepositoryEventos(EventosContext context)
        {
            this.context = context;
        }

        public List<Evento> GetEventos()
        {
            return this.context.Eventos.ToList();
        }
        public List<Categoria> GetCategorias()
        {
            return this.context.Categorias.ToList();
        }

        public Evento FindEvento(int id)
        {
            return this.context.Eventos.Where(x => x.IdEvento == id).FirstOrDefault();
        }

        public List<Evento> GetEventosCategoria(int id)
        {
            return this.context.Eventos.Where(z => z.IdCategoria == id).ToList();
        }

        public int GetMaxIdEvento()
        {
            if (this.context.Eventos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Eventos.Max(x => x.IdEvento) + 1;
            }
        }

        public void InsertEveto(Evento evento)
        {
            int id = this.GetMaxIdEvento();
            evento.IdEvento = id;
            this.context.Eventos.Add(evento);
            this.context.SaveChanges();
        }

        public void ModificarEvento(int idEvento, string nombre, string artista, int idcategoria)
        {
            Evento eve = this.FindEvento(idEvento);
            eve.Nombre = nombre;
            eve.Artista = artista;
            eve.IdCategoria = idcategoria;
            this.context.SaveChanges();
        }

        public void DeleteEvento(int idEvento)
        {
            Evento eve = this.FindEvento(idEvento);
            this.context.Eventos.Remove(eve);
            this.context.SaveChanges();
        }
    }
}

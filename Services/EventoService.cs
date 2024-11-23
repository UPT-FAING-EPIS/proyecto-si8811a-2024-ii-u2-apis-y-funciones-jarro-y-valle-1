using Microsoft.Extensions.Options;
using MongoDB.Driver;
using proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Models;
using proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Services
{
    public class EventoService
    {
        private readonly IMongoCollection<Evento> _eventos;

        public EventoService(EVConnection connection)
        {
            _eventos = connection.GetCollection<Evento>("Evento");
        }

        public virtual async Task<List<Evento>> GetAsync() =>
            await _eventos.Find(e => true).ToListAsync();

        public virtual async Task<Evento> GetByIdAsync(string id) =>
            await _eventos.Find<Evento>(e => e.Id == id).FirstOrDefaultAsync();

        public virtual async Task<List<Evento>> GetByNombreAsync(string nombre)
        {
            var filter = Builders<Evento>.Filter.Regex(e => e.Nombre, new MongoDB.Bson.BsonRegularExpression(nombre, "i"));
            return await _eventos.Find(filter).ToListAsync();
        }

        public virtual async Task<Evento> CreateAsync(Evento nuevoEvento)
        {
            await _eventos.InsertOneAsync(nuevoEvento);
            return nuevoEvento;
        }

        public virtual async Task<Evento> UpdateAsync(string id, Evento evento)
        {
            await _eventos.ReplaceOneAsync(a => a.Id == id, evento);
            return evento;
        }

        public virtual async Task DeleteAsync(string id) =>
            await _eventos.DeleteOneAsync(e => e.Id == id);
    }
}

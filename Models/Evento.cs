using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Models
{
    public class Evento
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }

        public string Facultad { get; set; }
        public string Resultado { get; set; }
        public string Descripcion { get; set; }

    }
}

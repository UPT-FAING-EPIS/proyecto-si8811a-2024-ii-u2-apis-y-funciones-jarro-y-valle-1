using Microsoft.Extensions.Options;
using MongoDB.Driver;
using proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Settings;

namespace proyecto_si8811a_2024_ii_u1_apis_y_funciones_jarro_y_valle.Models
{
    public class EVConnection
    {
        private readonly IMongoDatabase _database;

        public EVConnection(IOptions<MongoDBSettings> settings)
        {
            var connectionString = Environment.GetEnvironmentVariable("VJ_CONNECTION_STRING")
                                   ?? settings.Value.ConnectionString;

            // Verificar si se ha detectado la variable de entorno
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("La cadena de conexión VJ no está configurada.");
            }

            // Si la variable fue detectada correctamente
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("VJ_CONNECTION_STRING")))
            {
                Console.WriteLine("Variable de entorno 'VJ_CONNECTION_STRING' detectada correctamente.");
            }
            else
            {
                Console.WriteLine("La variable de entorno 'VJ_CONNECTION_STRING' no se ha detectado.");
            }

            // Crear el cliente de MongoDB
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}

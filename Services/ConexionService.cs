using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PRUEBA.Services // Ajusta el namespace según la carpeta donde esté
{
    public class ConexionService
    {
        private readonly IConfiguration _config;

        public ConexionService(IConfiguration config)
        {
            _config = config;
        }

        public bool EstaConectado()
        {
            try
            {
                using var conexion = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                conexion.Open();
                return conexion.State == System.Data.ConnectionState.Open;
            }
            catch
            {
                return false;
            }
        }
    }
}
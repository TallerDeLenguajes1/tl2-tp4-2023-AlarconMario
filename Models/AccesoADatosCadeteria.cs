using System.IO;
using spaceCadeteria;
using System.Text.Json;

namespace spaceAccesoADatosCadeteria
{
    public class AccesoADatosCadeteria
    {
         public Cadeteria cadeteria = null;

         public Cadeteria obtenerDatos()
         {
            string miJson = File.ReadAllText("Models/Cadeteria.json");
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(miJson); 
            return cadeteria;
         }
    }
}
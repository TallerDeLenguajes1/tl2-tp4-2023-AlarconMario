using System.IO;
using spaceCadete;
using System.Text.Json;

namespace spaceAccesoADatosCadete
{
    public class AccesoADatosCadetes
    {
         private List<Cadete> listCadete = new List<Cadete>();

         public List<Cadete> obtener()
         {
            if (File.Exists("Cadete.json"))
            {
                try
                {
                    string jsonContent = File.ReadAllText("Cadete.json");
                    listCadete = JsonSerializer.Deserialize<List<Cadete>>(jsonContent);
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
                }
            }
            return listCadete;
         }
    }
}
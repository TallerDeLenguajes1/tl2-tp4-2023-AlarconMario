using System.IO;
using spaceCadete;
using System.Text.Json;
using spacePedido;

namespace spaceAccesoADatosCadete
{
    public class AccesoADatosCadetes
    {
         private List<Cadete> listCadete = new List<Cadete>();

         public List<Cadete> obtener()
         {   
            string miJson = File.ReadAllText("Models/Cadete.json");
            var cad = JsonSerializer.Deserialize<Cadete[]>(miJson);
            listCadete.AddRange(cad);
            return listCadete;
         }

         public void guardar(List<Cadete> cadetes)
        {
            string filePath = "Models/Cadete.json";
            var nuevoJsonString = new JsonSerializerOptions
            {
                WriteIndented = true 
            };
            string jsonPedidos = JsonSerializer.Serialize(cadetes,nuevoJsonString);
            File.WriteAllText(filePath, jsonPedidos); 
        }
    }
}
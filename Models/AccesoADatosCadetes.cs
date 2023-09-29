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
            var cad = JsonSerializer.Deserialize<Cadete>(miJson);
            listCadete.Add(cad);
            return listCadete;
         }
    }
}
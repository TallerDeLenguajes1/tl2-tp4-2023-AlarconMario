using System.IO;
using spaceCadete;
using System.Text.Json;

namespace spaceAccesoADatosCadete
{
    public class AccesoADatosCadetes
    {
         public Cadete cadete = null;

         public List<Cadete> obtener()
         {
            List<Cadete> listCadetes = new List<Cadete>();
            try
            {
                using(StreamReader reader = new StreamReader("Models/Cadete.csv"))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] datos = line.Split(',');
                        string nombre = datos[0];
                        int id = int.Parse(datos[1]);
                        string telf = datos[2];
                        string direccion = datos[3];
                        Cadete cadete  = new Cadete(nombre, id, telf, direccion);
                        listCadetes.Add(cadete);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error" + ex);
            } 
            return listCadetes;
         }
    }
}
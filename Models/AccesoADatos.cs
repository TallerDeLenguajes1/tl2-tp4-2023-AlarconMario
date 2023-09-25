using System.Text.Json;
using spaceCadete;
using spaceCadeteria;
using spacePedido;


namespace spaceAccesoADatos
{
    public abstract class AccesoADatos
    {
        public Cadeteria cadeteria = null;
        public abstract Cadeteria CargarInfoCadeteria();
    }
    public class AccesoCsv : AccesoADatos
    {
        
        public override Cadeteria CargarInfoCadeteria()
        {
           try
           {
                using (StreamReader reader = new StreamReader("Cadeteria.csv"))
                {
                    string[] datos = reader.ReadLine().Split(',');
                    string nombre = datos[0];
                    string telf = datos[1];
                    int cantPed = int.Parse(datos[2]);
                    List<Pedido> Listpedidos = new List<Pedido>();
                    cadeteria = new Cadeteria(nombre, telf, cantPed, DatosCadetes(), Listpedidos);
                }
           }
           catch(Exception ex)
           {
                Console.WriteLine("Error" + ex);
           } 
           return cadeteria;
        }

        public List<Cadete> DatosCadetes()
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
    public class AccesoJson : AccesoADatos
    {
        public override Cadeteria CargarInfoCadeteria()
        {   
            try
            {
                string miJson = File.ReadAllText("Models/Cadeteria.json");
                cadeteria = JsonSerializer.Deserialize<Cadeteria>(miJson); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw; 
            }
            return cadeteria;
        }
    }
}


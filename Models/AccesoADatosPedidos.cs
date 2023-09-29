using spacePedido;
using System.Text.Json;

namespace spaceAccesoADatosPedido
{
    public class AccesoADatosPedidos
    {
        private List<Pedido> listPedido = new List<Pedido>();

        public List<Pedido> obtener()
        {
            if (File.Exists("/ModelsPedido.json"))
            {
                try
                {
                    // Lee el contenido del archivo JSON
                    string jsonContent = File.ReadAllText("Models/Pedido.json");

                    // Deserializa el JSON a una lista de pedidos
                    var ped = JsonSerializer.Deserialize<Pedido>(jsonContent);
                    listPedido.Add(ped);
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
                }
            }
            return listPedido;
        }
    }
}
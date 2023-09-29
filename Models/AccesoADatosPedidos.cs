using spacePedido;
using System.Text.Json;

namespace AccesoADatosPedido
{
    public class AccesoADatosPedidos
    {
        private List<Pedido> listPedido = new List<Pedido>();

        public List<Pedido> obtener()
        {
                        
            // Verifica si el archivo JSON existe
            if (File.Exists("Pedido.json"))
            {
                try
                {
                    // Lee el contenido del archivo JSON
                    string jsonContent = File.ReadAllText("Pedido.json");

                    // Deserializa el JSON a una lista de pedidos
                    listPedido = JsonSerializer.Deserialize<List<Pedido>>(jsonContent);
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
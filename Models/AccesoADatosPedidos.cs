using spacePedido;
using System.Text.Json;

namespace spaceAccesoADatosPedido
{
    public class AccesoADatosPedidos
    {
        private List<Pedido> listPedido = new List<Pedido>();
        public List<Pedido> obtener()
        {
            string jsonContent = File.ReadAllText("Models/Pedido.json");
            var pedidos = JsonSerializer.Deserialize<Pedido[]>(jsonContent);
            listPedido.AddRange(pedidos);   
            return listPedido;
        }
        public void guardar(List<Pedido> pedidos)
        {
            string filePath = "Models/Pedido.json";
            var nuevoJsonString = new JsonSerializerOptions
            {
                WriteIndented = true 
            };
            string jsonPedidos = JsonSerializer.Serialize(pedidos,nuevoJsonString);
            File.WriteAllText(filePath, jsonPedidos); 
        }
    }
}
using spaceCadete;
using spacePedido;


namespace spaceInforme
{
    public class Informe
    {
        int promedioDeEnvios;
        int pedidosEntregados;
        int totalDePedidos;
        double montoTotal;

        public int PromedioDeEnvios { get => promedioDeEnvios; set => promedioDeEnvios = value; }
        public int PedidosEntregados { get => pedidosEntregados; set => pedidosEntregados = value; }
        public double MontoTotal { get => montoTotal; set => montoTotal = value; }
        public int TotalDePedidos { get => totalDePedidos; set => totalDePedidos = value; }
        
        public Informe(List<Pedido> pedido, List<Cadete> cadete)
        {
            this.totalDePedidos = pedido.Count;
            foreach(var ped in pedido)
            {
                if(ped.Estado == "Entregado")
                {
                    pedidosEntregados++;
                }
            }
            montoTotal = pedidosEntregados * 500;
            if(cadete != null)
            {
                promedioDeEnvios = pedidosEntregados / cadete.Count;
            }
        }
    }
    
}
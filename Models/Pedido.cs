using spaceCliente;

namespace spacePedido
{
    public class Pedido
    {
        private int nro;
        private string? obs;
        //Cliente cliente;
        private string? estado;
        int idCadete;
       

        public int Nro { get => nro; set => nro = value; }
        public string? Obs { get => obs; set => obs = value; }
        //public Cliente Clientes { get => cliente; set => cliente = value; }
        public string? Estado { get => estado; set => estado = value; }
        public int IdCadete { get=> idCadete; set => idCadete = value; }
       

        public Pedido(int _id, string _obs, string _estado, int _idCadete)
        {
            this.nro = _id;
            this.obs = _obs;
            this.estado = _estado;
            this.idCadete = _idCadete;
            
        }
        public Pedido()
        {
        }
        public string verdireccionCliente(Cliente cliente){
            return cliente.Direccion;
        } 
        
        public void verDatosClientes(Cliente c)
        {  
            Console.WriteLine("INFORMACION DEL CLIENTE");
            Console.WriteLine("Nombre: "+ c.Nombre);
            Console.WriteLine("Direccion: "+ c.Direccion);
            Console.WriteLine("Telefono: "+ c.Telf);
            Console.WriteLine("Dato de Referencia: "+ c.DatoReferencia);

        }

        public enum estadoPedido{
            SinAsignar,
            EnCamino,
            Entregado
        }
        
    }
     
     
}
using spaceCliente;

namespace spacePedido
{
    public class Pedido
    {
        private int nro;
        private string obs;
        Cliente cliente;
        private string? estado;
        int idCadete;
       
        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Clientes { get => cliente; set => cliente = value; }
        public string? Estado { get => estado; set => estado = value; }
        public int IdCadete { get=> idCadete; set => idCadete = value; }
       
        public Pedido()
        {
        }
        public Pedido(int _id, string _obs, string _estado, int _idCadete)
        {
            this.nro = _id;
            this.obs = _obs;
            this.estado = _estado;
            this.idCadete = _idCadete;
            this.cliente = CrearClienteAleatorio();
            
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

        public Cliente CrearClienteAleatorio()
        {
            // Genera nombres aleatorios
            string[] nombres = { "Juan", "Maria", "Carlos", "Ana", "Luis", "Laura", "Pedro", "Sofia" };
            string nombreAleatorio = nombres[new Random().Next(nombres.Length)];

            // Genera direcciones aleatorias
            string[] direcciones = { "Calle A", "Avenida B", "Calle C", "Avenida D", "Calle E" };
            string direccionAleatoria = direcciones[new Random().Next(direcciones.Length)];

            // Genera números de teléfono aleatorios
            string telefonoAleatorio = "381" + new Random().Next(1000, 9999);

            // Genera datos de referencia aleatorios
            string[] referencias = { "Referencia 1", "Referencia 2", "Referencia 3", "Referencia 4" };
            string referenciaAleatoria = referencias[new Random().Next(referencias.Length)];

            // Crea una instancia de Cliente con los datos aleatorios
            Cliente clienteAleatorio = new Cliente(nombreAleatorio, direccionAleatoria, telefonoAleatorio, referenciaAleatoria);

            return clienteAleatorio;
        } 
    }    
}
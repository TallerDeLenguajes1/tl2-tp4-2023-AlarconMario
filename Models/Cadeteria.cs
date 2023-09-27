using spacePedido;
using spaceCadete;
using spaceAccesoADatos;

namespace spaceCadeteria
{
    public class Cadeteria
    {
        private string? nombre;
        private string? telf;
        private int cantidaPedidos;
        private static Cadeteria instance;
        private List<Cadete> ListadoCadetes;
        private List<Pedido> ListadoPedidos;

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Telf { get => telf; set => telf = value; }
        public List<Cadete> Cadetes { get => ListadoCadetes; set => ListadoCadetes = value; }
        public List<Pedido> Pedidos { get => ListadoPedidos; set => ListadoPedidos = value; }
        public int CantidaPedidos { get => cantidaPedidos; set => cantidaPedidos = value; }

        public static Cadeteria Instance
        {
            get
            {
                if (instance == null)
                {
                    AccesoADatos cargar = new AccesoJson();
                    instance = cargar.CargarInfoCadeteria();
                }
                return instance;
            }
        }

        public Cadeteria()
        {
            ListadoCadetes = new List<Cadete>();
            ListadoPedidos = new List<Pedido>();
        }
        public Cadeteria(string nombre, string telf, int cantidaPedidos, List<Cadete> cadetes, List<Pedido> pedidos)
        {
            this.Nombre = nombre;
            this.Telf = telf;
            this.Cadetes = cadetes;
            this.Pedidos = pedidos;
            this.cantidaPedidos = cantidaPedidos + 1;
        }
        public void AgregarPeido()
        {
            Pedido pedido = crearPedido();
            ListadoPedidos.Add(pedido);    
        }
        private Pedido crearPedido()
        {
            Random random = new Random();
            int idC = random.Next(1, 4);
            int numeroAleatorio = random.Next(0,3);
            cantidaPedidos+=1;
            Pedido.estadoPedido est = (Pedido.estadoPedido)numeroAleatorio;
            var p = new Pedido(cantidaPedidos, "prueba", est.ToString(), idC);
            if(est == 0)
            {
                p.IdCadete = 0;
            }
            return p;
        }
        public void Datos(Cadeteria cad)
        {
            Console.WriteLine($"Cadeteria: {cad.Nombre}");
            Console.WriteLine($"Telefono: {cad.Telf}");
            
        }
        public int JornalACobrar(int _idCadete)
        {
            int total = 0;
            if(ListadoPedidos  != null)
            {
                foreach(var ped in ListadoPedidos)
                {
                    if(ped.IdCadete == _idCadete)
                    {
                        total += 500;
                    }
                }
                
            }
            return total;
        }
        public int enviosEntregados(int _idCadete)
        {
            int contador = 0;
            foreach(var ped in ListadoPedidos)
            {
                if(ped.IdCadete == _idCadete)
                {
                    contador++;
                }
            }
            return contador;
        }
        
        public void AsignarCadeteAPedido(int _idCadete, int _idPedido){
            for (int i = 0; i < ListadoPedidos.Count; i++)
            {
                if (ListadoPedidos[i].Nro == _idPedido)
                {
                    ListadoPedidos[i].IdCadete = _idCadete;
                    ListadoPedidos[i].Estado = "Enviado";
                }
            }
        }
        public void cambiarEstado(int _nroPedido, int _estado)
        {
            if(ListadoPedidos != null)
            {
                for(int i = 0; i < ListadoPedidos.Count; i++)
                {   
                    if(ListadoPedidos[i].Nro == _nroPedido)
                    {
                        if((Pedido.estadoPedido)_estado == (Pedido.estadoPedido)0)
                        {
                            ListadoPedidos[i].IdCadete = 0;
                        }
                        ListadoPedidos[i].Estado = ((Pedido.estadoPedido)_estado).ToString();
                        break;
                    }
                }
            }
            
        }
        public void reasignarPedido(int _nroPedido, int _idCadete)
        {
            for(int i = 0; i < ListadoPedidos.Count; i++)
            {   
                if(ListadoPedidos[i].Nro == _nroPedido)
                {
                    ListadoPedidos[i].IdCadete = _idCadete;
                    break;
                }
            }
        }
        public List<Pedido> pedidosAsignado()
        {
            List<Pedido> asignados = new List<Pedido>();
            foreach(var ped in ListadoPedidos)
            {
                if(ped.Estado != "SinAsignar")
                {
                    asignados.Add(ped);
                }
            }
            return asignados;
        }
        public List<Pedido> pedidosSinAsignar()
        {
            List<Pedido> sinAsignar = new List<Pedido>();
            foreach(var ped in ListadoPedidos)
            {
                if(ped.Estado == "SinAsignar")
                {
                    sinAsignar.Add(ped);
                }
            }
            return sinAsignar;
        }
        public int selecionarPedido(int indice, List<Pedido> _pedidos)
        {
            int pedidoSeleccionado = _pedidos[indice].Nro;
            return pedidoSeleccionado;
        }
    }  
}
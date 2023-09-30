namespace spaceCliente
{
    public class Cliente
    {
        private string nombre;
        private string direccion;
        private string telf;
        private string datoReferencia;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telf { get => telf; set => telf = value; }
        public string DatoReferencia { get => datoReferencia; set => datoReferencia = value; }

        public Cliente()
        {
        }
        public Cliente(string _nombre, string _direccion, string _telf, string _datoReferencia)
        {
            this.nombre = _nombre;
            this.direccion = _direccion;
            this.telf = _telf;
            this.datoReferencia = _datoReferencia;
        }
    }
}


namespace spaceCadete
{
    
    public class Cadete
    {
        private int id;
        private string? nombre;
        private string? direccion;
        private string? telf;


        public string? Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Telf { get => telf; set => telf = value; }
        public Cadete(string nombre, int id, string telf, string direccion)
        {
            this.nombre = nombre;
            this.id = id;
            this.telf = telf;
            this.direccion = direccion;
        } 
        public Cadete()
        {
        }
    }
}

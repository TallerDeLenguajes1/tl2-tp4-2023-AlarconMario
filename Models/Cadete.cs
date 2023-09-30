
namespace spaceCadete
{
    
    public class Cadete
    {
        private int id;
        private string? nombre;
        private string? direccion;
        private string? telf;

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Telf { get => telf; set => telf = value; }

        public Cadete(string nombre, int id, string direccion, string telf)
        {
            this.Nombre = nombre;
            this.Id = id;
            this.Telf = telf;
            this.Direccion = direccion;
        } 
        public Cadete()
        {
        }
    }
}

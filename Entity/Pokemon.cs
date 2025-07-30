namespace Entity
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string? UrlImagen { get; set; }

        public int IdTipo { get; set; }

        public int IdDebilidad { get; set; }

        public int? IdEvolucion { get; set; }

        public bool Activo { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

    }
}

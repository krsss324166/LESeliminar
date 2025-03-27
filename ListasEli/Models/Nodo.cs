namespace ListasEli.Models
{
    public class Nodo
    {
        public string Informacion { get; set; }
        public Nodo? Referencia { get; set; }

        public Nodo()
        {
            Informacion = string.Empty;
            Referencia = null;
        }

        public Nodo(string informacion)
        {
            Informacion = informacion;
            Referencia = null;
        }

        public override string ToString()
        {
            return $"{Informacion} ==> ";
        }
    }
}

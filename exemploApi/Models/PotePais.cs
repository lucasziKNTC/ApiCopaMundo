namespace exemploApi.Models
{
    public class PotePais
    {
        public int IDPote { get; set; }

        public int IDPais { get; set; }

        public Pote Pote { get; set; }

        public Paises Paises { get; set; }

    }
}

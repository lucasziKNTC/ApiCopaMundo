namespace exemploApi.Models
{
    public class Paises
    {
        public int ID { get; set; }

        public int RankingFifa { get; set; }

        public string Participantes { get; set; }

        public int IdConfederacao { get; set; }

        public bool Sede { get; set; }

        public Confederacao confederacao { get; set; }

    }
}

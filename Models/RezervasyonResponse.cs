namespace TrenRezervasyon.Models
{
    public class RezervasyonResponse
    {
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; } = new List<YerlesimAyrinti>();

    }
}

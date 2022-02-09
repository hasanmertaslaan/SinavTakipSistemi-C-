namespace SinavTakipSistemi.Models
{
    public class Soru
    {
        public int Id { get; set; }
        public int SinavId { get; set; }
        public string Sual { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string Cevap { get; set; }
    }
}

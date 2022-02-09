namespace SinavTakipSistemi.Models
{
    public class SinavSonucu
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string SinavAdi { get; set; }
        public int SoruSayisi { get; set; }
        public int DogruSayisi { get; set; }
        public int YanlisSayisi { get; set; }
    }
}

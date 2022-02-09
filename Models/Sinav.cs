using System.Collections.Generic;

namespace SinavTakipSistemi.Models
{
    public class Sinav
    {
        public int Id { get; set; }
        public string SinavAdi { get; set; }

        //DTO
        public int SoruAdeti { get; set; }
    }
}

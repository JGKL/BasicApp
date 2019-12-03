using System;

namespace BasicApp.Core.Business.Models
{
    public class Training
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Programma { get; set; }
        public int Kilometers { get; set; }


        public string Tempo { get; set; }
        public int Hartslag { get; set; }
        public string Tijden { get; set; }
        public string Gevoel { get; set; }
        public string Opmerkingen { get; set; }

        public string SportIcon { get; set; } = "running";
        public string DistanceIcon { get; set; } = "distance";
        public string TimeIcon { get; set; } = "time";
    }
}

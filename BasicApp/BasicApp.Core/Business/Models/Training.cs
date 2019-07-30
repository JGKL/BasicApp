using System;

namespace BasicApp.Core.Business.Models
{
    public class Training
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; } = DateTime.Now;
        public string Programma { get; set; }
        public string Tempo { get; set; }
        public string Hartslag { get; set; }
        public string Tijden { get; set; }
        public string Gevoel { get; set; }
        public string Kilometers { get; set; }
        public string Opmerkingen { get; set; }

        public string NextIcon => "fa-caret-right";
        public string DateIcon => "fa-calendar-o";
    }
}

using System;

namespace FFAA.AccessCard.Entity
{
    public class CardInfoEntity
    {
        public long TarjetaID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Tipo { get; set; }
        public string Cargo { get; set; }
        public string Clasificacion { get; set; }
        public long Identificacion { get; set; }
        public string Grado { get; set; }
        public string Nombres { get; set; }
        public string NombreFirma { get; set; }
        public string CargoFirma { get; set; }
        public string Apellidos { get; set; }
        public int? Unidad { get; set; }
        public string Dependencia { get; set; }
        public int? Vigencia { get; set; }
    }
}

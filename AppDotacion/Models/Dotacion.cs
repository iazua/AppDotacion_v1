using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace AppDotacion.Models
{
    [Table("Dotaciones")]
    public class Dotacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ID { get; set; }

        public string? Rut_DNI { get; set; }
        public string? Agente { get; set; }
        public string? Pais_Call_Center { get; set; }
        public string? Nombre_Call_Center { get; set; }
        public string? Area { get; set; }
        public string? AreaGestion { get; set; }
        public byte? Contrato { get; set; }
        public string? Tipos_de_agente { get; set; }
        public string? Servicio { get; set; }
        public string? Usuarios_RcWeb { get; set; }
        public string? Nombre_Jefatura { get; set; }
        public string? Rut_Ficticio { get; set; }
        public string? Rut_DNI2 { get; set; }
        public byte? DV { get; set; }
        public string? Clasifica_Cargo { get; set; }
        public string? CARGO { get; set; }

        private int? _fechaIngresoInt;
        private int? _fechaBajaInt;

        [Display(Name = "Fecha de Ingreso")]
        [NotMapped]
        public DateTime? Fecha_Ingreso
        {
            get => _fechaIngresoInt.HasValue ? ConvertIntToDate(_fechaIngresoInt.Value) : null;
            set => _fechaIngresoInt = value.HasValue ? ConvertDateToInt(value.Value) : null;
        }

        [Column("Fecha_Ingreso")]
        public int? Fecha_IngresoInt
        {
            get => _fechaIngresoInt;
            set => _fechaIngresoInt = value;
        }

        [Display(Name = "Fecha de Baja")]
        [NotMapped]
        public DateTime? Fecha_Baja
        {
            get => _fechaBajaInt.HasValue ? ConvertIntToDate(_fechaBajaInt.Value) : null;
            set => _fechaBajaInt = value.HasValue ? ConvertDateToInt(value.Value) : null;
        }

        [Column("Fecha_Baja")]
        public int? Fecha_BajaInt
        {
            get => _fechaBajaInt;
            set => _fechaBajaInt = value;
        }

        public int? N_Personal { get; set; }
        public string? Correo { get; set; }

        private DateTime ConvertIntToDate(int dateInt)
        {
            // Asume formato YYYYMMDD (ej: 20231231 = 31/Dic/2023)
            if (dateInt.ToString().Length == 8)
            {
                return DateTime.ParseExact(
                    dateInt.ToString(),
                    "yyyyMMdd",
                    CultureInfo.InvariantCulture
                );
            }
            // Si es un valor numérico de días (como OLE Automation Date)
            else
            {
                return DateTime.FromOADate(dateInt);
            }
        }

        private int ConvertDateToInt(DateTime date)
        {
            // Usar formato YYYYMMDD para almacenamiento
            return int.Parse(date.ToString("yyyyMMdd"));
        }
    }
}
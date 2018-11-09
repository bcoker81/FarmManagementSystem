using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WherePigsFlyFms.Models
{
    [Table("Vaccinations")]
    public class VaccinationModel
    {
        [Key]
        public int VaccineId { get; set; }
        public int VaccineType { get; set; }
        public string VaccineName { get; set; }
        public string VaccineNotes { get; set; }
        [DataType(DataType.Date)]
        public DateTime VaccineDate { get; set; }

        public int FK_Animal_Id { get; set; }
        [ForeignKey("FK_Animal_Id")]
        public Animals Animals { get; set; }
    }
}
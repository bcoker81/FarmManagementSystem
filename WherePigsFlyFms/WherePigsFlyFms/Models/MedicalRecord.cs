using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WherePigsFlyFms.Models
{
    [Table("MedicalRecords")]
    public class MedicalRecord
    {
        [Key]
        public int MedicalRecordId { get; set; }
        public DateTime? IncidentDate { get; set; }
        [MaxLength(30)]
        public string IncidentDescription { get; set; }
        [MaxLength(200)]
        public string Resolution { get; set; }
        [MaxLength(200)]
        public string Notes { get; set; }
        [MaxLength(50)]
        public string VetInvolved { get; set; }
        [MaxLength(20)]
        public string VetLocation { get; set; }
        public bool IsDeleted { get; set; }

        public int FK_Animal_Id { get; set; }
        [ForeignKey("FK_Animal_Id")]
        public Animals Animals { get; set; }
    }
}
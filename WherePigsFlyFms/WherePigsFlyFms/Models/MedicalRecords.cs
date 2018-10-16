using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WherePigsFlyFms.Models
{
    public class MedicalRecords
    {
        [Key]
        public int MedicalRecordId { get; set; }
        public Nullable<System.DateTime> DogParvovirus { get; set; }
        public Nullable<System.DateTime> DogDistemper { get; set; }
        public Nullable<System.DateTime> DogHepatitis { get; set; }
        public Nullable<System.DateTime> DogLeptospirosis { get; set; }
        public Nullable<System.DateTime> DogBordetella { get; set; }
        public string OtherCare { get; set; }
        public string Microchip { get; set; }
        public Nullable<System.DateTime> MicrochipDate { get; set; }
        public Nullable<System.DateTime> RabiesVac { get; set; }
        public Nullable<System.DateTime> Catpanleuk { get; set; }
        public Nullable<System.DateTime> CatRespVirus { get; set; }
        public Nullable<System.DateTime> EctoParasites { get; set; }
        public string EctoParasiteNotes { get; set; }
        public Nullable<System.DateTime> BloodParasites { get; set; }
        public string BloodParasiteNotes { get; set; }
        public string IntestinalParasites { get; set; }
        public string IntestinalParasiteNotes { get; set; }

        public int FK_Animal_Id { get; set; }
        [ForeignKey("FK_Animal_Id")]
        public Animals Animals {get;set;}
    }
}
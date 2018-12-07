using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WherePigsFlyFms.Models
{
    public enum Gender
    {
        Male, Female
    }

    [Table("Animals")]
    public class Animals
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Tag Number")]
        public string TagNumber { get; set; }
        public string Breed { get; set; }
        //public string BreedText { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public Nullable<int> Weight { get; set; }
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Date Acquired")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> DateAcquired { get; set; }
        [Display(Name = "Animal Type")]
        public string AnimalType { get; set; }
        [Display(Name = "Doner Name")]
        public string NameOfDoner { get; set; }
        [Display(Name = "Doner address number")]
        public string DonerAddress1 { get; set; }
        [Display(Name = "Doner address street")]
        public string DonerAddress2 { get; set; }
        [Display(Name = "Doner city")]
        public string DonerCity { get; set; }
        [Display(Name = "Doner state")]
        public string DonerState { get; set; }
        [Display(Name = "Doner zip")]
        public string DonerZip { get; set; }
        [Display(Name = "Doner phone")]
        public string DonerPhone { get; set; }
        [Display(Name = "Doner email")]
        public string DonerEmail { get; set; }
        [Display(Name = "Date removed or sold")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> DateRemovedOrSold { get; set; }
        [Display(Name = "Date euthenized or died")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> DateEuthenizedOrDied { get; set; }
        [Display(Name = "Photo")]
        public string PhotoUri { get; set; }
        public bool Archived { get; set; }
        [NotMapped]
        public int MedicalCount { get; set; }

        public string WikiLinkUri { get; set; }
        public ICollection<AttachmentModel> Attachments { get; set; }
        public ICollection<VaccinationModel> Vaccines { get; set; }
        //public ICollection<MedicalRecords> MedicalRecords { get; set; }
    }
}
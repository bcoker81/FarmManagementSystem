using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WherePigsFlyFms.Validators;

namespace WherePigsFlyFms.Models
{
    public enum Gender
    {
        Male, Female
    }

    //[FluentValidation.Attributes.Validator(typeof(AnimalValidator))]
    [Table("Animals")]
    public class Animals
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Display(Name = "Tag Number")]
        [MaxLength(15)]
        public string TagNumber { get; set; }
        //public int Breed { get; set; }
        public string Breed { get; set; }
        [NotMapped]
        public string AnimalTypeText { get; set; }
        [NotMapped]
        public string DonerStateText { get; set; }
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
        public int AnimalType { get; set; }
        [Display(Name = "Donor Name")]
        public string NameOfDoner { get; set; }
        [Display(Name = "Donor address number")]
        public string DonerAddress1 { get; set; }
        [Display(Name = "Donor address street")]
        public string DonerAddress2 { get; set; }
        [Display(Name = "Donor city")]
        public string DonerCity { get; set; }
        [Display(Name = "Donor state")]
        public int DonerState { get; set; }
        [Display(Name = "Donor zip")]
        public string DonerZip { get; set; }
        [Display(Name = "Donor phone")]
        public string DonerPhone { get; set; }
        [Display(Name = "Donor email")]
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WherePigsFlyFms.Models;

namespace WherePigsFlyFms.ViewModels
{
    public class FarmViewModel
    {
        public List<Animals> Animals { get; set; }
        public Animals Animal { get; set; }
        public List<VaccinationModel> Vaccines { get; set; }
        public VaccinationModel Vaccine { get; set; }
        public List<SelectListItem> listValues; 
        //public MedicalRecords MedicalRecord { get; set; }
        //public List<MedicalRecords> MedicalRecords { get; set; }

        public FarmViewModel()
        {
            Animals = new List<Animals>();
            Animal = new Animals();
            listValues = new List<SelectListItem>();
            //MedicalRecord = new MedicalRecords();
            //MedicalRecords = new List<MedicalRecords>();
        }
    }
}
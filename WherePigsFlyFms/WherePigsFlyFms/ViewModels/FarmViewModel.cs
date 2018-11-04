using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WherePigsFlyFms.Models;

namespace WherePigsFlyFms.ViewModels
{
    public class FarmViewModel
    {
        public List<Animals> Animals { get; set; }
        public Animals Animal { get; set; }
        public List<VaccinationModel> Vaccines { get; set; }
        public VaccinationModel Vaccine { get; set; }
        //public MedicalRecords MedicalRecord { get; set; }
        //public List<MedicalRecords> MedicalRecords { get; set; }

        public FarmViewModel()
        {
            Animals = new List<Animals>();
            Animal = new Animals();
            //MedicalRecord = new MedicalRecords();
            //MedicalRecords = new List<MedicalRecords>();
        }
    }
}
﻿using System;
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
        public List<PickListModel> PickLists { get; set; }
        public PickListModel Picklist { get; set; }
        public AttachmentModel Attachments { get; set; }
        public IEnumerable<SelectListItem> BreedsList { get; set; }
        public IEnumerable<SelectListItem> AnimalTypeList { get; set; }
        public IEnumerable<SelectListItem> VaccinesList { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }
        public List<MedicalRecord> MedicalRecords { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public PickListType DropdownSelection { get; set; }
        public FarmViewModel()
        {
            Animals = new List<Animals>();
            Animal = new Animals();
            listValues = new List<SelectListItem>();
            Attachments = new AttachmentModel();
            Picklist = new PickListModel();
            PickLists = new List<PickListModel>();
            MedicalRecords = new List<MedicalRecord>();
            MedicalRecord = new MedicalRecord();
        }
    }
}
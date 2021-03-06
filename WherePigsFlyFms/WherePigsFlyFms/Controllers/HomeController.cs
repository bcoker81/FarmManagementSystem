﻿using System.Linq;
using System.Web;
using System.Web.Mvc;
using WherePigsFlyFms.Data;
using WherePigsFlyFms.Models;
using WherePigsFlyFms.Toast;
using WherePigsFlyFms.UnitOfWork;
using WherePigsFlyFms.Utilities;
using WherePigsFlyFms.ViewModels;

namespace WherePigsFlyFms.Controllers
{
    public class HomeController : FarmBaseController
    {

        public ActionResult Index()
        {
            FarmViewModel viewModel = new FarmViewModel();

            using (var context = new FmsDbContext())
            {
                _uow = new FmsUoW(context);
                _util = new FmsUtilities();

                //viewModel.BreedsList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "Breed").ToList());
                var animalTypesList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "AnimalType").ToList());
                var vaccList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "VAC").ToList());
                //viewModel.VaccinesList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "VAC").ToList());
                var stateList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "ST").ToList());
                viewModel.Animals = _uow.AnimalRepo.FindMany(p => p.Archived == false).ToList();
                var orderedAnimalTypes = animalTypesList.OrderBy(p => p.Text);
                var orderedStates = stateList.OrderBy(p => p.Text);
                viewModel.StateList = orderedStates;
                viewModel.AnimalTypeList = orderedAnimalTypes;
                viewModel.VaccinesList = vaccList;
                foreach (var item in viewModel.Animals)
                {
                    var records = _uow.VaccineRepo.FindMany(p => p.FK_Animal_Id == item.Id);
                    var recordCnt = records.Count();
                    item.MedicalCount = recordCnt;
                }

                this.AddToastMessage("Animals...", "have been retrieved from the database.", ToastType.Success);
                _uow = null;
            }
            return View("Index", viewModel);
        }

        public ActionResult SaveVaccineHistory(FarmViewModel model)
        {
            using (var context = new FmsDbContext())
            {
                if (model !=null)
                {
                    _uow = new FmsUoW(context);
                    var updateRecord = _uow.AnimalRepo.FindSingle(p => p.Id == model.Animal.Id);
                    var lookupDesc = _uow.LookupRepo.FindSingle(p => p.LookupId == model.Vaccine.VaccineType);
                    model.Vaccine.VaccineName = lookupDesc.Description;
                    model.Vaccine.FK_Animal_Id = model.Animal.Id;
                    _uow.VaccineRepo.Add(model.Vaccine);
                    _uow.Commit();
                }
            }
            this.AddToastMessage("Success!", "Animal medical history updated!", ToastType.Success);
            return RedirectToAction("Index");
        }

        public ActionResult SaveAnimal(FarmViewModel model)
        {
            using (var context = new FmsDbContext())
            {
                if (model != null)
                {
                    _uow = new FmsUoW(context);
                    _uow.AnimalRepo.Add(model.Animal);
                    _uow.Commit();
                }
            }
            this.AddToastMessage("Success!", "Animal saved to database!", ToastType.Success);

            return RedirectToAction("Index");
        }

        public ActionResult ViewAnimalDetails(int id)
        {
            FarmViewModel viewModel = new FarmViewModel();

            using (var context = new FmsDbContext())
            {
                _uow = new FmsUoW(context);
                var valueTypes = _uow.LookupRepo.GetAll().ToList();
                foreach (var values in valueTypes)
                {
                    viewModel.listValues.Add(new SelectListItem { Value = values.LookupId.ToString(), Text = values.Description });
                }
                
                var result = _uow.AnimalRepo.FindSingle(p => p.Id == id);
                viewModel.Vaccines = _uow.VaccineRepo.FindMany(p => p.FK_Animal_Id == id).ToList();
                viewModel.Animal = result;
                this.AddToastMessage("Success!", "Animal retrieved from database!", ToastType.Success);

            }

            return View("AnimalDetails", viewModel);
        }

        public ActionResult DeleteAnimal(int id)
        {
            return RedirectToAction("Index");
        }

        public virtual ActionResult Upload(HttpPostedFileBase file, FarmViewModel viewModel)
        {
            _util.Upload(file, viewModel);
            this.AddToastMessage("Success!", "File uploaded successfully", ToastType.Success);
            return RedirectToAction("AnimalDetails", new { id = viewModel.Animal.Id });
        }

        public ActionResult EditAnimal(FarmViewModel model)
        {
             
            return View("_RegisterAnimal", model);
        }

        public ActionResult Archive(int id)
        {
            using (var context = new FmsDbContext())
            {
                _uow = new FmsUoW(context);

                var result = _uow.AnimalRepo.FindSingle(p => p.Id == id);
                result.Archived = true;
                _uow.Commit();
            }
            return RedirectToAction("Index");
        }

        public ActionResult SaveCode(FarmViewModel model)
        {
            _util = new FmsUtilities();

            using (var context = new FmsDbContext())
            {
                _uow = new FmsUoW(context);

                var masterList = _uow.PickListRepo.FindMany(p => p.ListType == model.DropdownSelection.ToString()).ToList();
                var newIndex = _util.GenerateIndexNumber(masterList);
                model.Picklist.Value = newIndex;

                model.Picklist.ListType = model.DropdownSelection.ToString();
                _uow.PickListRepo.Add(model.Picklist);
                _uow.Commit();
                _uow = null;
            }
            return RedirectToAction("Index");
        }
    }
}
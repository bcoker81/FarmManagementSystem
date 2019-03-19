using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WherePigsFlyFms.Data;
using WherePigsFlyFms.Models;
using WherePigsFlyFms.Toast;
using WherePigsFlyFms.UnitOfWork;
using WherePigsFlyFms.Utilities;
using WherePigsFlyFms.Validators;
using WherePigsFlyFms.ViewModels;

namespace WherePigsFlyFms.Controllers
{
    public class HomeController : FarmBaseController
    {

        public ActionResult Index()
        {
            FarmViewModel viewModel = new FarmViewModel();
            _uow = null;
            try
            {
                using (var context = new FmsDbContext())
                {
                    if (_uow == null)
                    {
                        _uow = new FmsUoW(context);
                    }
                    _util = new FmsUtilities();

                    //viewModel.BreedsList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "Breed").ToList());
                    var animalTypesList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "AnimalType").ToList());
                    viewModel.VaccinesList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "VAC").ToList());
                    viewModel.StateList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "ST").OrderBy(p => p.Text).ToList());
                    viewModel.Animals = _uow.AnimalRepo.FindMany(p => p.Archived == false).ToList();
                    var animalCount = viewModel.Animals.Count();
                    viewModel.AnimalTypeList = animalTypesList.OrderBy(p => p.Text);
                    
                    foreach (var item in viewModel.Animals)
                    {
                        var records = _uow.VaccineRepo.FindMany(p => p.FK_Animal_Id == item.Id);
                        var recordCnt = records.Count();
                        item.MedicalCount = recordCnt;
                        item.AnimalTypeText = GetAnimalType(item.AnimalType, "AnimalType");
                    }

                    this.AddToastMessage("System Data Loaded", $"retrieved {animalCount} animals from the system.", ToastType.Info);
                    _uow = null;
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error @:{DateTime.Now} ", ex);
            }
            
            return View("Index", viewModel);
        }

        public ActionResult SaveVaccineHistory(FarmViewModel model)
        {
            try
            {
                using (var context = new FmsDbContext())
                {
                    if (model != null)
                    {
                        _uow = new FmsUoW(context);
                        var updateRecord = _uow.AnimalRepo.FindSingle(p => p.Id == model.Animal.Id);
                        //var lookupDesc = _uow.LookupRepo.FindSingle(p => p.LookupId == model.Vaccine.VaccineType);
                        // model.Vaccine.VaccineName = lookupDesc.Description;
                        model.Vaccine.FK_Animal_Id = model.Animal.Id;
                        _uow.VaccineRepo.Add(model.Vaccine);
                        _uow.Commit();
                    }
                }
                this.AddToastMessage("Success!", $"Medical history for {model.Animal.Name} has been updated!", ToastType.Success);
            }
            catch (Exception ex)
            {
                log.Error($"Error @:{DateTime.Now} ", ex);
            }
            
            return RedirectToAction("ViewAnimalDetails", new { id = model.Animal.Id });
        }

        public ActionResult SaveAnimal(FarmViewModel model)
        {
            //AnimalValidator anVal = new AnimalValidator();
            try
            {
                using (var context = new FmsDbContext())
                {
                    if (model != null)
                    {
                        if (! ModelState.IsValid)
                        {
                            //var result = anVal.Validate(model.Animal);
                        }
                        _uow = new FmsUoW(context);
                        _uow.AnimalRepo.Add(model.Animal);
                        _uow.Commit();
                    }
                }
                this.AddToastMessage("Success!", "Animal saved to database!", ToastType.Success);
            }
            catch (Exception ex)
            {
                log.Error($"Error @:{DateTime.Now}" , ex);
            }

            return RedirectToAction("Index");
        }

        public ActionResult ViewAnimalDetails(int id)
        {
            FarmViewModel viewModel = new FarmViewModel();

            try
            {
                using (var context = new FmsDbContext())
                {
                    if (_uow == null)
                    {
                        _uow = new FmsUoW(context);
                    }

                    _uow = new FmsUoW(context);
                    var valueTypes = _uow.PickListRepo.GetAll().Where(p => p.ListType == "VAC").ToList();
                    foreach (var values in valueTypes)
                    {
                        viewModel.listValues.Add(new SelectListItem { Value = values.Value.ToString(), Text = values.Text });
                    }

                    viewModel.Animal = _uow.AnimalRepo.FindSingle(p => p.Id == id);
                    viewModel.Vaccines = _uow.VaccineRepo.FindMany(p => p.FK_Animal_Id == id).ToList();
                    foreach (var vacItem in viewModel.Vaccines)
                    {
                        vacItem.VaccineTypeText = GetAnimalType(Convert.ToInt32(vacItem.VaccineType), "VAC");
                        //vacItem.VacText = GetPickListCodeDescription(Convert.ToInt32(vacItem.VaccineType), vacItem.VaccineId);
                    }
                    
                    viewModel.Animal.AnimalTypeText = GetAnimalType(viewModel.Animal.AnimalType, "AnimalType");
                    viewModel.Animal.DonerStateText = GetAnimalType(viewModel.Animal.DonerState, "ST");

                    this.AddToastMessage("Success!", $"{viewModel.Animal.Name}, retrieved from database!", ToastType.Info);
                }
                _uow = null;
            }
            catch (Exception ex)
            {
                log.Error($"Error @:{DateTime.Now} ", ex);
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
            try
            {
                using (var context = new FmsDbContext())
                {
                    _uow = new FmsUoW(context);

                    var result = _uow.AnimalRepo.FindSingle(p => p.Id == id);
                    result.Archived = true;
                    _uow.Commit();
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error @:{DateTime.Now} ", ex);
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult RemoveMedicalHistory(int id, int animalId)
        {
            _uow = null;
            using (var context = new FmsDbContext())
            {
                if (_uow == null)
                {
                    _uow = new FmsUoW(context);
                }
                var result = _uow.VaccineRepo.FindSingle(p => p.VaccineId == id);
                _uow.VaccineRepo.Delete(result);
                _uow.Commit();
            }
            return ViewAnimalDetails(animalId);
        }

        private string GetAnimalType(int index, string listType)
        {
            string value = string.Empty;
            using (var context = new FmsDbContext())
            {
                if (_uow == null)
                {
                    _uow = new FmsUoW(context);
                }

                var lookupText = _uow.PickListRepo.FindMany(p => p.Value == index).Where(p => p.ListType == listType).First();
                value = lookupText.Text;
                //this.AddToastMessage("Animal Type Initializer", "Reading animals type..", ToastType.Info);
            }

            return value;
        }

        public ActionResult UpdateAnimalDetails(int id)
        {
            FarmViewModel model = new FarmViewModel();

            try
            {
                using (var context = new FmsDbContext())
                {
                    if (_uow == null)
                    {
                        _uow = new FmsUoW(context);
                    }
                    model.VaccinesList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "VAC").ToList());
                    model.StateList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "ST").OrderBy(p => p.Text).ToList());
                    model.Vaccines = _uow.VaccineRepo.FindMany(p => p.FK_Animal_Id == id).ToList();
                    model.AnimalTypeList = _util.GetPickList(_uow.PickListRepo.FindMany(p => p.ListType == "AnimalType").OrderBy(p => p.Text).ToList());
                    model.Animal = _uow.AnimalRepo.FindSingle(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error @:{DateTime.Now} ", ex);
            }

            return View("_RegisterAnimal", model);
        }

        private string GetPickListCodeDescription(string listType, int index)
        {
            PickListModel value = new PickListModel();
            try
            {
                using (var context = new FmsDbContext())
                {
                    if (_uow == null)
                    {
                        _uow = new FmsUoW(context);
                    }

                    value = context.PickList.Where(p => p.Value == index).Where(p => p.ListType == listType).First();
                }

                return value.Text;
            }
            catch (System.Exception)
            {

                throw;
            }
       
        }
    }
}
using System.Linq;
using System.Web.Mvc;
using WherePigsFlyFms.Data;
using WherePigsFlyFms.Toast;
using WherePigsFlyFms.UnitOfWork;
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
               
                viewModel.Animals = _uow.AnimalRepo.GetAll().ToList();
                foreach (var item in viewModel.Animals)
                {
                    var records = _uow.VaccineRepo.FindMany(p => p.FK_Animal_Id == item.Id);
                    var recordCnt = records.Count();
                    item.MedicalCount = recordCnt;
                }

                this.AddToastMessage("Success!", "Data retrieved from database!", ToastType.Success);
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
    }
}
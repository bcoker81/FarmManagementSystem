using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WherePigsFlyFms.Data;
using WherePigsFlyFms.Models;
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
                this.AddToastMessage("Success!", "Data retrieved from database!", ToastType.Success);
            }
            return View("Index", viewModel);
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

                var result = _uow.AnimalRepo.FindSingle(p => p.Id == id);
                viewModel.Animal = result;
                this.AddToastMessage("Success!", "Animal retrieved from database!", ToastType.Success);

            }

            return View("AnimalDetails", viewModel);
        }

        public ActionResult ViewMedicalDetails(int id)
        {
            //FarmViewModel viewModel = new FarmViewModel();
            //var result  = _uow.MedicalRepo.FindMany(p => p.FK_Animal_Id = id);

            return View();
        }
    }
}
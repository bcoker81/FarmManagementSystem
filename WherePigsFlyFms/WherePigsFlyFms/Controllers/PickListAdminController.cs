using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WherePigsFlyFms.Data;
using WherePigsFlyFms.Toast;
using WherePigsFlyFms.UnitOfWork;
using WherePigsFlyFms.ViewModels;

namespace WherePigsFlyFms.Controllers
{
    public class PickListAdminController : FarmBaseController
    {
        public ActionResult Index()
        {
            FarmViewModel viewModel = new FarmViewModel();

            using (var context = new FmsDbContext())
            {
                _uow = new FmsUoW(context);

                //viewModel.PickLists = _uow.PickListRepo.GetAll().ToList();
                this.AddToastMessage("Code Tables...", "Please select a list to modify.", ToastType.Success);
            }

            return View("PickListAdministration", viewModel);
        }

        public ActionResult CodeSelectionIndex(FarmViewModel model)
        {
            FarmViewModel viewModel = new FarmViewModel();

            using (var context = new FmsDbContext())
            {
                _uow = new FmsUoW(context);

                if (model.DropdownSelection == Models.PickListType.AnimalType)
                {
                    viewModel.PickLists = _uow.PickListRepo.FindMany(p => p.ListType == "AnimalType").ToList();
                }
                else if (model.DropdownSelection == Models.PickListType.Breed)
                {
                    viewModel.PickLists = _uow.PickListRepo.FindMany(p => p.ListType == "Breed").ToList();
                }
                else if (model.DropdownSelection == Models.PickListType.ST)
                {
                    viewModel.PickLists = _uow.PickListRepo.FindMany(p => p.ListType == "ST").ToList();
                }
                else if (model.DropdownSelection == Models.PickListType.VAC)
                {
                    viewModel.PickLists = _uow.PickListRepo.FindMany(p => p.ListType == "VAC").ToList();
                }
            }
            return View("PickListAdministration", viewModel);
        }
    }
}
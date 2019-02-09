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

                viewModel.PickLists = _uow.PickListRepo.GetAll().ToList();
                this.AddToastMessage("Codes loaded successfully...", "User the search feature to improve your efficiency", ToastType.Success);
            }

            return View("PickListAdministration", viewModel);
        }

        public ActionResult CodeSelectionIndex(FarmViewModel model)
        {
            FarmViewModel viewModel = new FarmViewModel();
            
            using (var context = new FmsDbContext())
            {
                _uow = new FmsUoW(context);

                viewModel.PickLists = _uow.PickListRepo.GetAll().ToList();

            }
            return View("PickListAdministration", viewModel);
        }
    }
}
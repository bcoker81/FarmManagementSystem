using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WherePigsFlyFms.Data;
using WherePigsFlyFms.Toast;
using WherePigsFlyFms.UnitOfWork;
using WherePigsFlyFms.Utilities;
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
                this.AddToastMessage("Codes loaded successfully...", "User the search feature to improve your efficiency", ToastType.Info);
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

        public ActionResult SaveCode(FarmViewModel model)
        {
            _uow = null;
            _util = new FmsUtilities();
            var listCount = 0;
            using (var context = new FmsDbContext())
            {
                if (_uow == null)
                {
                    _uow = new FmsUoW(context);
                }
                var doesExist = _uow.PickListRepo.FindMany(p => p.ListType == model.DropdownSelection.ToString()).Where(p => p.Text == model.Picklist.Text);

                if (doesExist != null)
                {
                    var masterList = _uow.PickListRepo.FindMany(p => p.ListType == model.DropdownSelection.ToString()).ToList();
                    listCount = masterList.Count();
                    model.Picklist.Value = _util.GenerateIndexNumber(masterList);
                    model.Picklist.ListType = model.DropdownSelection.ToString();
                    model.Picklist.Text = model.Picklist.Text.ToUpper();
                    _uow.PickListRepo.Add(model.Picklist);
                    _uow.Commit();
                }
                else
                {
                    this.AddToastMessage($"Oops!", "This code already exists in your database!", ToastType.Error);
                }
               

                _uow = null;
            }
            this.AddToastMessage($"Success! {listCount} items in {model.Picklist.ListType}", "New code added to the database.", ToastType.Success);
            return Index();
        }
    }
}
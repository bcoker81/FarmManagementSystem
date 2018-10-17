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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WherePigsFlyFms.UnitOfWork;

namespace WherePigsFlyFms.Controllers
{
    public class FarmBaseController : Controller
    {
       public static IFmsUoW _uow;
       
    }
}
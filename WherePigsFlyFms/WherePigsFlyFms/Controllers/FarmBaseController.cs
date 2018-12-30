using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WherePigsFlyFms.UnitOfWork;
using WherePigsFlyFms.Utilities;

namespace WherePigsFlyFms.Controllers
{
    public class FarmBaseController : Controller
    {
        public static IFmsUoW _uow = null;
        public static IFmsUtilities _util;
    }
}
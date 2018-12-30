using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WherePigsFlyFms.Models;
using WherePigsFlyFms.ViewModels;

namespace WherePigsFlyFms.Utilities
{
    public interface IFmsUtilities
    {
        AttachmentModel Upload(HttpPostedFileBase file, FarmViewModel viewModel);
        IEnumerable<SelectListItem> GetPickList(List<PickListModel> pickList);
        int GenerateIndexNumber(List<PickListModel> lists);
    }
}
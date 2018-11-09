using System.Web;
using WherePigsFlyFms.Models;
using WherePigsFlyFms.ViewModels;

namespace WherePigsFlyFms.Utilities
{
    public interface IFmsUtilities
    {
        AttachmentModel Upload(HttpPostedFileBase file, FarmViewModel viewModel);
    }
}
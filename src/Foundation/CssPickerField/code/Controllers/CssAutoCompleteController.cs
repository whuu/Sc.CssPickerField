using Sitecore.Web.UI;
using SmartSitecore.CssPickerField.Cache;
using System.Linq;
using System.Web.Mvc;

namespace SmartSitecore.CssPickerField.Controllers
{
    public class CssAutoCompleteController : Controller
    {
        [HttpGet]
        public ActionResult Load(string styles, string query)
        {
            return Json(new { suggestions = CssCacheManager.GetCache(styles).Get(query).Select(s => new { value = s, data = s }) }, JsonRequestBehavior.AllowGet);
        }
    }
}
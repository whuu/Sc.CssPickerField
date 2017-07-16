using SmartSitecore.CssPickerField.Cache;
using System.Linq;
using System.Web.Mvc;

namespace SmartSitecore.CssPickerField.Controllers
{
    public class CssAutoCompleteController : Controller
    {
        [HttpGet]
        public ActionResult Load(string query)
        {
            return Json(new { suggestions = CssCacheManager.GetCache().Get(query).Select(s => new { value = s, data = s }) }, JsonRequestBehavior.AllowGet);
        }
    }
}
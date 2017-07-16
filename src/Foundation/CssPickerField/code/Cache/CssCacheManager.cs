using SmartSitecore.CssPickerField.Repositories;
using SmartSitecore.CssPickerField.Models;

namespace SmartSitecore.CssPickerField.Cache
{
    public class CssCacheManager
    {
        private static CssCache _cache;

        public static CssCache GetCache()
        {
            if (_cache == null)
            {
                var repository = new CssRepository();
                _cache = new CssCache(repository.GetSettings().CacheSize, repository);
            }
            return _cache;
        }
    }
}
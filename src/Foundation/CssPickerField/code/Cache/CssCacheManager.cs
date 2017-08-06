using SmartSitecore.CssPickerField.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SmartSitecore.CssPickerField.Cache
{
    public class CssCacheManager
    {
        private static List<CssCache> _cache = new List<CssCache>();

        public static CssCache GetCache(string name = null)
        {
            var repository = new CssRepository();
            var settings = repository.GetSettings();
            var cacheName = string.IsNullOrEmpty(name) ? settings.StorageName : name;

            if (!_cache.Exists(x => x.Name == cacheName))
            {
                _cache.Add(new CssCache(cacheName, settings.CacheSize, repository));
            }
            return _cache.FirstOrDefault(x => x.Name == cacheName);
        }
    }
}
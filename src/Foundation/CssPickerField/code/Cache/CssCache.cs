using System.Collections.Generic;
using System.Linq;
using Sitecore.Caching;
using SmartSitecore.CssPickerField.Repositories;

namespace SmartSitecore.CssPickerField.Cache
{
    public class CssCache : CustomCache
    {
        private CssRepository _repository;

        public CssCache(long maxSize, CssRepository repository) : base("SmartSitecore.CssCache", maxSize)
        {
            _repository = repository;
        }

        public IEnumerable<string> Get(string key)
        {
            if (InnerCache.Count == 0)
            {
                Set();
            }
            var keys = InnerCache.GetCacheKeys().Where(s => s.ToLower().Contains(key.ToLower()));
            keys = keys.OrderBy(q => q).ToList();
            return keys;
        }

        private void Set()
        {
            var styles = _repository.GetStyles();
            foreach (var style in styles)
            {
                SetString(style, style);
            }
        }
    }
}
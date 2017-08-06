using System.Collections.Generic;
using System.Linq;
using Sitecore.Caching;
using SmartSitecore.CssPickerField.Repositories;

namespace SmartSitecore.CssPickerField.Cache
{
    public class CssCache : CustomCache
    {
        private ICssRepository _repository;

        public CssCache(string name, long maxSize, ICssRepository repository) : base(name, maxSize)
        {
            _repository = repository;
        }

        public IEnumerable<string> Get(string key)
        {
            var keys = InnerCache.GetCacheKeys().Where(s => s.ToLower().Contains(key.ToLower()));
            keys = keys.OrderBy(q => q).ToList();
            return keys;
        }

        public void Set(string[] paths = null)
        {
            if (InnerCache.Count == 0)
            {
                var styles = _repository.GetStyles(paths);
                foreach (var style in styles)
                {
                    SetString(style, style);
                }
            }
        }
    }
}
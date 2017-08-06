using System.Collections.Generic;
using System.Linq;
using Sitecore.Caching;
using SmartSitecore.CssPickerField.Repositories;
using SmartSitecore.CssPickerField.Models;

namespace SmartSitecore.CssPickerField.Cache
{
    public class CssCache
    {
        private ICssRepository _repository;

        private Sitecore.Caching.Cache _cache;

        private string _cacheKey = "css.list";

        private string _name;

        public string Name { get
            {
                return _name;
            }
        }

        public CssCache(string name, long maxSize, ICssRepository repository)
        {
            _repository = repository;
            _name = name;
            _cache = new Sitecore.Caching.Cache(name, maxSize);
        }

        public IEnumerable<string> Get(string key)
        {
            var cacheable = _cache.GetValue(_cacheKey) as CacheableList;
            if (cacheable == null)
            {
                return new List<string>();
            }
            var keys = cacheable.Words.Where(s => s.ToLower().Contains(key.ToLower()));
            return keys.OrderBy(q => q).ToList();
        }

        public void Set(string[] paths = null)
        {
            var cacheable = _cache.GetValue(_cacheKey) as CacheableList;
            if (cacheable == null)
            {
                var styles = _repository.GetStyles(paths);
                cacheable = new CacheableList()
                {
                    Words = styles.ToList()
                };
                _cache.Add(_cacheKey, cacheable);
            }
        }
    }
}

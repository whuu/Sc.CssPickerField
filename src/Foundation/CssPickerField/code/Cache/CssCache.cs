using System.Collections.Generic;
using System.Linq;
using SmartSitecore.CssPickerField.Repositories;
using SmartSitecore.CssPickerField.Models;

namespace SmartSitecore.CssPickerField.Cache
{
    public class CssCache
    {
        private ICssRepository _repository;

        private Sitecore.Caching.Cache _cache;

        private string _cacheKey = "css.list";

        public CssCache(long maxSize, ICssRepository repository)
        {
            _repository = repository;
            _cache = new Sitecore.Caching.Cache("cache css", maxSize);
        }

        public IEnumerable<string> Get(string phrase)
        {
            var cacheable = _cache.GetValue(_cacheKey) as CacheableList;
            if (cacheable == null)
                cacheable = Set();
            var keys = cacheable.Words.Where(s => s.ToLower().Contains(phrase.ToLower()));
            return keys.OrderBy(q => q).ToList();
        }

        private CacheableList Set()
        {
            var styles = _repository.GetStyles();
            var cacheable = new CacheableList();
            cacheable.Words = styles.ToList();
            _cache.Add(_cacheKey, cacheable);
            return cacheable;
        }
    }
}
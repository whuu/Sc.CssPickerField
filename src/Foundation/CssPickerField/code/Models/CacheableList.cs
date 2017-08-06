using Sitecore.Caching;
using System;
using System.Collections.Generic;

namespace SmartSitecore.CssPickerField.Models
{
    [Serializable]
    public class CacheableList : ICacheable
    {
        public List<string> Words { get; set; }

        public bool Cacheable { get; set; }

        public bool Immutable
        {
            get { return true; }
        }

        public event DataLengthChangedDelegate DataLengthChanged;

        public CacheableList()
        {
            Cacheable = true;
        }

        long ICacheable.GetDataLength()
        {
            System.IO.MemoryStream mem = new System.IO.MemoryStream();
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binFormatter.Serialize(mem, this);
            return (long) Convert.ToInt32(mem.Length);
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartSitecore.CssPickerField.Models
{
    public class CssPickerSettings
    {
        public List<string> Paths { get; private set; }

        public long CacheSize { get; set; }

        public string StorageName
        {
            get
            {
                return string.Join(",", Paths);
            }
        }

        public CssPickerSettings()
        {
            this.Paths = new List<string>();
        }
    }
}
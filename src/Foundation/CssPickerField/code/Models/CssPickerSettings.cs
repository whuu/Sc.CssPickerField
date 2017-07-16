using System.Collections.Generic;

namespace SmartSitecore.CssPickerField.Models
{
    public class CssPickerSettings
    {
        public List<string> Paths { get; private set; }

        public long CacheSize { get; set; }

        public CssPickerSettings()
        {
            this.Paths = new List<string>();
        }
    }
}
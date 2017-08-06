using System.Collections.Generic;
using SmartSitecore.CssPickerField.Models;

namespace SmartSitecore.CssPickerField.Repositories
{
    public interface ICssRepository
    {
        CssPickerSettings GetSettings();

        IEnumerable<string> GetStyles(string[] paths);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using SmartSitecore.CssPickerField.Models;
using ExCSS;

namespace SmartSitecore.CssPickerField.Repositories
{
    public class CssRepository
    {
        public CssPickerSettings GetSettings()
        {
            var settings = Sitecore.Configuration.Factory.CreateObject("cssPickerStyles/stringlistmap", true) as CssPickerSettings;
            return settings;
        }

        public IEnumerable<string> GetStyles()
        {
            var styles = new List<string>();
            try
            {
                var settings = GetSettings();
                foreach (var path in settings.Paths)
                {
                    styles.AddRange(GetStylesFromFile(path));
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("CssPicker: Can't load styles settings", ex, this);
            }
            return styles;
        }

        private IEnumerable<string> GetStylesFromFile(string path)
        {
            var file = File.ReadAllText(HttpContext.Current.Server.MapPath(path));
            var parser = new Parser();
            var stylesheet = parser.Parse(file);

            var classes = new List<string>();
            foreach (var rule in stylesheet.StyleRules)
            {
                if (!rule.Value.StartsWith("."))
                    continue;

                var rawClasses = rule.Value.Split('.');
                foreach (var rawClassName in rawClasses)
                {
                    var className = rawClassName.Split(new[] { " ", ":", ",", ")", "[", ">", "~", "+" }, StringSplitOptions.None)[0];
                    if (!classes.Contains(className) && !string.IsNullOrEmpty(className))
                    {
                        classes.Add(className);
                    }
                }
            }
            return classes;
        }
    }
}
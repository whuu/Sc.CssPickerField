using Sitecore;
using SmartSitecore.CssPickerField.Cache;
using System;

namespace SmartSitecore.CssPickerField.Fields
{
    /// <summary>
    /// Css style picker field
    /// </summary>
    public class StylePickerField : AutoCompleteTextField.Fields.AutoCompleteText
    {
        protected string StylesParameterName = "Styles";

        /// <summary>
        /// Comma separated Css file paths, override settings from file
        /// </summary>
        public string Styles { get; set; }

        /// <summary>
        /// Datasource of Field
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Autocomplete API endpoint address
        /// </summary>
        /// <returns></returns>
        protected override string GetDatasourceUrl()
        {
            return $"/api/sitecore/CssAutoComplete/Load?styles={Styles}";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!Sitecore.Context.ClientPage.IsEvent)
            {
                SetStyles();
            }
        }

        /// <summary>
        /// Read styles from field datasource or configuration file and add to the cache
        /// </summary>
        protected virtual void SetStyles()
        {
            var str = StringUtil.GetString(new string[1]
            {
                Source
            });
            Styles = StringUtil.ExtractParameter(StylesParameterName, str);
            if (!string.IsNullOrEmpty(Styles))
            {
                var paths = Styles.Split(',');
                CssCacheManager.GetCache(Styles).Set(paths);
            }
            else
            {
                CssCacheManager.GetCache().Set();
            }
        }
    }
}
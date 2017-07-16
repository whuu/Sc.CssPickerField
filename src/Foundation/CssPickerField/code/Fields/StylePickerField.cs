namespace SmartSitecore.CssPickerField.Fields
{
    /// <summary>
    /// Css style picker field
    /// </summary>
    public class StylePickerField : AutoCompleteTextField.Fields.AutoCompleteText
    {
        protected override string GetDatasourceUrl()
        {
            return "/api/sitecore/CssAutoComplete/Load";
        }
    }
}
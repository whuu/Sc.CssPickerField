# Sc.CssPickerField

Sitecore Single-line Text Field with Css classes autocompletion. Based on [Sc.AutoCompleteTextField](https://github.com/whuu/Sc.AutoCompleteTextField) 

## Usage
* Add new field with `Css Picker` type to your templates, or add base template `/sitecore/templates/Foundation/CssPicker/_CssPicker` to your existing template.
* Replace paths to css files in `/App_Config/Include/CssPickerField/SmartSitecore.CssPicker.config` or use Sitecore patch to add your css files. 
* Alternatively add `styles=` in field data source with paths to css files, separated with comma:
![Css picker field datasource](https://raw.githubusercontent.com/whuu/Sc.CssPickerField/master/img/css-picker-with-datasource.png)
* Paths entered in field's data source replace the one defined in configuration file. 
* Go to the item based on the template and start writing css class name, Css classses appears in a suggestions list and can be picked:

![Css picker field](https://raw.githubusercontent.com/whuu/Sc.CssPickerField/master/img/css-picker-field.png)

Css Picker can be used also on component's rendering parameters to improve content editors experience:
* Add `/sitecore/templates/System/Layout/Rendering Parameters/Standard Rendering Parameters` to base templates in `_CssPicker` template or your custom template with `Css Picker` field. 
Select `_CssPicker`, or your custom template in Parameters Template field of the rendering definition item.
Open properties of your component in content or experience editor and start writing css class name:
![Css picker field](https://raw.githubusercontent.com/whuu/Sc.CssPickerField/master/img/css-picker-in-rendering-params.PNG.png)
* Use rendering parameters in code:
* In  standard Sitecore MVC controller:

  `var selectedCss = RenderingContext.Current.Rendering.Parameters["Css Class"];`
*In Glass Mapper MVC (where MyParameters is a Model class for corresponding template):

  `var selectedCss = GetRenderingParameters<MyParameters>().Css_Class;`


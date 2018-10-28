using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShop.TagHelpers
{
    [HtmlTargetElement(Attributes = "is-active-route")]
    public class ActiveRouteTagHelper : TagHelper
    {
        private IDictionary<string, string> _routeValues;

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
        public IDictionary<string, string> RouteValues
        {
            get => _routeValues ?? (_routeValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
            set => _routeValues = value;
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (ShouldBeActive())
            {
                MakeActive(output);
            }

            output.Attributes.RemoveAll("is-active-route");
        }

        private void MakeActive(TagHelperOutput output)
        {
            var classAttr = output.Attributes.FirstOrDefault(x => x.Name == "class");

            if (classAttr == null)
            {
                classAttr = new TagHelperAttribute("class", "active");
                output.Attributes.Add(classAttr);
            }
            else if (classAttr.Value == null || classAttr.Value.ToString().IndexOf("active", StringComparison.Ordinal) < 0)
            {
                output.Attributes.SetAttribute("class", classAttr.Value == null ? "active" : classAttr.Value + " active");
            }
        }

        private bool ShouldBeActive()
        {
            var currentController = ViewContext.RouteData.Values["Controller"].ToString();
            var currentAction = ViewContext.RouteData.Values["Action"].ToString();

            if (!string.IsNullOrWhiteSpace(Controller) && !string.Equals(Controller, currentController, StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(Action) && !string.Equals(Action, currentAction, StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            foreach (var item in RouteValues)
            {
                if (!ViewContext.RouteData.Values.ContainsKey(item.Key) || ViewContext.RouteData.Values[item.Key].ToString() != item.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

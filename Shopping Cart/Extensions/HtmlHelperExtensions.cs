using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Shopping_Cart.Models;

namespace Shopping_Cart.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString HtmlConvertToJson(this HtmlHelper htmlHelper, object model)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };
            return new HtmlString(JsonConvert.SerializeObject(model,settings));
        }

        public static MvcHtmlString BuildSortableLink(this HtmlHelper htmlHelper, string fieldName,
            string actionName, string sortField, QueryOptions queryOptions)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var isCurrentSortField = queryOptions.SortField == sortField;
            return new MvcHtmlString(string.Format("<a href=\"{0}\">{1} {2}</a>",
                urlHelper.Action(actionName,
                new
                {
                    SortField=sortField,
                    SortOrder=(isCurrentSortField && queryOptions.SortOrder==SortOrder.Ascending)
                    ? SortOrder.Descending : SortOrder.Ascending
                }),
        fieldName,
            BuildSortIcon(isCurrentSortField,queryOptions)));
        }

        private static string BuildSortIcon(bool isCurrentSortField, QueryOptions queryOptions)
        {
            var sortIcon = "sort";
            if (isCurrentSortField)
            {
                sortIcon += "-by-alphabet";
                if (queryOptions.SortOrder == SortOrder.Descending)
                    sortIcon += "-alt";
            }
            return $"<span class=\"glyphicon glyphicon-{sortIcon}\"></span>";
        }
    }
}
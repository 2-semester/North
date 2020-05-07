using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace North.Pages.Extensions
{
    public static class TableRowForHtmlExtension
    {
        public static IHtmlContent TableRowFor(
            this IHtmlHelper htmlHelper, string page, object index,
            params IHtmlContent[] values)
        {
            var s = htmlStrings(page, index, values);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings(string page, object index, IHtmlContent[] values)
        {
            var list = new List<object>();
            foreach (var value in values) addValue(list, value);
            list.Add(new HtmlString("<td>"));
            list.Add(new HtmlString($"<a href=\"{page}/Edit?id={index}\">{Constants.EditLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Details?id={index}\">{Constants.DetailsLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Delete?id={index}\">{Constants.DeleteLinkTitle}</a>"));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        public static IHtmlContent TableRowFor(
            this IHtmlHelper htmlHelper, string page, object index,
            string fixedFilter, string fixedValue,

            params IHtmlContent[] values)
        {
            var s = htmlStrings(page, index, fixedFilter, fixedValue, values);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings(string page, object index, string fixedFilter, string fixedValue, IHtmlContent[] values)
        {
            var list = new List<object>();
            foreach (var value in values) addValue(list, value);
            list.Add(new HtmlString("<td>"));
            list.Add(new HtmlString($"<a href=\"{page}/Edit?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.EditLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Details?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.DetailsLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Delete?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.DeleteLinkTitle}</a>"));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        public static IHtmlContent TableRowWithoutEditFor(
            this IHtmlHelper htmlHelper, string page, object index,

            params IHtmlContent[] values)
        {
            var s = htmlStringsWithoutEdit(page, index, values);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStringsWithoutEdit(string page, object index, IHtmlContent[] values)
        {
            var list = new List<object>();
            foreach (var value in values) addValue(list, value);
       
            list.Add(new HtmlString("<td>"));
            list.Add(new HtmlString($"<a href=\"{page}/Details?id={index}\">{Constants.DetailsLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Delete?id={index}\">{Constants.DeleteLinkTitle}</a>"));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        public static IHtmlContent TableRowWithoutEditFor(
            this IHtmlHelper htmlHelper, string page, object index,
            string fixedFilter, string fixedValue,

            params IHtmlContent[] values)
        {
            var s = htmlStringsWithoutEdit(page, index, fixedFilter, fixedValue, values);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStringsWithoutEdit(string page, object index, string fixedFilter, string fixedValue, IHtmlContent[] values)
        {
            var list = new List<object>();
            foreach (var value in values) addValue(list, value);
            list.Add(new HtmlString("<td>"));
            list.Add(new HtmlString($"<a href=\"{page}/Details?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.DetailsLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Delete?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.DeleteLinkTitle}</a>"));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        internal static void addValue(List<object> htmlStrings, IHtmlContent value)
        {
            if (htmlStrings is null) return;
            if (value is null) return;
            htmlStrings.Add(new HtmlString("<td>"));
            htmlStrings.Add(value);
            htmlStrings.Add(new HtmlString("</td>"));
        }
    }
}
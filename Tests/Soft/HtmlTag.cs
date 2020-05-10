using North.Tests.Soft;

namespace North.Tests.Soft {

    public static class HtmlTag {

        public static string Header => "text/html; charset=utf-8";
        public static string IndexForm(string url) => $"<form id=\"indexForm\" method=\"get\" action=\"{url}\">";

        public static string Edit<T>(HtmlTagArgs<T> a) {
            var value = HtmlHelper.Value(a.Value, true);
            var head = formGroup + label(a.Name, a.DisplayName) + input;
            var data = dataVal;
            var isRequired = HtmlTag.required(a.Name);
            var isNumber = number(a.Name);
            var tail = item(a.Name) + type(a.Type, value) + validation(a.Name);
            var required = data + (a.IsNumber ? isNumber : string.Empty) + isRequired;
            var html = head + (a.IsRequired ? required : string.Empty) + tail;

            return html;
        }

        public static string Select<TView>(HtmlTagArgs<TView> a) {
            var head = formGroup + label(a.Name, a.DisplayName) + beginSelect;
            var required = dataVal + HtmlTag.required(a.DisplayName);
            var tail = item(a.Name) + endSelect + validation(a.Name);

            var html = head + (a.IsRequired ? required : string.Empty) + tail;

            return html;
        }

        public static string Display<TView>(HtmlTagArgs<TView> a) {
            var v = HtmlHelper.Value(a.Value);
            var html = display(a.DisplayName, v);

            return html;
        }

        private static string formGroup => "<div class=\"form-group\">";
        private static string dataVal => " data-val=\"true\"";
        private static string beginSelect => "<select class=\"form-control\"";
        private static string endSelect => "></select>";
        private static string input => "<input class=\"form-control text-box single-line\"";

        private static string type(string type, string value) => $" type=\"{type}\" value=\"{value}\" />";

        private static string label(string name, string displayName)
            => $"<label class=\"text-dark\" for=\"Item_{name}\">{displayName}</label>";

        private static string display(string name, string value) =>
            $"<dt class=\"col-sm-2\">{name}</dt><dd class=\"col-sm-10\">{value}</dd>";

        private static string validation(string name) =>
            $"<span class=\"field-validation-valid text-danger\" data-valmsg-for=\"Item.{name}\" " +
            "data-valmsg-replace=\"true\"></span></div>";

        private static string required(string name) => $" data-val-required=\"The {name} field is required.\"";

        private static string number(string name) => $" data-val-number=\"The field {name} must be a number.\"";

        private static string item(string name) => $" id=\"Item_{name}\" name=\"Item.{name}\"";

    }

}

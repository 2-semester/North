using System;
using System.Linq.Expressions;
using North.Tests.Soft;
using North.Aids;

namespace North.Tests.Soft {

    public class HtmlTagArgs<T> {

        public HtmlTagArgs(object obj, Expression<Func<T, object>> e, in bool isRequired = false, in bool isNumber= false) {
           IsRequired = isRequired;
           IsNumber = isNumber;
           DisplayName = GetMember.DisplayName(e);
           Name = GetMember.Name(e);
           var p = obj?.GetType().GetProperty(Name);
           Value = p?.GetValue(obj);
           Type = HtmlHelper.Type<T>(Name);
        }

        public bool IsRequired { get; set; }
        public bool IsNumber { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }

    }

}

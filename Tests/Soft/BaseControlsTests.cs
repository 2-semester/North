using System;
using System.Linq.Expressions;
using North.Tests.Soft;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;

namespace North.Tests.Soft {

    public abstract class BaseControlsTests<TView, TData, TContext>
        : BaseDataTests<TData, TContext> where TContext : DbContext where TData: PeriodData {

        protected void canView(TData o, Expression<Func<TView, object>> e, string value = null) {
            var a = new HtmlTagArgs<TView>(o, e);
            a.Value = value ?? a.Value;
            var expected = HtmlTag.Display(a);

            if (pageHtml.Contains(expected)) return;
            Assert.AreEqual(pageHtml, expected);
        }

        protected void canEdit(TData o, Expression<Func<TView, object>> e,
            bool isRequired = false, bool isNumber = false) {
            var a = new HtmlTagArgs<TView>(o, e, isRequired, isNumber);
            var expected = HtmlTag.Edit(a);

            if (pageHtml.Contains(expected)) return;
            Assert.AreEqual(pageHtml, expected);
        }

        protected void canSelect(TData o, Expression<Func<TView, object>> e,
            bool isRequired = false) {
            var a = new HtmlTagArgs<TView>(o, e, isRequired);
            var expected = HtmlTag.Select(a);

            if (pageHtml.Contains(expected)) return;
            Assert.AreEqual(pageHtml, expected);
        }

    }

}

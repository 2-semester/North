﻿using System;
using System.Collections.Generic;
using System.Text;
using North.Data.SportCategoryType;
using North.Domain.SportCategoryType;
using North.Facade.SportCategoryType;

namespace North.Pages.SportCategoryType
{
    public class SportCategoryTypesPage : CommonPage<ISportCategoryTypesRepository, SportCategoryTypeDomain,
        SportCategoryTypeView, SportCategoryTypeData>
    {
        protected internal SportCategoryTypesPage(ISportCategoryTypesRepository r) : base(r)
        {
            PageTitle = "Spordiala";
        }

        public override string ItemId => Item.Id;

        protected internal override string getPageUrl() => "/SportCategoryType/SportCategoryTypes";

        protected internal override SportCategoryTypeDomain toObject(SportCategoryTypeView view)
        {
            return SportCategoryTypeViewFactory.Create(view);
        }

        protected internal override SportCategoryTypeView toView(SportCategoryTypeDomain obj)
        {
            return SportCategoryTypeViewFactory.Create(obj);
        }
    }
}

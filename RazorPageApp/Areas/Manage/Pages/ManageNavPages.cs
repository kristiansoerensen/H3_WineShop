// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPageApp.Areas.Manage.Pages
{
    public static class ManageNavPages
    {
        public static string Index => "Index";
        public static string ProductIndex => "ProductIndex";
        public static string CategoryIndex => "CategoryIndex";
        public static string BrandIndex => "BrandIndex";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string ProductIndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, ProductIndex);
        public static string CategoryIndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, CategoryIndex);
        public static string BrandIndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, BrandIndex);


        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}

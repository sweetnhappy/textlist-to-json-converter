﻿using System.Web;
using System.Web.Mvc;

namespace TextList_To_Json_Converter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
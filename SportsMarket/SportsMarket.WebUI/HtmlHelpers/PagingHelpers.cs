﻿using SportsMarket.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SportsMarket.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo paginginfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for( int i = 1; i <= paginginfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if( i == paginginfo.CurrentPage)
                {
                    tag.AddCssClass("Selected");
                    tag.AddCssClass("btn-btn-primary");

                }
                tag.AddCssClass("btn-btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        } 
    }
}
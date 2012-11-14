using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloakedRobot.Web.Areas.Admin.Models;

namespace CloakedRobot.Web.Areas.Admin.Helpers
{
    public static class MenuUtil
    {
        public static IList<MenuItem> GetTopMenu(UrlHelper url)
        {
            var items = new List<MenuItem>
			            	{
			            		new MenuItem { Title = "Back To Blog", Url = "/" },
                                new MenuItem { Title = "Dashboard", Url = url.Action("Dashboard", "Home", new { area = "Admin" }), Icon = "icon-play" },
			            		new MenuItem { Title = "Write New Post", Url = url.Action("New", "Post"), Icon = "icon-pencil" },
                                new MenuItem { Title = "Posts", Url = url.Action("List", "PostList"), Icon = "icon-file" },
			            	};

            AnalyzeMenuItems(items, url.RequestContext.HttpContext.Request.Url ?? new Uri("/admin"));

            return items;
        }

        private static void AnalyzeMenuItems(IEnumerable<MenuItem> items, Uri currentUri)
        {
            foreach (var menu in items)
            {
                if (menu.SubMenus != null)
                {
                    if (menu.Url == null)
                    {
                        menu.Url = (menu.SubMenus.FirstOrDefault() ?? new MenuItem()).Url;
                    }
                    AnalyzeMenuItems(menu.SubMenus, currentUri);
                }
                menu.IsCurrent = currentUri.AbsolutePath == menu.Url;
            }
        }
    }
}
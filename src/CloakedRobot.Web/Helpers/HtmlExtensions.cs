using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloakedRobot.Web.Helpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Html5DateTag(this HtmlHelper html, DateTimeOffset timestamp)
        {
            return MvcHtmlString.Create(string.Format(@"<time datetime=""{0}"">{1}</time>", timestamp.ToString("yyyy-MM-ddTHH:mm"), timestamp.ToString("dddd, dd MMMM yyyy")));
        }

        public static MvcHtmlString Html5DateTimeTag(this HtmlHelper html, DateTimeOffset timestamp)
        {
            return MvcHtmlString.Create(string.Format(@"<time datetime=""{0}"">{1}</time>", timestamp.ToString("yyyy-MM-ddTHH:mm"), timestamp.ToString("dddd, dd MMMM yyyy, HH:mm")));
        }

        public static MvcHtmlString Html5MinutesAgoTag(this HtmlHelper html, DateTimeOffset timestamp)
        {
            return MvcHtmlString.Create(string.Format(@"<time datetime=""{0}"">{1}</time>", timestamp.ToString("yyyy-MM-ddTHH:mm"),
                DateTimeOffset.Now.Subtract(timestamp).ToReadableString()
                ));
        }
    }
}
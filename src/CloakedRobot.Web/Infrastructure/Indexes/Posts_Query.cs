using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloakedRobot.Web.Models;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace CloakedRobot.Web.Infrastructure.Indexes
{
    public class Posts_Query : AbstractIndexCreationTask<Post>
    {
        public Posts_Query()
        {
            Map = posts => from post in posts
                           select new
                           {
                               post.Title,
                               post.DatePublished
                           };

            Index(x => x.Title, FieldIndexing.Analyzed);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloakedRobot.Web.Areas.Admin.Controllers;
using CloakedRobot.Web.Models;
using Rhino.Mocks;
using Xunit;

namespace Testing.CloakedRobot.Web.BlogConfigTests
{
    public class BlogConfigControllerTests : BlogControllerTests
    {
        [Fact]
        public void WhenTheBlogConfigIsAvailable_ThePropertyShouldReturnTheConfig()
        {
            var config = new BlogConfig { Title = "Test Config", Id = "blog/config" };
            SetupData(session => session.Store(config));

            BlogConfig configFromController = null;
            ExecuteAction<LoginController>(controller => configFromController = controller.BlogConfig);

            Assert.Equal(config.Title, configFromController.Title);
        }

        [Fact]
        public void WhenTheBlogConfigIsNotAvailable_AndWhenNotOnWelcomeController_ThePropertyShouldRedirectToRelativeWelcome()
        {
            ExecuteAction<LoginController>(controller =>
            {
                controller.RouteData.Values.Add("controller", "not the welcome controller");
                var _ = controller.BlogConfig;
            });

            ControllerContext.HttpContext.Response.AssertWasCalled(x => x.Redirect("~/welcome", true));
        }

        [Fact]
        public void WhenTheBlogConfigIsNotAvailable_AndWhenOnWelcomeController_ThePropertyShouldNotRedirect()
        {
            ExecuteAction<LoginController>(controller =>
            {
                controller.RouteData.Values.Add("controller", "welcome");
                var _ = controller.BlogConfig;
            });

            ControllerContext.HttpContext.Response.AssertWasNotCalled(x => x.Redirect("~/welcome", true));
        }
    }
}

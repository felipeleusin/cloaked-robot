using CloakedRobot.Web.Infrastructure;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Listeners;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Testing.CloakedRobot
{
    public abstract class BlogControllerTests : IDisposable
    {
        private readonly EmbeddableDocumentStore documentStore;
        protected ControllerContext ControllerContext { get; set; }

        protected BlogControllerTests()
        {
            documentStore = new EmbeddableDocumentStore
                            {
                                RunInMemory = true
                            };

            documentStore.RegisterListener(new NoStaleQueriesAllowed());
            documentStore.Initialize();
        }

        protected void SetupData(Action<IDocumentSession> action)
        {
            using (var session = documentStore.OpenSession())
            {
                action(session);
                session.SaveChanges();
            }
        }

        public class NoStaleQueriesAllowed : IDocumentQueryListener
        {
            public void BeforeQueryExecuted(IDocumentQueryCustomization queryCustomization)
            {
                queryCustomization.WaitForNonStaleResults();
            }
        }

        public void Dispose()
        {
            documentStore.Dispose();
        }

        protected void ExecuteAction<TController>(Action<TController> action)
            where TController : BlogController, new()
        {
            var controller = new TController { RavenSession = documentStore.OpenSession() };

            var httpContext = MockRepository.GenerateStub<HttpContextBase>();
            httpContext.Stub(x => x.Response).Return(MockRepository.GenerateStub<HttpResponseBase>());
            ControllerContext = new ControllerContext(httpContext, new RouteData(), controller);
            controller.ControllerContext = ControllerContext;

            action(controller);

            controller.RavenSession.SaveChanges();
        }
    }
}

using Microsoft.Owin;
using Owin;
using ProdutosDevIO.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartupAttribute(typeof(ProdutosDevIO.Startup))]
namespace ProdutosDevIO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            DependencyInjectionConfig.RegisterDIContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CultureConfig.RegisterCulture();
        }
    }
}

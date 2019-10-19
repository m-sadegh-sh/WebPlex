namespace WebPlex.Web {
	using System.Security.Principal;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;

	using Autofac;
	using Autofac.Integration.Mvc;

	using WebPlex.Core;
	using WebPlex.Web.Security;

	public sealed class WebTypesModule : Module {
		protected override void Load(ContainerBuilder builder) {
			builder.Register(cc => new HttpContextWrapper(HttpContext.Current)).As<HttpContextBase>().InstancePerHttpRequest();
			builder.Register(cc => cc.Resolve<HttpContextBase>().Request).InstancePerHttpRequest();
			builder.Register(cc => cc.Resolve<HttpContextBase>().Response).InstancePerHttpRequest();
			builder.Register(cc => cc.Resolve<HttpContextBase>().Cache).InstancePerHttpRequest();
			builder.Register(cc => cc.Resolve<HttpContextBase>().Session).InstancePerHttpRequest();
			builder.Register(cc => cc.Resolve<HttpContextBase>().Server).InstancePerHttpRequest();
			builder.Register(cc => cc.Resolve<HttpContextBase>().User ?? new FakePrincipal()).InstancePerHttpRequest();
			builder.Register(cc => cc.Resolve<IPrincipal>().Identity).InstancePerHttpRequest();
			builder.Register(cc => new RequestContext(cc.Resolve<HttpContextBase>(), new RouteData())).InstancePerHttpRequest();
			builder.Register(cc => new UrlHelper(cc.Resolve<RequestContext>())).InstancePerHttpRequest();

			builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerHttpRequest();
			builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerHttpRequest();

			builder.RegisterType<AuthorizationService>().As<IAuthorizationService>().InstancePerHttpRequest();
		}
	}
}
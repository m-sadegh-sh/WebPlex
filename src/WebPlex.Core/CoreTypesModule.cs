namespace WebPlex.Core {
	using System.Web.Caching;

	using Autofac;
	using Autofac.Integration.Mvc;

	using WebPlex.Core.Caching;
	using WebPlex.Core.Configuration;

	public sealed class CoreTypesModule : Module {
		protected override void Load(ContainerBuilder builder) {
			builder.RegisterInstance(BootstrapConfig.Current).SingleInstance();
			builder.Register(cc => new CacheManager(cc.Resolve<Cache>())).As<ICacheManager>().InstancePerHttpRequest();
		}
	}
}
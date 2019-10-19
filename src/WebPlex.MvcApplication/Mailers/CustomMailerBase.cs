namespace WebPlex.MvcApplication.Mailers {
	using System.Web.Routing;

	using Mvc.Mailer;

	using WebPlex.Core;
	using WebPlex.Core.Domain.Settings;
	using WebPlex.Core.Engine;
	using WebPlex.Services.Impl.Security;

	public abstract class CustomMailerBase : MailerBase {
		protected override void Initialize(RequestContext requestContext) {
			base.Initialize(requestContext);

			Logger = EngineContext.Current.Resolve<ILogService>();
			WorkContext = EngineContext.Current.Resolve<IWorkContext>();
			WebHelper = EngineContext.Current.Resolve<IWebHelper>();
			Application = EngineContext.Current.Resolve<ApplicationSettings>();
		}

		protected ILogService Logger { get; private set; }

		protected IWorkContext WorkContext { get; private set; }

		protected IWebHelper WebHelper { get; private set; }

		protected ApplicationSettings Application { get; private set; }
	}
}
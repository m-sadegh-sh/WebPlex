namespace WebPlex.Web.Mvc {
	using System.IO;
	using System.Text;
	using System.Web.Mvc;
	using System.Web.WebPages;

	using Microsoft.Ajax.Utilities;

	using WebPlex.Core;
	using WebPlex.Core.Domain.Settings;
	using WebPlex.Core.Engine;
	using WebPlex.Services.Helpers;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Web.Mvc.UI.Builders;

	public abstract class PlexViewPage<TModel> : WebViewPage<TModel> {
		public override void InitHelpers() {
			base.InitHelpers();

			Logger = EngineContext.Current.Resolve<ILogService>();
			WorkContext = EngineContext.Current.Resolve<IWorkContext>();
			WebHelper = EngineContext.Current.Resolve<IWebHelper>();
			DateTimeHelper = EngineContext.Current.Resolve<IDateTimeHelper>();
			Application = EngineContext.Current.Resolve<ApplicationSettings>();
		}

		protected ILogService Logger { get; private set; }

		protected IWorkContext WorkContext { get; private set; }

		protected IWebHelper WebHelper { get; private set; }

		protected IDateTimeHelper DateTimeHelper { get; private set; }

		protected ApplicationSettings Application { get; private set; }

		public TitleBuilder Title {
			get {
				if (ViewBag.Title == null)
					ViewBag.Title = new TitleBuilder();

				return ViewBag.Title;
			}
		}

		public KeywordsBuilder Keywords {
			get {
				if (ViewBag.Keywords == null)
					ViewBag.Keywords = new KeywordsBuilder();

				return ViewBag.Keywords;
			}
		}

		public DescriptionBuilder Description {
			get {
				if (ViewBag.Description == null)
					ViewBag.Description = new DescriptionBuilder();

				return ViewBag.Description;
			}
		}

		public NavbarBuilder Navbar {
			get {
				if (ViewBag.Navbar == null)
					ViewBag.Navbar = new NavbarBuilder();

				return ViewBag.Navbar;
			}
		}

		public BreadcrumbBuilder Breadcrumb {
			get {
				if (ViewBag.Breadcrumb == null)
					ViewBag.Breadcrumb = new BreadcrumbBuilder();

				return ViewBag.Breadcrumb;
			}
		}

		protected HelperResult RenderScripts() {
			var scripts = new StringBuilder();

			RenderSection("Scripts", false).WriteTo(new StringWriter(scripts));

			var originalScripts = scripts.ToString();

			if (string.IsNullOrWhiteSpace(originalScripts))
				return null;

			var minifiedScripts = new Minifier().MinifyJavaScript(originalScripts, new CodeSettings {
					EvalTreatment = EvalTreatment.MakeImmediateSafe,
					PreserveImportantComments = false
			});

			return new HelperResult(tw => tw.Write("<script type=\"text/javascript\">$(function(){{{0}}});</script>", minifiedScripts));
		}

		protected HelperResult RenderStyles() {
			var styles = new StringBuilder();

			RenderSection("Styles", false).WriteTo(new StringWriter(styles));

			var originalStyles = styles.ToString();

			if (string.IsNullOrWhiteSpace(originalStyles))
				return null;

			var minifiedStyles = new Minifier().MinifyStyleSheet(originalStyles, new CssSettings {
					CommentMode = CssComment.None
			});

			return new HelperResult(tw => tw.Write("<style type=\"text/css\">{0}</style>", minifiedStyles));
		}
	}
}
using WebActivator;

using WebPlex.MvcApplication.App_Start;

[assembly: PostApplicationStartMethod(typeof (BundleConfig), "RegisterBundles")]

namespace WebPlex.MvcApplication.App_Start {
	using System.Web.Optimization;

	using WebPlex.Web.Optimization;

	public static class BundleConfig {
		public static void RegisterBundles() {
			var bundles = BundleTable.Bundles;

			bundles.Clear();

			bundles.Add(new ScriptBundle(Bundles.Scripts.Html5Shiv).Include("~" + Assets.Scripts.Html5Shiv.html5shiv_js));
			bundles.Add(new ScriptBundle(Bundles.Scripts.jQueryCore).Include("~" + Assets.Scripts.jQuery.Core.jquery_2_0_0_js));
			bundles.Add(new ScriptBundle(Bundles.Scripts.jQueryUI).Include("~" + Assets.Scripts.jQuery.UI.jquery_ui_1_10_0_js));

			bundles.Add(new ScriptBundle(Bundles.Scripts.jQueryValidate).Include("~" + Assets.Scripts.jQuery.Validate.jquery_unobtrusive_ajax_js, "~" + Assets.Scripts.jQuery.Validate.jquery_validate_js,
					"~" + Assets.Scripts.jQuery.Validate.jquery_validate_unobtrusive_js));

			bundles.Add(new ScriptBundle(Bundles.Scripts.Bootstrap).Include("~" + Assets.Scripts.Bootstrap.bootstrap_transition_js, "~" + Assets.Scripts.Bootstrap.bootstrap_alert_js, "~" + Assets.Scripts.Bootstrap.bootstrap_modal_js,
					"~" + Assets.Scripts.Bootstrap.bootstrap_dropdown_js, "~" + Assets.Scripts.Bootstrap.bootstrap_scrollspy_js, "~" + Assets.Scripts.Bootstrap.bootstrap_tab_js, "~" + Assets.Scripts.Bootstrap.bootstrap_tooltip_js,
					"~" + Assets.Scripts.Bootstrap.bootstrap_popover_js, "~" + Assets.Scripts.Bootstrap.bootstrap_button_js, "~" + Assets.Scripts.Bootstrap.bootstrap_collapse_js, "~" + Assets.Scripts.Bootstrap.bootstrap_carousel_js,
					"~" + Assets.Scripts.Bootstrap.bootstrap_typeahead_js, "~" + Assets.Scripts.Bootstrap.bootstrap_affix_js));

			bundles.Add(new ScriptBundle(Bundles.Scripts.WebPlex).IncludeDirectory("~" + Assets.Scripts.WebPlex.Url(), "*.js"));

			bundles.Add(new StyleBundle(Bundles.Styles.jQueryUI).Include("~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_core_css, "~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_accordion_css,
					"~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_autocomplete_css, "~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_button_css, "~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_datepicker_css,
					"~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_dialog_css, "~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_menu_css, "~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_progressbar_css,
					"~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_resizable_css, "~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_selectable_css, "~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_slider_css,
					"~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_spinner_css, "~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_tabs_css, "~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_tooltip_css,
					"~" + Assets.Styles.jQuery.UI.themes.@base.jquery_ui_theme_css));

			bundles.Add(new LessBundle(Bundles.Styles.Bootstrap).Include("~" + Assets.Styles.Bootstrap.bootstrap_less));
		}
	}
}
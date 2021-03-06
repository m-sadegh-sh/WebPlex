// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using WebPlex.MvcApplication;
namespace WebPlex.MvcApplication.Controllers
{
    public partial class ComponentsController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ComponentsController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ComponentsController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult Title()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Title);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult Keywords()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Keywords);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult Description()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Description);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult Anchor()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Anchor);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult Alert()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Alert);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult Button()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Button);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult Breadcrumb()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Breadcrumb);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult AlertGroup()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.AlertGroup);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult ButtonGroup()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.ButtonGroup);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult Navbar()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Navbar);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult NavItem()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.NavItem);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ComponentsController Actions { get { return T4Routes.Components; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "components";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "components";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Title = ("Title").ToLowerInvariant();
            public readonly string Keywords = ("Keywords").ToLowerInvariant();
            public readonly string Description = ("Description").ToLowerInvariant();
            public readonly string Anchor = ("Anchor").ToLowerInvariant();
            public readonly string Alert = ("Alert").ToLowerInvariant();
            public readonly string Button = ("Button").ToLowerInvariant();
            public readonly string Breadcrumb = ("Breadcrumb").ToLowerInvariant();
            public readonly string AlertGroup = ("AlertGroup").ToLowerInvariant();
            public readonly string ButtonGroup = ("ButtonGroup").ToLowerInvariant();
            public readonly string Navbar = ("Navbar").ToLowerInvariant();
            public readonly string NavItem = ("NavItem").ToLowerInvariant();
        }


        static readonly ActionParamsClass_Title s_params_Title = new ActionParamsClass_Title();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Title TitleParams { get { return s_params_Title; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Title
        {
            public readonly string component = ("component").ToLowerInvariant();
        }
        static readonly ActionParamsClass_Keywords s_params_Keywords = new ActionParamsClass_Keywords();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Keywords KeywordsParams { get { return s_params_Keywords; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Keywords
        {
            public readonly string component = ("component").ToLowerInvariant();
        }
        static readonly ActionParamsClass_Description s_params_Description = new ActionParamsClass_Description();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Description DescriptionParams { get { return s_params_Description; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Description
        {
            public readonly string component = ("component").ToLowerInvariant();
        }
        static readonly ActionParamsClass_Anchor s_params_Anchor = new ActionParamsClass_Anchor();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Anchor AnchorParams { get { return s_params_Anchor; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Anchor
        {
            public readonly string component = ("component").ToLowerInvariant();
        }
        static readonly ActionParamsClass_Alert s_params_Alert = new ActionParamsClass_Alert();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Alert AlertParams { get { return s_params_Alert; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Alert
        {
            public readonly string component = ("component").ToLowerInvariant();
        }
        static readonly ActionParamsClass_Button s_params_Button = new ActionParamsClass_Button();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Button ButtonParams { get { return s_params_Button; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Button
        {
            public readonly string component = ("component").ToLowerInvariant();
        }
        static readonly ActionParamsClass_Breadcrumb s_params_Breadcrumb = new ActionParamsClass_Breadcrumb();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Breadcrumb BreadcrumbParams { get { return s_params_Breadcrumb; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Breadcrumb
        {
            public readonly string component = ("component").ToLowerInvariant();
        }
        static readonly ActionParamsClass_AlertGroup s_params_AlertGroup = new ActionParamsClass_AlertGroup();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AlertGroup AlertGroupParams { get { return s_params_AlertGroup; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AlertGroup
        {
            public readonly string component = ("component").ToLowerInvariant();
        }
        static readonly ActionParamsClass_ButtonGroup s_params_ButtonGroup = new ActionParamsClass_ButtonGroup();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ButtonGroup ButtonGroupParams { get { return s_params_ButtonGroup; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ButtonGroup
        {
            public readonly string component = ("component").ToLowerInvariant();
        }
        static readonly ActionParamsClass_Navbar s_params_Navbar = new ActionParamsClass_Navbar();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Navbar NavbarParams { get { return s_params_Navbar; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Navbar
        {
            public readonly string component = ("component").ToLowerInvariant();
        }
        static readonly ActionParamsClass_NavItem s_params_NavItem = new ActionParamsClass_NavItem();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_NavItem NavItemParams { get { return s_params_NavItem; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_NavItem
        {
            public readonly string component = ("component").ToLowerInvariant();
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string Alert = "Alert";
                public readonly string AlertGroup = "AlertGroup";
                public readonly string Anchor = "Anchor";
                public readonly string Breadcrumb = "Breadcrumb";
                public readonly string Button = "Button";
                public readonly string ButtonGroup = "ButtonGroup";
                public readonly string Description = "Description";
                public readonly string Keywords = "Keywords";
                public readonly string Navbar = "Navbar";
                public readonly string NavItem = "NavItem";
                public readonly string Title = "Title";
            }
            public readonly string Alert = "~/Views/Components/Alert.cshtml";
            public readonly string AlertGroup = "~/Views/Components/AlertGroup.cshtml";
            public readonly string Anchor = "~/Views/Components/Anchor.cshtml";
            public readonly string Breadcrumb = "~/Views/Components/Breadcrumb.cshtml";
            public readonly string Button = "~/Views/Components/Button.cshtml";
            public readonly string ButtonGroup = "~/Views/Components/ButtonGroup.cshtml";
            public readonly string Description = "~/Views/Components/Description.cshtml";
            public readonly string Keywords = "~/Views/Components/Keywords.cshtml";
            public readonly string Navbar = "~/Views/Components/Navbar.cshtml";
            public readonly string NavItem = "~/Views/Components/NavItem.cshtml";
            public readonly string Title = "~/Views/Components/Title.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ComponentsController : WebPlex.MvcApplication.Controllers.ComponentsController
    {
        public T4MVC_ComponentsController() : base(Dummy.Instance) { }

        partial void TitleOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, WebPlex.Web.Mvc.UI.Components.TitleComponent component);

        public override System.Web.Mvc.PartialViewResult Title(WebPlex.Web.Mvc.UI.Components.TitleComponent component)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Title);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "component", component);
            TitleOverride(callInfo, component);
            return callInfo;
        }

        partial void KeywordsOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, WebPlex.Web.Mvc.UI.Components.KeywordsComponent component);

        public override System.Web.Mvc.PartialViewResult Keywords(WebPlex.Web.Mvc.UI.Components.KeywordsComponent component)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Keywords);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "component", component);
            KeywordsOverride(callInfo, component);
            return callInfo;
        }

        partial void DescriptionOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, WebPlex.Web.Mvc.UI.Components.DescriptionComponent component);

        public override System.Web.Mvc.PartialViewResult Description(WebPlex.Web.Mvc.UI.Components.DescriptionComponent component)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Description);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "component", component);
            DescriptionOverride(callInfo, component);
            return callInfo;
        }

        partial void AnchorOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, WebPlex.Web.Mvc.UI.Components.AnchorComponent component);

        public override System.Web.Mvc.PartialViewResult Anchor(WebPlex.Web.Mvc.UI.Components.AnchorComponent component)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Anchor);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "component", component);
            AnchorOverride(callInfo, component);
            return callInfo;
        }

        partial void AlertOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, WebPlex.Web.Mvc.UI.Components.AlertComponent component);

        public override System.Web.Mvc.PartialViewResult Alert(WebPlex.Web.Mvc.UI.Components.AlertComponent component)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Alert);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "component", component);
            AlertOverride(callInfo, component);
            return callInfo;
        }

        partial void ButtonOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, WebPlex.Web.Mvc.UI.Components.ButtonComponent component);

        public override System.Web.Mvc.PartialViewResult Button(WebPlex.Web.Mvc.UI.Components.ButtonComponent component)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Button);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "component", component);
            ButtonOverride(callInfo, component);
            return callInfo;
        }

        partial void BreadcrumbOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, WebPlex.Web.Mvc.UI.Components.BreadcrumbComponent component);

        public override System.Web.Mvc.PartialViewResult Breadcrumb(WebPlex.Web.Mvc.UI.Components.BreadcrumbComponent component)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Breadcrumb);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "component", component);
            BreadcrumbOverride(callInfo, component);
            return callInfo;
        }

        partial void AlertGroupOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, WebPlex.Web.Mvc.UI.Components.AlertGroupComponent component);

        public override System.Web.Mvc.PartialViewResult AlertGroup(WebPlex.Web.Mvc.UI.Components.AlertGroupComponent component)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.AlertGroup);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "component", component);
            AlertGroupOverride(callInfo, component);
            return callInfo;
        }

        partial void ButtonGroupOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, WebPlex.Web.Mvc.UI.Components.ButtonGroupComponent component);

        public override System.Web.Mvc.PartialViewResult ButtonGroup(WebPlex.Web.Mvc.UI.Components.ButtonGroupComponent component)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.ButtonGroup);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "component", component);
            ButtonGroupOverride(callInfo, component);
            return callInfo;
        }

        partial void NavbarOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, WebPlex.Web.Mvc.UI.Components.NavbarComponent component);

        public override System.Web.Mvc.PartialViewResult Navbar(WebPlex.Web.Mvc.UI.Components.NavbarComponent component)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.Navbar);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "component", component);
            NavbarOverride(callInfo, component);
            return callInfo;
        }

        partial void NavItemOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, WebPlex.Web.Mvc.UI.Components.NavItemComponent component);

        public override System.Web.Mvc.PartialViewResult NavItem(WebPlex.Web.Mvc.UI.Components.NavItemComponent component)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.NavItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "component", component);
            NavItemOverride(callInfo, component);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591

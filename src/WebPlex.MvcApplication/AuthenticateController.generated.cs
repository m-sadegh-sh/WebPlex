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
    public partial class AuthenticateController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AuthenticateController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult SignIn()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SignIn, "https");
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ExternalSignIn()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalSignIn, "https");
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ExternalSignInCallback()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalSignInCallback, "https");
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult SignOut()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SignOut, "https");
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult SignUp()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SignUp, "https");
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ResetPassword()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResetPassword, "https");
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult SetOrChangePassword()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SetOrChangePassword, "https");
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult SetPassword()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SetPassword, "https");
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ChangePassword()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangePassword, "https");
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Disassociate()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Disassociate, "https");
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ExternalSignIns()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalSignIns, "https");
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AuthenticateController Actions { get { return T4Routes.Authenticate; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "authenticate";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "authenticate";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string SignIn = ("SignIn").ToLowerInvariant();
            public readonly string ExternalSignIn = ("ExternalSignIn").ToLowerInvariant();
            public readonly string ExternalSignInCallback = ("ExternalSignInCallback").ToLowerInvariant();
            public readonly string SignOut = ("SignOut").ToLowerInvariant();
            public readonly string SignUp = ("SignUp").ToLowerInvariant();
            public readonly string ResetPassword = ("ResetPassword").ToLowerInvariant();
            public readonly string SetOrChangePassword = ("SetOrChangePassword").ToLowerInvariant();
            public readonly string SetPassword = ("SetPassword").ToLowerInvariant();
            public readonly string ChangePassword = ("ChangePassword").ToLowerInvariant();
            public readonly string Disassociate = ("Disassociate").ToLowerInvariant();
            public readonly string ExternalSignIns = ("ExternalSignIns").ToLowerInvariant();
            public readonly string RemoveExternalSignIns = ("RemoveExternalSignIns").ToLowerInvariant();
        }


        static readonly ActionParamsClass_SignIn s_params_SignIn = new ActionParamsClass_SignIn();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SignIn SignInParams { get { return s_params_SignIn; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SignIn
        {
            public readonly string returnUrl = ("returnUrl").ToLowerInvariant();
            public readonly string model = ("model").ToLowerInvariant();
        }
        static readonly ActionParamsClass_ExternalSignIn s_params_ExternalSignIn = new ActionParamsClass_ExternalSignIn();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExternalSignIn ExternalSignInParams { get { return s_params_ExternalSignIn; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExternalSignIn
        {
            public readonly string providerKey = ("providerKey").ToLowerInvariant();
            public readonly string returnUrl = ("returnUrl").ToLowerInvariant();
        }
        static readonly ActionParamsClass_ExternalSignInCallback s_params_ExternalSignInCallback = new ActionParamsClass_ExternalSignInCallback();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExternalSignInCallback ExternalSignInCallbackParams { get { return s_params_ExternalSignInCallback; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExternalSignInCallback
        {
            public readonly string returnUrl = ("returnUrl").ToLowerInvariant();
        }
        static readonly ActionParamsClass_SignOut s_params_SignOut = new ActionParamsClass_SignOut();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SignOut SignOutParams { get { return s_params_SignOut; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SignOut
        {
            public readonly string returnUrl = ("returnUrl").ToLowerInvariant();
        }
        static readonly ActionParamsClass_SignUp s_params_SignUp = new ActionParamsClass_SignUp();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SignUp SignUpParams { get { return s_params_SignUp; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SignUp
        {
            public readonly string returnUrl = ("returnUrl").ToLowerInvariant();
            public readonly string model = ("model").ToLowerInvariant();
        }
        static readonly ActionParamsClass_ResetPassword s_params_ResetPassword = new ActionParamsClass_ResetPassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ResetPassword ResetPasswordParams { get { return s_params_ResetPassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ResetPassword
        {
            public readonly string returnUrl = ("returnUrl").ToLowerInvariant();
            public readonly string model = ("model").ToLowerInvariant();
        }
        static readonly ActionParamsClass_SetOrChangePassword s_params_SetOrChangePassword = new ActionParamsClass_SetOrChangePassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SetOrChangePassword SetOrChangePasswordParams { get { return s_params_SetOrChangePassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SetOrChangePassword
        {
            public readonly string returnUrl = ("returnUrl").ToLowerInvariant();
        }
        static readonly ActionParamsClass_SetPassword s_params_SetPassword = new ActionParamsClass_SetPassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SetPassword SetPasswordParams { get { return s_params_SetPassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SetPassword
        {
            public readonly string model = ("model").ToLowerInvariant();
            public readonly string returnUrl = ("returnUrl").ToLowerInvariant();
        }
        static readonly ActionParamsClass_ChangePassword s_params_ChangePassword = new ActionParamsClass_ChangePassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ChangePassword ChangePasswordParams { get { return s_params_ChangePassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ChangePassword
        {
            public readonly string model = ("model").ToLowerInvariant();
            public readonly string returnUrl = ("returnUrl").ToLowerInvariant();
        }
        static readonly ActionParamsClass_Disassociate s_params_Disassociate = new ActionParamsClass_Disassociate();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Disassociate DisassociateParams { get { return s_params_Disassociate; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Disassociate
        {
            public readonly string providerKey = ("providerKey").ToLowerInvariant();
            public readonly string userKey = ("userKey").ToLowerInvariant();
            public readonly string returnUrl = ("returnUrl").ToLowerInvariant();
        }
        static readonly ActionParamsClass_ExternalSignIns s_params_ExternalSignIns = new ActionParamsClass_ExternalSignIns();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExternalSignIns ExternalSignInsParams { get { return s_params_ExternalSignIns; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExternalSignIns
        {
            public readonly string returnUrl = ("returnUrl").ToLowerInvariant();
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
                public readonly string ChangePassword = "ChangePassword";
                public readonly string ExternalSignIns = "ExternalSignIns";
                public readonly string RemoveExternalSignIns = "RemoveExternalSignIns";
                public readonly string ResetPassword = "ResetPassword";
                public readonly string SetPassword = "SetPassword";
                public readonly string SignIn = "SignIn";
                public readonly string SignUp = "SignUp";
            }
            public readonly string ChangePassword = "~/Views/Authenticate/ChangePassword.cshtml";
            public readonly string ExternalSignIns = "~/Views/Authenticate/ExternalSignIns.cshtml";
            public readonly string RemoveExternalSignIns = "~/Views/Authenticate/RemoveExternalSignIns.cshtml";
            public readonly string ResetPassword = "~/Views/Authenticate/ResetPassword.cshtml";
            public readonly string SetPassword = "~/Views/Authenticate/SetPassword.cshtml";
            public readonly string SignIn = "~/Views/Authenticate/SignIn.cshtml";
            public readonly string SignUp = "~/Views/Authenticate/SignUp.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AuthenticateController : WebPlex.MvcApplication.Controllers.AuthenticateController
    {
        public T4MVC_AuthenticateController() : base(Dummy.Instance) { }

        partial void SignInOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        public override System.Web.Mvc.ActionResult SignIn(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SignIn, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            SignInOverride(callInfo, returnUrl);
            return callInfo;
        }

        partial void SignInOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, WebPlex.MvcApplication.Models.Authenticate.SignInModel model, string returnUrl);

        public override System.Web.Mvc.ActionResult SignIn(WebPlex.MvcApplication.Models.Authenticate.SignInModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SignIn, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            SignInOverride(callInfo, model, returnUrl);
            return callInfo;
        }

        partial void ExternalSignInOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string providerKey, string returnUrl);

        public override System.Web.Mvc.ActionResult ExternalSignIn(string providerKey, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalSignIn, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "providerKey", providerKey);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ExternalSignInOverride(callInfo, providerKey, returnUrl);
            return callInfo;
        }

        partial void ExternalSignInCallbackOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        public override System.Web.Mvc.ActionResult ExternalSignInCallback(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalSignInCallback, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ExternalSignInCallbackOverride(callInfo, returnUrl);
            return callInfo;
        }

        partial void SignOutOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        public override System.Web.Mvc.ActionResult SignOut(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SignOut, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            SignOutOverride(callInfo, returnUrl);
            return callInfo;
        }

        partial void SignUpOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        public override System.Web.Mvc.ActionResult SignUp(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SignUp, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            SignUpOverride(callInfo, returnUrl);
            return callInfo;
        }

        partial void SignUpOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, WebPlex.MvcApplication.Models.Authenticate.SignUpModel model, string returnUrl);

        public override System.Web.Mvc.ActionResult SignUp(WebPlex.MvcApplication.Models.Authenticate.SignUpModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SignUp, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            SignUpOverride(callInfo, model, returnUrl);
            return callInfo;
        }

        partial void ResetPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        public override System.Web.Mvc.ActionResult ResetPassword(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResetPassword, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ResetPasswordOverride(callInfo, returnUrl);
            return callInfo;
        }

        partial void ResetPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, WebPlex.MvcApplication.Models.Authenticate.ResetPasswordModel model, string returnUrl);

        public override System.Web.Mvc.ActionResult ResetPassword(WebPlex.MvcApplication.Models.Authenticate.ResetPasswordModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResetPassword, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ResetPasswordOverride(callInfo, model, returnUrl);
            return callInfo;
        }

        partial void SetOrChangePasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        public override System.Web.Mvc.ActionResult SetOrChangePassword(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SetOrChangePassword, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            SetOrChangePasswordOverride(callInfo, returnUrl);
            return callInfo;
        }

        partial void SetPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, WebPlex.MvcApplication.Models.Authenticate.SetPasswordModel model, string returnUrl);

        public override System.Web.Mvc.ActionResult SetPassword(WebPlex.MvcApplication.Models.Authenticate.SetPasswordModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SetPassword, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            SetPasswordOverride(callInfo, model, returnUrl);
            return callInfo;
        }

        partial void ChangePasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, WebPlex.MvcApplication.Models.Authenticate.ChangePasswordModel model, string returnUrl);

        public override System.Web.Mvc.ActionResult ChangePassword(WebPlex.MvcApplication.Models.Authenticate.ChangePasswordModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangePassword, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ChangePasswordOverride(callInfo, model, returnUrl);
            return callInfo;
        }

        partial void DisassociateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string providerKey, string userKey, string returnUrl);

        public override System.Web.Mvc.ActionResult Disassociate(string providerKey, string userKey, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Disassociate, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "providerKey", providerKey);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "userKey", userKey);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            DisassociateOverride(callInfo, providerKey, userKey, returnUrl);
            return callInfo;
        }

        partial void ExternalSignInsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        public override System.Web.Mvc.ActionResult ExternalSignIns(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalSignIns, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ExternalSignInsOverride(callInfo, returnUrl);
            return callInfo;
        }

        partial void RemoveExternalSignInsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult RemoveExternalSignIns()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveExternalSignIns, "https");
            RemoveExternalSignInsOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591

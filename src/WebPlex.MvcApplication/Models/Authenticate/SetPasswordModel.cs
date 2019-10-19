namespace WebPlex.MvcApplication.Models.Authenticate {
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	using WebPlex.Resources;

	public class SetPasswordModel : IModel {
		[Display(ResourceType = typeof (Members), Name = "ChangePasswordModel_NewPassword")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[AllowHtml]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[Display(ResourceType = typeof (Members), Name = "ChangePasswordModel_NewPasswordConfirmation")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[System.Web.Mvc.Compare("NewPassword", ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_NotMatched")]
		[AllowHtml]
		[DataType(DataType.Password)]
		public string NewPasswordConfirmation { get; set; }
	}
}
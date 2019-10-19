namespace WebPlex.MvcApplication.Models.Authenticate {
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	using WebPlex.Resources;

	public sealed class ChangePasswordModel : SetPasswordModel {
		[Display(ResourceType = typeof (Members), Name = "ChangePasswordModel_CurrentPassword")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[AllowHtml]
		[DataType(DataType.Password)]
		public string CurrentPassword { get; set; }
	}
}
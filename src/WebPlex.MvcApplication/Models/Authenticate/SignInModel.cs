namespace WebPlex.MvcApplication.Models.Authenticate {
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	using DataAnnotationsExtensions;

	using WebPlex.Resources;

	public sealed class SignInModel : IModel {
		[Display(ResourceType = typeof (Members), Name = "SignInModel_Email")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[StringLength(128, ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_InvalidMaxLength")]
		[Email(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_InvalidEmail")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(ResourceType = typeof (Members), Name = "SignInModel_Password")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[AllowHtml]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(ResourceType = typeof (Members), Name = "SignInModel_RememberMe")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		public bool RememberMe { get; set; }
	}
}
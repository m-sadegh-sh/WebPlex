namespace WebPlex.MvcApplication.Models.Authenticate {
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	using DataAnnotationsExtensions;

	using WebPlex.Resources;

	public sealed class SignUpModel : IModel {
		[Display(ResourceType = typeof (Members), Name = "SignUpModel_Email")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[StringLength(128, ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_InvalidMaxLength")]
		[Email(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_InvalidEmail")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(ResourceType = typeof (Members), Name = "SignUpModel_Password")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[AllowHtml]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(ResourceType = typeof (Members), Name = "SignUpModel_PasswordConfirmation")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[System.Web.Mvc.Compare("Password", ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_NotMatched")]
		[AllowHtml]
		[DataType(DataType.Password)]
		public string PasswordConfirmation { get; set; }
	}
}
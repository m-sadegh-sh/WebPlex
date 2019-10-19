namespace WebPlex.MvcApplication.Models.Authenticate {
	using System.ComponentModel.DataAnnotations;

	using DataAnnotationsExtensions;

	using WebPlex.Resources;

	public sealed class ResetPasswordModel : IModel {
		[Display(ResourceType = typeof (Members), Name = "ResetPasswordModel_Email")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[StringLength(128, ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_InvalidMaxLength")]
		[Email(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_InvalidEmail")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}
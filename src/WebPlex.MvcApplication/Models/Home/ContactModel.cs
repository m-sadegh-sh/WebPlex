namespace WebPlex.MvcApplication.Models.Home {
	using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	using DataAnnotationsExtensions;

	using WebPlex.Resources;

	public sealed class ContactModel : IModel {
		[Display(ResourceType = typeof (Members), Name = "ContactModel_Name")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[StringLength(32, ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_InvalidMaxLength")]
		public string Name { get; set; }

		[Display(ResourceType = typeof (Members), Name = "ContactModel_Email")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[StringLength(128, ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_InvalidMaxLength")]
		[Email(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_InvalidEmail")]
		public string Email { get; set; }

		[Display(ResourceType = typeof (Members), Name = "ContactModel_Message")]
		[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Validation_Required")]
		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string Message { get; set; }
	}
}
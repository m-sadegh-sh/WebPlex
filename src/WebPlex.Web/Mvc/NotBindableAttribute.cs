namespace WebPlex.Web.Mvc {
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.Security;

	using WebPlex.Resources;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class NotBindableAttribute : ValidationAttribute {
		protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
			if (value != null)
				throw new SecurityException(string.Format(Exceptions.NotBindableAttribute_BindingNotAllowed, validationContext.ObjectType, validationContext.DisplayName));

			return null;
		}
	}
}
namespace WebPlex.Services.Impl.Security {
	using CuttingEdge.Conditions;

	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;

	public static class UserExtentions {
		public static string GetFullName(this UserEntity user) {
			Condition.Requires(user).IsNotNull();

			var userAttributeService = EngineContext.Current.Resolve<IUserAttributeService>();

			var firstName = userAttributeService.GetValue(user, UserAttribute.FirstName, "", false, false);
			var lastName = userAttributeService.GetValue(user, UserAttribute.LastName, "", false, false);

			string fullName;

			if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
				fullName = string.Format("{0} {1}", firstName, lastName);
			else if (!string.IsNullOrWhiteSpace(firstName))
				fullName = firstName;
			else if (!string.IsNullOrWhiteSpace(lastName))
				fullName = lastName;
			else
				fullName = user.Email;

			return fullName;
		}
	}
}
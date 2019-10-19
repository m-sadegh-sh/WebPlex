namespace WebPlex.Core.Domain.Entities.Contents {
	using System;

	using WebPlex.Core.Extensions;

	public class SubscriptionEntity : EntityBase {
		public virtual string Email { get; set; }
		public virtual SubscriptionStatus Status { get; set; }
		public virtual DateTime SubscribDateUtc { get; set; }
		public virtual DateTime? ConfirmDateUtc { get; set; }
		public virtual DateTime? CancelDateUtc { get; set; }

		public override string ToString() {
			return string.Format("{0} ({1})", Email, Status);
		}

		public override bool Equals(object obj) {
			return Equals(obj as SubscriptionEntity);
		}

		public virtual bool Equals(SubscriptionEntity other) {
			if (other == null)
				return false;

			if (base.Equals(other))
				return true;

			return string.Equals(Email, other.Email, StringComparison.InvariantCultureIgnoreCase);
		}

		public override int GetHashCode() {
			return Email.NotNullOrDefault().GetHashCode();
		}
	}
}
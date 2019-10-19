namespace WebPlex.Core.Domain.Entities.Workflow {
	using System;

	using Iesi.Collections.Generic;

	public class QueuedMailEntity : EntityBase {
		private ISet<string> _cc;
		private ISet<string> _bcc;

		public virtual string FromEmail { get; set; }
		public virtual string FromName { get; set; }
		public virtual string ToEmail { get; set; }
		public virtual string ToName { get; set; }

		public virtual ISet<string> Cc {
			get { return _cc ?? (_cc = new HashedSet<string>()); }
			set { _cc = value; }
		}

		public virtual ISet<string> Bcc {
			get { return _bcc ?? (_bcc = new HashedSet<string>()); }
			set { _bcc = value; }
		}

		public virtual string Subject { get; set; }
		public virtual string Body { get; set; }
		public virtual bool IsBodyHtml { get; set; }
		public virtual QueuedMailImportance Importance { get; set; }
		public virtual int SendTries { get; set; }
		public virtual DateTime? SentDateUtc { get; set; }

		public override string ToString() {
			return string.Format("{0} ({1}), {2} ({3})", FromEmail, FromName, ToEmail, ToName);
		}
	}
}
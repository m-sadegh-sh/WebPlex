namespace WebPlex.MvcApplication.AutoMapping.Resolvers {
	using AutoMapper;

	using WebPlex.Core;
	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Resources;

	public sealed class QueuedMailImportanceResolver : IValueResolver {
		public ResolutionResult Resolve(ResolutionResult source) {
			var importance = (QueuedMailImportance) source.Value;

			string value;

			switch (importance) {
				case QueuedMailImportance.Low:
					value = Members.QueuedMailImportance_Low;
					break;

				case QueuedMailImportance.Normal:
					value = Members.QueuedMailImportance_Normal;
					break;

				case QueuedMailImportance.High:
					value = Members.QueuedMailImportance_High;
					break;

				case QueuedMailImportance.Critical:
					value = Members.QueuedMailImportance_Critical;
					break;

				default:
					throw new NotSupportedEnumException(importance);
			}

			return source.New(value);
		}
	}
}
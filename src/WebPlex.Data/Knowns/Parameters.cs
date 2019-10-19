namespace WebPlex.Data.Knowns {
	using WebPlex.Core.Builders;
	using WebPlex.Data.Builders;

	public static class Parameters {
		public static readonly Constant Page = new ParameterKey(p => Page);
		public static readonly Constant Size = new ParameterKey(p => Size);
		public static readonly Constant Id = new ParameterKey(p => Size);

		public static readonly Constant SettingId = new ParameterKey(p => SettingId);

		public static readonly Constant SubscriptionId = new ParameterKey(p => SubscriptionId);

		public static readonly Constant LanguageId = new ParameterKey(p => LanguageId);
		public static readonly Constant ResourceKeyId = new ParameterKey(p => ResourceKeyId);
		public static readonly Constant ResourceValueId = new ParameterKey(p => ResourceValueId);

		public static readonly Constant BannedIpId = new ParameterKey(p => BannedIpId);
		public static readonly Constant LogId = new ParameterKey(p => LogId);
		public static readonly Constant PermissionId = new ParameterKey(p => PermissionId);
		public static readonly Constant PermissionGroupId = new ParameterKey(p => PermissionGroupId);
		public static readonly Constant RoleId = new ParameterKey(p => RoleId);
		public static readonly Constant UserAttributeId = new ParameterKey(p => UserAttributeId);
		public static readonly Constant UserId = new ParameterKey(p => UserId);

		public static readonly Constant EmailAccountId = new ParameterKey(p => EmailAccountId);
		public static readonly Constant QueuedMailId = new ParameterKey(p => QueuedMailId);
	}
}
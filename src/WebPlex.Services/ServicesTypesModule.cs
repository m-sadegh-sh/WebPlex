namespace WebPlex.Services {
	using Autofac;
	using Autofac.Integration.Mvc;

	using NHibernate.Validator.Cfg.Loquacious;

	using WebPlex.Core.Domain.Entities.Configuration;
	using WebPlex.Core.Domain.Entities.Contents;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Core.Domain.Settings;
	using WebPlex.Services.Helpers;
	using WebPlex.Services.Impl.Configuration;
	using WebPlex.Services.Impl.Contents;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Impl.Workflow;
	using WebPlex.Services.Infrastructure;
	using WebPlex.Services.Security;
	using WebPlex.Services.Utils;
	using WebPlex.Services.Validations.Configuration;
	using WebPlex.Services.Validations.Contents;
	using WebPlex.Services.Validations.Security;
	using WebPlex.Services.Validations.Workflow;

	public class ServicesTypesModule : Module {
		protected override void Load(ContainerBuilder builder) {
			builder.RegisterType<OperationResult>();
			builder.RegisterGeneric(typeof (OperationResult<>));

			builder.RegisterType<ValidationProvider>().SingleInstance();

			builder.RegisterType<ApplicationSettingsService>().As<IApplicationSettingsService>().InstancePerHttpRequest();
			builder.RegisterType<CloudSettingsService>().As<ICloudSettingsService>().InstancePerHttpRequest();
			builder.RegisterType<ContactFormSettingsService>().As<IContactFormSettingsService>().InstancePerHttpRequest();
			builder.RegisterType<SettingService>().As<ISettingService>().InstancePerHttpRequest();

			builder.RegisterType<SubscriptionService>().As<ISubscriptionService>().InstancePerHttpRequest();

			builder.RegisterType<BannedIpService>().As<IBannedIpService>().InstancePerHttpRequest();
			builder.RegisterType<LogService>().As<ILogService>().InstancePerHttpRequest();
			builder.RegisterType<PermissionGroupService>().As<IPermissionGroupService>().InstancePerHttpRequest();
			builder.RegisterType<PermissionService>().As<IPermissionService>().InstancePerHttpRequest();
			builder.RegisterType<RoleService>().As<IRoleService>().InstancePerHttpRequest();
			builder.RegisterType<UserAttributeService>().As<IUserAttributeService>().InstancePerHttpRequest();
			builder.RegisterType<UserService>().As<IUserService>().InstancePerHttpRequest();
			builder.RegisterType<MembershipService>().As<IMembershipService>().InstancePerHttpRequest();
			builder.RegisterType<OAuthService>().As<IOAuthService>().InstancePerHttpRequest();
			builder.RegisterType<OAuthTokenService>().As<IOAuthTokenService>().InstancePerHttpRequest();

			builder.RegisterType<EmailAccountService>().As<IEmailAccountService>().InstancePerHttpRequest();
			builder.RegisterType<QueuedMailService>().As<IQueuedMailService>().InstancePerHttpRequest();

			builder.Register(cc => cc.Resolve<IApplicationSettingsService>().Instance).InstancePerHttpRequest();
			builder.Register(cc => cc.Resolve<ICloudSettingsService>().Instance).InstancePerHttpRequest();
			builder.Register(cc => cc.Resolve<IContactFormSettingsService>().Instance).InstancePerHttpRequest();

			builder.RegisterType<ApplicationSettingsValidation>().As<IValidationDefinition<ApplicationSettings>>().InstancePerHttpRequest();
			builder.RegisterType<CloudSettingsValidation>().As<IValidationDefinition<CloudSettings>>().InstancePerHttpRequest();
			builder.RegisterType<ContactFormSettingsValidation>().As<IValidationDefinition<ContactFormSettings>>().InstancePerHttpRequest();
			builder.RegisterType<SettingValidation>().As<IValidationDefinition<SettingEntity>>().InstancePerHttpRequest();

			builder.RegisterType<SubscriptionValidation>().As<IValidationDefinition<SubscriptionEntity>>().InstancePerHttpRequest();

			builder.RegisterType<BannedIpValidation>().As<IValidationDefinition<BannedIpEntity>>().InstancePerHttpRequest();
			builder.RegisterType<LogValidation>().As<IValidationDefinition<LogEntity>>().InstancePerHttpRequest();
			builder.RegisterType<PermissionGroupValidation>().As<IValidationDefinition<PermissionGroupEntity>>().InstancePerHttpRequest();
			builder.RegisterType<PermissionValidation>().As<IValidationDefinition<PermissionEntity>>().InstancePerHttpRequest();
			builder.RegisterType<RoleValidation>().As<IValidationDefinition<RoleEntity>>().InstancePerHttpRequest();
			builder.RegisterType<UserAttributeValidation>().As<IValidationDefinition<UserAttributeEntity>>().InstancePerHttpRequest();
			builder.RegisterType<UserValidation>().As<IValidationDefinition<UserEntity>>().InstancePerHttpRequest();
			builder.RegisterType<MembershipValidation>().As<IValidationDefinition<MembershipEntity>>().InstancePerHttpRequest();
			builder.RegisterType<OAuthValidation>().As<IValidationDefinition<OAuthEntity>>().InstancePerHttpRequest();
			builder.RegisterType<OAuthTokenValidation>().As<IValidationDefinition<OAuthTokenEntity>>().InstancePerHttpRequest();

			builder.RegisterType<EmailAccountValidation>().As<IValidationDefinition<EmailAccountEntity>>().InstancePerHttpRequest();
			builder.RegisterType<QueuedMailValidation>().As<IValidationDefinition<QueuedMailEntity>>().InstancePerHttpRequest();

			builder.RegisterType<DateTimeHelper>().As<IDateTimeHelper>().InstancePerHttpRequest();

			builder.RegisterType<MessageService>().As<IMessageService>().InstancePerHttpRequest();

			builder.RegisterType<PermissionGroupProvider>().As<IPermissionGroupProvider>().InstancePerHttpRequest();
			builder.RegisterType<PermissionProvider>().As<IPermissionProvider>().InstancePerHttpRequest();
			builder.RegisterType<PermissionInstaller>().InstancePerHttpRequest();
		}
	}
}
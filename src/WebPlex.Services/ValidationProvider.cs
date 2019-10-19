namespace WebPlex.Services {
	using System.Linq;

	using NHibernate.Validator.Engine;

	using WebPlex.Core.Engine;
	using WebPlex.Services.Infrastructure;

	public class ValidationProvider {
		private readonly ValidatorEngine _validatorEngine;

		public ValidationProvider(ValidatorEngine validatorEngine) {
			_validatorEngine = validatorEngine;
		}

		public OperationResult Validate<T>(T entity) where T : class {
			var result = EngineContext.Current.Resolve<OperationResult>();

			result += _validatorEngine.Validate(entity).ToList();

			return result;
		}
	}
}
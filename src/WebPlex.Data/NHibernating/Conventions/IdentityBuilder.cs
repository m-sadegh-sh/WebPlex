namespace WebPlex.Data.NHibernating.Conventions {
	using System;

	using CuttingEdge.Conditions;

	using Utilities.DataTypes.ExtensionMethods;

	public static class IdentityBuilder {
		private const string PRIMARY_KEY_POSTFIX = "Id";

		public static string BuildSchema(string @namespace) {
			var lastDotPosition = @namespace.LastIndexOf(".", StringComparison.Ordinal) + 1;
			var schema = @namespace.Substring(lastDotPosition, @namespace.Length - lastDotPosition);

			return Scape(schema);
		}

		public static string BuildTableName(string typeName) {
			var tableName = typeName.Replace("Entity", "").Pluralize();

			return Scape(tableName);
		}

		public static string BuildTableName<T>(string childTypeName) where T : class {
			var parentTypeName = typeof (T).Name;

			var tableName = string.Concat(parentTypeName.Replace("Entity", ""), childTypeName.Replace("Entity", "")).Pluralize();

			return Scape(tableName);
		}

		public static string BuildPrimaryKey(string typeName) {
			var primaryKey = string.Concat(typeName.Replace("Entity", ""), PRIMARY_KEY_POSTFIX);

			return Scape(primaryKey);
		}

		public static string BuildColumnName(params string[] candidateColumnNames) {
			var columnName = "";

			foreach (var candidateColumnName in candidateColumnNames)
				columnName = columnName + candidateColumnName.Replace("Entity", "");

			return Scape(columnName);
		}

		public static string BuildKeyName(params string[] candidateKeyNames) {
			var keyName = "";

			foreach (var candidateKeyName in candidateKeyNames) {
				if (!string.IsNullOrEmpty(candidateKeyName)) {
					keyName = string.Concat(candidateKeyName.Replace("Entity", ""), PRIMARY_KEY_POSTFIX);
					break;
				}
			}

			Condition.Requires(keyName).IsNotNullOrEmpty();

			return Scape(keyName);
		}

		private static string Scape(string unscapedString) {
			return string.Format("`{0}`", unscapedString);
		}
	}
}
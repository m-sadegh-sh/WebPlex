namespace WebPlex.Data.NHibernating.CustomTypes {
	using System;
	using System.Data;

	using NHibernate;
	using NHibernate.SqlTypes;
	using NHibernate.UserTypes;

	using WebPlex.Core.Builders;
	using WebPlex.Core.Extensions;

	[Serializable]
	public sealed class ConstantType : IUserType {
		bool IUserType.Equals(object x, object y) {
			if (x == null || y == null)
				return false;

			var left = (Constant) x;
			var right = (Constant) y;

			return left == right;
		}

		public object Assemble(object cached, object owner) {
			return cached;
		}

		public object DeepCopy(object value) {
			return new FlatConstant(value.ToStringOrDefault());
		}

		public object Disassemble(object value) {
			return value;
		}

		public int GetHashCode(object x) {
			return x.GetHashCode();
		}

		public bool IsMutable {
			get { return true; }
		}

		public object NullSafeGet(IDataReader rs, string[] names, object owner) {
			var index = rs.GetOrdinal(names[0]);

			return new FlatConstant((string) rs[index]);
		}

		public void NullSafeSet(IDbCommand cmd, object value, int index) {
			if (value == null || value == DBNull.Value)
				NHibernateUtil.String.NullSafeSet(cmd, null, index);

			NHibernateUtil.String.Set(cmd, value.ToString(), index);
		}

		public object Replace(object original, object target, object owner) {
			return original;
		}

		public Type ReturnedType {
			get { return typeof (Constant); }
		}

		public SqlType[] SqlTypes {
			get { return new[] {NHibernateUtil.String.SqlType}; }
		}
	}
}
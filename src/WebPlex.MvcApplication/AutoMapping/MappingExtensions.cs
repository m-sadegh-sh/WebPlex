namespace WebPlex.MvcApplication.AutoMapping {
	using System.Collections.Generic;

	using AutoMapper;

	public static class MappingExtensions {
		public static T2 To<T1, T2>(this T1 t1) where T1 : class where T2 : class {
			return Mapper.Map<T1, T2>(t1);
		}

		public static void To<T1, T2>(this T1 t1, T2 t2) where T1 : class where T2 : class {
			Mapper.Map(t1, t2);
		}

		public static IList<T2> AllTo<T1, T2>(this IList<T1> t1) where T1 : class where T2 : class {
			return Mapper.Map<IList<T1>, IList<T2>>(t1);
		}
	}
}
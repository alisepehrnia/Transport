using System;
using System.Collections.Generic;

namespace Transport.Core.Extensions
{
	public static class EnumExtensions
	{
		public static Dictionary<int, string> ToDictionary<T>() where T : struct, Enum
		{
			if (!typeof(T).IsEnum)
				throw new ArgumentException("T is not an Enum type");

			var result = new Dictionary<int, string>();
			foreach (object foo in Enum.GetValues(typeof(T)))
			{
				result.Add(key: (int)foo, foo.ToString());
			}

			return result;
		}
	}
}

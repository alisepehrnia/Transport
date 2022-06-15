using System;
using System.Collections.Generic;
using System.Linq;

namespace Transport.Core.Extensions
{
	/// <summary>
	/// Makes Working With enum Types Easier
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Throws Argument Exception If T Is Not An Enum Type
		/// </summary>
		private static void TypeCheck<T>()
		{
			if (!typeof(T).IsEnum)
				throw new ArgumentException($"{nameof(T)} is not an Enum type");
		}

		/// <summary>
		/// Converts An enum To Dictionary<int, string>
		/// </summary>
		/// <typeparam name="T">Type of enum To Convert</typeparam>
		/// <returns>Dictionary<int, string></returns>
		public static Dictionary<int, string> ToDictionary<T>() where T : struct, Enum
		{
			TypeCheck<T>();
			var result = new Dictionary<int, string>();
			foreach (object foo in Enum.GetValues(typeof(T)))
			{
				result.Add(key: (int)foo, foo.ToString());
			}

			return result;
		}

		/// <summary>
		/// Get The Name Of An Enum Value
		/// </summary>
		/// <typeparam name="T">Type of enum</typeparam>
		/// <param name="enumValue">Enum Value</param>
		/// <returns>Name Of Enum As string</returns>
		public static string GetName<T>(this T enumValue) where T : struct, Enum
		{
			TypeCheck<T>();
			return Enum.GetName(typeof(T), enumValue);
		}

		/// <summary>
		/// Get Names Of All Values In An Enum
		/// </summary>
		/// <typeparam name="T">Type of enum</typeparam>
		/// <returns>Names Of Enum As string[]</returns>
		public static string[] GetNames<T>() where T : struct, Enum
		{
			TypeCheck<T>();
			return Enum.GetNames(typeof(T));
		}

		/// <summary>
		/// Get Names Of All Values In An Enum Values Specified
		/// </summary>
		/// <param name="values">Values To Get Names</param>
		/// <typeparam name="T">Type of enum</typeparam>
		/// <returns>Names Of Specified Enum Values As IEnumerable<string></returns>
		public static IEnumerable<string> GetNames<T>(this T[] values) where T : struct, Enum
		{
			TypeCheck<T>();
			var valuesNames = values.Select(v => v.GetName());
			var allNames = GetNames<T>();
			return valuesNames.Intersect(allNames);
		}

		/// <summary>
		/// Get Names Of All Values In An Enum Values Specified
		/// </summary>
		/// <param name="values">Values To Get Names</param>
		/// <typeparam name="T">Type of enum</typeparam>
		/// <returns>Names Of Specified Enum Values As IEnumerable<string></returns>
		public static IEnumerable<string> GetNames<T>(this ICollection<T> values) where T : struct, Enum
		{
			return values.ToArray().GetNames();
		}
	}
}

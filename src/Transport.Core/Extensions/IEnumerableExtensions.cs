using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Transport.Core.Extensions
{
	/// <summary>
	/// Makes Working With IEnumerable Types Easier
	/// </summary>
	public static class IEnumerableExtensions
	{
		/// <summary>
		/// Converts Objects To IEnumerable<SelectListItem>.
		/// Each List Item Has Text & Value Defined By Selector
		/// </summary>
		/// <typeparam name="TModel">Model Type To Convert</typeparam>
		/// <param name="objects">Objects Of Model</param>
		/// <param name="selector">Slector Function</param>
		/// <returns></returns>
		public static IEnumerable<SelectListItem> ToListItems<TModel>(this IEnumerable<TModel> objects, Func<TModel, string> selector)
		{
			return objects.Select(u => new SelectListItem()
			{
				Text = selector(u),
				Value = selector(u)
			});
		}
	}
}

using System.Web;
using System.Web.Mvc;

namespace Proj_Sec8_S3
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}

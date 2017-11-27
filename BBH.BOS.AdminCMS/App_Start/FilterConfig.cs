using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.AdminCMS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

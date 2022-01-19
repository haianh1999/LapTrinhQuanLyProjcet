using System.Web;
using System.Web.Mvc;

namespace HTHABaiThucHanh8883
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

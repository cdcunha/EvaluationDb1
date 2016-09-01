using System.Web;
using System.Web.Mvc;

namespace DB1.AvalicaoTecnica.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

using System.Web.Mvc;

namespace MC_Api {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) => filters.Add(new HandleErrorAttribute());
    }
}
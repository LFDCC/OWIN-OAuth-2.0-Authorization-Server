using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Home控制器
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index方法
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
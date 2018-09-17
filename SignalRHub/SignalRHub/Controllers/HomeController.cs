using Microsoft.AspNetCore.Mvc;

namespace SignalRHub.Controllers
{
    /// <summary>
    /// Default controller that redirects browser to swagger url.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Method that redirects browser to swagger url.
        /// </summary>
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}

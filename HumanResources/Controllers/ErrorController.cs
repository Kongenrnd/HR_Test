using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Controllers
{
    public class ErrorController: Controller
    {
        [Route("Error/{id}")]
        public IActionResult HttpsStatusCodeHandler(int statusCode)
        {
            var httpsStatusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            ViewBag.ErrorMessage = "無法導頁至" + httpsStatusCodeResult.OriginalPath;
            switch (statusCode) 
            {
                case 404:
                    ViewBag.ErrorMessage = "無法導頁至"+httpsStatusCodeResult.OriginalPath;
                break;
            }
            return View("NotFound");
        }
    }
}

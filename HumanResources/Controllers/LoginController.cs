using HumanResources.Data;
using HumanResources.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace HumanResources.Controllers
{
    [Route("[Controller]")]
    public class LoginController : Controller
    {
        HumanResourcesContext context;
        public LoginController() 
        {
            context = new HumanResourcesContext();
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult index(string errorCode) 
        {
            
            if (errorCode != null)
            {
                ViewBag.ErrorMessage = "密碼錯誤";
            }
            return View();
        }
        [HttpPost]
        public ActionResult ValidLogin(string uid, string pwd)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { errorCode = "error" });
            }
            else
            { 
                var list = (
                        from a in this.context.SystemUserDatas
                        where a.UserAccount == uid & a.UserPassword == pwd & a.UserAuth== "啟用"
                        select new { a.UserAccount}
                        ).FirstOrDefault();
                if (list != null)
                {
                    return RedirectToAction("Privacy", "Home");
                }
                return RedirectToAction("Index", new { errorCode = "error" });
            }
        }
    }
}

using System.Security.Claims;
using HumanResources.Data;
using HumanResources.Models;
using HumanResources.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
namespace HumanResources.Controllers
{
    [Route("[Controller]")]
    public class LoginController : Controller
    {
        private readonly HumanResourcesContext _context;
        public LoginController(HumanResourcesContext context) 
        {
           _context = context;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidLogin(LoginModel loginData)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", new { errorCode = "error" });
            }
            else
            { 
                var list = (
                        from a in _context.SystemUserDatas
                        where a.UserAccount == loginData.uid & a.UserPassword == loginData.pwd
                        select new { a.UserAuth }
                        ).FirstOrDefault();
                if (list != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, loginData.uid)
                    };
                    // 根據用戶的角色來加入額外的 Claim
                    foreach (var role in list.UserAuth.Split(','))
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //var authProperties = new AuthenticationProperties
                    //{
                    //    IsPersistent = loginData.RememberMe
                    //};

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index", new { errorCode = "error" });
            }
        }
        // 這是處理登出的動作
        [HttpGet]
        [Route("[action]")]
        public IActionResult logout()
        {
            return View(); // 登出後重定向到首頁
        }
        // 這是處理登出的動作
        [HttpPost]
        [Route("[Action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckLogout()
        {
            // 執行登出操作，清除用戶的身份驗證票證
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); // 登出後重定向到首頁
        }
    }
}

using HumanResources.Models;
using HumanResources.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountManagementController : Controller
    {
        IHRRepository _hRRepository;
        public AccountManagementController(IHRRepository hRRepository) 
        {
            _hRRepository = hRRepository;
        }
        [HttpGet]
        public IActionResult AddAccount()
        {
            AddAccountViewModel model = new AddAccountViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddAccount(AddAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                SystemUserData data = new SystemUserData() { 
                    UserAccount = model.UserAccount, 
                    UserPassword = model.UserPassword,
                    UserAuth = model.UserAuth,
                    UserEmail = model.UserEmail,
                    UserName = model.UserName,
                    CreateTime = DateTime.Now,
                    LastModifiedBy = model.LastModifiedBy,
                    LastModifiedTime = DateTime.Now,
                    PasswordHash = null
                };

                var successed = _hRRepository.AddUserAccount(data);
                if (successed)
                {
                    return View();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}

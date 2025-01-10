using HumanResources.Data;
using HumanResources.Models;
using HumanResources.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Controllers
{
    public class HRSearchController : Controller
    {
        HRRepository hRRepository;
        public HRSearchController()
        {
            hRRepository = new HRRepository();
        }
        public IActionResult Search()
        {
            HRSearchViewModel model = new HRSearchViewModel();
            model.HumanResourcesMasters = hRRepository.GetAllHRMasterData();
            model.Title = "人力資源總覽";
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            HumanResourcesMaster data = new HumanResourcesMaster();
            return View(data);
        }
        [HttpPost]
        public IActionResult Create(HumanResourcesMaster data)
        {
            var test = ModelState.Values;
            bool sucess = hRRepository.AddHRMasterData(data);
            if (sucess)
            {
                return RedirectToAction("Search");
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        [Route("~/[controller]/[action]/{id?}")]
        public IActionResult Edit(int id)
        {
            HumanResourcesMaster data = new HumanResourcesMaster();
            data = hRRepository.GetHRMasterDataByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(HumanResourcesMaster data)
        {
            var sucess = hRRepository.UpdateHRMasterData(data);
            if (sucess)
            {
                return RedirectToAction("Search");
            }
            else
            {
                return RedirectToAction("Edit",new { id = data.Id });
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var sucess = hRRepository.DeleteHRMasterData(id);
            if (sucess)
            {
                return RedirectToAction("Search");
            }
            else
            {
                return RedirectToAction("Search");
            }
        }
    }
}

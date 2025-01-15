using HumanResources.Data;
using HumanResources.Models;
using HumanResources.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Controllers
{
    public class HRSearchController : Controller
    {
        IHRRepository _hRRepository;
        public HRSearchController(IHRRepository hRRepository)
        {
            _hRRepository = hRRepository;
        }
        public IActionResult Search()
        {
            HRSearchViewModel model = new HRSearchViewModel();
            model.HumanResourcesMasters = _hRRepository.GetAllHRMasterData();
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
            bool sucess = _hRRepository.AddHRMasterData(data);
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
            data = _hRRepository.GetHRMasterDataByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(HumanResourcesMaster data)
        {
            var sucess = _hRRepository.UpdateHRMasterData(data);
            if (sucess)
            {
                return RedirectToAction("Search");
            }
            else
            {
                return RedirectToAction("Edit",new { id = data.Id });
            }
        }
        [HttpGet]
        [Route("~/[controller]/[action]/{id?}")]
        public IActionResult Delete(int id)
        {
            var model = _hRRepository.GetHRMasterDataByID(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(HumanResourcesMaster data)
        {
            var sucess = _hRRepository.DeleteHRMasterData(data.Id);
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

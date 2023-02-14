using Microsoft.AspNetCore.Mvc;
using SportShop.DataAccess.Repositories;
using SportShop.DataAccess.ViewModels;

namespace SportShop.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Category : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            CategoryVm vm = new CategoryVm();
            vm.categories = _unitOfWork.category.GetAll();
            return View(vm);
        }
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVm vm = new CategoryVm();
            if(id == null||id==0)
                return View(vm);
            else
            {
                vm.category = _unitOfWork.category.GetT(x => x.Id==id); 
                if(vm.category==null)
                    return NotFound();
                return View(vm);
            }
        }
        [HttpPost]
        public IActionResult CreateUpdate(CategoryVm vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.category.Id == 0)
                {
                    _unitOfWork.category.Add(vm.category);
                    TempData["Seccess"] = "Create Done!";
                }
                else
                {
                    _unitOfWork.category.Update(vm.category);
                    TempData["Seccess"] = "Update Done!";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            else
            {
                var category = _unitOfWork.category.GetT(x => x.Id == id);
                if (category == null)
                    return NotFound();
                else
                    return View(category);
            }
        }
        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeleteDate(int? id)
        {
            var category = _unitOfWork.category.GetT(x => x.Id == id);
            if (category == null)
                return NotFound();
            _unitOfWork.category.Delete(category);
            _unitOfWork.Save();
            TempData["Sccess"] = "Category Delete Done!";
            return RedirectToAction("Index");
        }
    }
}

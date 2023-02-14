using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportShop.DataAccess.Repositories;
using SportShop.DataAccess.ViewModels;

namespace SportShop.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Product : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Product(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ProductVm vm = new ProductVm();
            vm.products = _unitOfWork.product.GetAll(include:"category");
            return View(vm);
        }
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            ProductVm vm = new ProductVm()
            {
                product = new(),
                categories = _unitOfWork.category.GetAll().Select(x =>
                new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })

            };
            if (id == null || id == 0)
                return View(vm);
            else
            {
                vm.product = _unitOfWork.product.GetT(x => x.Id == id);
                //vm.product.category= _unitOfWork.category.GetT(x => x.Id == id);
                if (vm.product == null)
                    return NotFound();
                return View(vm);
            }
        }
        [HttpPost]
        public IActionResult CreateUpdate(ProductVm vm,IFormFile File)
        {
            string fileName = string.Empty;
            if (ModelState.IsValid)
            {
                if(File != null)
                {
                    string Upload = Path.Combine(_webHostEnvironment.WebRootPath, "Images/ProductImages");
                    fileName = File.FileName;
                    string FullPath = Path.Combine(Upload, fileName);
                    if (vm.product.ImgUrl != null)
                    {
                        var OldPath = Path.Combine(_webHostEnvironment.WebRootPath, vm.product.ImgUrl.Trim('\\'));
                        if (System.IO.File.Exists(OldPath))
                        {
                            System.IO.File.Delete(OldPath);
                        }
                    }
                    File.CopyTo(new FileStream(FullPath,FileMode.Create));
                    vm.product.ImgUrl = @"\ProductImage\" + fileName;
                }


                if (vm.product.Id == 0)
                {
                    _unitOfWork.product.Add(vm.product);
                    TempData["Seccess"] = "Create Done!";
                }
                else
                {
                    _unitOfWork.product.Update(vm.product);
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
                var product = _unitOfWork.product.GetT(x => x.Id == id);
                if (product == null)
                    return NotFound();
                else
                    return View(product);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteDate(int? id)
        {
            var product = _unitOfWork.product.GetT(x => x.Id == id);
            if (product == null)
                return NotFound();
            _unitOfWork.product.Delete(product);
            _unitOfWork.Save();
            TempData["Sccess"] = "product Delete Done!";
            return RedirectToAction("Index");
        }
    }
}

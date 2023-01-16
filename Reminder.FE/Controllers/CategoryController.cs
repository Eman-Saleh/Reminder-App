using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reminder.DB.Interfaces;
using Reminder.FE.Models;

namespace Reminder.FE.Controllers
{
    public class CategoryController : Controller
    {
        private SimpleAES simpleAES = new SimpleAES();
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            List<CategoryModel> categoryModel = new List<CategoryModel>();
            var category = _unitOfWork.CategoryTbls.GetAll();
            if (category != null)
            {
                foreach (var item in category)
                {
                    categoryModel.Add(MapCategoryDBToModel(item));
                  
                }
            }
            return View(categoryModel);
        }

        private CategoryModel MapCategoryDBToModel(DB.Models.CategoryTbl item)
        {
            CategoryModel categoryModel = new CategoryModel();
            categoryModel.Id = item.Id;
            if (item.CreatedBy.HasValue)
            {
                categoryModel.CreatedBy = item.CreatedBy.Value;
                categoryModel._CreatedBy =_unitOfWork.UserTbls.GetByID(item.CreatedBy.Value) .UserName;
            }
            categoryModel.Name = item.Name;
            if(item.ParentId != null)
            {
                categoryModel.ParentId = item.ParentId;
                categoryModel.ParentName = _unitOfWork.CategoryTbls.GetByID(item.ParentId.Value).Name;
            }
            return categoryModel;
        }

      
        // GET: CategoryController/AddEditCategory/5
        [HttpGet]
        public IActionResult AddEditCategory(int id)
        {
            try
            {
                ViewBag.Categories = _unitOfWork.CategoryTbls.GetAll();
                if (id != 0 && id != null)
                {

                    var categoryTbl = _unitOfWork.CategoryTbls.GetByID(id);
                    CategoryModel CategoryModel = MapCategoryDBToModel(categoryTbl);
                    return View(CategoryModel);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        // POST: CategoryController/AddEditCategory/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEditCategory(string id, CategoryModel CategoryMdl)
        {
            try
            {
                ViewBag.Categories = _unitOfWork.CategoryTbls.GetAll();
                if (ModelState.IsValid)
                {

                    if (id != null && id != "0")
                    {
                        int Categoryid = int.Parse(id);
                        
                        var categoryTbl = _unitOfWork.CategoryTbls.GetByID(Categoryid);
                      
                       // categoryTbl.CreatedBy =int.Parse( simpleAES.DecryptString(HttpContext.Session.GetString("EncryptedUserID")));
                        categoryTbl.ParentId = int.Parse(CategoryMdl.ParentName);
                        categoryTbl.Name = CategoryMdl.Name;
                        _unitOfWork.CategoryTbls.Update(categoryTbl);
                        _unitOfWork.Complete();

                    }
                    else
                    {
                        var categoryTbl = new DB.Models.CategoryTbl(); 
                        categoryTbl.CreatedBy = int.Parse(simpleAES.DecryptString(HttpContext.Session.GetString("EncryptedUserID")));

                        categoryTbl.ParentId = int.Parse(CategoryMdl.ParentName);
                        categoryTbl.Name = CategoryMdl.Name;
                        _unitOfWork.CategoryTbls.Add(categoryTbl);
                        _unitOfWork.Complete();
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        // POST: CategoryController/Delete/5
        [HttpGet]
       
        public ActionResult Delete(string  id)
        {
            try
            {
                // TODO: Add delete logic here
                int _id = int.Parse(id);
                _unitOfWork.CategoryTbls.DeleteByID(_id);
                _unitOfWork.Complete();
                return Json(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error" });

            }
        }
    }
}

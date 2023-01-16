using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reminder.DB.Interfaces;
using Reminder.FE.Models;

namespace Reminder.FE.Controllers
{
    public class UserController : Controller
    {
        private SimpleAES simpleAES = new SimpleAES();
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: UserController
        public IActionResult Index()
        {
            List<UserModel> userModel = new List<UserModel>();
            var user = _unitOfWork.UserTbls.GetAll();
            if(user !=null)
            {
                foreach(var item in user)
                {
                    userModel.Add (new UserModel { Id = item.Id ,
                    Deleted=item.Deleted.Value,
                    Email=item.Email,
                    UserName=item.UserName
                    });
                }
            }
            return View(userModel);
        }
        

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        [HttpGet]
        public IActionResult AddEditUser(int id)
        {
            try
            {
                if (id != 0 && id != null)
                {

                    var usr = _unitOfWork.UserTbls.GetByID(id);
                    UserModel userModel = MapUserDBToModel(usr);
                    return View(userModel);
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


        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEditUser(string id, UserModel userMdl)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (id != null && id != "0")
                    {
                        int Userid = int.Parse(id);
                        var testUserEmail = _unitOfWork.UserTbls.GetAll().Where(a => a.Id != Userid && a.Email == userMdl.Email).AsQueryable();
                        if (testUserEmail.ToList().Count > 0)
                        {
                            ModelState.AddModelError("Email", "Email exist");
                            return View(userMdl);
                        }
                        var user = _unitOfWork.UserTbls.GetByID(Userid);

                        user.Email = userMdl.Email;
                        user.UserName = userMdl.UserName;
                        _unitOfWork.UserTbls.Update(user);
                        _unitOfWork.Complete();

                    }
                    else
                    {
                        var testUserEmail = _unitOfWork.UserTbls.GetAll().Where(a => a.Email == userMdl.Email).AsQueryable();
                        if (testUserEmail.ToList().Count >0)
                        {
                            ModelState.AddModelError("Email", "Email exist");
                            return View(userMdl);
                        }

                        var user = new DB.Models.UserTbl();

                        user.Email = userMdl.Email;
                        user.UserName = userMdl.UserName;

                        _unitOfWork.UserTbls.Add(user);
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
        private UserModel MapUserDBToModel(DB.Models.UserTbl usr)
        {
            UserModel userModel = new UserModel();
            userModel.UserName = usr.UserName;
            userModel.Email = usr.Email;
            userModel.Deleted = usr.Deleted.Value ;
            return userModel;
        }

     

        // POST: UserController/Delete/5
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(string  id)
        {
            try
            {
                // TODO: Add delete logic here
                int _id = int.Parse(id);
                _unitOfWork.UserTbls.DeleteByID(_id);
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

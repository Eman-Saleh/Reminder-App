using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reminder.BE.Repositories;
using Reminder.DB.Interfaces;
using Reminder.FE.Models;
using System.Net;
using System.Net.Mail;

namespace Reminder.FE.Controllers
{
    public class ReminderController : Controller
    {
        private SimpleAES simpleAES = new SimpleAES();
        private readonly IUnitOfWork _unitOfWork;
        public ReminderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: ReminderController
        public ActionResult Index()
        {
            List<ReminderModel> reminderModel = new List<ReminderModel>();
            var _reminder = _unitOfWork.ReminderTbls.GetAll();
            if (_reminder != null)
            {
                foreach (var item in _reminder)
                {
                    reminderModel.Add(MapFromDBToModel(item));

                }
            }
            return View(reminderModel);
        }
        // GET: ReminderController/AddEditReminder/5
        [HttpGet]
        public IActionResult AddEditReminder(int id)
        {
            try
            {
                ViewBag.Categories = _unitOfWork.CategoryTbls.GetAll();
                if (id != 0 && id != null)
                {
                    var reminderTbl = _unitOfWork.ReminderTbls.GetByID(id);
                    ReminderModel ReminderModel = MapFromDBToModel(reminderTbl);
                    return View(ReminderModel);
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
        // POST: ReminderController/AddEditReminder/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEditReminder(string id, ReminderModel ReminderMdl)
        {
            try
            {
                ViewBag.Categories = _unitOfWork.CategoryTbls.GetAll();
                if (ModelState.IsValid)
                {

                    if (id != null && id != "0")
                    {
                        int Reminderid = int.Parse(id);
                        var reminderTbl = _unitOfWork.ReminderTbls.GetByID(Reminderid);
                        reminderTbl.CreatedBy = int.Parse(simpleAES.DecryptString(HttpContext.Session.GetString("UserID")));
                        reminderTbl.CategoryId = ReminderMdl.CategoryId;
                        reminderTbl.Title = ReminderMdl.Title;
                        reminderTbl.ReminderDate = ReminderMdl.ReminderDate;
                        _unitOfWork.ReminderTbls.Update(reminderTbl);
                        _unitOfWork.Complete();
                    }
                    else
                    {
                        var reminderTbl = new DB.Models.ReminderTbl();
                        reminderTbl.CategoryId = ReminderMdl.CategoryId;
                        reminderTbl.Title = ReminderMdl.Title;
                        reminderTbl.ReminderDate = ReminderMdl.ReminderDate;
                        _unitOfWork.ReminderTbls.Add(reminderTbl);
                        _unitOfWork.Complete();
                        int userId = int.Parse(simpleAES.DecryptString(HttpContext.Session.GetString("EncryptedUserID")));
                        string _userMail=  _unitOfWork.UserTbls.GetByID(userId).Email;

                           BackgroundJob.Schedule(()=>SendMail(ReminderMdl.Title + " " + ReminderMdl.CategoryId,_userMail),ReminderMdl.ReminderDate.Value );
                      //  new BackgroundJobClient().Schedule( () => Hangfire.RecurringJob.AddOrUpdate(reminderTbl.Id.ToString(), () => SendMail(ReminderMdl.Title + " " + ReminderMdl.CategoryId, _userMail), ReminderMdl.ReminderDate.Value));

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
        public void SendMail(string mail,string ToEmail)
        {
            // Implement any logic you want - not in the controller but in some repository.
            Console.WriteLine($"This is a test - Hello {ToEmail} {mail}"); //to creator of remindeer with title and category data

            //Send mail details and credintials
            //using (var message = new MailMessage("myemail@gmail.com", ToEmail))
            //{
            //    message.Subject =mail;
            //    message.Body = "Message body test at " + DateTime.Now;
            //    using (SmtpClient client = new SmtpClient
            //    {
            //        EnableSsl = true,
            //        Host = "smtp.gmail.com",
            //        Port = 587,
            //        Credentials = new NetworkCredential("myemail@gmail.com", "myPass")
            //    })
            //    {
            //        client.Send(message);
            //    }   
            //}
        }

        private ReminderModel MapFromDBToModel(DB.Models.ReminderTbl item)
        {ReminderModel reminderModel = new ReminderModel();
            reminderModel.Title=item.Title;
            reminderModel.ReminderDate=item.ReminderDate;
            if (item.CreatedBy != null)
            {
                reminderModel.CreatedBy = item.CreatedBy;
                reminderModel._CreatedBy = _unitOfWork.UserTbls.GetByID(item.CreatedBy.Value).UserName;
            }
            if (item.CategoryId != null)
            {
                reminderModel.CategoryId = item.CategoryId;
                reminderModel._Category = _unitOfWork.CategoryTbls.GetByID(item.CategoryId.Value).Name;
            }
            return reminderModel;
        }

        //// POST: ReminderController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        _unitOfWork.ReminderTbls.DeleteByID(id);
        //        _unitOfWork.Complete();
        //        return Json(new { status = "success" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { status = "error" });

        //    }
        //}
    }
}

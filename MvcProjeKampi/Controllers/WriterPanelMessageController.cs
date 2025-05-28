using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            var writer = wm.GetByWriterMail(mail);
            if (writer == null)
            {
                return RedirectToAction("Page404", "ErrorPages");
            }

            var listin = mm.GetListInbox(mail);
            return View(listin);
        }

        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];
            var writer = wm.GetByWriterMail(mail);
            if (writer == null)
            {
                return RedirectToAction("Page404", "ErrorPages");
            }

            var listsend = mm.GetListSendbox(mail);
            return View(listsend);
        }

        public PartialViewResult MessageList()
        {
            string mail = (string)Session["WriterMail"];
            ViewBag.inb = mm.GetListInbox(mail).Count();
            ViewBag.send = mm.GetListSendbox(mail).Count();  
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            var writer = wm.GetByWriterMail(sender);
            if (writer == null)
            {
                return RedirectToAction("Page404", "ErrorPages");
            }

            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
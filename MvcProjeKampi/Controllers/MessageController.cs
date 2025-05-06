using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());

        public ActionResult Inbox()
        {
            var listin = mm.GetListInbox();
            return View(listin);
        }

        public ActionResult Sendbox()
        {
            var listsend = mm.GetListSendbox();
            return View(listsend);
        }

        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            return View();
        }
    }
}
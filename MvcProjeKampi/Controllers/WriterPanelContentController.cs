using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        public ActionResult MyContent(string p)
        {
            //Context c = new Context();
            //p = (string)Session["WriterMail"];
            //var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            string mail = (string)Session["WriterMail"];
            var writer = wm.GetByWriterMail(mail);
            if (writer == null)
            {
                return RedirectToAction("Page404", "ErrorPages");
            }

            var values = cm.GetListByWriter(writer.WriterID);
            return View(values);
        }

        public ActionResult AddContent(int id)
        {
            ViewBag.vlh = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writer = wm.GetByWriterMail(mail);
            if (writer == null)
            {
                return RedirectToAction("Page404", "ErrorPages");
            }

            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writer.WriterID;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}
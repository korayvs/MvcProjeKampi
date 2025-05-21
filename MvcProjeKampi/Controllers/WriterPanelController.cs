using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        //Context c = new Context();

        public ActionResult WriterProfile()
        {
            string mail = (string)Session["WriterMail"];
            var writer = wm.GetByWriterMail(mail);
            if (writer != null)
            {
                int id = writer.WriterID;
                var value = wm.GetById(id);
                return View(value);
            }

            else
            {
                return RedirectToAction("Page404", "ErrorList");
            }
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading", "WriterPanel");
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

        public ActionResult MyHeading()
        {            
            //p = (string)Session["WriterMail"];
            //var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            string mail = (string)Session["WriterMail"];
            var writer = wm.GetByWriterMail(mail);
            if (writer == null)
            {
                return RedirectToAction("Page404", "ErrorPages");
            }

            var values = hm.GetListByWriter(writer.WriterID);
            return View(values);
        }

        public ActionResult NewHeading()
        {            
            //ViewBag.m = deger;

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            //string writermailinfo = (string)Session["WriterMail"];
            //var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            //ViewBag.d = writeridinfo;
            //p.WriterID = writeridinfo;

            string mail = (string)Session["WriterMail"];
            var writer = wm.GetByWriterMail(mail);

            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writer.WriterID;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var value = hm.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DelHeading(int id)
        {
            var value = hm.GetById(id);
            if (value.HeadingStatus == true)
            {
                value.HeadingStatus = false;
                hm.HeadingDelete(value);
            }

            else
            {
                value.HeadingStatus = true;
                hm.HeadingDelete(value);
            }
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p = 1)
        {
            var headings = hm.GetList().ToPagedList(p, 4);
            return View(headings);
        }
    }
}


//<customErrors mode="On">
//		  <error statusCode="404" redirect="/ErrorPages/Page404/"/>
//	  </customErrors>
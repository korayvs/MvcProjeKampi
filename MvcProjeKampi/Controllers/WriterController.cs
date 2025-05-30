﻿using BusinessLayer.Concrete;
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
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterValidator writerValidator = new WriterValidator();

        public ActionResult Index()
        {
            var values = wm.GetList();
            return View(values);
        }

        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {            
            ValidationResult results = writerValidator.Validate(p);
            if(results.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
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

        public ActionResult EditWriter(int id)
        {
            var value = wm.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
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

        public ActionResult HeadingsByWriter(int id = 1)
        {
            var headings = hm.GetListByWriter(id);
            return View(headings);
        }
    }
}
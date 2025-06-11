using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class SkillCardController : Controller
    {
        SkillManager sm = new SkillManager(new EfSkillDal());

        public ActionResult Index()
        {
            var value = sm.GetList();
            return View(value);
        }
    }
}
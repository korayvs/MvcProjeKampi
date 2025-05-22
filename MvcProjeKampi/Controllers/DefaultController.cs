using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headinglist = hm.GetList();
            return View(headinglist);
        }

        public PartialViewResult Index(int? id)     //int id = 0
        {
            int headingid = id ?? 0;
            if (headingid != 0 && headingid != null)
            {
                var contentlist = cm.GetListByHeadingId(headingid);
                return PartialView(contentlist);
            }
            else
            {
                var result = cm.GetList();
                return PartialView(result);
            }
            //var contentlist = cm.GetListByHeadingId(id);
            //return PartialView(contentlist);
        }
    }
}
using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Rules.Conditions;
using Glass.Mapper.Sc;
using Models.Callouts;

namespace USD.Website.Controllers
{
    public class CalloutsController : Controller
    {
        public ActionResult LinksCallout()
        {
            Sitecore.Data.Items.Item item = Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.Item;
            LinksCallout flc = item.GlassCast<LinksCallout>();
            return PartialView(flc);
        }

        public ActionResult LinkItem()
        {
            Sitecore.Data.Items.Item item = Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.Item;

            if (item != null)
            {
                LinkItem li = item.GlassCast<LinkItem>();

                return PartialView(li);
            }
            else
            {

                return PartialView(null);
            }
        }
    }
}
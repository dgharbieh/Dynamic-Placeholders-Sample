using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Models.Base;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Callouts
{
     [SitecoreType(TemplateId = "{05FFD154-2CED-42F4-B5B3-4E260CFEA7C6}", AutoMap = true)]
    public class LinksCallout : BasePage
    {
        public virtual string Title { get; set; }

        [SitecoreField("Icon")]
        public virtual Image Icon { get; set; }
    }
   
   
}

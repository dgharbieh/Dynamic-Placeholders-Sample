using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Callouts
{
    [SitecoreType(TemplateId = "{8D722281-5378-4581-AF0C-A64EE34D4F10}", AutoMap = true)]
    public class LinkItem : BasePage
    {
        public virtual string Title { get; set; }

        [SitecoreField("Link")]
        public virtual Link Link { get; set; }

    }
}

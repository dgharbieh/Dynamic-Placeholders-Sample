using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Base
{
    public class BasePage
    {
        public virtual ID Id { get; set; }
        public virtual string Content { get; set; }
    }
}

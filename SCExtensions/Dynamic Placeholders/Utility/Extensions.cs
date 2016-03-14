using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using System.Xml;
using Sitecore;
using System.Web;
using Sitecore.Mvc.Presentation;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Common;
using System.Globalization;

namespace SCExtensions.DynamicPlaceholders.Utility
{
    public static class DynamicPlaceholderExtension
    {
        public static HtmlString DynamicPlaceholder(this SitecoreHelper helper, string dynamicKey)
        {
            string DynamicKey = GetDynamicKey(dynamicKey);
            if (!String.IsNullOrWhiteSpace(DynamicKey)) dynamicKey = DynamicKey;

            Guid currentRenderingId = RenderingContext.Current.Rendering.UniqueId;
            return helper.Placeholder(String.Format("{0}_{1}", dynamicKey, currentRenderingId));
        }

        private static string GetDynamicKey(string placeHolderName)
        {
            bool NeedIncrement = false;
            int IncrementStep = 0;
            IEnumerable<PlaceholderContext> myPlaceholders = ContextService.Get().GetInstances<PlaceholderContext>();

            foreach (PlaceholderContext context in myPlaceholders)
            {
                if (context.PlaceholderName == placeHolderName ||
                    context.PlaceholderName.StartsWith(placeHolderName + "_"))
                {
                    NeedIncrement = true;
                    IncrementStep++;
                }
            }

            if (NeedIncrement)
            {
                placeHolderName += "_" + IncrementStep.ToString(CultureInfo.InvariantCulture);
            }

            return placeHolderName;
        }
    }

    public static class Extensions
    {
        public static void RemoveRenderingReference(this Item item, string renderingReferenceUid)
        {
            var doc = new XmlDocument();
            doc.LoadXml(item[FieldIDs.LayoutField]);

            //remove the orphaned rendering reference from the layout definition
            var node = doc.SelectSingleNode(string.Format("//r[@uid='{0}']", renderingReferenceUid));

            if (node != null && node.ParentNode != null)
            {
                node.ParentNode.RemoveChild(node);

                //save layout definition back to the item
                using (new EditContext(item))
                {
                    item[FieldIDs.LayoutField] = doc.OuterXml;
                }
            }
        }
    }
}

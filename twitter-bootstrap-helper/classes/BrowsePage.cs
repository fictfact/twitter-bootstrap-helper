using System;
using System.Collections.Generic;

namespace twitterbootstraphelper.classes
{
	public class BrowsePage
	{

		public BrowsePage()
		{
			this.cssClass = new List<string>();
		}

		public int pageNum;
		public string label;
		public List<string> cssClass;

        public string GetCSSClasses
        {
            get
            {
                if (this.cssClass != null)
                {
                    string cssTemp = "";

                    foreach (var temp in this.cssClass)
                    {
                        cssTemp += temp + " ";
                    }

                    return cssTemp.Trim();
                }

                return "";
            }
        }
	}
}


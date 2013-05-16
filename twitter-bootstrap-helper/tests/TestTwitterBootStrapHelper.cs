using System;
using System.Collections.Generic;
using NUnit.Framework;

using twitterbootstraphelper;
using twitterbootstraphelper.classes;

namespace twitterbootstraphelper.tests
{
	[TestFixture()]
	public class TestTwitterBootStrapHelper
	{
		[Test()]
		public void TestCase ()
		{
			TwitterBootStrapHelper tbs = new TwitterBootStrapHelper();

            //let's create a test which will return a menu with 9 items
            List<BrowsePage> testMenu = new List<BrowsePage>();

            int pageIndex = 2;

            for (int i = 1; i < 10; i++)
            {
                BrowsePage bp = new BrowsePage();

                bp.label = i.ToString();

                bp.pageNum = i;

                if (i == pageIndex)
                    bp.cssClass.Add("active");

                testMenu.Add(bp);
            }

            List<BrowsePage> menu = tbs.GetBrowseMenu(9, 10, 1, 2, "active");

            Assert.AreEqual(testMenu.Count, menu.Count);

            for (int i = 0; i < testMenu.Count; i++)
            {
                BrowsePage testBP = testMenu[i];

                BrowsePage menuBP = menu[i];

                Assert.AreEqual(testBP.label, menuBP.label);

                Assert.AreEqual(testBP.pageNum, menuBP.pageNum);

                Assert.AreEqual(testBP.GetCSSClasses, menuBP.GetCSSClasses);
            }

		}
	}
}


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
		public void TestSimpleMenu ()
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

            RunAssertions(testMenu, menu);

		}

        [Test()]
        public void TestMenuLessThanPageSize()
        {
            TwitterBootStrapHelper tbs = new TwitterBootStrapHelper();

            //let's create a test which will return a menu with 2 items + 'Next' button
            List<BrowsePage> testMenu = new List<BrowsePage>();

            int pageIndex = 1;

            for (int i = 1; i < 3; i++)
            {
                BrowsePage bp = new BrowsePage();

                bp.label = i.ToString();

                bp.pageNum = i;

                if (i == pageIndex)
                    bp.cssClass.Add("active");

                testMenu.Add(bp);
            }

            BrowsePage testBP = new BrowsePage();

            testBP.label = "Next";

            testBP.pageNum = 3;

            testMenu.Add(testBP);

            List<BrowsePage> menu = tbs.GetBrowseMenu(6, 2, 2, 1, "active");

            RunAssertions(testMenu, menu);

        }

        public void RunAssertions(List<BrowsePage> leftList, List<BrowsePage> rightList)
        {
            Assert.AreEqual(leftList.Count, rightList.Count);

            for (int i = 0; i < leftList.Count; i++)
            {
                BrowsePage testBP2 = leftList[i];

                BrowsePage menuBP = rightList[i];

                Assert.AreEqual(testBP2.label, menuBP.label);

                Assert.AreEqual(testBP2.pageNum, menuBP.pageNum);

                Assert.AreEqual(testBP2.GetCSSClasses, menuBP.GetCSSClasses);
            }
        }
	}
}


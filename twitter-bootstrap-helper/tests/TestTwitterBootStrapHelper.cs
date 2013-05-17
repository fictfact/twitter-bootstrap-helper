using System;
using System.Linq;
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
		public void TestGetMenuWedge ()
		{
			TwitterBootStrapHelper tbs = new TwitterBootStrapHelper ();

			List<BrowsePage> menu = tbs.GetMenuWedge (6, 3, 5, "active");

			List<BrowsePage> testMenu = new List<BrowsePage> ();

			//i want a list that has the following 4,5(active),6)
			for (int i = 4; i<7; i++) {

				BrowsePage bp = new BrowsePage();

                bp.label = i.ToString();

                bp.pageNum = i;

                if (i == 5)
                    bp.cssClass.Add("active");

                testMenu.Add(bp);
			}

			Assert.AreEqual(menu.Count, 3);

			RunAssertions(testMenu, menu);
		}

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

            List<BrowsePage> menu = tbs.GetBrowseMenu(9, 10, 2, "active");

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

            List<BrowsePage> menu = tbs.GetBrowseMenu(6, 2, 1, "active");

            RunAssertions(testMenu, menu);

        }

        [Test()]
        public void TestRealWorldTest()
        {
            TwitterBootStrapHelper tbs = new TwitterBootStrapHelper();

            List<BrowsePage> menu = tbs.GetBrowseMenu(1316, 5, 1, "active");

            //should return a list with 6 items, last item should be pageNum of 6 and Label of "Next"
            Assert.AreEqual(menu.Count, 6);

            var last = menu[menu.Count - 1];

            Assert.AreEqual(last.pageNum, 6);

            Assert.AreEqual(last.label, "Next");

            menu = tbs.GetBrowseMenu(1316, 5, 6, "active");

            //should return a list with 7 items, last item should be pageNum of 11 and Label of "Next" and first should be 6 and "Prev"
            Assert.AreEqual(menu.Count, 7);

            last = menu[menu.Count - 1];

            Assert.AreEqual(last.pageNum, 11);

            Assert.AreEqual(last.label, "Next");

            var first = menu.First();

            Assert.AreEqual(first.pageNum, 5);
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


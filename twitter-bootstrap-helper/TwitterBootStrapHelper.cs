using System;
using System.Collections.Generic;

using twitterbootstraphelper.classes;

namespace twitterbootstraphelper
{
	public class TwitterBootStrapHelper
	{
		public TwitterBootStrapHelper ()
		{
		}

		public List<BrowsePage> GetBrowseMenu (int itemSize, int menuSize, int pageSize, int currentPage = 1, string cssActive="")
		{
			List<BrowsePage> browseList = new List<BrowsePage> ();

			int numberOfPages = (int)(itemSize / pageSize);

			if (numberOfPages <= menuSize) {

				int counter = 1;

				for (int x = 1; x <= numberOfPages; x++) {

					BrowsePage bp = new BrowsePage ();

					bp.pageNum = x;

					bp.label = x.ToString ();

					if ((currentPage == x) && (cssActive != "")) {
						bp.cssClass.Add ("pageActive");
					}

					browseList.Add (bp);

					counter++;
				}

				if ((itemSize % 100) > 0)
            	{
                	BrowsePage bp = new BrowsePage();

                	bp.pageNum = counter;

					bp.label = counter.ToString();

                	browseList.Add(bp);
            	}

			} else {

			}

			return browseList;
		}
	}
}


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

            int counter = 1;

			if (numberOfPages <= menuSize) {
                
				for (int x = 1; x <= numberOfPages; x++) {

					BrowsePage bp = new BrowsePage ();

					bp.pageNum = x;

					bp.label = x.ToString ();

					if ((currentPage == x) && (cssActive != "")) {
						bp.cssClass.Add (cssActive);
					}

					browseList.Add (bp);

					counter++;
				}

				if ((itemSize % pageSize) > 0)
            	{
                	BrowsePage bp = new BrowsePage();

                	bp.pageNum = counter;

					bp.label = counter.ToString();

                	browseList.Add(bp);
            	}

			} else {

                if (currentPage < menuSize)
                {
                    for (int i = 1; i < menuSize + 1; i++)
                    {
                        BrowsePage bp = new BrowsePage();

                        bp.pageNum = i;

                        bp.label = i.ToString();

                        if ((currentPage == i) && (cssActive != ""))
                        {
                            bp.cssClass.Add(cssActive);
                        }

                        browseList.Add(bp);

                        counter++;
                    }

                    if (counter <= menuSize + 1)
                    {
                        BrowsePage bp = new BrowsePage();

                        bp.pageNum = counter;

                        bp.label = "Next";

                        browseList.Add(bp);
                    }
                } //end if (currentPage < pageSize)

			}

			return browseList;
		}
	}
}


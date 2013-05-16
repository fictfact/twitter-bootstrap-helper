using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

using twitterbootstraphelper.classes;

namespace twitterbootstraphelper
{
	public class TwitterBootStrapHelper
	{
		public TwitterBootStrapHelper ()
		{
		}

		public List<BrowsePage> GetBrowseMenu (int itemSize, int menuSize, int currentPage = 1, string cssActive="")
		{
			List<BrowsePage> browseList = new List<BrowsePage> ();

			browseList = this.GetMenuWedge (itemSize, menuSize, currentPage, cssActive);

			//let's determine if we need "next" or "prev" buttons
			var first = browseList.First ();

			int pageNum = first.pageNum;

			if (pageNum > 1) {

				BrowsePage bp = new BrowsePage ();

				bp.pageNum = pageNum - 1;

				bp.label = "Prev";

				browseList [0] = bp;
			}

			var last = browseList [browseList.Count - 1];

			pageNum = last.pageNum;

			if (pageNum < itemSize) {

				BrowsePage bp = new BrowsePage ();

				bp.pageNum = pageNum + 1;

				bp.label = "Next";

				browseList.Add(bp);

			}

			return browseList;
		}

		public List<BrowsePage> GetMenuWedge (int itemSize, int menuSize, int currentPage, string cssActive="")
		{
			List<BrowsePage> browseList = new List<BrowsePage> ();

			for (int i=1; i<itemSize+1; i++) {

				BrowsePage bp = new BrowsePage ();

				bp.pageNum = i;

				bp.label = i.ToString ();

				if ((currentPage == i) && (cssActive != "")) {
					bp.cssClass.Add (cssActive);
				}

				browseList.Add (bp);
			}

			if (itemSize <= menuSize) {
				return browseList;
			}

			//need to split into wedges based on menuSize
			int numberOfWedges = (int)itemSize / menuSize;

			List<List<BrowsePage>> wedges = new List<List<BrowsePage>>();

			int pointer = 0;

			int wedgeLocation = 0;

			bool foundWedge = false;

			for (int i = 0; i<numberOfWedges; i++) {

				wedges.Add(new List<BrowsePage>());

				int pointerStart = pointer;

				while(pointer < (pointerStart + menuSize))
				{
					wedges[i].Add(browseList[pointer]);

					if(browseList[pointer].pageNum == currentPage)
					{
						wedgeLocation = i;
						foundWedge = true;
					}

					pointer++;
				}

				if(foundWedge)
					break;
			}

			return wedges[wedgeLocation];
		}
	}
}


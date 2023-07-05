﻿namespace EduHomeUI.Areas.EHMasterPanel.Models
{
	public class Pager
	{
		public int TotalItems { get; private set; }
		public int CurrentPage { get; private set; }
		public int PageSize { get; private set; }
		public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
		public int StartPage { get; private set; }
		public int EndPage { get; private set; }

		public Pager(int totalItems, int page, int pageSize = 10)
		{
			TotalItems = totalItems;
			CurrentPage = page;
			PageSize = pageSize;

			CalculateStartAndEndPages();
		}

		private void CalculateStartAndEndPages()
		{
			int startPage = CurrentPage - 5;
			int endPage = CurrentPage + 4;

			if (startPage <= 0)
			{
				endPage = endPage - (startPage - 1);
				startPage = 1;
			}
			if (endPage > TotalPages)
			{
				endPage = TotalPages;
				if (endPage > 10)
				{
					startPage = endPage - 9;
				}
			}

			StartPage = startPage;
			EndPage = endPage;
		}
	}
}

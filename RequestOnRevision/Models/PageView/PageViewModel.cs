using System;

namespace RequestOnRevision.Models
{
    public class PageViewModel
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public PageViewModel(int countElements, int pageNumber, int elementsOnPage)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(countElements / (double)elementsOnPage);
        }

        public bool HasPreviousPage
        {
            get { return (PageNumber > 1); }
        }

        public bool HasNextPage
        {
            get { return (PageNumber < TotalPages); }
        }
    }
}
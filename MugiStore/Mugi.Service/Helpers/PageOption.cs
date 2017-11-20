using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Service.Helpers
{
    public class PageOption
    {
        private int _pageNumber = 1;

        public PageOption()
        {
            PageSize = int.MaxValue;
        }

        /// <summary>
        ///     Default equals int.MaxValue
        /// </summary>
        public int PageSize { get; set; }

        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value > 1 ? value : 1; }
        }

        public int PageStartIndex
        {
            get { return (PageNumber <= 1 || PageSize == int.MaxValue) ? 0 : (PageNumber - 1) * PageSize; }
        }

        public bool IsValid
        {
            get { return PageSize != int.MaxValue; }
        }
    }
}

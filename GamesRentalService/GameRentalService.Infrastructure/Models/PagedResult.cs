using System;
using System.Collections.Generic;
using System.Text;

namespace GameRentalService.Infrastructure.Models
{
    public abstract class PagedResultBase 
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage { get { return (this.CurrentPage - 1) * this.PageSize + 1; } }
        public int LastRowOnPage { get { return Math.Min(this.CurrentPage * this.PageSize, this.RowCount); } }
    }


    public class PagedResult<T> : PagedResultBase where T : class
    {
        public List<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}

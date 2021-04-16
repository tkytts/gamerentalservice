using System;
using System.Collections.Generic;
using System.Text;

namespace GameRentalService.Infrastructure.Models
{
    public class PaginationParameters
    {
        private const int _maxPageSize = 20;
        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
            }
        }
    }
}

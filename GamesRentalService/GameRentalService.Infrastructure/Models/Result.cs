using System;
using System.Collections.Generic;
using System.Text;

namespace GameRentalService.Infrastructure.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }
    }

    public class Result<T> where T : class
    {
        public T ResultObject { get; set; }
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookServiceSample.Models
{
    public class BookChapter
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public String Title { get; set; }
        public int Pages { get; set; }
    }
}
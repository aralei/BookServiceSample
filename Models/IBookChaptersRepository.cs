using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookServiceSample.Models
{
    interface IBookChaptersRepository
    {
        void Init();
        void Add(BookChapter bookChapter);
        IEnumerable<BookChapter> GetAll();
        BookChapter Find(Guid id);
        BookChapter Remove(Guid id);
        void Update(BookChapter bookChapter);
    }
}

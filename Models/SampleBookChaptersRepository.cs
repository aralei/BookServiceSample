using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookServiceSample.Models
{
    public class SampleBookChaptersRepository : IBookChaptersRepository
    {
        //found collections(ConcurrentDictionary)
        private readonly ConcurrentDictionary<Guid, BookChapter> _chapters =
            new ConcurrentDictionary<Guid, BookChapter>();
        public void Add(BookChapter chapter)
        {
            //Guidでidを生成する
            chapter.Id = Guid.NewGuid();
            //key=chapter.Idにvalue=chapterを入れる
            _chapters[chapter.Id] = chapter;
        }

        public BookChapter Find(Guid id)
        {
            BookChapter chapter;
            //idでvalueを検索し、変数chapterに格納する
            _chapters.TryGetValue(id, out chapter);
            return chapter;
        }

        //lamda式で配列を返す
        public IEnumerable<BookChapter> GetAll() => _chapters.Values;

        public void Init()
        {
            //chapterを追加保存する
            Add(new BookChapter
            {
                Number = 1,
                Title = "Application Architectures",
                Pages = 35
            });
            Add(new BookChapter
            {
                Number = 2,
                Title = "Core C#",
                Pages = 42
            });
            //more chapters
        }

        public BookChapter Remove(Guid id)
        {
            BookChapter removed; 
            //TryRemoveメソッド
            _chapters.TryRemove(id, out removed);
            return removed;
        }

        public void Update(BookChapter chapter)
        {
            _chapters[chapter.Id] = chapter;
        }
    }
}
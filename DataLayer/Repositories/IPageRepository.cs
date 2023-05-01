using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepository:IDisposable
    {
        IEnumerable<Page> GetAllPage();

        Page GetPageByID(int pageID);

        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(int pageID);
        bool DeletePage(Page page);

        void save();


        IEnumerable<Page> TopNews(int take=4);
        IEnumerable<Page> PagesInSlider();

        IEnumerable<Page> Lastnews(int take=4);

        IEnumerable<Page> ShowPageByGroupId(int groupid);

        IEnumerable<Page> SearchPage(string search);
    }
}

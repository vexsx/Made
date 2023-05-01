using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        private MadeContext db;
        public PageRepository(MadeContext context)
        {
            this.db = context;
        }
        public bool DeletePage(int pageID)
        {
            try
            {
                var page = GetPageByID(pageID);
                DeletePage(page);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePage(Page page)
        {
            try
            {
                db.Entry(page).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Page> GetAllPage()
        {
            return db.pages;
        }

        public Page GetPageByID(int pageID)
        {
            return db.pages.Find(pageID);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                db.pages.Add(page);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Page> Lastnews(int take = 4)
        {
            return db.pages.OrderByDescending(p => p.CreateTime).Take(take);
        }

        public IEnumerable<Page> PagesInSlider()
        {
            return db.pages.Where(p => p.ShowInSlider == true).ToList();
        }

        public void save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Page> SearchPage(string search)
        {

            return
                db.pages.Where(
                    p =>
                        p.Title.Contains(search) || p.ShortDescription.Contains(search) || p.Tags.Contains(search) ||
                        p.Text.Contains(search)).Distinct();

        }

        public IEnumerable<Page> ShowPageByGroupId(int groupid)
        {
            return db.pages.Where(p => p.GroupID == groupid);
        }

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return db.pages.OrderByDescending(p => p.visit).Take(take);
        }

        public bool UpdatePage(Page page)
        {
            try
            {
                db.Entry(page).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

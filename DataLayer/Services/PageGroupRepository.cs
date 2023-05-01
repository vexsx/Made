using DataLayer.Repositories;
using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
         private MadeContext db;

        public PageGroupRepository(MadeContext context)
        {
            this.db = context;
        }

        public PageGroup GetGroupByID(int GroupId)
        {
            return db.pageGroups.Find(GroupId);
        }

        public IEnumerable<PageGroup> GetPageGroups()
        {
            return db.pageGroups;
        }

        public bool InsertGroup(PageGroup PageGroup)
        {
            try
            {
                 db.pageGroups.Add(PageGroup);
                return true;    
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeleteGroup(int GroupId)
        {
            try
            {
                var group = GetGroupByID(GroupId);
                DeleteGroup(group);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGroup(PageGroup PageGroup)
        {
            try
            {
                db.Entry(PageGroup).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public void Save()
        {
            db.SaveChanges();
        }

        public bool UpdateGroup(PageGroup PageGroup)
        {
            try
            {
                db.Entry(PageGroup).State = System.Data.Entity.EntityState.Modified;
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

        public IEnumerable<ShowGroupViewModel> ShowGroupsForView()
        {
            return db.pageGroups.Select(g => new ShowGroupViewModel()
            {
                GroupID= g.GroupID,
                GroupTitle= g.GroupTitle,
                PageCount = g.Pages.Count
            });
        }
    }
}

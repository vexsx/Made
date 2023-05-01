using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IPageGroupRepository:IDisposable
    {
        IEnumerable<PageGroup> GetPageGroups();

        PageGroup GetGroupByID(int GroupId);

        bool InsertGroup(PageGroup PageGroup);
        bool UpdateGroup(PageGroup PageGroup);

        bool DeleteGroup(int GroupId);
        bool DeleteGroup(PageGroup PageGroup);

        void Save();


        IEnumerable<ShowGroupViewModel> ShowGroupsForView();



    }
}

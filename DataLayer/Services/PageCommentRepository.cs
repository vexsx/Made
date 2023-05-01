using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepository : IPageCommentRepository
    {
        MadeContext db = new MadeContext();

        public PageCommentRepository(MadeContext context)
        {
            db = context;
        }

        public bool AddComment(PageComment comment)
        {
            try
            {
                db.pageComments.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<PageComment> GetCommentByNewsID(int pageid)
        {
            return db.pageComments.Where(c=> c.PageID== pageid).ToList();
        }
    }
}

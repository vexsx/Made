using DataLayer;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Made.Controllers
{
    public class NewsController : Controller
    {
        MadeContext db = new MadeContext();
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;
        private IPageCommentRepository pageCommentRepository;


        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepository= new PageCommentRepository(db);
        }

        // GET: News
        public ActionResult ShowGroups()
        {
            return PartialView(pageGroupRepository.ShowGroupsForView());
        }
        public ActionResult ShowGroupsInMenu()
        {
            return PartialView(pageGroupRepository.GetPageGroups());
        }

        public ActionResult TopNews()
        {
            return PartialView(pageRepository.TopNews());
        }

        public ActionResult LastNews()
        {
            return PartialView(pageRepository.Lastnews());
        }

        [Route("Archive")]
        public ActionResult ArchiveNews() 
        {
            return View(pageRepository.GetAllPage());
        
        }

        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupID(int id,string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupId(id));
        }

        [Route("News/{id}")]
        public ActionResult ShowNews(int id) 
        {
            var news  = pageRepository.GetPageByID(id);
            if(news==null) { return HttpNotFound(); }
            news.visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.save();

            return View(news);
        
        }

        public ActionResult AddComment(int id,string name,string email,string comment) 
        {
            PageComment addcomment = new PageComment()
            {
                CreateDate= DateTime.Now,
                PageID=id,
                Name=name,
                Email=email,
                Comment=comment

            };
            pageCommentRepository.AddComment(addcomment);

            return PartialView("ShowComments", pageCommentRepository.GetCommentByNewsID(id));

        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(pageCommentRepository.GetCommentByNewsID(id));
        }
    }
}
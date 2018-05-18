using PhotoSharingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApp.Controllers
{
    public class CommentsController : Controller
    {
        ICommentRepository commentRepository = new CommentRepository; 
        public ActionResult DisplayCommentsForPhoto (int PhotoID)
        {
            //Use the repository to get the comments
            ICollection<Comment> comments = commentRepository.GetComments(PhotoID);
            return View("DisplayComments", comments);
        }
    }
}
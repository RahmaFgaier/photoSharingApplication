using PhotoSharingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApp.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoSharingContext context = new PhotoSharingContext(); 
        // gets all the photos in the database and passes them to the Inex view 
        public ActionResult Index()
        {
            return View("Index", context.Photos.ToList());
        }

        //gets a photo with a particular ID and passes it to the Details view 
        public ActionResult Details (int id = 0)
        {
            Photo photo = context.Photos.Find(id); 
            if (photo == null)
            {
                return HttpNotFound(); 
            }
            return View("Details", photo); 
        }


        public ActionResult Display(int id)
        {
            List<Photo> photos = context.Photos.ToList();
            var verif = photos.Find(photo => photo.PhotoID == id);
            if (verif != null)
                return View("Display", verif);
            else
                return HttpNotFound();
        }
    }
}
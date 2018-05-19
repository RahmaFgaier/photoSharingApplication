using PhotoSharingApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult First()
        {
            Photo firstPhoto = context.Photos.ToList()[0];
            if (firstPhoto != null)
            {
                return View("Details", firstPhoto);
            }
            else
            {
                return HttpNotFound();
            }
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

        //Create Photo
        public ActionResult Create()
        {
            Photo newPhoto = new Photo();
            newPhoto.CreateDate = DateTime.Now; 
            return View("Create", newPhoto);
        }

        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.CreateDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
                    context.Photos.Add(photo);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", photo);
            }
        }


        public ActionResult Delete(int id)
        {
            List<Photo> photos = context.Photos.ToList();
            var verif = photos.Find(photo => photo.PhotoID == id);
            if (verif == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Delete", verif);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Photo> photos = context.Photos.ToList();
            var verif = photos.Find(photo => photo.PhotoID == id);
            context.Entry(verif).State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public FileContentResult GetImage(int id)
        {
            List<Photo> photos = context.Photos.ToList();
            var verif = photos.Find(photo => photo.PhotoID == id);
            if (verif != null)
            {

                return (new FileContentResult(verif.PhotoFile, verif.ImageMimeType));
            }
            else
            {
                return null;
            }
        }

        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number = 0)
        {
            List<Photo> photos = new List<Photo>();
            if (number == 0)
            {
                photos = context.Photos.ToList();
            }
            else
            {
                photos = (from p in context.Photos
                          orderby p.CreateDate descending
                          select p).Take(number).ToList();
            }
            return PartialView("_PhotoGallery", photos);
        }

    }
}
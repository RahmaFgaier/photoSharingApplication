
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace PhotoSharingApp.Model
{
    public class PhotoSharingInitializer: DropCreateDatabaseAlways <PhotoSharingContext>
    {
        protected override void Seed(PhotoSharingContext context)
        {
            //Create listof Photo objects
            List<Photo> photos = new List<Photo>();
            Photo photo = new Photo();
            photo.Title = "Test Photo";
            photo.Description = "test";
            photo.Owner = "NaokiSato";
            photo.PhotoFile = System.IO.File.ReadAllBytes("C:\\Users\\Rahma_Fgaier\\photoSharingApplication\\PhotoSharingApp\\Images\\flower.jpeg");
            photo.ImageMimeType = "image/jpeg";
            photo.CreateDate = DateTime.Now;
            photos.Add(photo);

            //Add the list of photos to the database and save changes
            foreach (var p in photos)
            {
                context.Photos.Add(p);
            }
            context.SaveChanges();

            //Create List of Comments
            List<Comment> comments = new List<Comment>();
            Comment comment = new Model.Comment();
            comment.PhotoID = 1; 
            comment.User= "NaokiSato";
            comment.Subject = "Test Comment";
            comment.Body = "This comment should appear in photo 1";

            comments.Add(comment);
            foreach (var c in comments)
            {
                context.Comments.Add(c);
            }
            context.SaveChanges();
        }
    }
}
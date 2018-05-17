
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
            var photos = new List<Photo>
            {
                new Photo
                {
                    Title = "My first Photo",
                    Description = "This is part of the sample data",
                    Owner = "Fred"
                }
            };
            //Add the list of photos to the database and save changes
            photos.ForEach(s => context.Photos.Add(s));
            context.SaveChanges(); 
          
        }
    }
}
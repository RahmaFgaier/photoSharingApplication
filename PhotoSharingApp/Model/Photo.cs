using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public String Title { get; set; }
        public byte[] PhotoFile { get; set; }
        public String Description { get; set; }
        public DateTime CreateDate { get; set; }
        public String Owner { get; set; }



    }
}
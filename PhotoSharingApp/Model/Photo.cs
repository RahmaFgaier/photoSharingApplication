using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class Photo
    {
        public int PhotoID { get; set; }
        [DisplayName("Picture")]
        public String Title { get; set; }
        public byte[] PhotoFile { get; set; }
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [DisplayName("Created Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
        public String Owner { get; set; }
        public string ImageMimeType { get; set; }
        public virtual Photo photo { get; set;  }

}
}
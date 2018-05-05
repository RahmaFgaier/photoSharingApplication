using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class Comment
    {
        public int CommentID { get; set; }
        public String User { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
        public int PhotoID { get; set; }

    }
}
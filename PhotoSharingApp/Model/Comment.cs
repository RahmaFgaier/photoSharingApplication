using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class Comment
    {
        public int CommentID;
        public String User;
        public String Subject;
        public String Body;
        public int PhotoID; 
      
    }
}
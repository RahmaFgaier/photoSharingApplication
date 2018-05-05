using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class Photo
    {
        public int PhotoID;
        public String Title;  
        public byte[] PhotoFile; 
        public String Description; 
        public DateTime  CreateDate; 
        public String Owner ; 
    }
}
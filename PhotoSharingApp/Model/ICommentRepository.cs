using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharingApp.Model
{
    interface ICommentRepository
    {
        ICollection<Comment> GetComments(int PhotoID); 
    }
}

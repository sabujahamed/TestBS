using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNET.DTO
{
   public class Comments
    {
        public int CommentsID { get; set; }
        public string CommentContent { get; set; }
        public int PostID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public int NumberOfLike { get; set; }
        public int NumberOfDisLike { get; set; }

        public virtual Post Post { get; set; }
        public virtual List<LikeOrDisLikes> Vote { get; set; }

        



    }
}

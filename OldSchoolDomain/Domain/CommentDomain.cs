using System;

namespace OldSchoolDomain.Domain
{
    public class CommentDomain : Metadata
    {
        public int CommentId { get; set; }
        public int PostId { get; set; } // Referência ao post que este comentário pertence.
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}

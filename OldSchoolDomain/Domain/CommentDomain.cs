using System;

namespace OldSchoolDomain.Domain
{
    public class CommentDomain
    {
        public int CommentId { get; set; }
        public int PostId { get; set; } // Referência ao post que este comentário pertence.
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

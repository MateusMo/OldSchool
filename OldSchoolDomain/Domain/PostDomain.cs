using System;
using System.Collections.Generic;

namespace OldSchoolDomain.Domain
{
    public class PostDomain : Metadata
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MindsetId { get; set; }
        public required string Content { get; set; }
        public int Likes { get; set; } = 0; 
        public List<CommentDomain> Comments { get; set; } = new List<CommentDomain>(); 
    }
}

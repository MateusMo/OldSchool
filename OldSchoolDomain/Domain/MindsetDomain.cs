using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolDomain.Domain
{
    public class MindsetDomain : Metadata
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Likes { get; set; }
        public string Content { get; set; }
        public List<PostDomain> Posts { get; set; }
    }
}

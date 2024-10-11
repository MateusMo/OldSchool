using System;
using System.Collections.Generic;

namespace OldSchoolDomain.Domain
{
    public class UserDomain : Metadata
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string PasswordHash { get; set; }
        public DateTime LastLogin { get; set; }
        public List<PostDomain> Posts { get; set; } = new List<PostDomain>(); 
    }
}

﻿using System.Collections.Generic;
using System.Threading.Tasks;
using OldSchoolDomain.Domain;

namespace OldSchoolInfrastructure.Repository
{
    public interface ICommentRepository : IGenericRepository<CommentDomain>
    {
    }
}

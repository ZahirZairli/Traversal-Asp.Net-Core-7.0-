﻿using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> GetCommentsByDestinationId(int id);
        List<Comment> TGetCommentsWithDestination();
        List<Comment> TGetCommentsWithDestinationAndAppUser();
        List<Comment> TGetCommentsWithAppUserAndDestination(int id);
    }
}

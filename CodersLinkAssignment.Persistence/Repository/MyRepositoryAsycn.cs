using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;
using CodersLinkAssignment.Aplication.Interfaces;
using CodersLinkAssignment.Persistence.Context;

namespace CodersLinkAssignment.Persistence.Repository
{
    public class MyRepositoryAsycn<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly AplicationDbContext _context;

        public MyRepositoryAsycn(AplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

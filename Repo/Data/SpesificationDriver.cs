using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Repo.Data
{
    public class SpesificationDriver<TEntity> where TEntity:EntityBase
    {
        public static IQueryable<TEntity> GetQueryable(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            query = spec.Includes.Aggregate(query,(current, include) => current.Include(include));
            return query;
        }

    }
}
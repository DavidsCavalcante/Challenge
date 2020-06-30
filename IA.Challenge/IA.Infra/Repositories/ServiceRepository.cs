/// <summary>
/// IA.Infra.Repositories
/// </summary>

namespace IA.Infra.Repositories
{
    using IA.Domain.Entities;
    using IA.Domain.Interfaces.Repositories;
    using IA.Infra.Data.Contexts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// ServiceRepository
    /// </summary>
    public class ServiceRepository : IServiceRepository
    {
        /// <summary>
        /// SQLiteDbContext
        /// </summary>
        private readonly SQLiteDbContext _context;

        /// <summary>
        /// ServiceRepository
        /// </summary>
        /// <param name="context">SQLiteDbContext contex</param>
        public ServiceRepository(SQLiteDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity">Machine entity</param>
        public void Add(Machine entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity">Machine entity</param>
        public void Delete(Machine entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IEnumerable<Machine>
        /// </summary>
        /// <returns>IEnumerable<Machine></returns>
        public IEnumerable<Machine> Get()
        {
            return _context.Machines
                .Include(x=>x.AntivirusInfo)
                .Include(x=>x.HardDriveInfos)
                .ToList();
        }

        /// <summary>
        /// IEnumerable<Machine>
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>IEnumerable<Machine>Expression<Func<Machine, bool>> predicate</returns>
        public IEnumerable<Machine> Get(Expression<Func<Machine, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subscribe
        /// </summary>
        /// <param name="serviceInfo">Machine serviceInfo</param>
        /// <returns>Machine</returns>
        public Machine Subscribe(Machine serviceInfo)
        {
            var result = _context.Machines.Add(serviceInfo);
            _context.SaveChanges();
            return result.Entity;
        }

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// <param name="serviceInfo">Machine serviceInfo</param>
        /// <returns>Machine</returns>
        public Machine Unsubscribe(Machine serviceInfo)
        {
            _context.Machines.Remove(serviceInfo);
            _context.SaveChanges();
            return serviceInfo;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity">Machine entity</param>
        public void Update(Machine entity)
        {
            throw new NotImplementedException();
        }
    }
}
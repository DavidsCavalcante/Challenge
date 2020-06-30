/// <summary>
/// IA.Domain.Interfaces.Repositories
/// </summary>

namespace IA.Domain.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// IRepository
    /// </summary>
    /// <typeparam name="T"><T></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// IEnumerable
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        IEnumerable<T> Get();

        /// <summary>
        /// IEnumerable<T>
        /// </summary>
        /// <param name="predicate">(Expression<Func<T, bool>> predicate</param>
        /// <returns>IEnumerable<T>IEnumerable<T></returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity">entity</param>
        void Add(T entity);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity">entity</param>
        void Delete(T entity);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity">entity</param>
        void Update(T entity);
    }
}

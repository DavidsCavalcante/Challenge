/// <summary>
/// IA.Domain.Interfaces.Repositories
/// </summary>
namespace IA.Domain.Interfaces.Repositories
{
    using IA.Domain.Entities;

    /// <summary>
    /// IServiceRepository
    /// </summary>
    public interface IServiceRepository : IRepository<Machine>
    {
        /// <summary>
        /// Subscribe
        /// </summary>
        /// <param name="serviceInfo">serviceInfo</param>
        /// <returns></returns>
        Machine Subscribe(Machine serviceInfo);

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// <param name="serviceInfo">serviceInfo</param>
        /// <returns></returns>
        Machine Unsubscribe(Machine serviceInfo);
    }
}

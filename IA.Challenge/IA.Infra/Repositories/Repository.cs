/// <summary>
/// IA.Infra.Repositories
/// </summary>

namespace IA.Infra.Repositories
{
    using IA.Infra.Data.Contexts;

    /// <summary>
    /// Repository
    /// </summary>
    public abstract class Repository
    {
        /// <summary>
        /// context
        /// </summary>
        public SQLiteDbContext context;

        /// <summary>
        /// Commit()
        /// </summary>
        public void Commit() => context.SaveChanges();
    }
}
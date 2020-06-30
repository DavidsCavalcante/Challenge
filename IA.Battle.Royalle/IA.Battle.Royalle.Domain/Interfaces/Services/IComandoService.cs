/// <summary>
/// IA.Battle.Royalle.Domain.Interfaces.Services
/// </summary>

namespace IA.Battle.Royalle.Domain.Interfaces.Services
{
    /// <summary>
    /// ICommndoService
    /// </summary>
    public interface IComandoService
    {

        /// <summary>
        /// ExecutaCommando
        /// </summary>
        /// <param name="command">string comando DOS</param>
        /// <returns>string ExecutaCommando</returns>
        string ExecutaComando(string command);
    }
}
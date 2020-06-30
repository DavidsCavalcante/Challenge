/// <summary>
/// IA.Domain.Interfaces.Services
/// </summary>
namespace IA.Domain.Interfaces.Services
{
    using IA.Domain.ValueObjects;
    using IA.Domain.ValueObjects.Return;

    /// <summary>
    /// ICommandService
    /// </summary>
    public interface IComandoService
    {
        /// <summary>
        /// Executar
        /// </summary>
        /// <param name="comando">comando</param>
        /// <returns></returns>
        CustomResponse<string> Executar(Comando comando);
    }
}
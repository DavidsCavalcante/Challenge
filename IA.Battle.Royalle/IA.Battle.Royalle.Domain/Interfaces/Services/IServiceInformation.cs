/// <summary>
/// IA.Battle.Royalle.Domain.Interfaces.Services
/// </summary>

namespace IA.Battle.Royalle.Domain.Interfaces.Services
{

    using System.Collections.Generic;
    using IA.Battle.Royalle.Domain.Models;

    /// <summary>
    /// IServiceInformation
    /// </summary>
    public interface IServiceInformation
    {

        /// <summary>
        ///        
        /// </summary>
        /// <returns>string ListaIPMaquina()</returns>
        string ListaIPMaquina();

        /// <summary>
        /// ListaDrivesMaquina
        /// </summary>
        /// <returns>ICollection<HardDriveInfo></returns>
        ICollection<HardDriveInfo> ListaDrivesMaquina();

        /// <summary>
        /// ListaAntivirus
        /// </summary>
        /// <returns>AntivirusInfo</returns>
        AntivirusInfo ListaAntivirus();
        
        /// <summary>
        /// ListaVersaoSO
        /// </summary>
        /// <returns>string ListaVersaoSO()</returns>
        string ListaVersaoSO();

        /// <summary>
        /// ListaVersaoFramWork
        /// </summary>
        /// <returns>string ListaVersaoFramWork()</returns>
        string ListaVersaoFramWork();

        /// <summary>
        /// Subscribe
        /// </summary>
        void Subscribe();

        /// <summary>
        /// Unsubscribe
        /// </summary>
        void Unsubscribe();
    }
}
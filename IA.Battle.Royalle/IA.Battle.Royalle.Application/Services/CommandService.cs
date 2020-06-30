/// <summary>
/// IA.Battle.Royalle.Application.Services
/// </summary>

namespace IA.Battle.Royalle.Application.Services
{
    using IA.Battle.Royalle.Domain.Interfaces.Services;
    using System.Diagnostics;

    /// <summary>
    /// ComandoService
    /// </summary>
    public class ComandoService : IComandoService
    {

        /// <summary>
        /// Execute Commando DOS.
        /// </summary>
        /// <param name="comando">comando</param>
        /// <returns>string comando executado</returns>
        public string ExecutaComando(string comando)
        {
            var process = new Process();

            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                FileName = "CMD.exe",
                Arguments = @$"/c {comando}",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized
            };

            process.StartInfo = startInfo;
            process.Start();

            var saida = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            return (string.IsNullOrEmpty(saida)) ? "Comando não reconhecido." : saida;
        }
    }
}
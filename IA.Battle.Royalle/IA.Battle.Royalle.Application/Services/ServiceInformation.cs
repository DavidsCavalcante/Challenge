/// <summary>
/// IA.Battle.Royalle.Application.Services
/// </summary>

namespace IA.Battle.Royalle.Application.Services
{
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Management;
    using System.Net;
    using System.Net.Sockets;
    using IA.Battle.Royalle.Domain.Interfaces.Services;
    using IA.Battle.Royalle.Domain.Models;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// ServiceInformation
    /// </summary>
    public class ServiceInformation : IServiceInformation
    {
        /// <summary>
        /// RestClient
        /// </summary>
        private readonly RestClient restClient;

        /// <summary>
        /// IConfiguration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Escopo
        /// </summary>
        private const string _escopo = @"root\SecurityCenter2";

        /// <summary>
        /// Query Antivirus
        /// </summary>
        private const string _consulta = "SELECT * FROM AntiVirusProduct";

        /// <summary>
        /// ServiceInformation
        /// </summary>
        /// <param name="configuration">IConfiguration configuration</param>
        public ServiceInformation(IConfiguration configuration)
        {
            _configuration = configuration;
            restClient = new RestClient(_configuration["CoreApiSettings"]);
        }

        /// <summary>
        /// Nome da Maquina
        /// </summary>
        /// <returns>Environment.MachineName</returns>
        public string ListaNomeMaquina() => Environment.MachineName;

        /// <summary>
        /// Versão do SO
        /// </summary>
        /// <returns>Environment.OSVersion.VersionString</returns>
        public string ListaVersaoSO() => Environment.OSVersion.VersionString;

        /// <summary>
        /// Lista Versão do FramWork
        /// </summary>
        /// <returns>string ListaVersaoFramWork()</returns>
        public string ListaVersaoFramWork() => $"{AppContext.TargetFrameworkName.Split(",")[0]} {Environment.Version}";

        /// <summary>
        /// IP da Maquina
        /// </summary>
        /// <returns>Retorna Ip Válido</returns>
        public string ListaIPMaquina()
        {
            string hostName = Dns.GetHostName();
            var addresses = Dns.GetHostAddresses(hostName);

            if (addresses.Any(x => x.AddressFamily == AddressFamily.InterNetwork))
                return addresses.Where(x => x.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString();
            else
                return "Nenhum IP válido.";
        }

        /// <summary>
        /// Lista Antivirus
        /// </summary>
        /// <returns></returns>
        public AntivirusInfo ListaAntivirus()
        {

            var antivirus = new AntivirusInfo();
            var objectCollection = new ManagementObjectSearcher(_escopo, _consulta).Get();

            antivirus.HasAntivirusInstalled = (objectCollection.Count > 0);

            foreach (ManagementObject virusChecker in objectCollection)
            {
                antivirus.ApplicationName += virusChecker["displayName"].ToString() + " ";
            }

            return antivirus;
        }

        /// <summary>
        /// Lista Drives da Maquina
        /// </summary>
        /// <returns>ICollection<HardDriveInfo></returns>
        public ICollection<HardDriveInfo> ListaDrivesMaquina()
        {
            var diskCollection = new List<HardDriveInfo>();
            
            DriveInfo[] drives = DriveInfo.GetDrives().Where(x => x.DriveType != DriveType.CDRom).ToArray();

            foreach (var drive in drives)
            {
                diskCollection.Add(new HardDriveInfo(drive.Name, drive.TotalFreeSpace, drive.TotalSize));
            }

            return diskCollection;
        }       

        /// <summary>
        /// Subscribe
        /// </summary>
        public void Subscribe()
        {
            var infoRegistration = new ServiceInfoRegistration();

            infoRegistration.AntivirusInfo = ListaAntivirus();
            infoRegistration.HardDriveInfos = ListaDrivesMaquina();
            infoRegistration.LocalAddress = ListaIPMaquina();
            infoRegistration.MachineName = ListaNomeMaquina();
            infoRegistration.RuntimeVersion = ListaVersaoFramWork();
            infoRegistration.WindowsVersion = ListaVersaoSO();

            var request = new RestRequest("services/v1/subscribe", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(infoRegistration));
            var resp = restClient.Execute(request);
        }

        /// <summary>
        /// Unsubscribe
        /// </summary>
        public void Unsubscribe()
        {
            var infoRegistration = new ServiceInfoRegistration();

            infoRegistration.AntivirusInfo = ListaAntivirus();
            infoRegistration.HardDriveInfos = ListaDrivesMaquina();
            infoRegistration.LocalAddress = ListaIPMaquina();
            infoRegistration.MachineName = ListaNomeMaquina();
            infoRegistration.RuntimeVersion = ListaVersaoFramWork();
            infoRegistration.WindowsVersion = ListaVersaoSO();

            var request = new RestRequest("services/v1/unsubscribe", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(infoRegistration));
            var resp = restClient.Execute(request);
        }
    }
}
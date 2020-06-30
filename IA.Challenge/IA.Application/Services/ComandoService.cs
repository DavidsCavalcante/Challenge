/// <summary>
/// IA.Application.Services
/// </summary>

namespace IA.Application.Services
{
    using IA.Domain.Interfaces.Services;
    using IA.Domain.ValueObjects;
    using IA.Domain.ValueObjects.Return;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using RestSharp;

    /// <summary>
    /// ComandoService
    /// </summary>
    public class ComandoService : IComandoService
    {
        /// <summary>
        /// resource
        /// </summary>
        private const string resource = "commands/v1/execute";
        //commands/v1/execute

        /// <summary>
        /// IConfiguration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// ComandoService
        /// </summary>
        /// <param name="configuration">configuration</param>
        public ComandoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Executa Comando
        /// </summary>
        /// <param name="comando">comando</param>
        /// <returns>CustomResponse<string></returns>
        public CustomResponse<string> Executar(Comando comando)
        {
            string host = comando.EnderecoIP;
            string port = _configuration["ClientApplicationPort"];
            string baseUrl = $"http://{host}:{port}/api";
            
            var client = new RestClient(baseUrl);

            var request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(comando.Instrucao));
            var resp = client.Execute(request);

            string feedbackMessage = "Comando executado";

            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                feedbackMessage = "Erro ao executar Comando DOS";   

            return new CustomResponse<string>()
            {
                Data = resp.Content,
                Message = feedbackMessage
            };
        }
    }
}
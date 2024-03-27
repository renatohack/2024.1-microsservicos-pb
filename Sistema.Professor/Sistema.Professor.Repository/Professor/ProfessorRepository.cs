using Sistema.Professor.Applicatrion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Sistema.Professor.Repository.Professor
{
    public class ProfessorRepository
    {
        private HttpClient HttpClient { get; set; }
        private string BaseUrl { get; set; }

        public ProfessorRepository()
        {
            this.BaseUrl = "https://localhost:7064/api/Professor";
            this.HttpClient = new HttpClient();
        }

        public async Task<IEnumerable<NotasDto>> ObterNotas(Guid idTurma, Guid idAluno)
        {
            var url = $"{BaseUrl}/consultarNotas/{idTurma}/{idAluno}";

            var requestHttp = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await HttpClient.SendAsync(requestHttp);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var notas = JsonSerializer.Deserialize<IEnumerable<NotasDto>>(jsonResponse);

            return notas;
        }
        public async Task InserirNotas(Guid idTurma, Guid idAluno, NotasDto request)
        {
            var jsonRequest = JsonSerializer.Serialize(request);

            var url = $"{BaseUrl}/inserirNotas/{idTurma}/{idAluno}";

            var requestHttp = new HttpRequestMessage(HttpMethod.Patch, url)
            {
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };

            await HttpClient.SendAsync(requestHttp);
        }

        public async Task DeletarNotas(Guid idTurma, Guid idAluno)
        {

            var url = $"{BaseUrl}/deletarNotas/{idTurma}/{idAluno}";

            var requestHttp = new HttpRequestMessage(HttpMethod.Delete, url);

            await HttpClient.SendAsync(requestHttp);

        }

        public async Task<int> ConsultarPresenca(Guid idTurma, Guid idAluno)
        {
            var url = $"{BaseUrl}/consultarPresenca/{idTurma}/{idAluno}";

            var requestHttp = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await HttpClient.SendAsync(requestHttp);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var presenca = JsonSerializer.Deserialize<PresencaDto>(jsonResponse);

            return presenca.presenca;
        }

        public async Task InserirPresenca(Guid idTurma, Guid idAluno, PresencaDto request)
        {
            var jsonRequest = JsonSerializer.Serialize(request);

            var url = $"{BaseUrl}/inserirPresenca/{idTurma}/{idAluno}";

            var requestHttp = new HttpRequestMessage(HttpMethod.Patch, url)
            {
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };

            await HttpClient.SendAsync(requestHttp);

        }

        public async Task AtualizarPresenca(Guid idTurma, Guid idAluno, PresencaDto request)
        {
            var jsonRequest = JsonSerializer.Serialize(request);

            var url = $"{BaseUrl}/alterarPresenca/{idTurma}/{idAluno}";

            var requestHttp = new HttpRequestMessage(HttpMethod.Patch, url)
            {
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };

            await HttpClient.SendAsync(requestHttp);

        }

    }
}
    


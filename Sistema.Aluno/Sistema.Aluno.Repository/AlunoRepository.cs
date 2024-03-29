﻿using Sistema.Aluno.Application;
using Sistema.Aluno.Core;
using Sistema.Aluno.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using domain = Sistema.Aluno.Domain.Aggregates;

namespace Sistema.Aluno.Repository
{
    public class AlunoRepository
    {
        private HttpClient HttpClient { get; set; }

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public AlunoRepository()
        {
            this.HttpClient = new HttpClient();
        }

        public async Task<ResponseModel> RealizarInscricao(Guid idAluno, RealizarInscricaoRequest request)
        {

            var jsonRequest = JsonSerializer.Serialize(request);

            var url = $"https://localhost:7064/api/Aluno/{idAluno}/realizarInscricao";

            var requestHttp = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };

            var response = await HttpClient.SendAsync(requestHttp);

            var responseModel = new ResponseModel()
            {
                StatusCode = (int)response.StatusCode,
                Message = await response.Content.ReadAsStringAsync()
            };

            return (responseModel);
        }

        public async Task CancelarInscricao(CancelarInscricaoRequest request)
        {
            var jsonRequest = JsonSerializer.Serialize(request);

            var url = $"https://localhost:7064/api/Aluno/cancelarInscricao";

            var requestHttp = new HttpRequestMessage(HttpMethod.Patch, url)
            {
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };

            await HttpClient.SendAsync(requestHttp);
        }

        public async Task<IEnumerable<ConsultarHistoricoResponse>> ConsultarHistorico(Guid idAluno)
        {
            var url = $"https://localhost:7064/api/Aluno/{idAluno}/consultarHistorico";

            var requestHttp = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await HttpClient.SendAsync(requestHttp);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var historico = JsonSerializer.Deserialize<IEnumerable<ConsultarHistoricoResponse>>(jsonResponse);

            return historico;
        }

        public async Task<int> ConsultarPresenca(Guid idAluno, Guid idInscricao)
        {
            var url = $"https://localhost:7064/api/Aluno/{idAluno}/consultarPresenca/{idInscricao}";

            var requestHttp = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await HttpClient.SendAsync(requestHttp);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var presenca = JsonSerializer.Deserialize<ConsultarPresencaResponse>(jsonResponse);

            return presenca.presenca;
        }

        public async Task<IEnumerable<ConsultarNotasResponse>> ConsultarNotas(Guid idAluno, Guid idInscricao)
        {
            var url = $"https://localhost:7064/api/Aluno/{idAluno}/consultarNotas/{idInscricao}";

            var requestHttp = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await HttpClient.SendAsync(requestHttp);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var notas = JsonSerializer.Deserialize<IEnumerable<ConsultarNotasResponse>>(jsonResponse);

            return notas;
        }
    }
}

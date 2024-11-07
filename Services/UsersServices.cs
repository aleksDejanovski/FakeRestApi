using FakeRestApiTest.StepDefinitions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace FakeRestApiTest.Services
{
    public class UsersServices : GeneralSteps
    {
        
        public UsersServices(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext) : base(specFlowOutputHelper, scenarioContext)
        {
        }

        public async Task<HttpResponseMessage> GetAllUsers()
        {
            return await httpClient.GetAsync($"{baseUrl}/Users");
        }

        public async Task<HttpResponseMessage> GetCurrentUser(int id)
        {
            return await httpClient.GetAsync($"{baseUrl}/Users/{id}");
        }

        public async Task <HttpResponseMessage> CreateNewUser (JObject body)
        {
            var requestUrl = $"{baseUrl}/Users";
            string jsonString = body.ToString();
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(requestUrl, content);
        }

        public async Task<HttpResponseMessage> UpdateUser (JObject body, int id)
        {
            var requestUrl = $"{baseUrl}/Users/{id}";
            string jsonString = body.ToString();
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return await httpClient.PutAsync(requestUrl, content);
        }

        public async Task<HttpResponseMessage> DeteleAUser(int id)
        {
            return await httpClient.DeleteAsync($"{baseUrl}/Users/{id}");
        }

    }
}

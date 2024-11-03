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
    public class ActivityServices : GeneralSteps
    {
        private readonly string baseUrl = "https://fakerestapi.azurewebsites.net/api/v1";
        public ActivityServices(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext) : base(specFlowOutputHelper, scenarioContext)
        {
        }

        public async Task<HttpResponseMessage> GetAllActivities()
        {
            return await httpClient.GetAsync($"{baseUrl}/Activities");
        }
        public async Task<HttpResponseMessage> GetSpecificActivity(int activityId)
        {
            return await httpClient.GetAsync($"{baseUrl}/Activities/{activityId}");
        }

        public async Task<HttpResponseMessage> CreateActivity(JObject body)
        {
            var requestUrl = $"{baseUrl}/Activities";
            string jsonString = body.ToString();
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(requestUrl, content);

        }

        public async Task<HttpResponseMessage> UpdateActivity(JObject body, int id)
        {
            var requestUrl = $"{baseUrl}/Activities/{id}";
            string jsonString = body.ToString();
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return await httpClient.PutAsync(requestUrl, content);

        }

        public async Task<HttpResponseMessage> DeleteGivenActivity(int activityId)
        {
            return await httpClient.DeleteAsync($"{baseUrl}/Activities/{activityId}");
        }



    }
}

using FakeRestApiTest.StepDefinitions;
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



    }
}

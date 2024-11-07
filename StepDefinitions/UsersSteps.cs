using FakeRestApiTest.Models;
using FakeRestApiTest.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace FakeRestApiTest.StepDefinitions
{
    public class UsersSteps : GeneralSteps
    {

        private readonly ScenarioContext scenarioContext;
        public UsersSteps(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext) : base(specFlowOutputHelper, scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }

        public ScenarioContext ScenarioContext { get; }

        UsersServices UsersServices => new UsersServices(specFlowOutputHelper, scenarioContext);

        [When(@"I call the get all users endpoint")]
        public async Task WhenICallTheGetAllUsersEndpoint()
        {
            response = await UsersServices.GetAllUsers();
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
        }

        [When(@"I call the Get users/\{id} endpoint using id as (.*)")]
        public async Task WhenICallTheGetUsersIdEndpointUsingIdAs(int id)
        {
            response = await UsersServices.GetCurrentUser(id);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
        }

        [Then(@"The response password property has value ""([^""]*)""")]
        public async Task ThenTheResponsePasswordPropertyHasValue(string value)
        {
            response = ScenarioContext.Get<HttpResponseMessage>("response");
            var json = await response.Content.ReadFromJsonAsync<UsersResponseModel>();
            json.Password.Should().Be(value);
        }

        [When(@"I call the POST users endpoint using id as ""([^""]*)"", username as ""([^""]*)"" and password as ""([^""]*)""")]
        public async Task WhenICallThePOSTUsersEndpointUsingIdAsUsernameAsAndPasswordAs(int id, string username, string password)
        {
            UsersResponseModel model = new UsersResponseModel();
            model.Id = id;
            model.UserName = username;
            model.Password = password;
            JObject body = JObject.FromObject(model);
            response = await UsersServices.CreateNewUser(body);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
        }
        [When(@"I create a new user sending only ""([^""]*)"" as a username")]
        public async Task WhenICreateANewUserSendingOnlyAsAUsername(string username)
        {
            UsersResponseModel model = new UsersResponseModel();
            model.UserName = username;
            JObject body = JObject.FromObject(model);
            response = await UsersServices.CreateNewUser(body);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
        }
        [When(@"I create a new user sending (.*) as id")]
        public async Task WhenICreateANewUserSendingAsId(int id)
        {
            UsersResponseModel model = new UsersResponseModel();
            model.Id = id;
            JObject body = JObject.FromObject(model);
            response = await UsersServices.CreateNewUser(body);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
        }

        [When(@"I Update a user with a id of (.*) and add set a username as ""([^""]*)"" and password as ""([^""]*)""")]
        public async Task WhenIUpdateAUserWithAIdOfAndAddSetAUsernameAsAndPasswordAs(int id, string username, string userpassword)
        {
            UsersResponseModel model = new UsersResponseModel();
            model.Id = id;  
            model.UserName = username;
            model.Password = userpassword;
            JObject body = JObject.FromObject(model);
            response = await UsersServices.UpdateUser(body,id);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");

        }

        [When(@"I delete a user with an id of (.*)")]
        public async Task WhenIDeleteAUserWithAnIdOf(int id)
        {
            response = await UsersServices.DeteleAUser(id);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
        }








    }
}

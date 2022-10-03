using ApiSample.Access;
using ApiSample.BL.Interfaces;
using ApiSample.Models.DataModel;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiSample.IntegrationTest
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public async Task GetAllUsers()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("User/GetAll");
            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode);
            var db = (MockDataAccess)webAppFactory.Services.GetService(typeof(IDataAccess));
            var resp = JsonSerializer.Deserialize<List<User>>(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(db.Users.Count, resp.Count);
        }
    }
}
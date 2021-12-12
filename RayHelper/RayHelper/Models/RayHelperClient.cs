using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RayHelper.Models.Entities;

namespace RayHelper.Models
{
    public class RayHelperClient
    {
        private readonly HttpClient _client = new HttpClient();

        //TODO move to appsettings.json file
        private const string BaseUrl = "http://rayserver.westeurope.cloudapp.azure.com";
        public async Task<List<Hospice>> GetHospices()
        {
            var json = await _client.GetStringAsync($"{BaseUrl}/api/Hospices").ConfigureAwait(false);
            var hospices = JsonConvert.DeserializeObject<List<Hospice>>(json);
            return hospices;
        }
        
        public async Task<List<User>> GetUsers()
        {
            var json = await _client.GetStringAsync($"{BaseUrl}/api/Users").ConfigureAwait(false);
            var users = JsonConvert.DeserializeObject<List<User>>(json);
            return users;
        }
        
        public async Task<User> Login(string login, string password)
        {
            var loginModel = new
                             {
                                 Login = login,
                                 Password = password
                             };
            var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{BaseUrl}/api/Users/authenticate", content).ConfigureAwait(false);
            var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            return user;
            
        }
    }
}
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RayHelper.Models
{
    public class RayHelperClient
    { 
        private readonly HttpClient _client = new HttpClient(); 
        public async Task<List<Hospice>> GetHospices()
        {
            var json = _client.GetStringAsync("http://rayhelper.westeurope.cloudapp.azure.com/api/Hospice");
            var hospices = JsonConvert.DeserializeObject<List<Hospice>>(await json.ConfigureAwait(false));
            return hospices;
        }
        
        public async Task<List<User>> GetUsers()
        {
            var json = _client.GetStringAsync("http://rayhelper.westeurope.cloudapp.azure.com/api/User");
            var users = JsonConvert.DeserializeObject<List<User>>(await json.ConfigureAwait(false));
            return users;
        }
    }
}
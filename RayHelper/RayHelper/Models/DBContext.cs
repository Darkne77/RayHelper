using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RayHelper.Models
{
    public class DbContext
    { 
        private readonly HttpClient _client = new HttpClient(); 
        public async Task<List<Hospice>> GetHospices()
        {
            var streamTask = _client.GetStreamAsync("http://rayhelper.westeurope.cloudapp.azure.com/api/Hospice");
            var hospices = await JsonSerializer
                                 .DeserializeAsync<List<Hospice>>(await streamTask)
                                 .ConfigureAwait(false);
            return hospices; 
        }
    }
}
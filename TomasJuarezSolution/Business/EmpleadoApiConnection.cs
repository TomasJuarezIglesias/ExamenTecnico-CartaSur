using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;

namespace Business
{
    public class EmpleadoApiConnection : IApiBusiness<Empleado>
    {
        private readonly HttpClient _httpClient;
        private const string url = "http://svct.cartasur.com.ar:8081/api/Empleados";

        public EmpleadoApiConnection()
        {
            _httpClient = new HttpClient();

        }

        public async Task<IEnumerable<Empleado>?> GetColection()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Empleado>?>(url, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<HttpResponseMessage> PostEntity(Empleado entity)
        {
            return await _httpClient.PostAsJsonAsync(url, entity, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
        }
    }
}

using System.Net.Http.Headers;
using TestHttp;
using Newtonsoft.Json;
using System.Text;

namespace TestHttp;

internal class Block
{
    public static async Task<HttpResponseMessage> CallAsync(string token)
    {              
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:6003/api/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var account = new AccountCreate { product = "REVOL_BASIC", currencyCode = "MXN", startDate = "2022-12-21", holder = 1, orgUnit = 12 };
        var jsonBody = JsonConvert.SerializeObject(account);
        var data = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("v1/core/accounts", data);

        return response;          
       
    }

}

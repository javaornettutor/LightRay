using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class RestAPI_Trial
    {
        public HttpClient Client { get; set; }
        public string EndPointURI { get; set; }

        public RestAPI_Trial(string endPointURI) 
        {
            EndPointURI = endPointURI;
            
            Client = new HttpClient();
        }

        public async Task<string> runAPI()
        {
            using (HttpClient client = Client)
            {
                try
                {
                    // Make the GET request
                    HttpResponseMessage response = await client.GetAsync(EndPointURI);
                    response.EnsureSuccessStatusCode(); // Throw if not a success code.

                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Output the response
                    return responseBody;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
            return string.Empty;
        }
    }
}

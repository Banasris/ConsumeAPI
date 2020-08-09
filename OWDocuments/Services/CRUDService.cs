using Newtonsoft.Json;
using OWDocuments.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OWDocuments.Services
{
    public class CRUDService : IIntegrationService
    {
        private static HttpClient _httpClient = new HttpClient();
        public CRUDService()
        {
            
            // add value to username variable
            var userName = "testow";

            // set up HttpClient instance

            _httpClient.BaseAddress = new Uri("https://ow-interview-exercise-dev.azurewebsites.net/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();

            // Assign pseudo-authentication header for username
            _httpClient.DefaultRequestHeaders.Add("username", userName);
        }

        public async Task Run()
        {
            //await GetDocumentMetadata();
            //await PostDocument();
            await GetDocumentStatus();

        }

        //curl -X GET "https://ow-interview-exercise-dev.azurewebsites.net/Documents/message22" -H "accept: application/json" -H "username: testow"

        // Get document metadata from API
        public async Task GetDocumentMetadata()
        {
            // send the get request to the uri
            var response = await _httpClient.GetAsync("Documents/message22");

            // capture http response message if the call is successful
            var httpResponseMessage = response.EnsureSuccessStatusCode();

            // serialize the http content to a string
            string content = await response.Content.ReadAsStringAsync();

            //desialize the JSON to GetDocumentResponse object 
            var document = JsonConvert.DeserializeObject<GetDocumentResponse>(content);
           
        }

        // Get document status from API
        public async Task GetDocumentStatus()
        {
            // send the get request to the uri
            var response = await _httpClient.GetAsync("Documents/message21/status");

            // capture http response message if the call is successful
            var httpResponseMessage = response.EnsureSuccessStatusCode();

            // serialize the http content to a string
            var content = await response.Content.ReadAsStringAsync();

            //desialize the JSON to GetDocumentStatusResponse object 
            var document = JsonConvert.DeserializeObject<GetDocumentStatusResponse>(content);
 
        }

        // post document
        public async Task PostDocument()
        {
            // create document object that needs to be posted
            var documentToCreate = new CreateDocumentRequest
            {
                MessageId = "Message33",
                Name = "This is not a PDF file",
                AdditionalInfo = new AdditionalInfo
                {
                    AdditionalProp1 = "add prop1",
                    AdditionalProp2 = "add prop2",
                    AdditionalProp3 = "add prop3"
                }

            };

            // serialize ducument object 
            string serializedDocumentToCreate = JsonConvert.SerializeObject(documentToCreate);

            //create a new HTTP request message 
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/Documents");

            //add the media type to the request header
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

            //add the content to the request
            request.Content = new StringContent(serializedDocumentToCreate);

            //add the content hearer to the request
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("Application/json");

            //get the response
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            //read the response
            var content = await response.Content.ReadAsStringAsync();

            //deserialize the response as CreateDocumentResponse object
            var createdDocument = JsonConvert.DeserializeObject<CreateDocumentResponse>(content);

        }
    }
}

namespace DocumentClientConsole
{
    using DataModels;
    using DocumentAPITestApp;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    internal class DocumentAPITests
    {
        static async Task Main(string[] args)
        {
            var testApp = new DocumentAPITests();   
            await testApp.CreateDocument_WhenDocumentDoesNotExist_ShouldCreateDocument();
            await testApp.GetDocument_WhenDocumentExists_ShouldReturnDocument();
            await testApp.DeleteDocument_WhenDocumentExists_ShouldBeDeleted();
        }

        private async Task CreateDocument_WhenDocumentDoesNotExist_ShouldCreateDocument()
        {
            ApiTestHelper.WriteTestStart(nameof(CreateDocument_WhenDocumentDoesNotExist_ShouldCreateDocument));   
            var document = new Document()
            {
                Id = "901Test1",
                Title = "TitleTest1",
                Text = "TextTest1",
                Author = "AuthorTest1"
            };

            var serializedDocument = JsonConvert.SerializeObject(document);
            var content = new StringContent(serializedDocument, UnicodeEncoding.UTF8, "application/json");

            var localBaseUri = "https://localhost:44385/api/document/add";
            var httpClient = new HttpClient();

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            var postResult = await httpClient.PostAsync(localBaseUri, content);
            stopwatch.Stop();

            if (postResult.IsSuccessStatusCode)
            {
                Console.WriteLine($"Document CREATE test succeeded. Document with Id: {document.Id} created. Elapsed time: {stopwatch.Elapsed}");
                return;
            }

            Console.WriteLine($"*** Document CREATE test FAILED ***");
        }

        private async Task DeleteDocument_WhenDocumentExists_ShouldBeDeleted()
        {
            ApiTestHelper.WriteTestStart(nameof(DeleteDocument_WhenDocumentExists_ShouldBeDeleted));

            var documentId = "901Test1";
            var localBaseUri = $"https://localhost:44385/api/document/remove?id={documentId}";
            var httpClient = new HttpClient();

            Stopwatch stopwatch = Stopwatch.StartNew(); 
            stopwatch.Start();
            var deletedResult = await httpClient.DeleteAsync(localBaseUri);

            if (deletedResult.IsSuccessStatusCode)
            {
                Console.WriteLine($"Document DELETE test succeeded. Document with Id: {documentId} deleted. Elapsed time: {stopwatch.Elapsed}");
                return;
            }

            Console.WriteLine($"*** Document DELETE test FAILED ***");
        }

        private async Task GetDocument_WhenDocumentExists_ShouldReturnDocument()
        {
            ApiTestHelper.WriteTestStart(nameof(CreateDocument_WhenDocumentDoesNotExist_ShouldCreateDocument));

            var documentClientProgram = new DocumentAPITests();

            // use for running the version published on cloud
            // var baseUri = "https://docservgbk20230224.azurewebsites.net/api/document";

            // use this Uri for tests with localhost (when running the service on local box)
            var localBaseUri = "https://localhost:44385/api/document/id";
            var id = "901Test1";

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            var doc = await documentClientProgram.GetDocument(localBaseUri, id);
            stopwatch.Stop();

            if (string.IsNullOrWhiteSpace(doc))
            {
                Console.WriteLine($"*** Document GET Test FAILED *** {localBaseUri}");
                return;
            }
         
            // Desrialization of a string received by the client back into an in-memory object
            var document = JsonConvert.DeserializeObject<Document>(doc);
            
            Console.WriteLine($"Document GET test succeeded. Title received from the service: {document.Title}.  Elapsed time: {stopwatch.Elapsed}");
            Console.WriteLine(doc);
        }

        public async Task<string> GetDocument(string baseUri, string id)
        {
            string documentAsString = null;
            try
            {
                var httpClient = new HttpClient();

                var uri = $"{baseUri}?val={id}";
                documentAsString = await httpClient.GetStringAsync(uri);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return documentAsString;
        }
    }
}

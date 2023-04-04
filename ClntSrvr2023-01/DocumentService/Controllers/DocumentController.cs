using System;
using System.Collections.Generic;
using System.Net;

using DataModels;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace DocumentService.Controllers
{
    public class DocumentController : Controller
    {
        private IDocumentRepository documentRepository = new DocumentRepository();

        /// <summary>
        /// sample call uri: https://localhost:44385/api/document/author?val=3
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/ping")]

        public ActionResult<List<Document>> GetDefault()
        {
            var docs = new List<Document>()
            {
                new Document()
                {
                    Id = "101",
                    Title = $"CSTP 1303 Document Service is running: {DateTime.Now}",
                    Author = "George K."
                }
            };

            return docs;
        }

        /// <summary>
        /// GET a single document from the service 
        /// [Route("api/document/id")]
        /// 2/25 ==> New sample uri: https://localhost:44385/api/document/id?val=3
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/id")]
        public ActionResult<Document> Get(string val)
        {
            Document document = documentRepository.Get(val);

            if (document == null)
            {
                throw new InvalidOperationException($"{(int)HttpStatusCode.NotFound} Document not found");
            }

            return document;
        }

        [HttpPost]
        [Route("api/[controller]/add")]
        public ActionResult<Document> Post([FromBody] Document document)
        {
            if (string.IsNullOrWhiteSpace(document.Id))
            {
                throw new InvalidOperationException("Document is invalid.");
            }

            documentRepository.Add(document);

            return new OkObjectResult(document);
        }

        [HttpDelete]
        [Route("api/[controller]/remove")]
        public ActionResult<Document> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new InvalidOperationException("Document is invalid.");
            }

            documentRepository.Remove(id);

            return new OkObjectResult(id);
        }

        /// <summary>
        /// sample call uri: https://localhost:44385/api/document/author?val=3
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/author")]

        public ActionResult<List<Document>> GetAll(string val)
        {
            var docs = new List<Document>()
            {
                new Document()
                {
                    Id = "101",
                    Title = "cstp 1303 news today 2/25 9 AM",
                    Author = "George Karim",
                    Text = "Due to weather conditions, our class is online today :)"
                },
                new Document()
                {
                    Id = "102",
                    Title = "cstp 1303 topics today",
                    Author = "George Karim",
                    Text = "Consuming a Web API"
                }
            };

            return docs;
        }
    }
}

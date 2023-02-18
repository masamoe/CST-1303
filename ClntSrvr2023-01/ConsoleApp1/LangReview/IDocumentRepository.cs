using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LangReview
{
    public interface IDocumentRepository
    {
        Document Get(string Id);

        List<Document> GetAll(string title);

        void Add(Document document);

        void Remove(Document document);

        void Update(string id, Document document);
    }
}

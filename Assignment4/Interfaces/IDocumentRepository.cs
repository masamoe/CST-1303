using DataModels;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IDocumentRepository
    {
        Document Get(string Id);

        List<Document> GetAll(string title);

        void Add(Document document);

        void Remove(string id);

        void Update(string id, Document document);
    }
}

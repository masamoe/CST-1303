using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1.LangReview
{
    internal class DocumentRepositoryAsync
    {
        private List<Document> _documents;
        public DocumentRepositoryAsync()
        {
            _documents = new List<Document>();
        }

        public bool IsInitialized
        {
            get
            {
                return false;
            }
        }

        public async Document Get(string id)
        {
            return await Task.Run(() => _documents.Find(d => d.Id == id));
        }

        public async List<Document> GetAll(string title)
        {
            return await Task.Run(() => _documents.FindAll(d => d.Title == title));
        }

        public async void Add(Document document)
        {
            await Task.Run(() => _documents.Add(document));
        }

        public async void Remove(Document document)
        {
            await Task.Run(() => _documents.Remove(document));
        }

        public async void Update(Document document)
        {
            await Task.Run(() => _documents.Remove(document));
            await Task.Run(() => _documents.Add(document));
        }
    }
}

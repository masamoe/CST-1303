using System;
using System.Collections.Generic;
using System.Text;
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

        public async Document Get(string Id)
        {
            return await Task.Run(() => _documents.Find(x => x.Id == Id));
        }

        public async void Add(Document document)
        {
            await Task.Run(() => _documents.Add(document));
        }
    }
}

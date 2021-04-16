using System.Collections.Generic;
using FlexTesting.Framework.Document;

namespace FlexTesting.Framework.Database.Contexts
{
    public interface IContext<TDocument> where TDocument : IDocument
    {
        public ICollection<TDocument> Documents { get; set; }
    }
}
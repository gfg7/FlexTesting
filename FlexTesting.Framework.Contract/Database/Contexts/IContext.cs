using System.Collections.Generic;
using FlexTesting.Framework.Contract.Document;

namespace FlexTesting.Framework.Contract.Database.Contexts
{
    public interface IContext<TDocument> where TDocument : IDocument
    {
        public ICollection<TDocument> Documents { get; set; }
    }
}
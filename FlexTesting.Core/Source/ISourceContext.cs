using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTesting.Core.Source
{
    public interface ISourceContext
    {
        public IMongoCollection<Contract.Models.Source> Sources { get;}
    }
}

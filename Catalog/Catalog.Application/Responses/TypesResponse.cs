using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Responses
{
    public class TypesResponse
    {
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}

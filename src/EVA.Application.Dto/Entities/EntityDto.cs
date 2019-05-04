using System.Collections.Generic;
using Newtonsoft.Json;

namespace EVA.Application.Dto.Entities
{
    public class EntityDto
    {
        [JsonRequired]
        public string Type { get; set; }

        [JsonRequired]        
        public Dictionary<string, object> Attributes { get; set; }
    }
}
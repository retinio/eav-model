using Newtonsoft.Json;

namespace EVA.Application.Dto.Attribute.Values
{
    public class AtributeValueDto
    {
        [JsonRequired]
        public string Name { get; set; }

        [JsonRequired]
        public object Value { get; set; }
    }
}
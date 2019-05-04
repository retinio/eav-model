using Newtonsoft.Json;

namespace EVA.Application.Dto.Attribute
{
    public class AttributeWithOutTypeDto
    {
        /// <summary>
        /// Attribute name
        /// </summary>
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// Attribute description
        /// </summary>
        public string Description { get; set; }
    }
}
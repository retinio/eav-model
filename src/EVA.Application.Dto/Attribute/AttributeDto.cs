using Newtonsoft.Json;

namespace EVA.Application.Dto.Attribute
{
    /// <summary>
    /// Attribute
    /// </summary>
    public class AttributeDto : AttributeWithOutTypeDto
    {
        /// <summary>
        /// Attribute type
        /// </summary>
        [JsonRequired]
        public AttributeTypeDto  Type { get; set; }
    }
}
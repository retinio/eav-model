using Newtonsoft.Json;

namespace EVA.Application.Dto.EntityType
{
    public class EntityTypeDto
    {
        /// <summary>
        /// Entity type name
        /// </summary>
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// Entity type description
        /// </summary>
        public string Description { get; set; }
    }
}
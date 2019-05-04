using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EVA.Application.Dto.Attribute
{
    /// <summary>
    /// Attribute types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AttributeTypeDto
    {
        [EnumMember(Value = "boolean")]
        Boolean,

        [EnumMember(Value = "integer")]
        Integer,

        [EnumMember(Value = "decimal")]
        Decimal,

        [EnumMember(Value = "string")]
        String,

        [EnumMember(Value = "datetime")]
        DateTime
    }
}
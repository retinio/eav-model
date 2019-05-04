using System;
using System.Collections.Generic;
using System.Linq;
using EVA.Domain.Abstractions;

namespace EVA.Domain.Attributes
{
    public class AttributeType : Enumeration
    {
        public static AttributeType Boolean = new AttributeType(1, "boolean");
        public static AttributeType Integer = new AttributeType(2, "integer");
        public static AttributeType Decimal = new AttributeType(3, "decimal");
        public static AttributeType String = new AttributeType(4, "string");
        public static AttributeType DateTime = new AttributeType(5, "datetime");
        
        public AttributeType(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<AttributeType> List() => new[] { Boolean, Integer, Decimal, String, DateTime };


        public static AttributeType FromId(int id)
        {
            var type = List().SingleOrDefault(s => s.Id == id);
            if (type == null)
            {
                throw new DomainException($"Possible values for AttributeType: {string.Join(",", List().Select(s => s.Name))}");
            }

            return type;
        }

        public static AttributeType FromName(string name)
        {
            var type = List().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase));
            if (type == null)
            {
                throw new DomainException($"Possible values for AttributeType: {string.Join(",", List().Select(s => s.Name))}");
            }

            return type;
        }

        /// <summary>
        /// Create new attribute 
        /// </summary>
        /// <param name="name">Name of attribute</param>
        /// <returns></returns>
        public Attribute CreateAttribute(string name)
        {
            return new Attribute(Id, name);
        }

        /// <summary>
        /// Create new attribute 
        /// </summary>
        /// <param name="name">Uniq name of attribute</param>
        /// <param name="description">Attribute description</param>
        /// <returns></returns>
        public Attribute CreateAttribute(string name, string description)
        {
            return new Attribute(Id, name, description);
        }
    }
}
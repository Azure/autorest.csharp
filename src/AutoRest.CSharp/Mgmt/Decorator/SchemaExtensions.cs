// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class SchemaExtensions
    {
        /// <summary>
        /// Union all the properties on myself and all the properties from my parents
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        private static IEnumerable<Property> GetAllProperties(this ObjectSchema schema)
        {
            return schema.Parents!.All.OfType<ObjectSchema>().SelectMany(parentSchema => parentSchema.Properties).Concat(schema.Properties);
        }

        private static bool IsTagsProperty(Property property)
            => property.CSharpName().Equals("Tags")
                && property.Schema is DictionarySchema dictSchema
                && dictSchema.ElementType.Type == AllSchemaTypes.String;

        public static bool HasTags(this Schema schema)
        {
            if (schema is not ObjectSchema objSchema)
            {
                return false;
            }

            var allProperties = objSchema.GetAllProperties();

            return allProperties.Any(property => IsTagsProperty(property));
        }

        public static bool IsTagsOnly(this Schema schema)
        {
            if (schema is not ObjectSchema objSchema)
            {
                return false;
            }

            var allProperties = objSchema.GetAllProperties();

            // we are expecting this schema only has a `Tags` property
            if (allProperties.Count() != 1)
                return false;

            var onlyProperty = allProperties.Single();

            return IsTagsProperty(onlyProperty);
        }

        public static bool IsResourceModel(this Schema schema)
        {
            if (schema is not ObjectSchema objSchema)
                return false;

            var allProperties = objSchema.GetAllProperties();
            bool idPropertyFound = false;
            bool typePropertyFound = !Configuration.MgmtConfiguration.DoesResourceModelRequireType;
            bool namePropertyFound = !Configuration.MgmtConfiguration.DoesResourceModelRequireName;

            foreach (var property in allProperties)
            {
                // check if this property is flattened from lower level, we should only consider first level properties in this model
                // therefore if flattenedNames is not empty, this property is flattened, we skip this property
                if (property.FlattenedNames.Any())
                    continue;
                switch (property.SerializedName)
                {
                    case "id":
                        if (property.Schema.Type == AllSchemaTypes.String)
                            idPropertyFound = true;
                        continue;
                    case "type":
                        if (property.Schema.Type == AllSchemaTypes.String)
                            typePropertyFound = true;
                        continue;
                    case "name":
                        if (property.Schema.Type == AllSchemaTypes.String)
                            namePropertyFound = true;
                        continue;
                }
            }

            return idPropertyFound && typePropertyFound && namePropertyFound;
        }
    }
}

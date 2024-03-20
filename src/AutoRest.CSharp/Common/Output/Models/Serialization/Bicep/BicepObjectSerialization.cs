// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Bicep
{
    internal class BicepObjectSerialization
    {
        public BicepObjectSerialization(SerializableObjectType objectType, JsonObjectSerialization jsonObjectSerialization)
        {
            IsResourceData = EvaluateIsResourceData(jsonObjectSerialization);;

            Properties = jsonObjectSerialization.Properties.Select(p =>
                new BicepPropertySerialization(p, p.SerializationHooks?.BicepSerializationMethodName));

            FlattenedProperties = objectType.Properties
                .Where(p => p.FlattenedProperty != null)
                .Select(p => p.FlattenedProperty!).ToList();
        }

        private static bool EvaluateIsResourceData(JsonObjectSerialization jsonObjectSerialization)
        {
            bool hasName = false;
            bool hasType = false;
            bool hasId = false;
            foreach (var property in jsonObjectSerialization.Properties)
            {
                switch (property.SerializedName)
                {
                    case "name":
                        hasName = true;
                        break;
                    case "type":
                        hasType = true;
                        break;
                    case "id":
                        hasId = true;
                        break;
                }
                if (hasId && hasName && hasType)
                {
                    return true;
                }
            }

            return false;
        }

        public IList<FlattenedObjectTypeProperty> FlattenedProperties { get; }

        public IEnumerable<BicepPropertySerialization> Properties { get; }

        public bool IsResourceData { get; }
    }
}

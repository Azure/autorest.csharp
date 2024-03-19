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
            IsResourceData = jsonObjectSerialization.Properties.Any(p => p.SerializedName == "name") &&
                             jsonObjectSerialization.Properties.Any(p => p.SerializedName == "type") &&
                             jsonObjectSerialization.Properties.Any(p => p.SerializedName == "id");
            Properties = jsonObjectSerialization.Properties.Select(p =>
                new BicepPropertySerialization(p, p.SerializationHooks?.BicepSerializationMethodName));
            ObjectType = objectType;
            // does this actually only give safe flattened?
            FlattenedProperties = objectType.Properties
                .Where(p => p.FlattenedProperty != null)
                .Select(p => p.FlattenedProperty!).ToList();
        }

        public IList<FlattenedObjectTypeProperty> FlattenedProperties { get; }

        public SerializableObjectType ObjectType { get; }

        public IEnumerable<BicepPropertySerialization> Properties { get; }

        public bool IsResourceData { get; }
    }
}

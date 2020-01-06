// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientObject : ClientModel, ISchemaTypeProvider
    {
        public ClientObject(Schema schema, string name, string? description, SchemaTypeReference? inherits, IEnumerable<ClientObjectProperty> properties, ClientObjectDiscriminator? discriminator, DictionaryTypeReference? implementsDictionary, ObjectSerialization[] serializations)
        {
            Schema = schema;
            Name = name;
            Description = description;
            Inherits = inherits;
            Discriminator = discriminator;
            ImplementsDictionary = implementsDictionary;
            Serializations = serializations;
            Properties = new List<ClientObjectProperty>(properties);
        }

        public override string Name { get; }
        public string? Description { get; }
        public Schema Schema { get; }
        public SchemaTypeReference? Inherits { get; }
        public ObjectSerialization[] Serializations { get; }
        public IList<ClientObjectProperty> Properties { get; }
        public ClientObjectDiscriminator? Discriminator { get; }
        public DictionaryTypeReference? ImplementsDictionary { get; }
    }
}

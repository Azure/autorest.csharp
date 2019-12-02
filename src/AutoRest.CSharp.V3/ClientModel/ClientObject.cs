// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.ClientModel
{
    internal class ClientObject : ClientModel, ISchemaTypeProvider
    {
        public ClientObject(Schema schema, string name, IEnumerable<ClientObjectProperty> properties, IEnumerable<ClientObjectConstant> constants)
        {
            Schema = schema;
            Name = name;
            Properties = new List<ClientObjectProperty>(properties);
            Constants = new List<ClientObjectConstant>(constants);
        }

        public override string Name { get; }
        public Schema Schema { get; }

        public IList<ClientObjectConstant> Constants { get; }
        public IList<ClientObjectProperty> Properties { get; }
    }
}

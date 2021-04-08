// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ResourceDataSerializationWriter
    {
        public void WriteSerialization(CodeWriter writer, ResourceData resourceData)
        {
            var serializationWriter = new SerializationWriter();
            serializationWriter.WriteSerialization(writer, resourceData);
        }
    }
}

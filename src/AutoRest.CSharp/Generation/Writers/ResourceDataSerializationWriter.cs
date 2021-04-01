// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Text.Json;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Generation.Writers
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

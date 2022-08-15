// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class AbstractTypeWriter : ModelWriter
    {
        private readonly TypeProvider _internalType;

        public AbstractTypeWriter(TypeProvider internalType)
        {
            _internalType = internalType;
        }

        protected override void WriteAbstractTypeExtensionMethod(CodeWriter writer, ObjectType schema)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Create an wrapped subclass instance of {schema.Declaration.Name} by serializing the provided BinaryData.");
            writer.WriteXmlDocumentationParameter("data", $"The BinaryData that will be used in serializing, it should be a valid json object.");
            writer.WriteXmlDocumentationReturns($"The wrapped subclass instance of {schema.Declaration.Name}.");
            using (writer.Scope($"public static {schema.Declaration.Name} FromBinaryData({typeof(BinaryData)} data)"))
            {
                writer.Line($"return data.ToObjectFromJson<{_internalType.Declaration.Name}>();");
            }
        }
    }
}

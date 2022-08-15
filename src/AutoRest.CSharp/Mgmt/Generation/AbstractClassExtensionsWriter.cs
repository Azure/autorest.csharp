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
    internal class AbstractClassExtensionsWriter
    {
        private readonly CodeWriter _writer;
        private readonly SchemaObjectType _internalType;

        public readonly string BaseClassName;

        public AbstractClassExtensionsWriter(string baseClassName, SchemaObjectType internalType)
        {
            _writer = new CodeWriter();
            BaseClassName = baseClassName;
            _internalType = internalType;
        }

        public void Write()
        {
            using (_writer.Namespace($"{_internalType.Declaration.Namespace}"))
            {
                _writer.WriteXmlDocumentationSummary($"A class to add extension methods to class {BaseClassName}");
                using (_writer.Scope($"public partial class {BaseClassName}"))
                {
                    _writer.WriteXmlDocumentationSummary($"Create an wrapped subclass instance of {BaseClassName} by serializing the provided BinaryData.");
                    _writer.WriteXmlDocumentationParameter("data", $"The BinaryData that will be used in serializing, it should be a valid json object.");
                    _writer.WriteXmlDocumentationReturns($"The wrapped subclass instance of {BaseClassName}.");
                    using (_writer.Scope($"public static {BaseClassName} FromBinaryData({typeof(BinaryData)} data)"))
                    {
                        _writer.Line($"return data.ToObjectFromJson<{_internalType.Declaration.Name}>();");
                    }
                }
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}

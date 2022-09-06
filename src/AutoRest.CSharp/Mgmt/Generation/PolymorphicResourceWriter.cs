// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class PolymorphicResourceWriter : ResourceWriter
    {
        private Resource This { get; }
        public PolymorphicResourceWriter(CodeWriter writer, Resource resource) : base(writer, resource)
        {
            This = resource;
        }

        protected override void WriteCtors()
        {
            if (This.IsStatic)
                return;

            if (This.MockingCtor is not null)
            {
                _writer.WriteMethodDocumentation(This.MockingCtor);
                using (_writer.WriteMethodDeclaration(This.MockingCtor))
                {
                }
            }

            _writer.Line();
            if (This.ResourceDataCtor is not null)
            {
                _writer.WriteMethodDocumentation(This.ResourceDataCtor);
                using (_writer.WriteMethodDeclaration(This.ResourceDataCtor))
                {
                }
            }

            _writer.Line();
            if (This.ArmClientCtor is not null)
            {
                _writer.Line();
                _writer.WriteMethodDocumentation(This.ArmClientCtor);
                using (_writer.WriteMethodDeclaration(This.ArmClientCtor))
                {
                    foreach (var param in This.ExtraConstructorParameters)
                    {
                        _writer.Line($"_{param.Name} = {param.Name};");
                    }

                    foreach (var set in This.UniqueSets)
                    {
                        WriteRestClientConstructorPair(set.RestClient, set.Resource);
                    }
                    if (This.CanValidateResourceType)
                        WriteDebugValidate();
                }
            }
            _writer.Line();
        }

        protected override void WriteProperties()
        {
            // TODO -- use the actual extensible enum
            _writer.Line($"protected override string Type => \"{This.Type.Name}\";");
            _writer.Line();

            _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");

            _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{This.ResourceType}\";");
            _writer.Line();

            WriteStaticValidate($"ResourceType");
        }
    }
}

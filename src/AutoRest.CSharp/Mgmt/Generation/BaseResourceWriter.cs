// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class BaseResourceWriter : MgmtClientBaseWriter
    {
        private BaseResource This { get; }
        public BaseResourceWriter(CodeWriter writer, BaseResource baseResource) : base(writer, baseResource)
        {
            This = baseResource;
        }

        private readonly Parameter _resourceIdParameter = new Parameter(
            Name: "id",
            Description: null,
            Type: typeof(ResourceIdentifier),
            DefaultValue: null,
            Validation: ValidationType.AssertNotNull,
            Initializer: null);

        protected override void WriteStaticMethods()
        {
            base.WriteStaticMethods();

            // writes the static resource factory
            var signature = This.StaticFactoryMethod;
            using (_writer.WriteMethodDeclaration(signature))
            {
                foreach (var resource in This.DerivedResources)
                {
                    // the polymorphicOption of these resources should never be null
                    var option = resource.PolymorphicOption;
                    Debug.Assert(option != null);
                    using (_writer.Scope($"if ({option.MethodSignature.Name}(data.Id))"))
                    {
                        _writer.Append($"return new {resource.Type}(");
                        foreach (var parameter in signature.Parameters)
                        {
                            _writer.AppendRaw(parameter.Name).AppendRaw(",");
                        }
                        _writer.RemoveTrailingComma();
                        _writer.LineRaw(");");
                    }
                }

                // TODO -- we might need to create an internal UnknownResource class to handle this escape path for forward compatibility
                _writer.LineRaw("// TODO -- should we throw or return an UnknownResource?");
                _writer.Line($"throw new {typeof(InvalidOperationException)}();");
            }
            _writer.Line();

            // writes the assertion of resource types
            foreach (var resource in This.DerivedResources)
            {
                // the polymorphicOption of these resources should never be null
                var option = resource.PolymorphicOption;
                Debug.Assert(option != null);
                using (_writer.WriteMethodDeclaration(option.MethodSignature))
                {
                    _writer.LineRaw("// checking the resource type");
                    using (_writer.Scope($"if (id.ResourceType != {resource.Type.Name}.ResourceType)"))
                    {
                        _writer.LineRaw("return false;");
                    }

                    // TODO -- check scope resource type
                    if (option.ScopeResourceTypeConstraint != null)
                    {
                        _writer.LineRaw("// TODO -- checking the resource scope");
                        //using (_writer.Scope($"if ({})"))
                        //{
                        //}
                    }

                    // check the name constraint
                    if (option.ResourceNameConstraint != null)
                    {
                        _writer.LineRaw("// checking the resource name");
                        using (_writer.Scope($"if (id.Name != {option.ResourceNameConstraint.Value.ConstantValue:L})"))
                        {
                            _writer.LineRaw("return false;");
                        }
                    }

                    _writer.LineRaw("return true;");
                }
                _writer.Line();
            }

            _writer.Line();
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
                    _writer.Line($"HasData = true;");
                    _writer.Line($"_data = {This.ResourceDataParameter.Name};");
                }
            }

            _writer.Line();
            if (This.ArmClientCtor is not null)
            {
                _writer.Line();
                _writer.WriteMethodDocumentation(This.ArmClientCtor);
                using (_writer.WriteMethodDeclaration(This.ArmClientCtor))
                {
                    // we do not need to implement anything here since the XXXCore in the base resource will be abstract
                }
            }
            _writer.Line();
        }

        protected override void WriteProperties()
        {
            // TODO -- change this to the actual extensible enum
            // write the private discriminator of this base resource
            //_writer.LineRaw("// TODO -- change it to the real extensible enum discriminator");
            //_writer.Line($"protected virtual string Type => \"Base\";");
            //_writer.Line();

            // write the HasData and Data property
            _writer.WriteXmlDocumentationSummary($"Gets whether or not the current instance has data.");
            _writer.Line($"public virtual bool HasData {{ get; }}");
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Gets the data representing this Feature.");
            _writer.WriteXmlDocumentationException(typeof(InvalidOperationException), $"Throws if there is no data loaded in the current instance.");
            using (_writer.Scope($"public virtual {This.ResourceData.Type} Data"))
            {
                using (_writer.Scope($"get"))
                {
                    _writer.Line($"if (!HasData)");
                    _writer.Line($"throw new {typeof(InvalidOperationException)}(\"The current instance does not have data, you must call Get first.\");");
                    _writer.Line($"return _data;");
                }
            }

            _writer.Line();
        }

        protected override void WriteOperations()
        {
            foreach (var method in This.CommonOperations)
            {
                WriteCommonOperation(method, true);
                WriteCommonOperation(method, false);
            }
        }

        private void WriteCommonOperation(MgmtCommonOperation commonOperation, bool isAsync)
        {
            var coreSignature = commonOperation.CoreMethodSignature.WithAsync(isAsync);
            _writer.WriteAbstractMethodDeclaration(coreSignature);
            _writer.Line();

            var signature = commonOperation.MethodSignature;
            using (WriteCommonMethodWithoutValidation(signature, null, isAsync, enableAttributes: true, attributes: new[] { new ForwardsClientCallsAttribute() }))
            {
                _writer.AppendRaw("return ")
                    .AppendRawIf("await ", isAsync)
                    .Append($"{coreSignature.Name}(");
                foreach (var parameter in signature.Parameters)
                {
                    _writer.AppendRaw(parameter.Name).AppendRaw(",");
                }
                _writer.RemoveTrailingComma();
                _writer.LineRaw(");");
            }

            _writer.Line();
        }
    }
}

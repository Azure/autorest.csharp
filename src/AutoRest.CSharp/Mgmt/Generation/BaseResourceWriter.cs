// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.Output.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class BaseResourceWriter : ResourceWriter
    {
        private BaseResource This { get; }
        protected internal BaseResourceWriter(BaseResource baseResource) : base(baseResource)
        {
            This = baseResource;
        }

        protected override void InitializeCustomMethodWriters()
        {
            foreach (var operation in This.AllOperations)
            {
                _customMethods.Add($"Write{operation.Name}Body", WriteBaseMethodBody);
            }
        }

        protected override void WriteStaticMethods()
        {
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

                // throws when it matches nothing
                var resourceNames = This.DerivedResources.Select(resource => (FormattableString)$"{resource.Type.Name}").ToList();
                var resourceNameList = resourceNames.Join(", ", " or ");
                //_writer.Line($"throw new {typeof(InvalidOperationException)}($\"The resource identifier {{data.Id}} cannot be recognized as one of the following resource candidates: {resourceNameList}\");");
                _writer.Append($"return new {This.FallbackResource.Type}(");
                foreach (var parameter in signature.Parameters)
                {
                    _writer.AppendRaw(parameter.Name).AppendRaw(",");
                }
                _writer.RemoveTrailingComma();
                _writer.LineRaw(");");
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
                    using (_writer.Scope($"if ({PolymorphicOption.IdParameter.Name}.ResourceType != {resource.Type.Name}.ResourceType)"))
                    {
                        _writer.LineRaw("return false;");
                    }

                    // check scope resource type
                    if (option.ScopeResourceTypeConstraint != null)
                    {
                        _writer.LineRaw("// checking the resource scope");
                        var scopeResourceType = option.ScopeResourceTypeConstraint.ScopeResourceType;
                        using (_writer.Scope($"if ({option.ScopeResourceTypeConstraint.ScopePathGetter}.ResourceType != {GetResourceTypeExpression(scopeResourceType)})"))
                        {
                            _writer.LineRaw("return false;");
                        }
                    }

                    // check the name constraint
                    if (option.ResourceNameConstraint != null)
                    {
                        _writer.LineRaw("// checking the resource name");
                        using (_writer.Scope($"if ({PolymorphicOption.IdParameter.Name}.Name != {option.ResourceNameConstraint.Value.ConstantValue:L})"))
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

        protected override void WriteMethod(MgmtClientOperation clientOperation, bool isAsync)
        {
            // create core method
            var coreSignature = clientOperation.MethodSignature with
            {
                Name = $"{clientOperation.Name}Core",
                Modifiers = MethodSignatureModifiers.Protected | MethodSignatureModifiers.Abstract,
                Description = $"The core implementation for operation {clientOperation.Name}"
            };
            coreSignature = coreSignature.WithAsync(isAsync);
            _writer.WriteMethodDocumentation(coreSignature);
            using (_writer.WriteMethodDeclaration(coreSignature))
            { }
            _writer.Line();

            base.WriteMethod(clientOperation, isAsync);
            _writer.Line();
        }

        private void WriteBaseMethodBody(MgmtClientOperation operation, Diagnostic diagnostic, bool isAsync)
        {
            // call its corresponding core method directly here
            var coreMethodName = $"{operation.Name}Core";
            _writer.AppendRaw("return ")
                    .AppendRawIf("await ", isAsync && !operation.IsPagingOperation)
                    .Append($"{CreateMethodName(coreMethodName, isAsync)}(");
            foreach (var parameter in operation.MethodParameters)
            {
                _writer.AppendRaw(parameter.Name).AppendRaw(",");
            }
            _writer.RemoveTrailingComma();
            _writer.AppendRaw(")")
                .AppendRawIf(".ConfigureAwait(false)", isAsync && !operation.IsPagingOperation)
                .LineRaw(";");
        }
    }
}

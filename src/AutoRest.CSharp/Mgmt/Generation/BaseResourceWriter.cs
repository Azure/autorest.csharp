// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Linq;
using System;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class BaseResourceWriter : ResourceWriter
    {
        private BaseResource This { get; }
        protected internal BaseResourceWriter(CodeWriter writer, BaseResource baseResource) : base(writer, baseResource)
        {
            This = baseResource;
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
                _writer.Line($"throw new {typeof(InvalidOperationException)}($\"The resource identifier {{data.Id}} cannot be recognized as one of the following resource candidates: {resourceNameList}\");");
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
                    using (_writer.Scope($"if ({option.IdParameter.Name}.ResourceType != {resource.Type.Name}.ResourceType)"))
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
                        using (_writer.Scope($"if ({option.IdParameter.Name}.Name != {option.ResourceNameConstraint.Value.ConstantValue:L})"))
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
    }
}

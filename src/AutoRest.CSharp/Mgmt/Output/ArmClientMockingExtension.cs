// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using Humanizer.Localisation;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ArmClientMockingExtension : MgmtMockingExtension
    {
        public ArmClientMockingExtension(CSharpType resourceType, IEnumerable<MgmtClientOperation> operations, MgmtExtension? extensionForChildResources) : base(resourceType, operations, extensionForChildResources)
        {
        }

        public override FormattableString IdVariableName => $"scope";

        public override FormattableString BranchIdVariableName => $"scope";

        public override bool IsEmpty => !ClientOperations.Any() && !MgmtContext.Library.ArmResources.Any();

        protected override Method BuildGetSingletonResourceMethod(Resource resource)
        {
            var originalMethod = base.BuildGetSingletonResourceMethod(resource);
            if (IsArmCore)
                return originalMethod;

            // we need to add a scope parameter inside the method signature
            var originalSignature = (MethodSignature)originalMethod.Signature;
            var signature = originalSignature with
            {
                Parameters = originalSignature.Parameters.Prepend(_scopeParameter).ToArray()
            };

            var scopeTypes = resource.RequestPath.GetParameterizedScopeResourceTypes();
            var methodBody = new MethodBodyStatement[]
            {
                BuildScopeResourceTypeValidations(scopeTypes),
                Snippets.Return(
                    Snippets.New.Instance(resource.Type, ClientProperty, resource.SingletonResourceIdSuffix!.BuildResourceIdentifier(_scopeParameter)))
            };

            return new(signature, methodBody);
        }

        protected override Method BuildGetChildCollectionMethod(ResourceCollection collection)
        {
            var originalMethod = base.BuildGetChildCollectionMethod(collection);
            if (IsArmCore)
                return originalMethod;

            // we need to add a scope parameter inside the method signature
            var originalSignature = (MethodSignature)originalMethod.Signature;
            var signature = originalSignature with
            {
                Parameters = originalSignature.Parameters.Prepend(_scopeParameter).ToArray()
            };

            var scopeTypes = collection.RequestPath.GetParameterizedScopeResourceTypes();
            var ctorArguments = new List<ValueExpression>
            {
                ClientProperty,
                _scopeParameter
            };
            ctorArguments.AddRange(originalSignature.Parameters.Select(p => (ValueExpression)p));
            var methodBody = new MethodBodyStatement[]
            {
                BuildScopeResourceTypeValidations(scopeTypes),
                Snippets.Return(
                    Snippets.New.Instance(collection.Type, ctorArguments.ToArray()))
            };

            return new(signature, methodBody);
        }

        private MethodBodyStatement BuildScopeResourceTypeValidations(ResourceTypeSegment[]? scopeTypes)
        {
            if (scopeTypes is null || !scopeTypes.Any() || scopeTypes.Contains(ResourceTypeSegment.Any))
                return MethodBodyStatement.Empty;

            var scopeVariable = (ValueExpression)_scopeParameter;
            var resourceTypeVariable = new ResourceIdentifierExpression(_scopeParameter).ResourceType;
            var conditions = new List<BoolExpression>();
            var resourceTypeStrings = new List<FormattableString>();
            foreach (var type in scopeTypes)
            {
                // here we have an expression of `!scope.ResourceType.Equals("<type>")`
                conditions.Add(
                    resourceTypeVariable.InvokeEquals(Snippets.Literal(type.ToString())).Not()
                );
                resourceTypeStrings.Add($"{type}");
            }

            // here we aggregate them together using or operator || and get: scope.ResourceType.Equals("<type1>") || scope.ResourceType.Equals("<type2>")
            var condition = conditions.Aggregate((a, b) => a.Or(b));
            var errorMessageFormat = $"Invalid resource type {{0}}, expected {resourceTypeStrings.Join(", ", " or ")}";
            return new IfStatement(condition)
            {
                Snippets.Throw(
                    Snippets.New.Instance(
                        typeof(ArgumentException),
                        new InvokeStaticMethodExpression(
                            typeof(string),
                            nameof(string.Format),
                            new ValueExpression[] { Snippets.Literal(errorMessageFormat), resourceTypeVariable })
                    ))
            };
        }

        private readonly Parameter _scopeParameter = new Parameter(
                Name: "scope",
                Description: $"The scope that the resource will apply against.",
                Type: typeof(ResourceIdentifier),
                DefaultValue: null,
                Validation: ValidationType.None,
                Initializer: null);
    }
}

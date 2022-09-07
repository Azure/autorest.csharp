// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class BaseResource : MgmtTypeProvider
    {
        private const string DataFieldName = "_data";
        /// <summary>
        /// Finds the corresponding <see cref="ResourceData"/> of this <see cref="Resource"/>
        /// </summary>
        public ResourceData ResourceData { get; }

        public BaseResource(string resourceName, IEnumerable<Resource> derivedResources) : base(resourceName)
        {
            DerivedResources = derivedResources;
            ResourceData = derivedResources.First().ResourceData;
        }

        private IEnumerable<MgmtCommonOperation>? _commonOperations;
        public IEnumerable<MgmtCommonOperation> CommonOperations => _commonOperations ??= EnsureCommonOperations();

        private IEnumerable<MgmtCommonOperation> EnsureCommonOperations()
        {
            var count = DerivedResources.Count();
            var commonMethods = new Dictionary<MethodKey, List<MgmtClientOperation>>();
            // add all the client operations on our derived resources into one dictionary to find if any of them are sharing the same signature
            foreach (var resource in DerivedResources)
            {
                foreach (var clientOperation in resource.AllOperations)
                {
                    // we need to do some escape on the ReturnType here - because they might be the resource, or ArmOperation<Resource>
                    // when this happens, they will never be the same
                    var key = new MethodKey(clientOperation.Name, clientOperation.MethodParameters.Select(parameter => parameter.Type).ToArray(), EscapeReturnType(clientOperation.ReturnType, resource));
                    commonMethods.AddInList(key, clientOperation);
                }
            }

            foreach ((var key, var operations) in commonMethods)
            {
                if (operations.Count != count)
                    continue;

                yield return new MgmtCommonOperation(key.Name, key.ReturnType, operations);
            }
        }

        /// <summary>
        /// This method escapes the return type when it is the type of this resource, or it is a generic type and its type arguments has the type of this resource
        /// This method escapes the type or the type argument to the type of this base resource instead.
        /// This is used when finding the common methods, the method with different return types will never be counted as a common method.
        /// To combine the method like "Get" method here, we need to escape its return type to the base resource type so that they would have the same return type and be considered as a overload of each other
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        private CSharpType EscapeReturnType(CSharpType returnType, Resource resource)
        {
            // if the return type is wrapped by the resource, we change it to the BaseResource
            if (returnType.Equals(resource.Type))
                return Type;

            if (returnType.IsGenericType && returnType.IsFrameworkType)
            {
                var arguments = returnType.Arguments.Select(typeArgument => typeArgument.Equals(resource.Type) ? Type : typeArgument).ToArray();
                return new CSharpType(returnType.FrameworkType, arguments);
            }

            return returnType;
        }

        protected override bool IsAbstract => true;

        public IEnumerable<Resource> DerivedResources { get; }

        public override CSharpType? BaseType => typeof(ArmResource);

        public override FormattableString Description => $"TODO";

        private string? _defaultName;
        protected override string DefaultName => _defaultName ??= ResourceName.AddResourceSuffixToResourceName();

        protected override ConstructorSignature? EnsureArmClientCtor()
        {
            return new ConstructorSignature(
              Name: Type.Name,
              null,
              Description: $"Initializes a new instance of the <see cref=\"{Type.Name}\"/> class.",
              Modifiers: Internal,
              Parameters: new[] { ArmClientParameter, ResourceIdentifierParameter },
              Initializer: new(
                  isBase: true,
                  arguments: new[] { ArmClientParameter, ResourceIdentifierParameter }));
        }

        protected override ConstructorSignature? EnsureResourceDataCtor()
        {
            return new ConstructorSignature(
                Name: Type.Name,
                null,
                Description: $"Initializes a new instance of the <see cref = \"{Type.Name}\"/> class.",
                Modifiers: Internal,
                Parameters: new[] { ArmClientParameter, ResourceDataParameter },
                Initializer: new(
                    IsBase: false,
                    Arguments: new FormattableString[] { $"{ArmClientParameter.Name:I}", Resource.ResourceDataIdExpression($"{ResourceDataParameter.Name:I}", ResourceData) }));
        }

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            return Enumerable.Empty<MgmtClientOperation>();
        }

        protected override FieldModifiers FieldModifiers => base.FieldModifiers | FieldModifiers.ReadOnly;

        protected override IEnumerable<FieldDeclaration>? GetAdditionalFields()
        {
            yield return new FieldDeclaration(FieldModifiers, ResourceData.Type, DataFieldName);
        }

        public MethodSignature StaticFactoryMethod => new MethodSignature(
            Name: "GetResource",
            Summary: null,
            Description: null,
            Modifiers: MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
            ReturnType: Type,
            ReturnDescription: null,
            Parameters: new[] { ArmClientParameter, ResourceDataParameter });

        public Parameter ResourceDataParameter => new(Name: "data", Description: $"The resource that is the target of operations.", Type: ResourceData.Type, DefaultValue: null, ValidationType.None, null);
    }
}

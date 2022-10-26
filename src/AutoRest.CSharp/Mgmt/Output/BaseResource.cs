// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;
using Humanizer.Localisation;

namespace AutoRest.CSharp.Mgmt.Output;

internal class BaseResource : Resource
{
    public BaseResource(string resourceName, IEnumerable<Resource> resources) : base(OperationSet.Null, Enumerable.Empty<Operation>(), resourceName, ResourceTypeSegment.Null, resources.First().ResourceData)
    {
        DerivedResources = resources;
    }

    protected override bool IsAbstract => true;

    public override bool CanValidateResourceType => false;

    public IEnumerable<Resource> DerivedResources { get; }

    public override CSharpType? BaseType => typeof(ArmResource);

    protected override FormattableString CreateDescription()
    {
        var resourceList = DerivedResources.Select(resource => (FormattableString)$"<see cref=\"{resource.Type.Name}\" />").ToArray();
        return $"This is the base client representation of the following resources {FormattableStringHelpers.Join(resourceList, ", ", " or ")}.";
    }

    protected override HashSet<NameSetKey> EnsureUniqueSets()
    {
        // return an empty set because the base resource will not have any implementations
        // but since the operations in the base resource are constructed from the derived resources,
        // if we do not force this to be empty, unused rest client will still be created
        return new HashSet<NameSetKey>();
    }

    // base resource does not have children
    public override IEnumerable<Resource> ChildResources => Enumerable.Empty<Resource>();

    public override MgmtClientOperation GetOperation => throw new InvalidOperationException("We should not access the Get operation of base resource in this way, please iterate AllOperations instead");
    public override MgmtClientOperation? CreateOperation => throw new InvalidOperationException("We should not access the Get operation of base resource in this way, please iterate AllOperations instead");
    public override MgmtClientOperation? DeleteOperation => throw new InvalidOperationException("We should not access the Get operation of base resource in this way, please iterate AllOperations instead");
    public override MgmtClientOperation? UpdateOperation => throw new InvalidOperationException("We should not access the Get operation of base resource in this way, please iterate AllOperations instead");

    protected override IEnumerable<MgmtClientOperation> EnsureAllOperations() => ClientOperations;

    protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
    {
        return EnsureBaseCommonOperations().Values;
    }

    private Dictionary<MethodKey, List<(Resource Resource, MgmtClientOperation Operation)>>? _commonOperationDict;
    private Dictionary<MethodKey, List<(Resource Resource, MgmtClientOperation Operation)>> EnsureOperationCategorizationDictionary()
    {
        if (_commonOperationDict != null)
            return _commonOperationDict;

        // find the common operations and set them back to the derived resources
        var commonOperationDict = new Dictionary<MethodKey, List<(Resource, MgmtClientOperation)>>();
        // we categorize all the operations using the method key of them, which consists of the name of operation, required parameters and the return type (escape to the base resoruce if it is the resource)
        foreach (var resource in DerivedResources)
        {
            foreach (var clientOperation in resource.AllOperations)
            {
                var requiredParameterTypes = clientOperation.MethodParameters.Where(parameter => !parameter.IsOptionalInSignature).Select(parameter => parameter.Type).ToArray();
                var key = new MethodKey(clientOperation.Name, requiredParameterTypes, EscapeReturnType(clientOperation.MgmtReturnType, resource));
                commonOperationDict.AddInList(key, (resource, clientOperation));
            }
        }

        // filter the non-common operations out
        var countOfResources = DerivedResources.Count();
        _commonOperationDict = commonOperationDict.Where(kv => kv.Value.Count == countOfResources).ToDictionary(
            kv => kv.Key,
            kv => kv.Value);

        return _commonOperationDict;
    }

    private Dictionary<MethodKey, MgmtClientOperation>? _baseCommonOperations;
    private Dictionary<MethodKey, MgmtClientOperation> EnsureBaseCommonOperations()
    {
        if (_baseCommonOperations != null)
            return _baseCommonOperations;

        _baseCommonOperations = new Dictionary<MethodKey, MgmtClientOperation>();
        foreach ((var key, var list) in EnsureOperationCategorizationDictionary())
        {
            // here we only use the first client operation to represent the base operation (since we never write an implementation of this method, it is fine
            var baseOperation = MgmtClientOperation.Override(list.First().Operation, key.Name, key.ReturnType, overrideDescription: $"The default implementation for operation {key.Name}", overrideOwner: this);
            _baseCommonOperations.Add(key, baseOperation);
        }
        return _baseCommonOperations;
    }

    private Dictionary<Resource, List<MgmtCommonOperation>>? _commonOperationMap;
    public Dictionary<Resource, List<MgmtCommonOperation>> CommonOperationMap => _commonOperationMap ??= EnsureCommonOperations();

    private Dictionary<Resource, List<MgmtCommonOperation>> EnsureCommonOperations()
    {
        // find the common operations and set them back to the derived resources
        var commonOperationsDict = EnsureOperationCategorizationDictionary();

        // create the core operations
        var baseOperationDict = EnsureBaseCommonOperations();

        var result = new Dictionary<Resource, List<MgmtCommonOperation>>();
        foreach ((var key, var list) in commonOperationsDict)
        {
            foreach ((var resource, var operation) in list)
            {
                var baseOperation = baseOperationDict[key];
                // construct a core method here
                var coreOperation = MgmtClientOperation.Override(operation, $"{baseOperation.Name}Core", baseOperation.MgmtReturnType, overrideDiagnosticName: operation.Name);
                result.AddInList(resource, new MgmtCommonOperation(operation, coreOperation));
            }
        }

        return result;
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
    private CSharpType? EscapeReturnType(CSharpType? returnType, Resource resource)
    {
        // if the return type is wrapped by the resource, we change it to the BaseResource
        if (resource.Type.Equals(returnType))
            return Type;

        return returnType;
    }

    public MethodSignature StaticFactoryMethod => new MethodSignature(
            Name: "GetResource",
            Summary: null,
            Description: null,
            Modifiers: MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
            ReturnType: Type,
            ReturnDescription: null,
            Parameters: new[] { ArmClientParameter, ResourceDataParameter });
}

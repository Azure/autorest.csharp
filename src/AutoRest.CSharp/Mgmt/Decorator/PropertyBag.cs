// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class PropertyBag
    {
        public static RestClientMethod UpdateMgmtRestClientMethod(this RestClientMethod method, string? resourceName, string methodName)
        {
            var queryOrHeaderParams = method.Parameters.Where(p => p.RequestLocation == RequestLocation.Header || p.RequestLocation == RequestLocation.Query);
            if (queryOrHeaderParams.Count() > 2)
            {
                var queryOrHeaderParamNames = queryOrHeaderParams.Select(p => p.Name).ToImmutableHashSet();
                var queryOrHeaderInputParams = method.Operation.Parameters.Where(p => queryOrHeaderParamNames.Contains(p.Name));
                var schema = BuildOptionalSchema(queryOrHeaderInputParams, resourceName, methodName);
                var schemaObject = new MgmtObjectType(schema);
                var newParameter = BuildOptionalParameter(schemaObject);
                MgmtContext.Library.PropertyBagModels.Add(schemaObject);
                return UpdateRestClientMethod(method, queryOrHeaderParamNames, newParameter);
            }
            return method;
        }

        public static PagingMethod UpdateMgmtPagingMethod(this PagingMethod pagingMethod, RestClientMethod originalMethod, RestClientMethod updatedMethod)
        {
            var queryOrHeaderParams = originalMethod.Parameters.Where(p => p.RequestLocation == RequestLocation.Header || p.RequestLocation == RequestLocation.Query);
            if (queryOrHeaderParams.Count() > 2)
            {
                RestClientMethod? nextPageMethod = pagingMethod.NextPageMethod;
                if (nextPageMethod is not null)
                {
                    nextPageMethod = RestClientBuilder.BuildNextPageMethod(updatedMethod);
                }
                return new PagingMethod(
                    updatedMethod,
                    nextPageMethod,
                    pagingMethod.Name,
                    pagingMethod.Diagnostics,
                    pagingMethod.PagingResponse
                    );
            }
            return pagingMethod;
        }

        private static ObjectSchema BuildOptionalSchema(IEnumerable<InputParameter> parameters, string? resourceName, string methodName)
        {
            var schema = new ObjectSchema {
                Extensions = new RecordOfStringAndAny { { "x-csharp-usage", "model,input" }, { "x-accessibility", "public" } },
                ApiVersions = new Collection<ApiVersion> { parameters.FirstOrDefault().Schema.ApiVersions.FirstOrDefault() },
                Properties = new Collection<Property>(parameters.Select(p => new Property
                {
                    Schema = p.Schema,
                    Language = new Languages
                    {
                        Default = new Language
                        {
                            Name= p.Name,
                            Description= p.Description
                        }
                    },
                    ReadOnly = false,
                    Required = p.DefaultValue == null
                }).ToList()) };
            var resourcePrefix = resourceName is null ?
                MgmtContext.Context.DefaultNamespace.Equals(typeof(ArmClient).Namespace) ? "Arm" : $"{MgmtContext.Context.DefaultNamespace.Split('.').Last()}Extensions" :
                resourceName.ReplaceLast("Resource", "").ReplaceLast("Collection", "");
            // TODO - We need to provide configuration here to agilely rename the property bag model name
            schema.Language.Default.Name = $"{resourcePrefix}{methodName}Options";
            schema.Language.Default.Description = $"A class representing the query and header parameters in {methodName} method.";
            return schema;
        }

        private static Parameter BuildOptionalParameter(MgmtObjectType schemaObject)
        {
            bool shouldValidate = schemaObject.Properties.Any(p => p.IsRequired);
            CSharpType type = schemaObject.Type;
            return new Parameter(
                "options",
                "A property bag which contains all the query and header parameters of this method.",
                TypeFactory.GetInputType(type),
                null,
                shouldValidate ? ValidationType.AssertNotNull : ValidationType.None,
                shouldValidate ? (FormattableString?)null : $"new {type.Name}()",
                IsApiVersionParameter: false,
                IsResourceIdentifier: false,
                SkipUrlEncoding: false)
            {
                IsPropertyBag = true
            };
        }

        private static RestClientMethod UpdateRestClientMethod(RestClientMethod method, IEnumerable<string> parameterNamesToRemove, Parameter parameterToAdd)
        {
            var parametersToKeep = new List<Parameter>();
            bool isPropertyBagInserted = false;
            foreach (var parameter in method.Parameters)
            {
                if (!parameterNamesToRemove.Contains(parameter.Name))
                {
                    // Generally we will insert the new parameter before the first optional parameter to be kept.
                    if (parameter.DefaultValue != null && isPropertyBagInserted == false)
                    {
                        parametersToKeep.Add(parameterToAdd);
                        isPropertyBagInserted = true;
                    }
                    parametersToKeep.Add(parameter);
                }
                else
                {
                    // We will immediately insert the new parameter once we encounter that the first parameter to be removed is a required query or header parameter.
                    if (parameter.DefaultValue == null && isPropertyBagInserted == false)
                    {
                        parametersToKeep.Add(parameterToAdd);
                        isPropertyBagInserted = true;
                    }
                }
            }
            // If all the parameters to be kept are required and not query or header parameters, we insert the new parameter at the end.
            if (isPropertyBagInserted == false)
            {
                parametersToKeep.Add(parameterToAdd);
            }
            return new RestClientMethod(method.Name,
                method.Summary,
                method.Description,
                method.ReturnType,
                method.Request,
                parametersToKeep.ToArray(),
                method.Responses,
                method.HeaderModel,
                method.BufferResponse,
                method.Accessibility.ToString().ToLower(),
                method.Operation,
                method.Parameters);
        }
    }
}

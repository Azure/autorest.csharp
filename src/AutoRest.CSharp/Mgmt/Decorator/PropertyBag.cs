// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
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
            if (method.Parameters.Where(p => p.DefaultValue != null).Count() > 2)
            {
                ObjectSchema schema = new ObjectSchema();
                var optionalParameters = method.Parameters.Where(p => p.DefaultValue != null && p.RequestLocation != RequestLocation.Body).ToHashSet();
                var optionalParametersName = optionalParameters.Select(p => p.Name).ToHashSet();
                var optionalRequestParameters = method.Operation.Parameters.Where(p => optionalParametersName.Contains(p.CSharpName())).
                    Concat(method.Operation.Requests.FirstOrDefault().Parameters.Where(p => optionalParametersName.Contains(p.CSharpName())));
                InitializeSchema(schema, optionalRequestParameters, resourceName, methodName);
                var newParameter = BuildOptionalParameter(schema);
                MgmtContext.Library.OptionalModels = MgmtContext.Library.OptionalModels.Concat(new List<TypeProvider>() { new MgmtObjectType(schema) });
                return UpdateRestClientMethod(method, method.Parameters.Where(p => !optionalParameters.Contains(p)).Append(newParameter));
            }
            return method;
        }

        public static PagingMethod UpdateMgmtPagingMethod(this PagingMethod pagingMethod, RestClientMethod originalMethod, RestClientMethod updatedMethod)
        {
            if (originalMethod.Parameters.Where(p => p.DefaultValue != null).Count() > 2)
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

        public static bool IsPropertyBagParameter(Parameter parameter)
        {
            if (!parameter.Type.IsFrameworkType && parameter.Type.Implementation is MgmtObjectType mgmtObject && MgmtContext.Library.OptionalModels.Contains(mgmtObject))
            {
                return true;
            }
            return false;
        }

        private static void InitializeSchema(ObjectSchema schema, IEnumerable<RequestParameter> parameters, string? resourceName, string methodName)
        {
            schema.Extensions = new RecordOfStringAndAny { { "x-csharp-usage", "model,input" } };
            schema.ApiVersions.Add(parameters.FirstOrDefault().Schema.ApiVersions.FirstOrDefault());
            foreach (var parameter in parameters)
            {
                schema.Properties.Add(new Property()
                {
                    Schema = parameter.Schema,
                    Language = parameter.Language,
                    ReadOnly = false
                });
            }
            var resourcePrefix = resourceName is null ?
                MgmtContext.Context.DefaultNamespace.Equals(typeof(ArmClient).Namespace) ? "Arm" : MgmtContext.Context.DefaultNamespace.Split('.').Last() :
                resourceName.ReplaceLast("Resource", "").ReplaceLast("Collection", "");
            schema.Language.Default.Name = $"{resourcePrefix}{methodName}Options";
            schema.Language.Default.Description = $"A class representing the optional parameters in {methodName} method.";
        }

        private static Parameter BuildOptionalParameter(ObjectSchema schema)
        {
            CSharpType type = new MgmtObjectType(schema).Type;
            return new Parameter(
                "options",
                schema.Language.Default.Description,
                TypeFactory.GetInputType(type),
                null,
                ValidationType.None,
                $"new {type.Name}()",
                IsApiVersionParameter: false,
                IsResourceIdentifier: false,
                SkipUrlEncoding: false);
        }

        private static RestClientMethod UpdateRestClientMethod(RestClientMethod method, IEnumerable<Parameter> parameters)
        {
            return new RestClientMethod(method.Name,
                method.Description,
                method.ReturnType,
                method.Request,
                parameters.ToArray(),
                method.Responses,
                method.HeaderModel,
                method.BufferResponse,
                method.Accessibility.ToString().ToLower(),
                method.Operation,
                method.ConditionHeaderFlag);
        }
    }
}

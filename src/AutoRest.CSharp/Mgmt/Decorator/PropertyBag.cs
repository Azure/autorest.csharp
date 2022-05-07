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
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class PropertyBag
    {
        public static ObjectSchema UpdateMgmtRestClientParameters(Operation operation, ref RestClientMethod restClientMethod, string optionsPrefix)
        {
            ObjectSchema schema = new ObjectSchema();
            var optionalParameters = restClientMethod.Parameters.Where(p => p.DefaultValue != null && p.RequestLocation != RequestLocation.Body).ToHashSet();
            var optionalParametersName = optionalParameters.Select(p => p.Name).ToHashSet();
            var optionalRequestParameters = operation.Parameters.Where(p => optionalParametersName.Contains(p.CSharpName())).
                Concat(operation.Requests.FirstOrDefault().Parameters.Where(p => optionalParametersName.Contains(p.CSharpName())));
            InitializeSchema(schema, optionalRequestParameters, restClientMethod, optionsPrefix);
            var newParameter = BuildOptionalParameter(schema);
            restClientMethod = UpdateRestClientMethod(restClientMethod, restClientMethod.Parameters.Where(p => !optionalParameters.Contains(p)).Append(newParameter));
            return schema;
        }

        public static MgmtRestOperation UpdateMgmtRestOperationParameters(this MgmtRestOperation operation)
        {
            var optionalParameter = operation.Parameters.Where(p => IsPropertyBagParameter(p)).FirstOrDefault();
            if (optionalParameter != null)
            {
                var resourcePrefix = operation.Resource is null ? operation.RestClient.ClientPrefix : operation.Resource.Type.Name.ReplaceLast("Resource", "");
                var methodName = operation.Name;
                var schemaName = $"{resourcePrefix}{methodName}Options";
                var objectType = optionalParameter.Type.Implementation as MgmtObjectType;
                if (objectType!.Type.Name != schemaName)
                {
                    objectType.ObjectSchema.Language.Default.Name = schemaName;
                    objectType.ObjectSchema.Language.Default.Description = $"A class representing the optional parameters in {resourcePrefix} {methodName} method.";
                    optionalParameter = PropertyBag.BuildOptionalParameter(objectType.ObjectSchema);
                    var updatedMethod = UpdateRestClientMethod(operation.Method, operation.Parameters.SkipLast(1).Append(optionalParameter));
                    operation = new MgmtRestOperation(
                        updatedMethod,
                        operation.RestClient,
                        operation.RequestPath,
                        operation.ContextualPath,
                        operation.Name,
                        operation.IsLongRunningOperation,
                        operation.ThrowIfNull);
                }
                MgmtContext.Library.OptionalModels = MgmtContext.Library.OptionalModels.Concat(new List<TypeProvider>() { new MgmtObjectType(objectType.ObjectSchema) });
            }
            return operation;
        }

        public static bool IsPropertyBagParameter(Parameter parameter)
        {
            if (!parameter.Type.IsFrameworkType && parameter.Type.Implementation is MgmtObjectType mgmtObject &&
                (MgmtContext.Library.OptionalObjectTypes.Contains(mgmtObject) || MgmtContext.Library.OptionalModels.Contains(mgmtObject)))
            {
                return true;
            }
            return false;
        }

        private static void InitializeSchema(ObjectSchema schema, IEnumerable<RequestParameter> parameters, RestClientMethod restClientMethod, string optionsPrefix)
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
            var methodName = restClientMethod.Name == "List" ? "GetAll" : restClientMethod.Name;
            schema.Language.Default.Name = $"{optionsPrefix.LastWordToSingular()}{methodName}Options"; // A better way to determine the schema name is needed
            schema.Language.Default.Description = $"A class representing the optional parameters in {optionsPrefix} {methodName} method.";
        }

        private static Parameter BuildOptionalParameter(ObjectSchema schema)
        {
            CSharpType type = new MgmtObjectType(schema).Type;
            //var defaultValue = Constant.NewInstanceOf(type);
            return new Parameter(
                "options",
                schema.Language.Default.Description,
                TypeFactory.GetInputType(type),
                null,
                false,
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

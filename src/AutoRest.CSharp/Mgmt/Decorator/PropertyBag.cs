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
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class PropertyBag
    {
        public static ObjectSchema UpdateParameters(Operation operation, ref RestClientMethod restClientMethod, string optionsPrefix)
        {
            ObjectSchema schema = new ObjectSchema();
            var optionalParameters = restClientMethod.Parameters.Where(p => p.DefaultValue != null).ToHashSet();
            var optionalParametersName = optionalParameters.Select(p => p.Name).ToHashSet();
            var optionalRequestParameters = operation.Parameters.Where(p => optionalParametersName.Contains(p.CSharpName())).
                Concat(operation.Requests.FirstOrDefault().Parameters.Where(p => optionalParametersName.Contains(p.CSharpName())));
            InitializeSchema(schema, optionalRequestParameters, restClientMethod, $"{optionsPrefix.LastWordToSingular()}{GetMethodName(operation)}");
            var newParameter = BuildOptionalParameter(schema);
            restClientMethod = new RestClientMethod(restClientMethod.Name,
                restClientMethod.Description,
                restClientMethod.ReturnType,
                restClientMethod.Request,
                restClientMethod.Parameters.Where(p => !optionalParameters.Contains(p)).Append(newParameter).ToArray(),
                restClientMethod.Responses,
                restClientMethod.HeaderModel,
                restClientMethod.BufferResponse,
                restClientMethod.Accessibility.ToString().ToLower(),
                restClientMethod.Operation,
                restClientMethod.ConditionHeaderFlag);
            return schema;
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
            schema.Language.Default.Name = $"{optionsPrefix}Options"; // A better way to determine the schema name is needed
            schema.Language.Default.Description = $"A class representing the optional query parameters in {optionsPrefix} {restClientMethod.Name} method.";
        }

        private static Parameter BuildOptionalParameter(ObjectSchema schema)
        {
            CSharpType type = new MgmtObjectType(schema, true).Type;
            var defaultValue = Constant.NewInstanceOf(type);
            return new Parameter(
                "options",
                schema.Language.Default.Description,
                TypeFactory.GetInputType(type),
                defaultValue,
                false,
                IsApiVersionParameter: false,
                IsResourceIdentifier: false,
                SkipUrlEncoding: false,
                RequestLocation: RequestLocation.Query);
        }

        private static string GetMethodName(Operation operation)
        {
            if (operation.TryGetConfigOperationName(out var name))
                return name;
            return operation.MgmtCSharpName(false);
        }
    }
}

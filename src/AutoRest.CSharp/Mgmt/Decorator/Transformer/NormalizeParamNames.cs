// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class NormalizeParamNames
    {
        public static void Update(CachedDictionary<string, HashSet<OperationSet>> dataSchemaDict)
        {
            foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    foreach (var request in operation.Requests)
                    {
                        foreach (var param in request.SignatureParameters)
                        {
                            if (param.In != HttpParameterIn.Body)
                                continue;

                            if (param.Schema is not ObjectSchema objectSchema)
                                continue;

                            param.Language.Default.Name = GetNewName(param.Language.Default.Name, objectSchema.Name, dataSchemaDict);
                        }
                    }
                }
            }
        }

        internal static string GetNewName(string paramName, string schemaName, CachedDictionary<string, HashSet<OperationSet>> dataSchemaHash)
        {
            if (schemaName.EndsWith("Options", StringComparison.Ordinal))
                return "options";

            if (schemaName.EndsWith("Info", StringComparison.Ordinal))
                return "info";

            if (schemaName.EndsWith("Details", StringComparison.Ordinal))
                return "details";

            if (schemaName.EndsWith("Content", StringComparison.Ordinal))
                return "content";

            if (schemaName.EndsWith("Patch", StringComparison.Ordinal))
                return "patch";

            if (schemaName.EndsWith("Input", StringComparison.Ordinal))
                return "input";

            if (schemaName.EndsWith("Data", StringComparison.Ordinal) || dataSchemaHash.ContainsKey(schemaName))
                return "data";

            if (paramName.Equals("parameters", StringComparison.OrdinalIgnoreCase))
                return schemaName.FirstCharToLowerCase();

            return paramName;
        }
    }
}

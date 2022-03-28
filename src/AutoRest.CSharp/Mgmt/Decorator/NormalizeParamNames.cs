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
        public static void Update(CachedDictionary<string, HashSet<OperationSet>> dataSchemaHash)
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

                            param.Language.Default.Name = GetNewName(param.Language.Default.Name, objectSchema, dataSchemaHash);
                        }
                    }
                }
            }
        }

        private static string GetNewName(string paramName, ObjectSchema objectSchema, CachedDictionary<string, HashSet<OperationSet>> dataSchemaHash)
        {
            if (objectSchema.Name.EndsWith("Options", StringComparison.Ordinal))
                return "options";

            if (objectSchema.Name.EndsWith("Data", StringComparison.Ordinal) || dataSchemaHash.ContainsKey(objectSchema.Name))
                return "data";

            if (paramName.Equals("parameters", StringComparison.Ordinal))
                return objectSchema.Name.FirstCharToLowerCase();

            return paramName;
        }
    }
}

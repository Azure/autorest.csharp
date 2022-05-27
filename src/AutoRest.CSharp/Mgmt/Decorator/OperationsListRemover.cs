// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OperationsListRemover
    {
        public static void RemoveListOperations()
        {
            var operationsToRemove = new Queue<Operation>();
            // we have to remove the corresponding schemas here now, despite even if we generate them, the "remover" will remove them
            // this is because that we have detections on the schemas (such like the duration check), which will cause the generation to fail if we do not omit them now and defer it to remover
            var schemaToOmit = new HashSet<Schema>();
            var schemaToKeep = new HashSet<Schema>();
            foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    if (IsOperationsListOperation(operation))
                    {
                        operationsToRemove.Enqueue(operation);
                        OmitOperationGroups.DetectSchemas(operation, schemaToOmit);
                    }
                    else
                    {
                        OmitOperationGroups.DetectSchemas(operation, schemaToKeep);
                    }
                }

                // remove the operations
                while (operationsToRemove.Count > 0)
                {
                    operationGroup.Operations.Remove(operationsToRemove.Dequeue());
                }
            }

            OmitOperationGroups.AddDependantSchemasRecursively(schemaToKeep);
            OmitOperationGroups.AddDependantSchemasRecursively(schemaToOmit);
            OmitOperationGroups.RemoveSchemas(schemaToOmit, schemaToKeep);
        }

        private static Regex operationsListPathRegex = new Regex(@"^/providers/[A-Za-z0-9]+\.[A-Za-z0-9]+/operations$");

        private static bool IsOperationsListOperation(Operation operation)
        {
            var httpPath = operation.GetHttpPath();
            return operationsListPathRegex.IsMatch(httpPath);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OmitOperationGroups
    {
        private static HashSet<Schema> _schemasToOmit = new HashSet<Schema>();
        private static HashSet<Schema> _schemasToKeep = new HashSet<Schema>();

        public static void RemoveOperationGroups(CodeModel codeModel, BuildContext<MgmtOutputLibrary> context)
        {
            var operationGroupsToOmit = context.Configuration.MgmtConfiguration.OperationGroupsToOmit;
            if (operationGroupsToOmit != null)
            {
                var omitSet = operationGroupsToOmit.ToHashSet();
                var omittedOGs = codeModel.OperationGroups.Where(og => omitSet.Contains(og.Key)).ToList();
                var nonOmittedOGs = codeModel.OperationGroups.Where(og => !omitSet.Contains(og.Key)).ToList();

                codeModel.OperationGroups = nonOmittedOGs;
                foreach (var operationGroup in codeModel.OperationGroups)
                {
                    DetectSchemasToKeep(operationGroup);
                }

                foreach (var operationGroup in omittedOGs)
                {
                    if (operationGroup.IsResource(context.Configuration.MgmtConfiguration))
                    {
                        DetectSchemasToOmit(codeModel, operationGroup);
                    }
                }
                _schemasToOmit = _schemasToOmit.Except(_schemasToKeep).ToHashSet();
                RemoveSchemas(codeModel);
            }
        }

        private static void RemoveSchemas(CodeModel codeModel)
        {
            foreach (var schema in _schemasToOmit)
            {
                if (schema is ObjectSchema objSchema)
                {
                    codeModel.Schemas.Objects.Remove(objSchema);
                    RemoveRelations(objSchema);
                }
            }
        }

        private static void RemoveRelations(ObjectSchema schema)
        {
            if (schema.Parents != null)
            {
                foreach (ObjectSchema parent in schema.Parents.Immediate)
                {
                    if (parent.Children != null)
                    {
                        parent.Children.Immediate.Remove(schema);
                    }
                }
            }
        }

        private static void AddDependantSchemasRecursively(HashSet<Schema> setToProcess)
        {
            Queue<Schema> sQueue = new Queue<Schema>(setToProcess);
            HashSet<Schema> handledSchemas = new HashSet<Schema>();
            while (sQueue.Count > 0)
            {
                var cur = sQueue.Dequeue();
                handledSchemas.Add(cur);
                if (cur is ObjectSchema curSchema)
                {
                    foreach (var property in curSchema.Properties)
                    {
                        if (property.Schema is ObjectSchema propertySchema)
                        {
                            if (!handledSchemas.Contains(propertySchema))
                            {
                                sQueue.Enqueue(propertySchema);
                                setToProcess.Add(propertySchema);
                            }
                        }
                        else if (property.Schema is ArraySchema arraySchema && arraySchema.ElementType is ObjectSchema arrayPropertySchema)
                        {
                            if (!handledSchemas.Contains(arrayPropertySchema))
                            {
                                sQueue.Enqueue(arrayPropertySchema);
                                setToProcess.Add(arrayPropertySchema);
                            }
                        }
                    }
                    if (curSchema.Parents != null)
                    {
                        foreach (var parent in curSchema.Parents.Immediate)
                        {
                            if (parent is ObjectSchema parentSchema)
                            {
                                if (!handledSchemas.Contains(parentSchema))
                                {
                                    sQueue.Enqueue(parentSchema);
                                    setToProcess.Add(parentSchema);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void DetectSchemasToKeep(OperationGroup operationGroup)
        {
            foreach (var operation in operationGroup.Operations)
            {
                AddResponseSchemas(operation, _schemasToKeep);
                AddRequestSchemas(operation, _schemasToKeep);
            }
            AddDependantSchemasRecursively(_schemasToKeep);
        }

        private static void DetectSchemasToOmit(CodeModel codeModel, OperationGroup operationGroup)
        {
            foreach (var operation in operationGroup.Operations)
            {
                AddResponseSchemas(operation, _schemasToOmit);
                AddRequestSchemas(operation, _schemasToOmit);
            }
            AddDependantSchemasRecursively(_schemasToOmit);
        }

        private static void AddResponseSchemas(Operation operation, HashSet<Schema> setToProcess)
        {
            foreach (var response in operation.Responses)
            {
                var schema = response.ResponseSchema;
                if (schema != null && schema is ObjectSchema objSchema)
                {
                    setToProcess.Add(objSchema);
                }
            }
        }

        private static void AddRequestSchemas(Operation operation, HashSet<Schema> setToProcess)
        {
            foreach (var request in operation.Requests)
            {
                if (request.Parameters != null)
                {
                    foreach (var param in request.Parameters)
                    {
                        if (param.Schema is ObjectSchema objSchema)
                        {
                            setToProcess.Add(objSchema);
                        }
                    }
                }
            }
        }

    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class OmitOperationGroups
    {
        public static void RemoveOperationGroups()
        {
            var omitSet = Configuration.MgmtConfiguration.OperationGroupsToOmit.ToHashSet();
            if (MgmtContext.CodeModel.OperationGroups.FirstOrDefault(og => og.Key == "Operations") != null)
            {
                omitSet.Add("Operations");
            }
            if (omitSet.Count > 0)
            {
                var omittedOGs = MgmtContext.CodeModel.OperationGroups.Where(og => omitSet.Contains(og.Key)).ToList();
                var nonOmittedOGs = MgmtContext.CodeModel.OperationGroups.Where(og => !omitSet.Contains(og.Key)).ToList();

                MgmtContext.CodeModel.OperationGroups = nonOmittedOGs;
                var schemasToOmit = new HashSet<Schema>();
                var schemasToKeep = new HashSet<Schema>();
                foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
                {
                    DetectSchemas(operationGroup, schemasToKeep);
                }
                AddDependantSchemasRecursively(schemasToKeep);

                foreach (var operationGroup in omittedOGs)
                {
                    DetectSchemas(operationGroup, schemasToOmit);
                }
                AddDependantSchemasRecursively(schemasToOmit);

                RemoveSchemas(schemasToOmit, schemasToKeep);
            }
        }

        private static void RemoveSchemas(HashSet<Schema> schemasToOmit, HashSet<Schema> schemasToKeep)
        {
            foreach (var schema in schemasToOmit)
            {
                if (schema is ObjectSchema objSchema && !schemasToKeep.Contains(objSchema))
                {
                    MgmtContext.CodeModel.Schemas.Objects.Remove(objSchema);
                    RemoveRelations(objSchema);
                }
                else if (schema is ChoiceSchema choiceSchema && !schemasToKeep.Contains(choiceSchema))
                {
                    MgmtContext.CodeModel.Schemas.Choices.Remove(choiceSchema);
                }
                else if (schema is SealedChoiceSchema sealChoiceSchema && !schemasToKeep.Contains(sealChoiceSchema))
                {
                    MgmtContext.CodeModel.Schemas.SealedChoices.Remove(sealChoiceSchema);
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
                        var propertySchema = property.Schema;
                        if (propertySchema is ObjectSchema || propertySchema is ChoiceSchema || propertySchema is SealedChoiceSchema)
                        {
                            if (!handledSchemas.Contains(propertySchema))
                            {
                                sQueue.Enqueue(propertySchema);
                                setToProcess.Add(propertySchema);
                            }
                        }
                        else if (propertySchema is ArraySchema arraySchema && arraySchema.ElementType is ObjectSchema arrayPropertySchema)
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

        private static void DetectSchemas(OperationGroup operationGroup, HashSet<Schema> setToProcess)
        {
            foreach (var operation in operationGroup.Operations)
            {
                AddResponseSchemas(operation, setToProcess);
                AddRequestSchemas(operation, setToProcess);
            }
        }

        private static void AddResponseSchemas(Operation operation, HashSet<Schema> setToProcess)
        {
            foreach (var response in operation.Responses.Concat(operation.Exceptions))
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

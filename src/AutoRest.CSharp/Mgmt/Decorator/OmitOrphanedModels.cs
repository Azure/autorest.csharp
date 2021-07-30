// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OmitOrphanedModels
    {
        private static HashSet<Schema> _schemasStillUsed = new HashSet<Schema>();

        public static void RemoveOrphanedModels(CodeModel codeModel)
        {
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                AddNonOmittedSchemasToSafeList(operationGroup);
            }

            AddDependantSchemasRecursively();
            RemoveSchemas(codeModel);
        }

        private static void AddNonOmittedSchemasToSafeList(OperationGroup operationGroup)
        {
            foreach (var operation in operationGroup.Operations)
            {
                AddResponseSchemas(operation);
                AddRequestSchemas(operation);
            }
        }

        private static void AddResponseSchemas(Operation operation)
        {
            foreach (var response in operation.Responses)
            {
                var schema = response.ResponseSchema;
                if (schema != null && schema is ObjectSchema objSchema)
                {
                    _schemasStillUsed.Add(objSchema);

                    foreach (var property in objSchema.Properties)
                    {
                        if (property.Schema is ObjectSchema propObjSchema)
                        {
                            _schemasStillUsed.Add(propObjSchema);
                        }
                        else if (property.Schema is ArraySchema propArraySchema && propArraySchema.ElementType is ObjectSchema elementSchema)
                        {
                            _schemasStillUsed.Add(elementSchema);
                        }
                    }
                }
            }
        }

        private static void AddRequestSchemas(Operation operation)
        {
            foreach (var request in operation.Requests)
            {
                if (request.Parameters != null)
                {
                    foreach (var param in request.Parameters)
                    {
                        if (param.Schema is ObjectSchema objSchema)
                        {
                            _schemasStillUsed.Add(objSchema);
                            foreach (var property in objSchema.Properties)
                            {
                                if (property.Schema is ObjectSchema propObjSchema)
                                {
                                    _schemasStillUsed.Add(propObjSchema);
                                }
                                else if (property.Schema is ArraySchema propArraySchema && propArraySchema.ElementType is ObjectSchema elementSchema)
                                {
                                    _schemasStillUsed.Add(elementSchema);
                                }
                            }
                        }
                        else if (param.Schema is ArraySchema arraySchema && arraySchema.ElementType is ObjectSchema elementSchema)
                        {
                            _schemasStillUsed.Add(elementSchema);
                            foreach (var property in elementSchema.Properties)
                            {
                                if (property.Schema is ObjectSchema proObjSchema)
                                {
                                    _schemasStillUsed.Add(proObjSchema);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void AddDependantSchemasRecursively()
        {
            Queue<Schema> sQueue = new Queue<Schema>(_schemasStillUsed);
            while (sQueue.Count > 0)
            {
                var cur = sQueue.Dequeue();
                if (cur is ObjectSchema curSchema)
                {
                    foreach (var property in curSchema.Properties)
                    {
                        if (property.Schema is ObjectSchema objPropSchema)
                        {
                            sQueue.Enqueue(objPropSchema);
                            _schemasStillUsed.Add(objPropSchema);
                        }
                        else if (property.Schema is ArraySchema arrayPropSchma && arrayPropSchma.ElementType is ObjectSchema elementSchema)
                        {
                            sQueue.Enqueue(elementSchema);
                            _schemasStillUsed.Add(elementSchema);
                        }
                    }
                    if (curSchema.Parents != null)
                    {
                        foreach (var parent in curSchema.Parents.Immediate)
                        {
                            if (parent is ObjectSchema parentSchema)
                            {
                                sQueue.Enqueue(parentSchema);
                                _schemasStillUsed.Add(parentSchema);
                            }
                        }
                    }
                }
            }
        }

        private static void RemoveSchemas(CodeModel codeModel)
        {
            var removeList = codeModel.Schemas.Objects.Where(s => s is ObjectSchema objSchema && !_schemasStillUsed.Contains(objSchema)).ToList();
            foreach (var schema in removeList)
            {
                codeModel.Schemas.Objects.Remove(schema);
                RemoveRelations(schema);
            }
        }

        private static void RemoveRelations(ObjectSchema schema)
        {
            // Parent is base class type. Removing model from inheritance reference.
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
    }
}

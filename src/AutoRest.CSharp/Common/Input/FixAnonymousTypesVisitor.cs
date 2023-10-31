﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal class FixAnonymousTypesVisitor : InputNamespaceVisitor
    {
        private readonly HashSet<string> _createdNames;
        private readonly InputNamespace _rootNamespace;

        private FixAnonymousTypesVisitor(InputNamespace rootNamespace)
        {
            _rootNamespace = rootNamespace;
            _createdNames = new HashSet<string>();
        }

        public static InputNamespace Visit(InputNamespace rootNamespace) => new FixAnonymousTypesVisitor(rootNamespace).VisitNamespace(rootNamespace);

        protected override InputModelType VisitModel(InputModelType modelType)
        {
            if (modelType.IsAnonymousModel)
            {
                var name = GetAnonymousModelNameAndUsage(modelType, out var usage);
                modelType = modelType with {Name = name, Usage = usage};
                _createdNames.Add(name);
            }

            return base.VisitModel(modelType);
        }

        private string GetAnonymousModelNameAndUsage(in InputModelType anonymousModel, out InputModelTypeUsage usage)
        {
            usage = InputModelTypeUsage.None;
            var names = new List<List<string>>();

            //check operation parameters first
            foreach (var client in _rootNamespace.Clients)
            {
                foreach (var operation in client.Operations)
                {
                    foreach (var parameter in operation.Parameters)
                    {
                        if (IsSameType(parameter.Type, anonymousModel))
                        {
                            usage |= InputModelTypeUsage.Input;
                            names.Add(new List<string> { operation.Name.ToCleanName(), GetNameWithCorrectPluralization(parameter.Type, parameter.Name).ToCleanName() });
                        }
                        else
                        {
                            FindMatchesRecursively(parameter.Type, anonymousModel, new List<string> { operation.Name.FirstCharToUpperCase(), parameter.Type.Name }, names, ref usage, InputModelTypeUsage.Input);
                        }
                    }

                    foreach (var response in operation.Responses)
                    {
                        if (response.BodyType is not InputModelType responseType)
                        {
                            continue;
                        }

                        if (IsSameType(responseType, anonymousModel))
                        {
                            usage |= InputModelTypeUsage.Output;
                            names.Add(new List<string> { operation.Name.ToCleanName(), GetNameWithCorrectPluralization(responseType, "ResponseType").ToCleanName() });
                        }
                        else
                        {
                            FindMatchesRecursively(responseType, anonymousModel, new List<string> { operation.Name.FirstCharToUpperCase(), responseType.Name }, names, ref usage, InputModelTypeUsage.Output);
                        }
                    }
                }
            }

            if (names.Count == 0)
            {
                foreach (var model in _rootNamespace.Models)
                {
                    foreach (var property in model.Properties)
                    {
                        if (IsSameType(property.Type, anonymousModel))
                        {
                            return $"{model.Name.FirstCharToUpperCase()}{property.Name.FirstCharToUpperCase()}";
                        }
                    }
                }
                return $"{_rootNamespace.Name}Model{anonymousModel.Name}";
            }

            if (names.Count == 1)
            {
                var newName = $"{names[0][0]}{names[0][names[0].Count - 1].FirstCharToUpperCase()}";
                if (_createdNames.Contains(newName))
                {
                    newName = names[0].Count >= 2
                        ? $"{names[0][1].FirstCharToUpperCase()}{names[0][names[0].Count - 1].FirstCharToUpperCase()}"
                        : $"{names[0][0].FirstCharToUpperCase()}{names[0][names[0].Count - 1].FirstCharToUpperCase()}";
                }
                return newName;
            }

            int smallest = names.Select(list => list.Count).Prepend(int.MaxValue).Min();
            int equalElements = 0;
            for (int offset = 0; offset < smallest; offset++)
            {
                string comparator = names[0][names[0].Count - 1 - offset];
                if (names.All(list => list[list.Count - 1 - offset] == comparator))
                {
                    equalElements++;
                }
                else
                {
                    break;
                }
            }

            if (equalElements == 1)
            {
                return $"{_rootNamespace.Name.FirstCharToUpperCase()}{names[0][names[0].Count - 1].FirstCharToUpperCase()}";
            }

            var sb = new StringBuilder();
            for (int i = names[0].Count - equalElements; i < names[0].Count; i++)
            {
                sb.Append(names[0][i].FirstCharToUpperCase());
            }
            return sb.ToString();
        }

        private void FindMatchesRecursively(InputType type, InputModelType anonModel, List<string> current, List<List<string>> names, ref InputModelTypeUsage usage, InputModelTypeUsage usageValue)
        {
            InputModelType? model = GetInputModelType(type);

            if (model is null)
            {
                return;
            }

            //check other model properties
            foreach (var property in model.Properties)
            {
                if (IsSameType(property.Type, anonModel))
                {
                    names.Add(new List<string>(current) { GetNameWithCorrectPluralization(property.Type, property.Name).ToCleanName() });
                    usage |= usageValue;
                }
                else
                {
                    FindMatchesRecursively(property.Type, anonModel, new List<string>(current) { GetTypeName(property.Type) }, names, ref usage, usageValue);
                }
            }
        }

        private string GetNameWithCorrectPluralization(InputType type, string name)
        {
            //TODO: Probably needs special casing for ipThing to become IPThing
            string result = name.FirstCharToUpperCase();
            switch (type)
            {
                case InputListType:
                case InputDictionaryType:
                    return result.ToSingular();
                default:
                    return result;
            }
        }

        private static InputModelType? GetInputModelType(InputType type)
            => type switch
            {
                InputModelType model => model,
                InputListType listType => GetInputModelType(listType.ElementType),
                InputDictionaryType dictionaryType => GetInputModelType(dictionaryType.ValueType),
                _ => null
            };

        private static bool IsSameType(InputType type, InputModelType anonModel)
            => type switch
            {
                InputListType listType => IsSameType(listType.ElementType, anonModel),
                InputDictionaryType dictionaryType => IsSameType(dictionaryType.ValueType, anonModel),
                InputModelType model => model.GetNotNullable().Equals(anonModel.GetNotNullable()),
                _ => false
            };

        private static string GetTypeName(InputType type)
            => type switch
            {
                InputListType listType => GetTypeName(listType.ElementType),
                InputDictionaryType dictionaryType => GetTypeName(dictionaryType.ValueType),
                _ => type.Name
            };
    }
}

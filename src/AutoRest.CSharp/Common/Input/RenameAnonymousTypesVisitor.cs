// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal class RenameAnonymousTypesVisitor : InputNamespaceVisitor
    {
        private readonly HashSet<string> _createdNames;
        private readonly InputNamespace _rootNamespace;

        private RenameAnonymousTypesVisitor(InputNamespace rootNamespace)
        {
            _rootNamespace = rootNamespace;
            _createdNames = new HashSet<string>();
        }

        public static InputNamespace Visit(InputNamespace rootNamespace) => new RenameAnonymousTypesVisitor(rootNamespace).VisitNamespace(rootNamespace);

        protected override InputModelType VisitModel(InputModelType modelType, InputModelType? visitedBaseModel)
        {
            if (modelType.IsAnonymousModel)
            {
                modelType = modelType with {Name = GetAnonModelName(modelType)};
            }

            return base.VisitModel(modelType, visitedBaseModel);
        }

        private string GetAnonModelName(InputModelType anonModel)
        {
            var names = new List<List<string>>();

            //check operation parameters first
            foreach (var client in _rootNamespace.Clients)
            {
                foreach (var operation in client.Operations)
                {
                    foreach (var parameter in operation.Parameters)
                    {
                        if (IsSameType(parameter.Type, anonModel))
                        {
                            names.Add(new List<string> { operation.Name.ToCleanName(), GetNameWithCorrectPluralization(parameter.Type, parameter.Name).ToCleanName() });
                        }
                        else
                        {
                            FindMatchesRecursively(parameter.Type, anonModel, _createdNames, new List<string>() { operation.Name.FirstCharToUpperCase(), parameter.Type.Name }, names);
                        }
                    }

                    foreach (var response in operation.Responses)
                    {
                        if (response.BodyType is not InputModelType responseType)
                        {
                            continue;
                        }

                        if (IsSameType(responseType, anonModel))
                        {
                            names.Add(new List<string> { operation.Name.ToCleanName(), GetNameWithCorrectPluralization(responseType, responseType.Name).ToCleanName() });
                        }
                        else
                        {
                            FindMatchesRecursively(responseType, anonModel, _createdNames, new List<string>() { operation.Name.FirstCharToUpperCase(), responseType.Name }, names);
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
                        if (IsSameType(property.Type, anonModel))
                            return $"{model.Name.FirstCharToUpperCase()}{property.Name.FirstCharToUpperCase()}";
                    }
                }
                return $"{_rootNamespace.Name}Model{anonModel.Name}";
            }

            if (names.Count == 1)
            {
                var newName = $"{names[0][0]}{names[0][names[0].Count - 1].FirstCharToUpperCase()}";
                if (_createdNames.Contains(newName))
                {
                    if (names[0].Count >= 2)
                    {
                        newName = $"{names[0][1].FirstCharToUpperCase()}{names[0][names[0].Count - 1].FirstCharToUpperCase()}";
                    }
                    else
                    {
                        newName = $"{names[0][0].FirstCharToUpperCase()}{names[0][names[0].Count - 1].FirstCharToUpperCase()}";
                    }
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

        private void FindMatchesRecursively(InputType type, InputModelType anonModel, HashSet<string> createdNames, List<string> current, List<List<string>> names)
        {
            InputModelType? model = GetInputModelType(type);

            if (model is null)
                return;

            //check other model properties
            foreach (var property in model.Properties)
            {
                if (IsSameType(property.Type, anonModel))
                {
                    names.Add(new List<string>(current) { GetNameWithCorrectPluralization(property.Type, property.Name).ToCleanName() });
                }
                else
                {
                    FindMatchesRecursively(property.Type, anonModel, createdNames, new List<string>(current) { GetTypeName(property.Type) }, names);
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
                _ => type.Equals(anonModel)
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

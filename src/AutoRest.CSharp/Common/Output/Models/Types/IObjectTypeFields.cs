// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal interface IObjectTypeFields<T> : IReadOnlyCollection<FieldDeclaration> // TODO: we could remove this generic parameter once we unified the two kinds of input models: InputModel types and Schema types
    {
        IReadOnlyList<Parameter> PublicConstructorParameters { get; }
        IReadOnlyList<Parameter> SerializationParameters { get; }
        FieldDeclaration GetFieldByParameter(Parameter parameter);
        bool TryGetFieldByParameter(Parameter parameter, [MaybeNullWhen(false)] out FieldDeclaration fieldDeclaration);
        T GetInputByField(FieldDeclaration field);
    }
}

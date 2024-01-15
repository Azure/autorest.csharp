// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input;

public interface IUnionType : IType
{
    IReadOnlyList<IType> UnionItemTypes { get; }

    internal IReadOnlyList<InputEnumTypeValue> GetEnumValues()
    {
        if (!IsAllLiteralStringPlusString())
            throw new InvalidOperationException($"Cannot convert union '{this}' to enum because its not all strings");

        var values = new List<InputEnumTypeValue>();
        foreach (var item in UnionItemTypes)
        {
            if (item is not InputLiteralType literalType)
                continue;
            values.Add(new InputEnumTypeValue(literalType.Value.ToString()!.FirstCharToUpperCase(), literalType.Value, literalType.Value.ToString()));
        }
        return values;
    }

    public bool IsAllLiteralString()
    {
        foreach (var item in UnionItemTypes)
        {
            if (item is not ILiteralType literal)
                return false;

            if (literal.LiteralValueType is not IPrimitiveType primitive)
                return false;

            if (primitive.Kind != InputPrimitiveTypeKind.String)
                return false;
        }

        return true;
    }

    public bool IsAllLiteralStringPlusString()
    {
        foreach (var item in UnionItemTypes)
        {
            IPrimitiveType? primitive = item is ILiteralType literal ? literal.LiteralValueType as IPrimitiveType : item as IPrimitiveType;
            if (primitive is null)
                return false;
            if (primitive.Kind != InputPrimitiveTypeKind.String)
                return false;
        }

        return true;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Output.Models;

internal readonly struct MethodKey
{
    public string Name { get; }
    public IReadOnlyList<CSharpType> Parameters { get; }
    public CSharpType? ReturnType { get; }

    public MethodKey(string name, IReadOnlyList<CSharpType> parameters, CSharpType? returnType)
    {
        Name = name;
        Parameters = parameters;
        ReturnType = returnType;
    }

    public override int GetHashCode()
        => HashCode.Combine(Name, ((System.Collections.IStructuralEquatable)Parameters).GetHashCode(EqualityComparer<CSharpType>.Default), ReturnType);

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj is not MethodKey other)
            return false;

        return Name == other.Name
            && Parameters.SequenceEqual(other.Parameters)
            && object.Equals(ReturnType, other.ReturnType);
    }
}

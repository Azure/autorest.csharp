﻿using System;
using System.Reflection;
using Azure.ResourceManager.Resources.Models;
using MgmtSafeFlatten;
using MgmtSafeFlatten.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    internal class MgmtSafeFlattenTests : TestProjectTests
    {
        public MgmtSafeFlattenTests() : base("MgmtSafeFlatten")
        {
        }

        private protected override Assembly GetAssembly() => typeof(TypeOneData).Assembly;

        [TestCase(typeof(TypeOneData), typeof(WritableSubResource), "LayerOneConflictId", "Id")]
        public void ValidatePropertyForwarder(Type newType, Type originalType, string newName, string originalName)
        {
            var newProperty = newType.GetProperty(newName);
            Assert.IsNotNull(newProperty, $"New property {newName} was not found on {newType.Name}");
            var originalProperty = originalType.GetProperty(originalName);
            Assert.IsNotNull(originalProperty, $"Original property {originalName} was not found on {originalType.Name}");
            Assert.AreEqual(originalProperty.CanRead, newProperty.CanRead, $"Expected {originalName} to have consistent getter, {newName} ({newProperty.CanRead}) and {originalName} ({originalProperty.CanRead})");
            Assert.AreEqual(originalProperty.CanWrite, newProperty.CanWrite, $"Expected {originalName} to have consistent setter, {newName} ({newProperty.CanWrite}) and {originalName} ({originalProperty.CanWrite})");
            Assert.AreEqual(originalProperty.PropertyType, newProperty.PropertyType, $"Expected {originalName} to have consistent type, {newName} ({newProperty.PropertyType.Name}) and {originalName} ({originalProperty.PropertyType.Name})");
        }

        [TestCase(typeof(TypeOneData), typeof(LayerOneBaseType), "LayerOneType")]
        public void ValidatePropertyUnfaltten(Type type, Type targetType, string propertyName)
        {
            var targetProperty = type.GetProperty(propertyName);
            Assert.IsNotNull(targetProperty, $"Property {propertyName} was not found on {type.Name}");
            Assert.AreEqual(targetType, targetProperty.PropertyType, $"Expected {propertyName} to be of type {targetProperty.Name})");
        }

        [TestCase("TypeFour", "LayerOneProperties", "LayerOneUniqueId", "UniqueId")]
        public void ValidatePropertyForwarder(string newTypeName, string originalTypeName, string newName, string originalName)
            => ValidatePropertyForwarder(GetType(newTypeName), GetType(originalTypeName), newName, originalName);

        [TestCase(typeof(TypeOneData), "LayerTwoSingle", "LayerTwoMyProp", "MyProp")]
        public void ValidatePropertyForwarder(Type newType, string originalTypeName, string newName, string originalName)
            => ValidatePropertyForwarder(newType, GetType(originalTypeName), newName, originalName);
    }
}

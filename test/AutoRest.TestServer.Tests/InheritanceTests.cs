// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Inheritance.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class InheritanceTests
    {
        [Test]
        public void SingularInheritanceUsesBaseClass()
        {
            Assert.AreEqual(typeof(BaseClass), typeof(ClassThatInheritsFromBaseClass).BaseType);
        }

        [Test]
        public void SingularInheritanceUsesBaseClassForClassesWithDiscriminator()
        {
            Assert.AreEqual(typeof(BaseClass), typeof(BaseClassWithDiscriminator).BaseType);
        }

        [Test]
        public void MultipleInheritanceResolvedToFirstClassWhenNoDiscriminatorOthersInlined()
        {
            var type = typeof(ClassThatInheritsFromBaseClassAndSomeProperties);
            Assert.AreEqual(typeof(BaseClass), type.BaseType);
            // public
            Assert.AreEqual(3, type.GetProperties().Length);

            var inheritedProperty = TypeAsserts.HasProperty(type, "BaseClassProperty", BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(typeof(BaseClass), inheritedProperty.DeclaringType);

            var inlinedProperty = TypeAsserts.HasProperty(type, "SomeProperty", BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(type, inlinedProperty.DeclaringType);

            inlinedProperty = TypeAsserts.HasProperty(type, "SomeOtherProperty", BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(type, inlinedProperty.DeclaringType);
        }

        [Test]
        public void MultipleInheritanceBaseTypeOverride()
        {
            var type = typeof(ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride);
            Assert.AreEqual(typeof(SomeProperties), type.BaseType);
            // public
            Assert.AreEqual(3, type.GetProperties().Length);

            var inlinedProperty = TypeAsserts.HasProperty(type, "BaseClassProperty", BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(type, inlinedProperty.DeclaringType);

            var inheritedProperty = TypeAsserts.HasProperty(type, "SomeProperty", BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(typeof(SomeProperties), inheritedProperty.DeclaringType);

            inheritedProperty = TypeAsserts.HasProperty(type, "SomeOtherProperty", BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(typeof(SomeProperties), inheritedProperty.DeclaringType);
        }

        [Test]
        public void MultipleInheritanceResolvedToBaseWithDiscriminatorOthersInlined()
        {
            var type = typeof(ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties);
            Assert.AreEqual(typeof(BaseClassWithDiscriminator), type.BaseType);
            // public
            Assert.AreEqual(3, type.GetProperties().Length);
            TypeAsserts.HasProperty(type, "DiscriminatorProperty", BindingFlags.Instance | BindingFlags.NonPublic);
            TypeAsserts.HasProperty(type, "BaseClassProperty", BindingFlags.Instance | BindingFlags.Public);
            TypeAsserts.HasProperty(type, "SomeProperty", BindingFlags.Instance | BindingFlags.Public);
            TypeAsserts.HasProperty(type, "SomeOtherProperty", BindingFlags.Instance | BindingFlags.Public);
        }

        [Test]
        public void DiscriminatorValueIsSetOnObjectConstruction()
        {
            var baseClassWithDiscriminator = new BaseClassWithDiscriminator();
            Assert.AreEqual("BaseClassWithDiscriminator", baseClassWithDiscriminator.DiscriminatorProperty);
        }

        [Test]
        public void DiscriminatorValueIsSetOnObjectSerializationConstruction()
        {
            var baseClassWithDiscriminator = new BaseClassWithDiscriminator(null, null);
            Assert.AreEqual("BaseClassWithDiscriminator", baseClassWithDiscriminator.DiscriminatorProperty);
        }

        [Test]
        public void DiscriminatorValueIsSetOnSubClassConstruction()
        {
            var baseClassWithDiscriminator = new ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties();
            Assert.AreEqual("ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties", baseClassWithDiscriminator.DiscriminatorProperty);
        }

        [Test]
        public void DiscriminatorValueIsSetOnSubClassSerializationConstruction()
        {
            var baseClassWithDiscriminator = new ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties(null, null, null, null);
            Assert.AreEqual("ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties", baseClassWithDiscriminator.DiscriminatorProperty);
        }

        [Test]
        public void RedefinedPropertyIgnored()
        {
            Assert.AreEqual(1, typeof(ClassThatInheritsFromBaseClassAndRedefinesAProperty).GetProperties().Length);
        }

        [Test]
        public void RedefinedPropertyFromComposedBaseClassIgnored()
        {
            // We expect BaseClassProperty on ClassThatInheritsFromSomePropertiesAndBaseClassAndRedefinesAProperty to be ignored
            Assert.AreEqual(3, typeof(ClassThatInheritsFromSomePropertiesAndBaseClassAndRedefinesAProperty).GetProperties().Length);
        }

        [Test]
        public void CanCreateInstanceOfDerivedClassWithEnumDiscriminator()
        {
            var derived = new DerivedClassWithEnumDiscriminator();
            Assert.AreEqual(BaseClassWithEnumDiscriminatorEnum.Derived, derived.DiscriminatorProperty);
        }

        [Test]
        public void CanCreateInstanceOfDerivedClassWithExtensibleEnumDiscriminator()
        {
            var derived = new DerivedClassWithExtensibleEnumDiscriminator();
            Assert.AreEqual(BaseClassWithEntensibleEnumDiscriminatorEnum.Derived, derived.DiscriminatorProperty);
        }
    }
}
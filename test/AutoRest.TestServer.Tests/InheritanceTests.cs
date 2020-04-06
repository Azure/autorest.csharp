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
            TypeAsserts.HasProperty(type, "BaseClassProperty", BindingFlags.Instance | BindingFlags.Public);
            TypeAsserts.HasProperty(type, "SomeProperty", BindingFlags.Instance | BindingFlags.Public);
            TypeAsserts.HasProperty(type, "SomeOtherProperty", BindingFlags.Instance | BindingFlags.Public);
        }

        [Test]
        public void MultipleInheritanceResolvedToBaseWithDiscriminatorOthersInlined()
        {
            var type = typeof(ClassThatInheritsFromBaseClassAndBaseClassWithDiscriminatorAndSomeProperties);
            Assert.AreEqual(typeof(BaseClassWithDiscriminator), type.BaseType);
            // public
            Assert.AreEqual(3, type.GetProperties().Length);
            TypeAsserts.HasProperty(type, "DiscriminatorProperty", BindingFlags.Instance | BindingFlags.NonPublic);
            TypeAsserts.HasProperty(type, "BaseClassProperty", BindingFlags.Instance | BindingFlags.Public);
            TypeAsserts.HasProperty(type, "SomeProperty", BindingFlags.Instance | BindingFlags.Public);
            TypeAsserts.HasProperty(type, "SomeOtherProperty", BindingFlags.Instance | BindingFlags.Public);
        }

        [Test]
        public void BaseTypesAreReducedToHighestDependency()
        {
            var type = typeof(ClassThatInheritsFromBaseClassAndBaseClassWithDiscriminator);
            Assert.AreEqual(typeof(BaseClassWithDiscriminator), type.BaseType);

            // public
            Assert.AreEqual(1, type.GetProperties().Length);
            TypeAsserts.HasProperty(type, "BaseClassProperty", BindingFlags.Instance | BindingFlags.Public);
            TypeAsserts.HasProperty(type, "DiscriminatorProperty", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        [Test]
        public void DiscriminatorValueIsSetOnObjectConstruction()
        {
            var baseClassWithDiscriminator = new BaseClassWithDiscriminator();
            Assert.AreEqual("BaseClassWithDiscriminator", baseClassWithDiscriminator.DiscriminatorProperty);
        }

        [Test]
        public void DiscriminatorValueIsSetOnSubClassConstruction()
        {
            var baseClassWithDiscriminator = new ClassThatInheritsFromBaseClassAndBaseClassWithDiscriminatorAndSomeProperties();
            Assert.AreEqual("ClassThatInheritsFromBaseClassAndBaseClassWithDiscriminatorAndSomeProperties", baseClassWithDiscriminator.DiscriminatorProperty);
        }
    }
}
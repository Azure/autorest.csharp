using System;
using System.Linq;
using System.Reflection;
using constants;
using constants.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ConstantsModelTest
    {
        private static Type GetType(string name)
            => typeof(ContantsClient).Assembly.GetTypes().FirstOrDefault(t => t.Name == name);

        [Test]
        public void NoModelAsStringNoRequiredTwoValueDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("NoModelAsStringNoRequiredTwoValueDefault")));
        }

        [Test]
        public void NoModelAsStringNoRequiredTwoValueDefault_HasOneDefaultCtor()
        {
            AssertHasDefaultCtor(GetType("NoModelAsStringNoRequiredTwoValueDefault"));
        }

        [Test]
        public void NoModelAsStringNoRequiredTwoValueDefault_PropertiesAreOptionalGetOnly()
        {
            var modelType = GetType("NoModelAsStringNoRequiredTwoValueDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(typeof(Nullable<>).MakeGenericType(GetType("NoModelAsStringNoRequiredTwoValueDefaultEnum")), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void NoModelAsStringNoRequiredTwoValueDefaultEnum_IsEnumWithTwoValues()
        {
            var modelType = GetType("NoModelAsStringNoRequiredTwoValueDefaultEnum");
            Assert.True(modelType.IsValueType);
            Assert.True(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetEnumValues().Length);
            TypeAsserts.HasField(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasField(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void NoModelAsStringNoRequiredTwoValueNoDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("NoModelAsStringNoRequiredTwoValueNoDefault")));
        }

        [Test]
        public void NoModelAsStringNoRequiredTwoValueNoDefault_HasOneDefaultCtor()
        {
            AssertHasDefaultCtor(GetType("NoModelAsStringNoRequiredTwoValueNoDefault"));
        }

        [Test]
        public void NoModelAsStringNoRequiredTwoValueNoDefault_PropertiesAreOptionalGetOnly()
        {
            var modelType = GetType("NoModelAsStringNoRequiredTwoValueNoDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(typeof(Nullable<>).MakeGenericType(GetType("NoModelAsStringNoRequiredTwoValueNoDefaultEnum")), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void NoModelAsStringNoRequiredTwoValueNoDefaultEnum_IsEnumWithTwoValues()
        {
            var modelType = GetType("NoModelAsStringNoRequiredTwoValueNoDefaultEnum");
            Assert.True(modelType.IsValueType);
            Assert.True(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetEnumValues().Length);
            TypeAsserts.HasField(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasField(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void NoModelAsStringNoRequiredOneValueNoDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("NoModelAsStringNoRequiredOneValueNoDefault")));
        }

        [Test]
        public void NoModelAsStringNoRequiredOneValueNoDefault_HasOneDefaultCtor()
        {
            AssertHasDefaultCtor(GetType("NoModelAsStringNoRequiredOneValueNoDefault"));
        }

        [Test]
        public void NoModelAsStringNoRequiredOneValueNoDefault_PropertiesAreGetOnly()
        {
            var modelType = GetType("NoModelAsStringNoRequiredOneValueNoDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(typeof(Nullable<>).MakeGenericType(GetType("NoModelAsStringNoRequiredOneValueNoDefaultEnum")), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void NoModelAsStringNoRequiredOneValueDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("NoModelAsStringNoRequiredOneValueDefault")));
        }

        [Test]
        public void NoModelAsStringNoRequiredOneValueDefault_HasOneDefaultCtor()
        {
            AssertHasDefaultCtor(GetType("NoModelAsStringNoRequiredOneValueDefault"));
        }

        [Test]
        public void NoModelAsStringNoRequiredOneValueDefault_PropertiesAreGetOnly()
        {
            var modelType = GetType("NoModelAsStringNoRequiredOneValueNoDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(typeof(Nullable<>).MakeGenericType(GetType("NoModelAsStringNoRequiredOneValueNoDefaultEnum")), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void NoModelAsStringRequiredTwoValueNoDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("NoModelAsStringRequiredTwoValueNoDefault")));
        }

        [Test]
        public void NoModelAsStringRequiredTwoValueNoDefault_HasOneCtorWithRequiredParam()
        {
            var constructors = GetType("NoModelAsStringRequiredTwoValueNoDefault").GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(3, constructors.Length);
            var ctor = constructors.SingleOrDefault(ctor => ctor.GetParameters().Length == 1);
            Assert.IsNotNull(ctor);
            Assert.AreEqual(GetType("NoModelAsStringRequiredTwoValueNoDefaultEnum"), ctor.GetParameters()[0].ParameterType);
        }

        [Test]
        public void NoModelAsStringRequiredTwoValueNoDefault_PropertiesAreGetOnly()
        {
            var modelType = GetType("NoModelAsStringRequiredTwoValueNoDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(GetType("NoModelAsStringRequiredTwoValueNoDefaultEnum"), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void NoModelAsStringRequiredTwoValueNoDefaultEnum_IsEnumWithTwoValues()
        {
            var modelType = GetType("NoModelAsStringRequiredTwoValueNoDefaultEnum");
            Assert.True(modelType.IsValueType);
            Assert.True(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetEnumValues().Length);
            TypeAsserts.HasField(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasField(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void NoModelAsStringRequiredTwoValueDefault()
        {
            Assert.True(IsInternal(GetType("NoModelAsStringRequiredTwoValueDefault")));
        }

        [Test]
        public void NoModelAsStringRequiredTwoValueDefault_HasOneCtorWithRequiredParam()
        {
            var constructors = GetType("NoModelAsStringRequiredTwoValueDefault").GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(3, constructors.Length);
            var ctor = constructors.SingleOrDefault(ctor => ctor.GetParameters().Length == 1);
            Assert.IsNotNull(ctor);
            Assert.AreEqual(GetType("NoModelAsStringRequiredTwoValueDefaultEnum"), ctor.GetParameters()[0].ParameterType);
        }

        [Test]
        public void NoModelAsStringRequiredTwoValueDefault_HasCtorWithDefaultValue()
        {
            var value1 = GetType("NoModelAsStringRequiredTwoValueDefaultEnum").GetField("Value1", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
            var model = Activator.CreateInstance(GetType("NoModelAsStringRequiredTwoValueDefault"), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, [value1, null], null);
            Assert.AreEqual(value1, model.GetType().GetProperty("Parameter", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(model));
        }

        [Test]
        public void NoModelAsStringRequiredTwoValueDefault_PropertiesAreGetOnly()
        {
            var modelType = GetType("NoModelAsStringRequiredTwoValueDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(GetType("NoModelAsStringRequiredTwoValueDefaultEnum"), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void NoModelAsStringRequiredTwoValueDefaultEnum_IsEnumWithTwoValues()
        {
            var modelType = GetType("NoModelAsStringRequiredTwoValueDefaultEnum");
            Assert.True(modelType.IsValueType);
            Assert.True(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetEnumValues().Length);
            TypeAsserts.HasField(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasField(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void NoModelAsStringRequiredOneValueNoDefault()
        {
            Assert.True(IsInternal(GetType("NoModelAsStringRequiredOneValueNoDefault")));
        }

        [Test]
        public void NoModelAsStringRequiredOneValueNoDefault_HasOneDefaultCtor()
        {
            AssertHasDefaultCtor(GetType("NoModelAsStringRequiredOneValueNoDefault"));
        }

        [Test]
        public void NoModelAsStringRequiredOneValueNoDefault_PropertiesAreGetOnly()
        {
            var modelType = GetType("NoModelAsStringRequiredOneValueNoDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(GetType("NoModelAsStringRequiredOneValueNoDefaultEnum"), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void NoModelAsStringRequiredOneValueNoDefault_GetPropertyValue()
        {
            var value1 = GetType("NoModelAsStringRequiredOneValueNoDefaultEnum").GetProperty("Value1", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
            var model = Activator.CreateInstance(GetType("NoModelAsStringRequiredOneValueNoDefault"), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, [value1, null], null);
            Assert.AreEqual(value1, model.GetType().GetProperty("Parameter", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(model));
        }

        [Test]
        public void NoModelAsStringRequiredOneValueDefault()
        {
            Assert.True(IsInternal(GetType("NoModelAsStringRequiredOneValueDefault")));
        }

        [Test]
        public void NoModelAsStringRequiredOneValueDefault_HasOneDefaultCtor()
        {
            AssertHasDefaultCtor(GetType("NoModelAsStringRequiredOneValueDefault"));
        }

        [Test]
        public void NoModelAsStringRequiredOneValueDefault_PropertiesAreGetOnly()
        {
            var modelType = GetType("NoModelAsStringRequiredOneValueDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(GetType("NoModelAsStringRequiredOneValueDefaultEnum"), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void NoModelAsStringRequiredOneValueDefault_GetPropertyValue()
        {
            var value1 = GetType("NoModelAsStringRequiredOneValueDefaultEnum").GetProperty("Value1", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
            var model = Activator.CreateInstance(GetType("NoModelAsStringRequiredOneValueDefault"), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, [value1, null], null);
            Assert.AreEqual(value1, model.GetType().GetProperty("Parameter", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(model));
        }

        [Test]
        public void ModelAsStringNoRequiredTwoValueNoDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("ModelAsStringNoRequiredTwoValueNoDefault")));
        }

        [Test]
        public void ModelAsStringNoRequiredTwoValueNoDefault_HasOneDefaultCtor()
        {
            AssertHasDefaultCtor(GetType("ModelAsStringNoRequiredTwoValueNoDefault"));
        }

        [Test]
        public void ModelAsStringNoRequiredTwoValueNoDefault_PropertiesAreOptionalGetOnly()
        {
            var modelType = GetType("ModelAsStringNoRequiredTwoValueNoDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(typeof(Nullable<>).MakeGenericType(GetType("ModelAsStringNoRequiredTwoValueNoDefaultEnum")), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void ModelAsStringNoRequiredTwoValueNoDefaultEnum_IsStructWithTwoValues()
        {
            var modelType = GetType("ModelAsStringNoRequiredTwoValueNoDefaultEnum");
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasProperty(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void ModelAsStringNoRequiredTwoValueDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("ModelAsStringNoRequiredTwoValueDefault")));
        }

        [Test]
        public void ModelAsStringNoRequiredTwoValueDefault_HasOneDefaultCtor()
        {
            AssertHasDefaultCtor(GetType("ModelAsStringNoRequiredTwoValueDefault"));
        }

        [Test]
        public void ModelAsStringNoRequiredTwoValueDefault_PropertiesAreOptionalGetOnly()
        {
            var modelType = GetType("ModelAsStringNoRequiredTwoValueDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(typeof(Nullable<>).MakeGenericType(GetType("ModelAsStringNoRequiredTwoValueDefaultEnum")), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void ModelAsStringNoRequiredTwoValueDefaultEnum_IsStructWithTwoValues()
        {
            var modelType = GetType("ModelAsStringNoRequiredTwoValueDefaultEnum");
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasProperty(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void ModelAsStringNoRequiredOneValueDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("ModelAsStringNoRequiredOneValueDefault")));
        }

        [Test]
        public void ModelAsStringNoRequiredOneValueDefault_HasOneDefaultCtor()
        {
            AssertHasDefaultCtor(GetType("ModelAsStringNoRequiredOneValueDefault"));
        }

        private static void AssertHasDefaultCtor(Type type)
        {
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            // when the model has default ctor, it should always have another ctor that takes an extra raw data parameter
            Assert.AreEqual(2, constructors.Length);
            Assert.IsTrue(constructors.Any(ctor => ctor.GetParameters().Length == 0));
        }

        [Test]
        public void ModelAsStringNoRequiredOneValueDefault_PropertiesAreOptionalGetOnly()
        {
            var modelType = GetType("ModelAsStringNoRequiredOneValueDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(typeof(Nullable<>).MakeGenericType(GetType("ModelAsStringNoRequiredOneValueDefaultEnum")), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void ModelAsStringNoRequiredOneValueDefaultEnum_IsStructWithOneValue()
        {
            var modelType = GetType("ModelAsStringNoRequiredOneValueDefaultEnum");
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(1, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void ModelAsStringRequiredTwoValueNoDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("ModelAsStringRequiredTwoValueNoDefault")));
        }

        [Test]
        public void ModelAsStringRequiredTwoValueNoDefault_HasOneCtorWithRequiredParam()
        {
            var constructors = GetType("ModelAsStringRequiredTwoValueNoDefault").GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(3, constructors.Length);
            var ctor = constructors.SingleOrDefault(ctor => ctor.GetParameters().Length == 1);
            Assert.IsNotNull(ctor);
            Assert.AreEqual(GetType("ModelAsStringRequiredTwoValueNoDefaultEnum"), ctor.GetParameters()[0].ParameterType);
        }

        [Test]
        public void ModelAsStringRequiredTwoValueNoDefault_PropertiesAreGetOnly()
        {
            var modelType = GetType("ModelAsStringRequiredTwoValueNoDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(GetType("ModelAsStringRequiredTwoValueNoDefaultEnum"), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void ModelAsStringRequiredTwoValueNoDefaultEnum_IsStructWithTwoValues()
        {
            var modelType = GetType("ModelAsStringRequiredTwoValueNoDefaultEnum");
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasProperty(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void ModelAsStringRequiredTwoValueDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("ModelAsStringRequiredTwoValueDefault")));
        }

        [Test]
        public void ModelAsStringRequiredTwoValueDefault_HasOneCtorWithOptionalParam()
        {
            var constructors = GetType("ModelAsStringRequiredTwoValueDefault").GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(3, constructors.Length);
            var ctor = constructors.SingleOrDefault(ctor => ctor.GetParameters().Length == 1);
            Assert.IsNotNull(ctor);
            /* eliminate the default value for the parameter property, so the type is not Nullable. */
            Assert.AreEqual(GetType("ModelAsStringRequiredTwoValueDefaultEnum"), ctor.GetParameters()[0].ParameterType);
        }

        [Test]
        public void ModelAsStringRequiredTwoValueDefault_HasCtorWithDefaultValue()
        {
            var value1 = GetType("ModelAsStringRequiredTwoValueDefaultEnum").GetProperty("Value1", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
            var model = Activator.CreateInstance(GetType("ModelAsStringRequiredTwoValueDefault"), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, [value1], null);
            Assert.AreEqual(value1, model.GetType().GetProperty("Parameter", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(model));
        }

        [Test]
        public void ModelAsStringRequiredTwoValueDefault_PropertiesAreGetOnly()
        {
            var modelType = GetType("ModelAsStringRequiredTwoValueDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(GetType("ModelAsStringRequiredTwoValueDefaultEnum"), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void ModelAsStringRequiredTwoValueDefaultEnum_IsStructWithTwoValues()
        {
            var modelType = GetType("ModelAsStringRequiredTwoValueDefaultEnum");
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasProperty(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void ModelAsStringRequiredOneValueNoDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("ModelAsStringRequiredOneValueNoDefault")));
        }

        [Test]
        public void ModelAsStringRequiredOneValueNoDefault_HasOneCtorWithRequiredParam()
        {
            var constructors = GetType("ModelAsStringRequiredOneValueNoDefault").GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(3, constructors.Length);
            var ctor = constructors.SingleOrDefault(ctor => ctor.GetParameters().Length == 1);
            Assert.IsNotNull(ctor);
            Assert.AreEqual(GetType("ModelAsStringRequiredOneValueNoDefaultEnum"), ctor.GetParameters()[0].ParameterType);
        }

        [Test]
        public void ModelAsStringRequiredOneValueNoDefault_PropertiesAreOptionalGetOnly()
        {
            var modelType = GetType("ModelAsStringRequiredOneValueNoDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(GetType("ModelAsStringRequiredOneValueNoDefaultEnum"), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void ModelAsStringRequiredOneValueNoDefaultEnum_IsStructWithOneValue()
        {
            var modelType = GetType("ModelAsStringRequiredOneValueNoDefaultEnum");
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(1, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void ModelAsStringRequiredOneValueDefault_IsInternal()
        {
            Assert.True(IsInternal(GetType("ModelAsStringRequiredOneValueDefault")));
        }

        [Test]
        public void ModelAsStringRequiredOneValueDefault_HasOneCtorWithOptionalParam()
        {
            var constructors = GetType("ModelAsStringRequiredOneValueDefault").GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual(3, constructors.Length); // one with required parameter, one with required parameter and extra raw data, and a default ctor
            var ctor = constructors.SingleOrDefault(ctor => ctor.GetParameters().Length == 1);
            Assert.IsNotNull(ctor);
            /* eliminate the default value for the parameter property, so the type is not Nullable. */
            Assert.AreEqual(GetType("ModelAsStringRequiredOneValueDefaultEnum"), ctor.GetParameters()[0].ParameterType);
        }

        [Test]
        public void ModelAsStringRequiredOneValueDefault_HasCtorWithDefaultValue()
        {
            var value1 = GetType("ModelAsStringRequiredOneValueDefaultEnum").GetProperty("Value1", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public).GetValue(null);
            var model = Activator.CreateInstance(GetType("ModelAsStringRequiredOneValueDefault"), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, [value1], null);
            Assert.AreEqual(value1, model.GetType().GetProperty("Parameter", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(model));
        }

        [Test]
        public void ModelAsStringRequiredOneValueDefault_PropertiesAreGetOnly()
        {
            var modelType = GetType("ModelAsStringRequiredOneValueDefault");
            Assert.AreEqual(1, modelType.GetProperties().Length);

            var prop = TypeAsserts.HasProperty(modelType, "Parameter", BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(GetType("ModelAsStringRequiredOneValueDefaultEnum"), prop.PropertyType);
            Assert.Null(prop.SetMethod);
            Assert.NotNull(prop.GetMethod);
        }

        [Test]
        public void ModelAsStringRequiredOneValueDefaultEnum_IsStructWithOneValue()
        {
            var modelType = GetType("ModelAsStringRequiredOneValueDefaultEnum");
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(1, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
        }

        private static bool IsInternal(Type t) => !t.IsVisible
           && !t.IsPublic
           && t.IsNotPublic
           && !t.IsNested
           && !t.IsNestedPublic
           && !t.IsNestedFamily
           && !t.IsNestedPrivate
           && !t.IsNestedAssembly
           && !t.IsNestedFamORAssem
           && !t.IsNestedFamANDAssem;
    }
}

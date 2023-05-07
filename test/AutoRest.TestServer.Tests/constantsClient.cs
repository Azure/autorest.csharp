﻿using System;
using System.Reflection;
using AutoRest.TestServer.Tests.Infrastructure;
using constants;
using constants.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ConstantsClientTest
    {
        [Test]
        public void PutNoModelAsStringNoRequiredTwoValueNoDefault_HasOptionalDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutNoModelAsStringNoRequiredTwoValueNoDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum?), paramInfo.ParameterType);
            Assert.True(paramInfo.HasDefaultValue);
            Assert.AreEqual(null, paramInfo.DefaultValue);
        }

        [Test]
        public void NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum_IsEnumWithTwoValues()
        {
            var modelType = typeof(NoModelAsStringNoRequiredTwoValueNoDefaultEnum);
            Assert.True(modelType.IsValueType);
            Assert.True(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetEnumValues().Length);
            TypeAsserts.HasField(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasField(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void PutNoModelAsStringNoRequiredTwoValueDefault_HasOptionalDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutNoModelAsStringNoRequiredTwoValueDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(NoModelAsStringNoRequiredTwoValueDefaultOpEnum?), paramInfo.ParameterType);
            Assert.True(paramInfo.HasDefaultValue);
            Assert.AreEqual((int)NoModelAsStringNoRequiredTwoValueDefaultOpEnum.Value1, paramInfo.DefaultValue);
        }

        [Test]
        public void NoModelAsStringNoRequiredTwoValueDefaultOpEnum_IsEnumWithTwoValues()
        {
            var modelType = typeof(NoModelAsStringNoRequiredTwoValueDefaultOpEnum);
            Assert.True(modelType.IsValueType);
            Assert.True(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetEnumValues().Length);
            TypeAsserts.HasField(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasField(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void PutNoModelAsStringNoRequiredOneValueNoDefault_HasNoRequiredDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutNoModelAsStringNoRequiredOneValueNoDefaultAsync");
            // TODO -- change to 2 when the optional constant change is consolidated on HLC
            Assert.AreEqual(1, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            // TODO -- uncomment the following when the optional constant change is consolidated on HLC
            //var paramInfo = TypeAsserts.HasParameter(method, "input");
            //Assert.AreEqual(typeof(NoModelAsStringNoRequiredOneValueNoDefaultOpEnum?), paramInfo.ParameterType);
            //Assert.True(paramInfo.HasDefaultValue);
        }

        [Test]
        public void PutNoModelAsStringNoRequiredOneValueDefault_HasNoRequiredDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutNoModelAsStringNoRequiredOneValueDefaultAsync");
            // TODO -- change to 2 when the optional constant change is consolidated on HLC
            Assert.AreEqual(1, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            // TODO -- uncomment the following when the optional constant change is consolidated on HLC
            //var paramInfo = TypeAsserts.HasParameter(method, "input");
            //Assert.AreEqual(typeof(NoModelAsStringNoRequiredOneValueDefaultOpEnum?), paramInfo.ParameterType);
            //Assert.True(paramInfo.HasDefaultValue);
        }

        [Test]
        public void PutNoModelAsStringRequiredTwoValueNoDefault_HasOneRequiredParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutNoModelAsStringRequiredTwoValueNoDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(NoModelAsStringRequiredTwoValueNoDefaultOpEnum), paramInfo.ParameterType);
            Assert.False(paramInfo.HasDefaultValue);
        }

        [Test]
        public void NoModelAsStringRequiredTwoValueNoDefaultOpEnum_IsEnumWithTwoValues()
        {
            var modelType = typeof(NoModelAsStringRequiredTwoValueNoDefaultOpEnum);
            Assert.True(modelType.IsValueType);
            Assert.True(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetEnumValues().Length);
            TypeAsserts.HasField(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasField(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void PutNoModelAsStringRequiredTwoValueDefault_HasRequiredDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutNoModelAsStringRequiredTwoValueDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(NoModelAsStringRequiredTwoValueDefaultOpEnum), paramInfo.ParameterType);
            Assert.True(paramInfo.HasDefaultValue);
            Assert.AreEqual(NoModelAsStringRequiredTwoValueDefaultOpEnum.Value1, paramInfo.DefaultValue);
        }

        [Test]
        public void NoModelAsStringRequiredTwoValueDefaultOpEnum_IsEnumWithTwoValues()
        {
            var modelType = typeof(NoModelAsStringRequiredTwoValueDefaultOpEnum);
            Assert.True(modelType.IsValueType);
            Assert.True(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetEnumValues().Length);
            TypeAsserts.HasField(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasField(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void PutNoModelAsStringRequiredOneValueNoDefault_HasNoRequiredDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutNoModelAsStringRequiredOneValueNoDefaultAsync");
            Assert.AreEqual(1, method.GetParameters().Length);
            TypeAsserts.HasParameter(method, "cancellationToken");
        }

        [Test]
        public void PutNoModelAsStringRequiredOneValueDefault_HasNoRequiredDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutNoModelAsStringRequiredOneValueDefaultAsync");
            Assert.AreEqual(1, method.GetParameters().Length);
            TypeAsserts.HasParameter(method, "cancellationToken");
        }

        [Test]
        public void PutModelAsStringNoRequiredTwoValueNoDefault_HasOptionalDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutModelAsStringNoRequiredTwoValueNoDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(ModelAsStringNoRequiredTwoValueNoDefaultOpEnum?), paramInfo.ParameterType);
            Assert.True(paramInfo.HasDefaultValue);
            Assert.AreEqual(null, paramInfo.DefaultValue);
        }

        [Test]
        public void ModelAsStringNoRequiredTwoValueNoDefaultOpEnum_IsStructWithTwoValues()
        {
            var modelType = typeof(ModelAsStringNoRequiredTwoValueNoDefaultOpEnum);
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasProperty(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void PutModelAsStringNoRequiredTwoValueDefault_HasOptionalDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutModelAsStringNoRequiredTwoValueDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(ModelAsStringNoRequiredTwoValueDefaultOpEnum?), paramInfo.ParameterType);
            Assert.True(paramInfo.HasDefaultValue);
            Assert.AreEqual(null, paramInfo.DefaultValue);
        }

        [Test]
        public void ModelAsStringNoRequiredTwoValueDefaultOpEnum_IsStructWithTwoValues()
        {
            var modelType = typeof(ModelAsStringNoRequiredTwoValueDefaultOpEnum);
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasProperty(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void PutModelAsStringNoRequiredOneValueNoDefault_HasOptionalDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutModelAsStringNoRequiredOneValueNoDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(ModelAsStringNoRequiredOneValueNoDefaultOpEnum?), paramInfo.ParameterType);
            Assert.True(paramInfo.HasDefaultValue);
            Assert.AreEqual(null, paramInfo.DefaultValue);
        }

        [Test]
        public void ModelAsStringNoRequiredOneValueNoDefaultOpEnum_IsStructWithOneValue()
        {
            var modelType = typeof(ModelAsStringNoRequiredOneValueNoDefaultOpEnum);
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(1, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void PutModelAsStringNoRequiredOneValueDefault_HasOptionalDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutModelAsStringNoRequiredOneValueDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(ModelAsStringNoRequiredOneValueDefaultOpEnum?), paramInfo.ParameterType);
            Assert.True(paramInfo.HasDefaultValue);
            Assert.AreEqual(null, paramInfo.DefaultValue);
        }

        [Test]
        public void ModelAsStringNoRequiredOneValueDefaultOpEnum_IsStructWithOneValue()
        {
            var modelType = typeof(ModelAsStringNoRequiredOneValueDefaultOpEnum);
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(1, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void PutModelAsStringRequiredTwoValueNoDefault_HasRequiredNoDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutModelAsStringRequiredTwoValueNoDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(ModelAsStringRequiredTwoValueNoDefaultOpEnum), paramInfo.ParameterType);
            Assert.False(paramInfo.HasDefaultValue);
        }

        [Test]
        public void ModelAsStringRequiredTwoValueNoDefaultOpEnum_IsStructWithTwoValues()
        {
            var modelType = typeof(ModelAsStringRequiredTwoValueNoDefaultOpEnum);
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasProperty(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void PutModelAsStringRequiredTwoValueDefault_HasOptionalDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutModelAsStringRequiredTwoValueDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(ModelAsStringRequiredTwoValueDefaultOpEnum?), paramInfo.ParameterType);
            Assert.True(paramInfo.HasDefaultValue);
            Assert.AreEqual(null, paramInfo.DefaultValue);
        }

        [Test]
        public void ModelAsStringRequiredTwoValueDefaultOpEnum_IsStructWithTwoValues()
        {
            var modelType = typeof(ModelAsStringRequiredTwoValueNoDefaultOpEnum);
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(2, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
            TypeAsserts.HasProperty(modelType, "Value2", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void PutModelAsStringRequiredOneValueNoDefault_HasRequiredNoDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutModelAsStringRequiredOneValueNoDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(ModelAsStringRequiredOneValueNoDefaultOpEnum), paramInfo.ParameterType);
            Assert.False(paramInfo.HasDefaultValue);
        }

        [Test]
        public void ModelAsStringRequiredOneValueNoDefaultOpEnum_IsStructWithOneValue()
        {
            var modelType = typeof(ModelAsStringRequiredOneValueNoDefaultOpEnum);
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(1, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
        }

        [Test]
        public void PutModelAsStringRequiredOneValueDefault_HasOptionalDefaultParam()
        {
            var method = TypeAsserts.HasPublicInstanceMethod(typeof(ContantsClient), "PutModelAsStringRequiredOneValueDefaultAsync");
            Assert.AreEqual(2, method.GetParameters().Length);

            TypeAsserts.HasParameter(method, "cancellationToken");
            var paramInfo = TypeAsserts.HasParameter(method, "input");
            Assert.AreEqual(typeof(ModelAsStringRequiredOneValueDefaultOpEnum?), paramInfo.ParameterType);
            Assert.True(paramInfo.HasDefaultValue);
            Assert.AreEqual(null, paramInfo.DefaultValue);
        }

        [Test]
        public void ModelAsStringRequiredOneValueDefaultOpEnum_IsStructWithOneValue()
        {
            var modelType = typeof(ModelAsStringRequiredOneValueDefaultOpEnum);
            Assert.True(modelType.IsValueType);
            Assert.False(modelType.IsEnum);
            Assert.AreEqual(1, modelType.GetProperties().Length);
            TypeAsserts.HasProperty(modelType, "Value1", BindingFlags.Static | BindingFlags.Public);
        }
    }
}

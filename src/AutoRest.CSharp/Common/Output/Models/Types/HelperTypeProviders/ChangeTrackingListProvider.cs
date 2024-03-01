// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal class ChangeTrackingListProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<ChangeTrackingListProvider> _instance = new(() => new ChangeTrackingListProvider(Configuration.Namespace, null));
        private readonly MethodSignature _ensureListSignature = new MethodSignature("EnsureList", null, null, MethodSignatureModifiers.Public, typeof(IList<>), null, Array.Empty<Parameter>());
        private readonly MethodSignature _getEnumeratorSignature = new MethodSignature("GetEnumerator", null, null, MethodSignatureModifiers.Public, typeof(IEnumerator<>), null, Array.Empty<Parameter>());
        private readonly TypeProvider _t;
        private readonly FieldDeclaration _innerlListField;
        private readonly TypeProvider _tArray;
        private readonly Parameter _tParam;
        private readonly Parameter _indexParam = new Parameter("index", null, typeof(int), null, ValidationType.None, null);
        private VariableReference _innerList;

        public static ChangeTrackingListProvider Instance => _instance.Value;

        private ChangeTrackingListProvider(string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
            _innerlListField = new FieldDeclaration(FieldModifiers.Private, typeof(IList<>), "_innerList");
            _innerList = new VariableReference(new CSharpType(typeof(IList<>)), _innerlListField.Declaration);
            _t = new GenericParameterTypeProvider("T", DefaultNamespace, null);
            _tArray = new GenericParameterTypeProvider("T[]", DefaultNamespace, null);
            _tParam = new Parameter("item", null, _t.Type, null, ValidationType.None, null);
            DeclarationModifiers = ClassSignatureModifiers.Internal;
        }

        protected override string DefaultName => "ChangeTrackingList";

        protected override IEnumerable<Method> BuildConstructors()
        {
            yield return new Method(new ConstructorSignature(Type, null, null, MethodSignatureModifiers.Public, Array.Empty<Parameter>()), Snippets.EmptyStatement);
            var iListParam = new Parameter("innerList", null, typeof(IList<>), null, ValidationType.None, null);
            var iListSignature = new ConstructorSignature(Type, null, null, MethodSignatureModifiers.Public, new Parameter[] { iListParam });
            var iListVariable = new ParameterReference(iListParam);
            var iListbody = new MethodBodyStatement[]
            {
                new IfStatement(Snippets.NotEqual(iListVariable, Snippets.Null))
                {
                    new AssignValueStatement(_innerList, iListVariable)
                }
            };

            yield return new Method(iListSignature, iListbody);
            var iReadOnlyListParam = new Parameter("innerList", null, typeof(IReadOnlyList<>), null, ValidationType.None, null);
            var iReadOnlyListSignature = new ConstructorSignature(Type, null, null, MethodSignatureModifiers.Public, new Parameter[] { iReadOnlyListParam });
            var iReadOnlyListVariable = new ParameterReference(iReadOnlyListParam);
            var iReadOnlyListbody = new MethodBodyStatement[]
            {
                new IfStatement(Snippets.NotEqual(iReadOnlyListVariable, Snippets.Null))
                {
                    new AssignValueStatement(_innerList, Snippets.Linq.ToList(iReadOnlyListVariable))
                }
            };

            yield return new Method(iReadOnlyListSignature, iReadOnlyListbody);
        }

        protected override IEnumerable<CSharpType> BuildTypeArguments()
        {
            yield return _t.Type;
        }

        protected override IEnumerable<CSharpType> BuildImplements()
        {
            yield return new CSharpType(typeof(IList<>));
            yield return new CSharpType(typeof(IReadOnlyList<>));
        }

        protected override IEnumerable<FieldDeclaration> BuildFields()
        {
            yield return _innerlListField;
        }

        protected override IEnumerable<PropertyDeclaration> BuildProperties()
        {
            yield return new PropertyDeclaration(null, MethodSignatureModifiers.Public, typeof(bool), "IsUndefined", new ExpressionPropertyBody(Snippets.Equal(_innerList, Snippets.Null)));
            yield return BuildCount();
            yield return BuildIsReadOnly();
            yield return BuildIndexer();
        }

        private PropertyDeclaration BuildIsReadOnly()
        {
            return new PropertyDeclaration(null, MethodSignatureModifiers.Public, typeof(bool), "IsReadOnly",
                        new ExpressionPropertyBody(new TernaryConditionalOperator(
                            new MemberExpression(Snippets.This, "IsUndefined"),
                            Snippets.False,
                            new MemberExpression(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), "IsReadOnly"))));
        }

        private PropertyDeclaration BuildCount()
        {
            return new PropertyDeclaration(null, MethodSignatureModifiers.Public, typeof(int), "Count",
                new ExpressionPropertyBody(new TernaryConditionalOperator(
                    new MemberExpression(Snippets.This, "IsUndefined"),
                    Snippets.Literal(0),
                    new MemberExpression(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), "Count"))));
        }

        private PropertyDeclaration BuildIndexer()
        {
            return new PropertyDeclaration(null, MethodSignatureModifiers.Public, _t.Type, "this", new MethodPropertyBody(
                new MethodBodyStatement[]
                {
                    new IfStatement(new BoolExpression(new MemberExpression(Snippets.This, "IsUndefined")))
                    {
                        Snippets.Throw(Snippets.New.Instance(typeof(ArgumentOutOfRangeException), Snippets.Nameof(new ParameterReference(_indexParam))))
                    },
                    Snippets.Return(new ArrayElementExpression(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), new ParameterReference(_indexParam))),
                },
                new MethodBodyStatement[]
                {
                    new IfStatement(new BoolExpression(new MemberExpression(Snippets.This, "IsUndefined")))
                    {
                        Snippets.Throw(Snippets.New.Instance(typeof(ArgumentOutOfRangeException), Snippets.Nameof(new ParameterReference(_indexParam))))
                    },
                    new AssignValueStatement(
                            new ArrayElementExpression(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), new ParameterReference(_indexParam)),
                            new KeywordExpression("value", null))
                }));
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildReset();
            yield return BuildGetEnumeratorOfT();
            yield return BuildGetEnumerator();
            yield return BuildAdd();
            yield return BuildClear();
            yield return BuildContains();
            yield return BuildCopyTo();
            yield return BuildRemove();
            yield return BuildIndexOf();
            yield return BuildInsert();
            yield return BuildRemoveAt();
            yield return BuildEnsureList();
        }

        private Method BuildRemoveAt()
        {
            var indexVariable = new ParameterReference(_indexParam);
            return new Method(new MethodSignature("RemoveAt", null, null, MethodSignatureModifiers.Public, null, null, new Parameter[] { _indexParam }), new MethodBodyStatement[]
            {
                new IfStatement(new BoolExpression(new MemberExpression(Snippets.This, "IsUndefined")))
                {
                    Snippets.Throw(Snippets.New.Instance(typeof(ArgumentOutOfRangeException), Snippets.Nameof(indexVariable)))
                },
                new InvokeInstanceMethodStatement(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), "RemoveAt", new ValueExpression[] { indexVariable }, false)
            });
        }

        private Method BuildInsert()
        {
            return new Method(new MethodSignature("Insert", null, null, MethodSignatureModifiers.Public, null, null, new Parameter[] { _indexParam, _tParam }), new MethodBodyStatement[]
            {
                new InvokeInstanceMethodStatement(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), "Insert", new ValueExpression[] { new ParameterReference(_indexParam), new ParameterReference(_tParam) }, false)
            });
        }

        private Method BuildIndexOf()
        {
            return new Method(new MethodSignature("IndexOf", null, null, MethodSignatureModifiers.Public, typeof(int), null, new Parameter[] { _tParam }), new MethodBodyStatement[]
            {
                new IfStatement(new BoolExpression(new MemberExpression(Snippets.This, "IsUndefined")))
                {
                    Snippets.Return(Snippets.Literal(-1))
                },
                Snippets.Return(new InvokeInstanceMethodExpression(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), "IndexOf", new ValueExpression[] { new ParameterReference(_tParam) }, null, false))
            });
        }

        private Method BuildRemove()
        {
            return new Method(new MethodSignature("Remove", null, null, MethodSignatureModifiers.Public, typeof(bool), null, new Parameter[] { _tParam }), new MethodBodyStatement[]
            {
                new IfStatement(new BoolExpression(new MemberExpression(Snippets.This, "IsUndefined")))
                {
                    Snippets.Return(Snippets.False)
                },
                Snippets.Return(new InvokeInstanceMethodExpression(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), "Remove", new ValueExpression[] { new ParameterReference(_tParam) }, null, false))
            });
        }

        private Method BuildCopyTo()
        {
            var arrayParam = new Parameter("array", null, _tArray.Type, null, ValidationType.None, null);
            var arrayIndexParam = new Parameter("arrayIndex", null, typeof(int), null, ValidationType.None, null);
            return new Method(new MethodSignature("CopyTo", null, null, MethodSignatureModifiers.Public, null, null, new Parameter[] { arrayParam, arrayIndexParam }), new MethodBodyStatement[]
            {
                new IfStatement(new BoolExpression(new MemberExpression(Snippets.This, "IsUndefined")))
                {
                    Snippets.Return()
                },
                new InvokeInstanceMethodStatement(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), "CopyTo", new ValueExpression[] { new ParameterReference(arrayParam), new ParameterReference(arrayIndexParam) }, false)
            });
        }

        private Method BuildContains()
        {
            return new Method(new MethodSignature("Contains", null, null, MethodSignatureModifiers.Public, typeof(bool), null, new Parameter[] { _tParam }), new MethodBodyStatement[]
            {
                new IfStatement(new BoolExpression(new MemberExpression(Snippets.This, "IsUndefined")))
                {
                    Snippets.Return(Snippets.False)
                },
                Snippets.Return(new InvokeInstanceMethodExpression(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), "Contains", new ValueExpression[] { new ParameterReference(_tParam) }, null, false))
            });
        }

        private Method BuildClear()
        {
            return new Method(new MethodSignature("Clear", null, null, MethodSignatureModifiers.Public, null, null, Array.Empty<Parameter>()), new MethodBodyStatement[]
            {
                new InvokeInstanceMethodStatement(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), "Clear")
            });
        }

        private Method BuildAdd()
        {
            var genericParameter = new Parameter("item", null, _t.Type, null, ValidationType.None, null);
            return new Method(new MethodSignature("Add", null, null, MethodSignatureModifiers.Public, null, null, new Parameter[] { genericParameter }), new MethodBodyStatement[]
            {
                new InvokeInstanceMethodStatement(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), "Add", new ParameterReference(genericParameter))
            });
        }

        private Method BuildGetEnumerator()
        {
            return new Method(new MethodSignature("GetEnumerator", null, null, MethodSignatureModifiers.None, typeof(IEnumerator), null, Array.Empty<Parameter>(), ExplicitInterface: typeof(IEnumerable)), new MethodBodyStatement[]
            {
                Snippets.Return(new InvokeInstanceMethodExpression(Snippets.This, _getEnumeratorSignature))
            });
        }

        private Method BuildGetEnumeratorOfT()
        {
            return new Method(_getEnumeratorSignature, new MethodBodyStatement[]
            {
                new IfStatement(new BoolExpression(new MemberExpression(Snippets.This, "IsUndefined")))
                {
                    new DeclareLocalFunctionStatement(new CodeWriterDeclaration("enumerateEmpty"), Array.Empty<Parameter>(), typeof(IEnumerator<>), new KeywordStatement("yield", new KeywordExpression("break", null))),
                    Snippets.Return(new InvokeStaticMethodExpression(null, "enumerateEmpty", Array.Empty<ValueExpression>()))
                },
                Snippets.Return(new InvokeInstanceMethodExpression(new InvokeInstanceMethodExpression(Snippets.This, _ensureListSignature), nameof(IList<object>.GetEnumerator), Array.Empty<ValueExpression>(), null, false))
            });
        }

        private Method BuildReset()
        {
            return new Method(new MethodSignature("Reset", null, null, MethodSignatureModifiers.Public, null, null, Array.Empty<Parameter>()), new MethodBodyStatement[]
            {
                new AssignValueStatement(_innerList, Snippets.Null)
            });
        }

        private Method BuildEnsureList()
        {
            return new Method(_ensureListSignature, new MethodBodyStatement[]
            {
                Snippets.Return(new BinaryOperatorExpression("??=", _innerList, Snippets.New.Instance(typeof(List<>))))
            });
        }
    }
}

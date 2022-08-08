// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    internal abstract class MgmtTestWriterBase
    {
        protected CodeWriter _writer;
        protected MgmtTestWriterBase() : this(new CodeWriter())
        {
        }

        protected MgmtTestWriterBase(CodeWriter writer)
        {
            _writer = writer;
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}

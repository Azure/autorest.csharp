// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AutoRest.CSharp.Generation.Writers
{
    /// <summary>
    /// Writer to compose the content of .Net external XML doc which can be included
    /// throught "// &lt;include&gt;" tag.
    /// For details, see: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments#d36-include
    /// </summary>
    internal class XmlDocWriter : IFormatProvider, ICustomFormatter
    {
        private IList<string> Members = new List<string>();

        private StringBuilder? CurrentWriter;

        /// <summary>
        /// Write content of XML documentation.
        /// </summary>
        /// <param name="tag">Tag name</param>
        /// <param name="text">Text context inside the given tag.</param>
        /// <exception cref="InvalidOperationException">throws if this method is inovoked before <see cref="CreateMember(string)"/> is invoked.</exception>
        public void WriteXmlDocumentation(string tag, FormattableString? text)
        {
            if (CurrentWriter == null)
            {
                throw new InvalidOperationException("Invoke 'CreateMember' first.");
            }

            // skip empty content
            if (text == null || string.IsNullOrEmpty(text.ToString()))
            {
                return;
            }

            // we don't add the indentation of XML doucment contents, because that will be carried over to the final doc
            CurrentWriter.Append($"<{tag}>\n");
            CurrentWriter.Append(text.ToString(this));
            CurrentWriter.Append($"\n</{tag}>\n");
        }

        public void Write(FormattableString? text)
        {
            if (CurrentWriter == null)
            {
                throw new InvalidOperationException("Invoke 'CreateMember' first.");
            }

            if (text == null || string.IsNullOrEmpty(text.ToString()))
            {
                return;
            }

            CurrentWriter.Append(text.ToString(this));
        }


        public object? GetFormat(Type? formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null;
        }

        // a much simpler implementatoin of CodeWriter.Append(FormattableString)
        // we only translate the necessary arguments in the formattable string
        public string Format(string? format, object? arg, IFormatProvider? formatProvider)
        {
            switch (arg)
            {
                case FormattableString fs:
                    return fs.ToString(formatProvider);
                case IEnumerable<FormattableString> fss:
                    var builder = new StringBuilder();
                    foreach (var fs in fss)
                    {
                        builder.Append(fs.ToString(formatProvider));
                    }
                    return builder.ToString();
                default:
                    string? s = arg?.ToString();
                    if (s == null)
                    {
                        throw new ArgumentNullException(format);
                    }
                    return s;
            }
        }

        public override string ToString()
        {
            // generated XML document follows the "/doc/members/member[@name={method_signature}]" structure
            // here we add indentation of high level tags, just for readability
            var builder = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<doc>\n  <members>\n");

            foreach (var member in Members)
            {
                builder.Append(member);
            }

            builder.Append("  </members>\n</doc>");
            return builder.ToString();
        }

        internal IDisposable CreateMember(string name)
        {
            return new Member(name, this);
        }

        // A <member> element
        private class Member : IDisposable
        {
            private readonly XmlDocWriter writer;

            internal Member(string name, XmlDocWriter writer)
            {
                this.writer = writer;
                writer.CurrentWriter = new StringBuilder($"    <member name=\"{name}\">\n");
            }

            public void Dispose()
            {
                writer.CurrentWriter!.Append("    </member>\n");
                writer.Members.Add(writer.CurrentWriter!.ToString());
            }
        }
    }
}

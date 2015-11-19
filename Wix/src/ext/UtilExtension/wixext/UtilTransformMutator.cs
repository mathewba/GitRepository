﻿//-------------------------------------------------------------------------------------------------
// <copyright file="UtilTransformMutator.cs" company="Outercurve Foundation">
//   Copyright (c) 2004, Outercurve Foundation.
//   This software is released under Microsoft Reciprocal License (MS-RL).
//   The license and further copyright text can be found in the file
//   LICENSE.TXT at the root directory of the distribution.
// </copyright>
// 
// <summary>
// The XSL mutator for the Windows Installer XML Toolset Utility Extension.
// </summary>
//-------------------------------------------------------------------------------------------------

namespace Microsoft.Tools.WindowsInstallerXml.Extensions
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Xsl;

    public sealed class UtilTransformMutator : MutatorExtension
    {
        private string transform;
        private int transformSequence;

        /// <summary>
        /// Instantiate a new UtilTransformMutator.
        /// </summary>
        /// <param name="transform">Path to the XSL transform file.</param>
        /// <param name="transformSequence">Order in which the transform should be applied,
        /// relative to other transforms.</param>
        public UtilTransformMutator(string transform, int transformSequence)
        {
            this.transform = transform;
            this.transformSequence = transformSequence;
        }

        /// <summary>
        /// Gets the sequence of the extension.
        /// </summary>
        /// <value>The sequence of the extension.</value>
        public override int Sequence
        {
            get { return 3000 + this.transformSequence; }
        }

        /// <summary>
        /// Mutate a WiX document as a string.
        /// </summary>
        /// <param name="wix">The Wix document element as a string.</param>
        /// <returns>The mutated Wix document as a string.</returns>
        public override string Mutate(string wixString)
        {
            try
            {
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(this.transform, XsltSettings.TrustedXslt, new XmlUrlResolver());

                using (XmlTextReader xmlReader = new XmlTextReader(new StringReader(wixString)))
                {
                    using (StringWriter stringWriter = new StringWriter())
                    {
                        XmlWriterSettings xmlSettings = new XmlWriterSettings();
                        xmlSettings.Indent = true;
                        xmlSettings.IndentChars = "    ";
                        xmlSettings.OmitXmlDeclaration = true;

                        using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlSettings))
                        {
                            xslt.Transform(xmlReader, xmlWriter);
                        }

                        wixString = stringWriter.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Core.OnMessage(UtilErrors.ErrorTransformingHarvestedWiX(this.transform, ex.Message));
                return null;
            }

            return wixString;
        }
    }
}

using System.Collections.Generic;
using System;
using MtconnectTranspiler.Xmi.UML;
using MtconnectTranspiler.Contracts;

namespace MtconnectTranspiler.Sinks.CPlusPlus.Models
{
    /// <summary>
    /// Helper methods to process content for scriban templates
    /// </summary>
    public class CppHelperMethods : ScribanTemplates.ScribanHelperMethods
    {
        private static Dictionary<string, Type> umlDataTypeToCSharp = new Dictionary<string, Type>()
        {
            { "boolean", typeof(bool) },
            { "ID", typeof(string) },
            { "string", typeof(string) },
            { "float", typeof(float) },
            { "datetime", typeof(DateTime) },
            { "integer", typeof(int) },
            { "xlinktype", typeof(string) },
            { "xslang", typeof(string) },
            { "SECOND", typeof(float) },
            { "IDREF", typeof(string) },
            { "xlinkhref", typeof(string) },
            { "MILLIMETER", typeof(float) },
            { "DEGREE", typeof(float) },
            { "x509", typeof(string) },
            { "CUBIC_MILLIMETER", typeof(float) },
            { "int32", typeof(int) },
            { "int64", typeof(long) },
            { "version", typeof(string) },
            { "uint32", typeof(uint) },
            { "uint64", typeof(ulong) },
            { "double", typeof(double) },

        };
        /// <summary>
        /// Gets the C# equivalant of the <see cref="UmlDataType"/>.
        /// </summary>
        /// <param name="source">Reference to the packaged UML DataType</param>
        /// <returns>Primitive type. Returns null if unrecognizes or unhandled DataType</returns>
        public static Type ToPrimitiveType(UmlDataType source)
        {
            if (umlDataTypeToCSharp.TryGetValue(source.Name, out Type type))
                return type;
            return null;
        }
        /// <summary>
        /// Gets the C# equivalant of the <see cref="UmlProperty"/>.
        /// </summary>
        /// <param name="model">Reference to the source XMI document</param>
        /// <param name="source">Reference to the packaged UML Property</param>
        /// <returns>Primitive type. Returns null if unrecognizes or unhandled Property</returns>
        public static Type ToPrimitiveType(Xmi.XmiDocument model, UmlProperty source)
        {
            var umlDataType = model.LookupDataType(source.PropertyType);
            if (umlDataType == null)
                return null;
            return ToPrimitiveType(umlDataType);
        }
    }
}

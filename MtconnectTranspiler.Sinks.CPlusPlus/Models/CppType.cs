using MtconnectTranspiler.Xmi;

namespace MtconnectTranspiler.Sinks.CPlusPlus.Models
{
    /// <summary>
    /// Represents properties required to define a C++ type.
    /// </summary>
    public class CppType : MtconnectVersionedObject
    {
        /// <summary>
        /// The intended namespace for the C++ type.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// The intended name for the C++ type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The accessibility of the C++ type.
        /// <list type="bullet">
        /// <item>public</item>
        /// <item>private</item>
        /// <item>protected</item>
        /// <item>internal</item>
        /// <item>protected internal</item>
        /// <item>private protected</item>
        /// </list>
        /// </summary>
        public string AccessModifier { get; set; } = "public";

        /// <summary>
        /// A modifier for the C++ type.
        /// <list type="bullet">
        /// <item>abstract</item>
        /// <item>static</item>
        /// <item>const</item>
        /// <item>volatile</item>
        /// <item>extern</item>
        /// </list>
        /// </summary>
        public string Modifier { get; set; }

        public CppType(XmiDocument model, XmiElement source) : base(model, source) { }
    }

}

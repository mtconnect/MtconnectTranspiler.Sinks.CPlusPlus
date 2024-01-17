using MtconnectTranspiler.Sinks.ScribanTemplates;
using MtconnectTranspiler.Xmi.UML;
using MtconnectTranspiler.Xmi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtconnectTranspiler.Sinks.CPlusPlus.Example.Models
{
    [ScribanTemplate("Enum.scriban")]
    public class ObservationEnum : CPlusPlus.Models.Enum
    {
        // NOTE: Only used for CATEGORY types that have subTypes.
        public Dictionary<string, string> SubTypes { get; set; } = new Dictionary<string, string>();

        // NOTE: Only used for CATEGORY types that have value enums.
        public Dictionary<string, string> ValueTypes { get; set; } = new Dictionary<string, string>();

        public ObservationEnum(XmiDocument model, XmiElement source, string name) : base(model, source, name) { }

        public ObservationEnum(XmiDocument model, UmlEnumeration source) : base(model, source) { }

        public ObservationEnum(XmiDocument model, UmlPackage source) : base(model, source) { }
    }
}
